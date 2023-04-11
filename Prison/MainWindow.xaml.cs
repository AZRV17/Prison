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
    public partial class MainWindow : Window
    {
        private List<Page> _pages = new List<Page>();
        private int index = 0;
        
        private PrisonersTableAdapter _prisonersTableAdapter = new PrisonersTableAdapter();
        private CellsTableAdapter _cellsTableAdapter = new CellsTableAdapter();
        private CourtsTableAdapter _courtsTableAdapter = new CourtsTableAdapter();
        private CrimesTableAdapter _crimesTableAdapter = new CrimesTableAdapter();
        private EmployeesTableAdapter _employeesTableAdapter = new EmployeesTableAdapter();
        private FinesTableAdapter _finesTableAdapter = new FinesTableAdapter();
        private MedicalRecordsTableAdapter _medicalRecordsTableAdapter = new MedicalRecordsTableAdapter();
        private VisitorsTableAdapter _visitorsTableAdapter = new VisitorsTableAdapter();
        private ConvictionsTableAdapter _convictionsTableAdapter = new ConvictionsTableAdapter();
        private UsersTableAdapter _usersTableAdapter = new UsersTableAdapter();
        private GoodsTableAdapter _goodsTableAdapter = new GoodsTableAdapter();
        // private BillTableAdapter _billTableAdapter = new BillTableAdapter();

        public MainWindow()
        {
            InitializeComponent();
            Prisoners prisoners = new Prisoners();
            Visitors visitors = new Visitors();
            MedicalRecords medicalRecords = new MedicalRecords();
            Fines fines = new Fines();
            Employees employees = new Employees();
            Crimes crimes = new Crimes();
            Courts courts = new Courts();
            Convictions convictions = new Convictions();
            Cells cells = new Cells();
            Users users = new Users();
            Goods goods = new Goods();
            // Bills bills = new Bills();
            _pages.Add(prisoners);
            _pages.Add(cells);
            _pages.Add(visitors);
            _pages.Add(crimes);
            _pages.Add(medicalRecords);
            _pages.Add(fines);
            _pages.Add(courts);
            _pages.Add(employees);
            _pages.Add(convictions);
            _pages.Add(users);
            _pages.Add(goods);
            // _pages.Add(bills);
            Frame.Content = _pages[index].Content;
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
                index++;
                Frame.Content = _pages[index].Content;
            }
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = (DataGrid)_pages[index].FindName("DataGrid");
            if (dataGrid.SelectedItem != null)
            {
                object id = (dataGrid.SelectedItem as DataRowView)[0];
                DeleteRecord(id, dataGrid);
            }
        }

        private void DeleteRecord(object id, DataGrid dataGrid)
        {
            switch (index)
            {
                    case 0: 
                    {
                        _prisonersTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _prisonersTableAdapter.GetData();
                        break;
                    }
                    case 1: 
                    {
                        _cellsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _cellsTableAdapter.GetData();
                        break;
                    }
                    case 2: 
                    {
                        _visitorsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _visitorsTableAdapter.GetData();
                        break;
                    }
                    case 3: 
                    {
                        _crimesTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _crimesTableAdapter.GetData();
                        break;
                    }
                    case 4: 
                    {
                        _medicalRecordsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _medicalRecordsTableAdapter.GetData();
                        break;
                    }
                    case 5: 
                    {
                        _finesTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _finesTableAdapter.GetData();
                        break;
                    }
                    case 6: 
                    {
                        _courtsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _courtsTableAdapter.GetData();
                        break;
                    }
                    case 7: 
                    {
                        _employeesTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _employeesTableAdapter.GetData();
                        break;
                    }
                    case 8: 
                    {
                        _convictionsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _convictionsTableAdapter.GetData();
                        break;
                    }
                    
                    case 9: 
                    {
                        _usersTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _usersTableAdapter.GetData();
                        break;
                    }
                    
                    case 10: 
                    {
                        _goodsTableAdapter.DeleteQuery(Convert.ToInt32(id));
                        dataGrid.ItemsSource = _goodsTableAdapter.GetData();
                        break;
                    }
                    // case 11: 
                    // {
                    //     _billTableAdapter.DeleteQuery(Convert.ToInt32(id));
                    //     dataGrid.ItemsSource = _billTableAdapter.GetData();
                    //     break;
                    // }
            }
        }
    }
}
