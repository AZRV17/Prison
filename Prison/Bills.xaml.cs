using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Bills : Page
    {
        private BillTableAdapter _billTableAdapter = new BillTableAdapter();
        private UsersTableAdapter _usersTableAdapter = new UsersTableAdapter();
        public Bills()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _billTableAdapter.GetData();
            UserComboBox.ItemsSource = _usersTableAdapter.GetData();
            UserComboBox.DisplayMemberPath = "Loign";
        }
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateOfBill = Convert.ToDateTime(DateOfBill.SelectedDate);
                int user_id = Convert.ToInt32((UserComboBox.SelectedItem as DataRowView).Row[0]);
                // _billTableAdapter.InsertQuery(dateOfBill.ToString(), user_id);
                DataGrid.ItemsSource = _billTableAdapter.GetData();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                DateTime dateOfBill = Convert.ToDateTime(DateOfBill.SelectedDate);
                int user_id = Convert.ToInt32((UserComboBox.SelectedItem as DataRowView).Row[0]);
                _billTableAdapter.UpdateQuery(dateOfBill.ToString(), user_id, id);
                DataGrid.ItemsSource = _billTableAdapter.GetData();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void DataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                DateOfBill.SelectedDate = Convert.ToDateTime((DataGrid.SelectedItem as DataRowView)[1]);
                UserComboBox.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
            }
        }
    }
}