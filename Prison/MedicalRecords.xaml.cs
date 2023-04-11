using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class MedicalRecords : Page
    {
        private MedicalRecordsTableAdapter _medicalRecordsTableAdapter = new MedicalRecordsTableAdapter();
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public MedicalRecords()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _medicalRecordsTableAdapter.GetData();
            PrisonerComboBox.ItemsSource = _prisonersTableAdapter.GetData();
            PrisonerComboBox.DisplayMemberPath = "LastName";
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (FromDate.SelectedDate != null && ToDate.SelectedDate != null && !string.IsNullOrWhiteSpace(Diagnose.Text) && PrisonerComboBox.SelectedItem != null)
            {
                if (!latinAndRussianRegex.IsMatch(Diagnose.Text))
                {
                    MessageBox.Show("Поле 'Диагноз' должно быть заполнено буквами");
                }
                else if (FromDate.SelectedDate.Value > ToDate.SelectedDate.Value)
                {
                    MessageBox.Show("Неверно указана дата");
                }
                else
                {
                    DateTime from = Convert.ToDateTime(FromDate.SelectedDate);
                    DateTime to = Convert.ToDateTime(ToDate.SelectedDate);
                    string diagnose = Diagnose.Text;
                    int prisoner_id = Convert.ToInt32((PrisonerComboBox.SelectedItem as DataRowView).Row[0]);

                    _medicalRecordsTableAdapter.InsertQuery(from, to, diagnose, prisoner_id);
                    DataGrid.ItemsSource = _medicalRecordsTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (FromDate.SelectedDate != null && ToDate.SelectedDate != null && !string.IsNullOrWhiteSpace(Diagnose.Text) && PrisonerComboBox.SelectedItem != null)
            {
                if (!latinAndRussianRegex.IsMatch(Diagnose.Text))
                {
                    MessageBox.Show("Поле 'Диагноз' должно быть заполнено буквами");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    DateTime from = Convert.ToDateTime(FromDate.SelectedDate);
                    DateTime to = Convert.ToDateTime(ToDate.SelectedDate);
                    string diagnose = Diagnose.Text;
                    int prisoner_id = Convert.ToInt32((PrisonerComboBox.SelectedItem as DataRowView).Row[0]);
                    _medicalRecordsTableAdapter.UpdateQuery(from, to, diagnose, prisoner_id, id);
                    DataGrid.ItemsSource = _medicalRecordsTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem as DataRowView != null)
            {
                FromDate.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[1]);
                ToDate.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[2]);
                Diagnose.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[3]);
                PrisonerComboBox.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[4]);
            }
        }
    }
}