using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Employees : Page
    {
        private EmployeesTableAdapter _employeesTableAdapter = new EmployeesTableAdapter();
        private PrisonersTableAdapter _prisonersTableAdapte = new PrisonersTableAdapter();
        private CellsTableAdapter _cellsTableAdapter = new CellsTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Employees()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _employeesTableAdapter.GetData();
            CellComboBox.ItemsSource = _cellsTableAdapter.GetData();
            CellComboBox.DisplayMemberPath = "CellNumber";
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && !string.IsNullOrWhiteSpace(Position.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(LastName.Text) ||
                    !latinAndRussianRegex.IsMatch(Position.Text))
                {
                    MessageBox.Show("Поля 'Имя', 'Фамилия' и 'Адрес' должны быть заполнены буквами");
                }
                else
                {
                    string name = Name.Text;
                    string lastName = LastName.Text;
                    string position = Position.Text;
                    int cell_id = (int)(CellComboBox.SelectedItem as DataRowView)[0];
                    _employeesTableAdapter.InsertQuery(name, lastName, position, cell_id);
                    DataGrid.ItemsSource = _employeesTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && !string.IsNullOrWhiteSpace(Position.Text))
            {
                try
                {
                    if (!latinAndRussianRegex.IsMatch(Name.Text) && !latinAndRussianRegex.IsMatch(LastName.Text) &&
                        !latinAndRussianRegex.IsMatch(Position.Text))
                    {
                        MessageBox.Show("Поля 'Имя', 'Фамилия' и 'Адрес' должны быть заполнены буквами");
                    }
                    else
                    {
                        int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                        string name = Name.Text;
                        string lastName = LastName.Text;
                        string position = Position.Text;
                        int cell_id = (int)(CellComboBox.SelectedItem as DataRowView)[0];
                        _employeesTableAdapter.UpdateQuery(name, lastName, position, cell_id, id);
                        DataGrid.ItemsSource = _employeesTableAdapter.GetData();
                    }
                }
                catch 
                {
                    MessageBox.Show("Ощибка");
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
                Position.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[3]);
            }
        }
    }
}