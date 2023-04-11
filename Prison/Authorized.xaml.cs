using System.Windows;
using Prison.PrisonDataSetTableAdapters;

namespace Prison
{
    public partial class Authorized1 : Window
    {
        private UsersTableAdapter _usersTableAdapter = new UsersTableAdapter();
        public Authorized1()
        {
            InitializeComponent();
        }

        private void SignInButton_OnClick(object sender, RoutedEventArgs e)
        {
            string loginInput = LoginTextBox.Text;
            string passwordInput = PasswordTextBox.Password;
            foreach (var user in _usersTableAdapter.GetData())
            {
                if (loginInput == user.Loign && passwordInput == user.Password)
                {
                    if (user.RoleID == 1)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else if (user.RoleID == 2)
                    {
                        ShopWindow shopWindow = new ShopWindow();
                        shopWindow.Show();
                        int user_id = user.UserID;
                        ((App)Application.Current).ID = user_id;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data Error");
                    }
                }
                else
                {
                    LoginHint.Visibility = Visibility.Visible;
                    PasswordHint.Visibility = Visibility.Visible;
                }
            }
        }
    }
}