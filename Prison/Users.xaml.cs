using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Newtonsoft.Json;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Users : Page
    {
        private UsersTableAdapter _usersTableAdapter = new UsersTableAdapter();
        private RolesTableAdapter _rolesTableAdapter = new RolesTableAdapter();

        public Users()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _usersTableAdapter.GetData();
            RoleComboBox.ItemsSource = _rolesTableAdapter.GetData();
            RoleComboBox.DisplayMemberPath = "RoleName";
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginText.Text) && !string.IsNullOrWhiteSpace(PasswordText.Text) && RoleComboBox.SelectedItem != null)
            {
                int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                string login = LoginText.Text;
                string password = PasswordText.Text;
                int role_id = Convert.ToInt32((RoleComboBox.SelectedItem as DataRowView)[0]);

                _usersTableAdapter.UpdateQuery(login, password, role_id, id);
                DataGrid.ItemsSource = _usersTableAdapter.GetData();
            }
            else
            {
                MessageBox.Show("Input data in all field");
            }
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginText.Text) && !string.IsNullOrWhiteSpace(PasswordText.Text) && RoleComboBox.SelectedItem != null)
            {
                string login = LoginText.Text;
                string password = PasswordText.Text;
                int role_id = Convert.ToInt32((RoleComboBox.SelectedItem as DataRowView)[0]);

                _usersTableAdapter.InsertQuery(login, password, role_id);
                DataGrid.ItemsSource = _usersTableAdapter.GetData();
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
                LoginText.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[1]);
                PasswordText.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
                RoleComboBox.SelectedItem = Convert.ToString((DataGrid.SelectedItem as DataRowView)[3]);
            }
        }

        private void ImportButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    Deserialize<UsersClass>(openFileDialog.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Чет не так");
            }
            
        }
        
        private void Deserialize<T>(string path)
        {
            List<T> users = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            foreach (var user in users)
            {
                UsersClass usersClass = user as UsersClass;
                _usersTableAdapter.InsertQuery(usersClass.Login, usersClass.Password, usersClass.RoleID);
                DataGrid.ItemsSource = _usersTableAdapter.GetData();
            }
        }
        
        internal class UsersClass
        {
            // напиши класс товаров, который будет принимать название, количество и цену
            public string Login { get; set; }
            public string Password { get; set; }
            public int RoleID { get; set; }
            
            public UsersClass(string login, string password, int role_id)
            {
                Login = login;
                Password = password;
                RoleID = role_id;
            }
        }
    }
}