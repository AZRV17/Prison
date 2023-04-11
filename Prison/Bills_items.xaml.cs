using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Bills_items : Page
    {
        private int _billID = 0;
        private Bill_itemsTableAdapter _billItemsTableAdapter = new Bill_itemsTableAdapter();
        private GoodsTableAdapter _goodsTableAdapter = new GoodsTableAdapter();
        private BillTableAdapter _billTableAdapter = new BillTableAdapter();
        private UsersTableAdapter _usersTableAdapter = new UsersTableAdapter();
        
        List<Order> orders = new List<Order>();
        public Bills_items()
        {
            InitializeComponent();
            BillsComboBox.ItemsSource = _billTableAdapter.GetData();
            BillsComboBox.DisplayMemberPath = "Date";
        }

        private void BillsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orders.Clear();
            int bill_id_selected = Convert.ToInt32((BillsComboBox.SelectedItem as DataRowView)[0]); 
            DataTable data = _billItemsTableAdapter.GetData();
            decimal sum = 0;            
            decimal moneyInput = 0;            
            decimal surrender = 0;            
            
            foreach (var i in data.Rows)
            {
                int good_id = (int)(i as DataRow)[2];
                int bill_id = (int)(i as DataRow)[1];
                foreach (var n in _goodsTableAdapter.GetData().Rows)
                {
                    int id2 = (int)(n as DataRow)[0];
                    if (good_id == id2 && bill_id == bill_id_selected)
                    {
                        decimal price = (decimal)(n as DataRow)[3];
                        Order order = new Order(good_id, (string)(n as DataRow)[1], (int)(i as DataRow)[2], price);
                        orders.Add(order);
                        foreach (var bill in _billTableAdapter.GetData().Rows)
                        {
                            if (bill_id == (int)(bill as DataRow)[0])
                            {
                                _billID = bill_id_selected;
                                DateTextBlock.Text = (bill as DataRow)[1].ToString();
                                sum = (decimal)(bill as DataRow)[4];
                                moneyInput = (decimal)(bill as DataRow)[3];
                                surrender = (decimal)(bill as DataRow)[5];
                                foreach (var employee in _usersTableAdapter.GetData().Rows)
                                {
                                    if ((int)(bill as DataRow)[2] == (int)(employee as DataRow)[0])
                                    {
                                        EmployeeTextBlock.Text = (employee as DataRow)[1].ToString();
                                    }
                                }
                            }
                        }
                        SumTextBlock.Text = sum.ToString();
                        SurrenderTextBlock.Text = surrender.ToString();
                        InputTextBlock.Text = moneyInput.ToString();
                    } 
                }
            }
            
            Bills_ItemsDataGrid.ItemsSource = orders;
            Bills_ItemsDataGrid.Items.Refresh();
        }

        private void SaveBillButton_OnClick(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Bill_{_billID}.txt";
            
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine("Prison");
                sw.WriteLine("Чек №" + _billID);
                int i = 1;
                foreach (Order order in orders)
                {
                    sw.WriteLine($"{i}. {order.Name} {order.Price}р");
                    i++;
                }
                sw.WriteLine($"Сумма: {SumTextBlock.Text}р");
                sw.WriteLine($"Внесено: {InputTextBlock.Text}р");
                sw.WriteLine($"Сдача: {SurrenderTextBlock.Text}р");
            }

            MessageBox.Show("Чек сохранен");
        }
    }
}