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
    public partial class Cells : Page
    {
        private CellsTableAdapter _cellsTableAdapter = new CellsTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я-0-9]+$");
        public Cells()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _cellsTableAdapter.GetData();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CellNum.Text) && !string.IsNullOrWhiteSpace(Capacity.Text))
            {
                if (!latinAndRussianRegex.IsMatch(CellNum.Text))
                {
                    MessageBox.Show("Поле 'Номер камеры' должен состоять из букв, цифр и дефиса");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    string cellNum = CellNum.Text;
                    int capacity = Convert.ToInt32(Capacity.Text);
                    _cellsTableAdapter.UpdateQuery(cellNum, capacity, id);
                    DataGrid.ItemsSource = _cellsTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CellNum.Text) && !string.IsNullOrWhiteSpace(Capacity.Text))
            {
                if (!latinAndRussianRegex.IsMatch(CellNum.Text))
                {
                    MessageBox.Show("Поле 'Номер камеры' должен состоять из букв, цифр и дефиса");
                }
                else
                {
                    string cellNum = CellNum.Text;
                    int capacity = Convert.ToInt32(Capacity.Text);

                    _cellsTableAdapter.InsertQuery(cellNum, capacity);
                    DataGrid.ItemsSource = _cellsTableAdapter.GetData();
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
                CellNum.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[1]);
                Capacity.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
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
        
        private void Capacity_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(isNum);
        }
    }
}