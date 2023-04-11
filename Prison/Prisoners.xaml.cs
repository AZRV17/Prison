using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Prisoners : Page
    {
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        private CellsTableAdapter _cellsTableAdapter = new CellsTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Prisoners()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _prisonersTableAdapter.GetData();
            Cell.ItemsSource = _cellsTableAdapter.GetData();
            Cell.DisplayMemberPath = "CellNumber";
        }


        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && Birth.SelectedDate != null && Admission.SelectedDate != null && Release.SelectedDate != null && Cell.SelectedItem != null)
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(LastName.Text))
                {
                    MessageBox.Show("Поля 'Имя' и 'Фамилия' должны быть заполнены буквами");
                }
                else if (Admission.SelectedDate.Value > Release.SelectedDate.Value || Birth.SelectedDate.Value > Release.SelectedDate.Value)
                {
                    MessageBox.Show("Неверно указана дата");
                }
                else
                {
                    string name = Name.Text;
                    string lastName = LastName.Text;
                    DateTime birth = Convert.ToDateTime(Birth.SelectedDate);
                    DateTime admission = Convert.ToDateTime(Admission.SelectedDate);
                    DateTime release = Convert.ToDateTime(Release.SelectedDate);
                    int cell_id = Convert.ToInt32((Cell.SelectedItem as DataRowView).Row[0]);

                    _prisonersTableAdapter.InsertQuery(name, lastName, birth.ToString(), admission.ToString(), release.ToString(), cell_id);
                    DataGrid.ItemsSource = _prisonersTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && Birth.SelectedDate != null && Admission.SelectedDate != null && Release.SelectedDate != null && Cell.SelectedItem != null)
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(LastName.Text))
                {
                    MessageBox.Show("Поля 'Имя' и 'Фамилия' должны быть заполнены буквами");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    string name = Name.Text;
                    string lastName = LastName.Text;
                    DateTime birth = Convert.ToDateTime(Birth.SelectedDate);
                    DateTime admission = Convert.ToDateTime(Admission.SelectedDate);
                    DateTime release = Convert.ToDateTime(Release.SelectedDate);
                    int cell_id = Convert.ToInt32((Cell.SelectedItem as DataRowView).Row[0]);
                    _prisonersTableAdapter.UpdateQuery(name, lastName, birth.ToString(), admission.ToString(),
                        release.ToString(), cell_id, id);
                    DataGrid.ItemsSource = _prisonersTableAdapter.GetData();
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
                Name.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[1]);
                LastName.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
                Birth.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[3]);
                Admission.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[4]);
                Release.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[5]);
                Cell.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[6]);
            }
        }
    }
}