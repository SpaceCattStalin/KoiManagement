using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for UserAccount.xaml
    /// </summary>
    public partial class UserAccount : Window, INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;

        private Customer user;
        public Customer User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(user));
            }
        }

        public UserAccount(Customer user)
        {
            InitializeComponent();
            _customerService = new CustomerService();
            User = user;
            DataContext = this;
            headerComponent.ShowOrderRequest += ShowOrdersRequest;
            headerComponent.ShowUserAccountRequest += ShowUserAccountRequest;
            accBtn.Background = (Brush)new BrushConverter().ConvertFromString("#b8c2cc");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            var home = new CustomerHomeWindow(user);
            Close();
            home.Show();
        }

        private void detailBtn_Click(object sender, RoutedEventArgs e)
        {
            var detail = new UserAccount(user);
            Close();
            detail.Show();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Content.ToString() == "Edit")
                {
                    nameTxt.IsEnabled = true;
                    phoneTxt.IsEnabled = true;
                    emailTxt.IsEnabled = true;

                    btn.Content = "Save";
                }
                else
                {

                    var name = nameTxt.Text;
                    var phone = phoneTxt.Text;
                    var email = emailTxt.Text;

                    if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(phone) || String.IsNullOrEmpty(email))
                    {
                        MessageBox.Show("All field required", "Error", MessageBoxButton.OK);
                        return;
                    }


                    var updatedCustomer = new Customer
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        Fullname = name,
                        Password = user.Password,
                        Phone = phone,
                        Address = email,
                        IsActive = user.IsActive,
                        Role = user.Role,
                    };

                    _customerService.Update(updatedCustomer);
                    MessageBox.Show("Update successfully!", "Update", MessageBoxButton.OK);

                    nameTxt.IsEnabled = false;
                    phoneTxt.IsEnabled = false;
                    emailTxt.IsEnabled = false;

                    btn.Content = "Edit";
                }

            }
        }

        private void ShowUserAccountRequest(object sender, EventArgs e)
        {
            var userAccount = new UserAccount(user);
            userAccount.Show();
            Close();
        }

        private void ShowOrdersRequest(object sender, EventArgs e)
        {
            var orders = new OrdersWindow(user);
            Close();
            orders.Show();
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            var orders = new OrdersWindow(user);
            Close();
            orders.Show();
        }

        private void accBtn_Click(object sender, RoutedEventArgs e)
        {
            var account = new UserAccount(user);
            Close();
            account.Show();

        }
    }
}
