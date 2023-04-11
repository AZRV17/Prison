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
    public partial class Fines : Page
    {
        private FinesTableAdapter _finesTableAdapter = new FinesTableAdapter();
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        public Fines()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _finesTableAdapter.GetData();
            PrisonerComboBox.ItemsSource = _prisonersTableAdapter.GetData();
            PrisonerComboBox.DisplayMemberPath = "LastName";
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Amount.Text) && DateOfFine.SelectedDate != null && PrisonerComboBox.SelectedItem != null)
            {
                decimal amount = Convert.ToDecimal(Amount.Text);
                DateTime dateOfFine = Convert.ToDateTime(DateOfFine.SelectedDate);
                int prisoner_id = Convert.ToInt32((PrisonerComboBox.SelectedItem as DataRowView).Row[0]);
                _finesTableAdapter.InsertQuery(amount, dateOfFine, prisoner_id);
                DataGrid.ItemsSource = _finesTableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Amount.Text) && DateOfFine.SelectedDate != null && PrisonerComboBox.SelectedItem != null)
            {
                int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                decimal amount = Convert.ToDecimal(Amount.Text);
                DateTime dateOfFine = Convert.ToDateTime(DateOfFine.SelectedDate);
                int prisoner_id = Convert.ToInt32((PrisonerComboBox.SelectedItem as DataRowView).Row[0]);
                _finesTableAdapter.UpdateQuery(amount, dateOfFine, prisoner_id, id);
                DataGrid.ItemsSource = _finesTableAdapter.GetData();
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
                Amount.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[1]);
                DateOfFine.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[2]);
                PrisonerComboBox.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[3]);
            }
        }

        private bool isNum(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }

            if (c == ',')
            {
                return true;
            }

            return false;
        }
        
        private void Amount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(isNum);
        }
    }
}