using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Convictions : Page
    {
        private ConvictionsTableAdapter _convictionsTableAdapter = new ConvictionsTableAdapter();
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        private CourtsTableAdapter _courtsTableAdapter = new CourtsTableAdapter();
        private CrimesTableAdapter _crimesTableAdapter = new CrimesTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Convictions()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _convictionsTableAdapter.GetData();
            PrisonerComboBox.ItemsSource = _prisonersTableAdapter.GetData();
            CourtComboBox.ItemsSource = _courtsTableAdapter.GetData();
            CrimeComboBox.ItemsSource = _crimesTableAdapter.GetData();

            PrisonerComboBox.DisplayMemberPath = "LastName";
            CourtComboBox.DisplayMemberPath = "Name";
            CrimeComboBox.DisplayMemberPath = "Name";
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DateOfConv.SelectedDate != null && !string.IsNullOrWhiteSpace(PrisonTermTextBox.Text) && PrisonerComboBox.SelectedItem != null && CourtComboBox.SelectedItem != null && CrimeComboBox.SelectedItem != null)
            {
                DateTime dateOfConv = Convert.ToDateTime(DateOfConv.SelectedDate);
                int prisonTerm = Convert.ToInt32(PrisonTermTextBox.Text);
                int prisoner_id = Convert.ToInt32((PrisonerComboBox.SelectedItem as DataRowView).Row[0]);
                int court_id = Convert.ToInt32((CourtComboBox.SelectedItem as DataRowView).Row[0]);
                int crime_id = Convert.ToInt32((CrimeComboBox.SelectedItem as DataRowView).Row[0]);
                _convictionsTableAdapter.InsertQuery(dateOfConv, prisonTerm, prisoner_id, court_id, crime_id);
                DataGrid.ItemsSource = _convictionsTableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DateOfConv.SelectedDate != null && PrisonTermTextBox.Text != "" && PrisonerComboBox.SelectedItem != null && CourtComboBox.SelectedItem != null && CrimeComboBox.SelectedItem != null)
            {
                int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                DateTime dateOfConv = Convert.ToDateTime(DateOfConv.SelectedDate);
                int prisonTerm = Convert.ToInt32(PrisonTermTextBox.Text);
                int prisoner_id = Convert.ToInt32((PrisonerComboBox.SelectedItem as DataRowView).Row[0]);
                int court_id = Convert.ToInt32((CourtComboBox.SelectedItem as DataRowView).Row[0]);
                int crime_id = Convert.ToInt32((CrimeComboBox.SelectedItem as DataRowView).Row[0]);
                _convictionsTableAdapter.UpdateQuery(dateOfConv, prisonTerm, prisoner_id, court_id, crime_id, id);
                DataGrid.ItemsSource = _convictionsTableAdapter.GetData();
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
                DateOfConv.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[1]);
                PrisonTermTextBox.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
                PrisonerComboBox.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[3]);
                CourtComboBox.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[4]);
                CrimeComboBox.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[5]);
            }
        }

        private bool isNum(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }

            return false;
        }
        
        private void PrisonTermTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(isNum);
        }
    }
}