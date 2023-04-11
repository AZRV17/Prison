using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Goods : Page
    {
        private GoodsTableAdapter _goodsTableAdapter = new GoodsTableAdapter();
        private Regex latinAndRussianRegex = new Regex("^[a-zA-Zа-яА-Я]+$");
        public Goods()
        {
            InitializeComponent();
            DataGrid.ItemsSource = _goodsTableAdapter.GetData();
        }

        private void EditButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Name.Text) && string.IsNullOrWhiteSpace(Amount.Text) && string.IsNullOrWhiteSpace(Price.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text))
                {
                    MessageBox.Show("Поле 'Имя' должно быть заполнено буквами");
                }
                else
                {
                    int id = Convert.ToInt32((DataGrid.SelectedItem as DataRowView)[0]);
                    string name = Name.Text;
                    int amount = Convert.ToInt32(Amount.Text);
                    decimal price = Convert.ToInt32(Price.Text);

                    _goodsTableAdapter.UpdateQuery(name, amount, price, id);
                    DataGrid.ItemsSource = _goodsTableAdapter.GetData();
                }
            }
            else
            {
                MessageBox.Show("Input data in all field");
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
        
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(Name.Text) && string.IsNullOrWhiteSpace(Amount.Text) && string.IsNullOrWhiteSpace(Price.Text))
            {
                if (!latinAndRussianRegex.IsMatch(Name.Text))
                {
                    MessageBox.Show("Поле 'Имя' должно быть заполнено буквами");
                }
                else
                {
                    string name = Name.Text;
                    int amount = Convert.ToInt32(Amount.Text);
                    decimal price = Convert.ToInt32(Price.Text);

                    _goodsTableAdapter.InsertQuery(name, amount, price);
                    DataGrid.ItemsSource = _goodsTableAdapter.GetData();
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
                Amount.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[2]);
                Price.Text = Convert.ToString((DataGrid.SelectedItem as DataRowView)[3]);
            }
        }

        private void ImportButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    Deserialize<GoodsClass>(openFileDialog.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при импорте данных");
            }
            
        }
        
        private void Deserialize<T>(string path)
        {
            List<T> goods = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            foreach (var good in goods)
            {
                GoodsClass goodsClass = good as GoodsClass;
                _goodsTableAdapter.InsertQuery(goodsClass.Name, goodsClass.Amount, goodsClass.Price);
                DataGrid.ItemsSource = _goodsTableAdapter.GetData();
            }
        }
        
        internal class GoodsClass
        {
            public string Name { get; set; }
            public int Amount { get; set; }
            public decimal Price { get; set; }
            
            public GoodsClass(string name, int amount, decimal price)
            {
                Name = name;
                Amount = amount;
                Price = price;
            }
        }

        private void Amount_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(isNum);
        }

        private void Price_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(isNum);
        }
    }
}