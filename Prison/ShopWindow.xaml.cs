using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class ShopWindow : Window
    {
        private List<Page> _pages = new List<Page>();
        private int index = 0;

        private BillTableAdapter _billTableAdapter = new BillTableAdapter();
        private GoodsTableAdapter _goodsTableAdapter = new GoodsTableAdapter();

        public ShopWindow()
        {
            InitializeComponent();
            ShopPage shopPage = new ShopPage();
            Bills_items billsItems = new Bills_items();
            _pages.Add(shopPage);
            _pages.Add(billsItems);
            Frame.Content = _pages[index].Content;
            billsItems.BillsComboBox.ItemsSource = _billTableAdapter.GetData();
            billsItems.BillsComboBox.DisplayMemberPath = "Date";
        }

        private void PrevButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                Frame.Content = _pages[index].Content;
            }
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (index < _pages.Count - 1)
            {
                Bills_items billsItems = new Bills_items();
                billsItems.BillsComboBox.ItemsSource = _billTableAdapter.GetData();
                billsItems.BillsComboBox.DisplayMemberPath = "Date";
                index++;
                Frame.Content = _pages[index].Content;
            }
        }
    }
}
