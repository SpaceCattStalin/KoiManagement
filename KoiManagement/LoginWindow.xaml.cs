using Services;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KoiManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerService _service;

        public LoginWindow()
        {
            InitializeComponent();

            _service = new CustomerService();


        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string password;
            string username;

            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Username and password can not be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            username = txtUsername.Text;
            password = txtPassword.Password;

            var user = _service.GetCustomer(username, password);

            if (user != null)
            {
                if (user.Role == "admin")
                {
                    var userAdmin = new UserAdminWindow();
                    Close();
                    userAdmin.Show();
                }
                else
                {
                    var customerHome = new CustomerHomeWindow(user);
                    Close();
                    customerHome.Show();
                }
            }

        }
    }
}
