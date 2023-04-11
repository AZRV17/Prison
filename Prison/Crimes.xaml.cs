using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Crimes : Page
    {
        private CrimesTableAdapter _crimesTableAdapter = new CrimesTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Crimes()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _crimesTableAdapter.GetData();
        }
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Name.Text) && !string.IsNullOrWhiteSpace(Desc.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(Desc.Text))
                {
                    MessageBox.Show("Поля 'Имя' или 'Описание' должны быть заполнены буквами");
                }
                else
                {
                    string name = Name.Text;
                    string desc = Desc.Text;

                    _crimesTableAdapter.InsertQuery(name, desc);
                    DataGrid.ItemsSource = _crimesTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) && string.IsNullOrWhiteSpace(Desc.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text) || !latinAndRussianRegex.IsMatch(Desc.Text))
                {
                    MessageBox.Show("Поля 'Имя' или 'Описание' должны быть заполнены буквами");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    string name = Name.Text;
                    string desc = Desc.Text;
                    _crimesTableAdapter.UpdateQuery(name, desc, id);
                    DataGrid.ItemsSource = _crimesTableAdapter.GetData();
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
                Desc.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
            }
        }
    }
}