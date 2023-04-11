using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class ShopPage : Page
    {
        private GoodsTableAdapter _goodsTableAdapter = new GoodsTableAdapter();
        private BillTableAdapter _billTableAdapter = new BillTableAdapter();
        private Bill_itemsTableAdapter _billItemsTableAdapter = new Bill_itemsTableAdapter();
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        List<Order> orders = new List<Order>();

        public ShopPage()
        {
            InitializeComponent();
            GoodsDataGrid.ItemsSource = _goodsTableAdapter.GetData();
            PrisonerSelect.ItemsSource = _prisonersTableAdapter.GetData();
            PrisonerSelect.DisplayMemberPath = "LastName";
        }

        private void ToBill_OnClick(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedItem != null)
            {
                int id = Convert.ToInt32((GoodsDataGrid.SelectedItem as DataRowView)[0]);
                string name = Convert.ToString((GoodsDataGrid.SelectedItem as DataRowView)[1]);
                int amount = Convert.ToInt32((GoodsDataGrid.SelectedItem as DataRowView)[2]);
                decimal price = Convert.ToDecimal((GoodsDataGrid.SelectedItem as DataRowView)[3]);
                int total_price = Convert.ToInt32(TotalSum.Text);
                total_price += Convert.ToInt32(price);
                TotalSum.Text = total_price.ToString();
                Order order = new Order(id, name, amount, price);
                orders.Add(order);
                BillDataGrid.ItemsSource = orders;
                BillDataGrid.Items.Refresh();
            }
        }

        private void FromBill_OnClick(object sender, RoutedEventArgs e)
        {
            if (BillDataGrid.SelectedItem != null)
            {
                Order selected = BillDataGrid.SelectedItem as Order;
                int total_price = Convert.ToInt32(TotalSum.Text);
                total_price -= Convert.ToInt32(selected.Price);
                TotalSum.Text = total_price.ToString();
                orders.Remove(selected);
                BillDataGrid.ItemsSource = orders;
                BillDataGrid.Items.Refresh();
            }
        }

        private void SaveBill_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(MoneyTextBox.Text) > 0 && orders.Count > 0)
                {
                    decimal Money = Convert.ToDecimal(MoneyTextBox.Text);
                    decimal Total = Convert.ToDecimal(TotalSum.Text);
                    decimal Surrender = Convert.ToDecimal(Money - Total);
                    int prisoner_id = (int)(PrisonerSelect.SelectedItem as DataRowView)[0];
                    string prisonerName = Convert.ToString((PrisonerSelect.SelectedItem as DataRowView)[2]);
                    _billTableAdapter.InsertQuery(DateTime.Now.ToString(), ((App)Application.Current).ID, Money, Surrender, Total, prisoner_id);

                    Bills_items billsItems = new Bills_items();
                    int bill_id = Convert.ToInt32(_billTableAdapter.GetData().Last()[0]);
                    foreach (Order order in orders)
                    {
                        _billItemsTableAdapter.InsertQuery(bill_id, order.Id, order.Amount);
                    }

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                  $"\\Bill_{bill_id}.txt";

                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("\t\t\tPrison");
                        sw.WriteLine("\t\t\tЧек №" + bill_id);
                        int i = 1;
                        foreach (Order order in orders)
                        {
                            sw.WriteLine($"\t\t{i}. {order.Name} - {order.Price}р");
                            i++;
                        }

                        sw.WriteLine($"\t\tСумма: {Total}р");
                        sw.WriteLine($"\t\tЗаключенный: {prisonerName}");
                        sw.WriteLine($"\t\tВнесено: {Money}р");
                        sw.WriteLine($"\t\tСдача: {Surrender}р");
                    }

                    billsItems.BillsComboBox.ItemsSource = _billTableAdapter.GetData();
                    billsItems.BillsComboBox.DisplayMemberPath = "Date";
                    billsItems.BillsComboBox.Items.Refresh();
                    MessageBox.Show("Заказ оформлен");
                }
                else
                {
                    MessageBox.Show("Внесенная сумма должна быть больше 0 и должен быть выбран хотя бы 1 товар, также должен быть выбран заключенный");
                }
            }
            catch
            {
                MessageBox.Show("В поле 'Внесено' должны быть только цифры");
            }
        }
    }


    internal class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public Order(int id, string name, int amount, decimal price)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Price = price;
        }
    }
}