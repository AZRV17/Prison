using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Courts : Page
    {
        private CourtsTableAdapter _courtsTableAdapter = new CourtsTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Courts()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _courtsTableAdapter.GetData();
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text)  && !string.IsNullOrWhiteSpace(Address.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(Address.Text))
                {
                    MessageBox.Show("Поля 'Имя' и 'Адрес' должны быть заполнены буквами");
                }
                else
                {
                    string name = Name.Text;
                    string address = Address.Text;
                    _courtsTableAdapter.InsertQuery(name, address);
                    DataGrid.ItemsSource = _courtsTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text)  && !string.IsNullOrWhiteSpace(Address.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(Address.Text))
                {
                    MessageBox.Show("Поля 'Имя' или 'Адрес' должны быть заполнены буквами");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    string name = Name.Text;
                    string address = Address.Text;
                    _courtsTableAdapter.UpdateQuery(name, address, id);
                    DataGrid.ItemsSource = _courtsTableAdapter.GetData();
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
                Address.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
            }
        }
    }
}