using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Visitors : Page
    {
        private VisitorsTableAdapter _visitorsTableAdapter = new VisitorsTableAdapter();
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Visitors()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _visitorsTableAdapter.GetData();
            PrisonerText.ItemsSource = _visitorsTableAdapter.GetData();
            PrisonerText.DisplayMemberPath = "LastName";
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PrisonerText.SelectedItem != null && !string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && VisitDate.SelectedDate != null)
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(LastName.Text))
                {
                    MessageBox.Show("Поля 'Имя', 'Фамилия' и 'Адрес' должны быть заполнены буквами");
                }
                else
                {
                    string name = Name.Text;
                    string lastName = LastName.Text;
                    DateTime visit = Convert.ToDateTime(VisitDate.SelectedDate);
                    int prisoner_id = Convert.ToInt32((PrisonerText.SelectedItem as DataRowView).Row[0]);

                    _visitorsTableAdapter.InsertQuery(name, lastName, visit, prisoner_id);
                    DataGrid.ItemsSource = _visitorsTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (PrisonerText.SelectedItem != null && !string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && VisitDate.SelectedDate != null)
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(LastName.Text))
                {
                    MessageBox.Show("Поля 'Имя', 'Фамилия' и 'Адрес' должны быть заполнены буквами");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    string name = Name.Text;
                    string lastName = LastName.Text;
                    DateTime visit = Convert.ToDateTime(VisitDate.SelectedDate);
                    int prisoner_id = Convert.ToInt32((PrisonerText.SelectedItem as DataRowView).Row[0]);
                    _visitorsTableAdapter.UpdateQuery(name, lastName, visit, prisoner_id, id);
                    DataGrid.ItemsSource = _visitorsTableAdapter.GetData();
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
                VisitDate.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[3]);
                PrisonerText.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[4]);
            }
        }
    }
}