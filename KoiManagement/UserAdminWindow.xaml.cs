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
    /// Interaction logic for UserAdminWindow.xaml
    /// </summary>
    public partial class UserAdminWindow : Window, INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<string> roles;

        public List<string> Roles
        {
            get { return roles; }
            set
            {
                roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        private List<Customer> customers;

        public List<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        private Customer selectedUser;

        public Customer SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }


        public UserAdminWindow()
        {
            InitializeComponent();
            DataContext = this;
            _customerService = new CustomerService();
            LoadCustomers();
            cbRole.SelectedItem = null;
            userBtn.Background = (Brush)new BrushConverter().ConvertFromString("#1b1918");
        }

        private void LoadCustomers()
        {
            Customers = _customerService.GetAll();
            Roles = Customers.Select(c => c.Role).Distinct().ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Add this user", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtFullname.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtStatus.Text) || String.IsNullOrEmpty(txtEmail.Text) || cbRole.SelectedItem == null)
                {
                    MessageBox.Show("All field are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newUser = new Customer
                {
                    Username = txtUsername.Text,
                    Fullname = txtFullname.Text,
                    Phone = txtPhone.Text,
                    Address = txtEmail.Text,
                    IsActive = Convert.ToByte(txtStatus.Text),
                    Role = cbRole.SelectedItem as string,
                };

                _customerService.Add(newUser);
                MessageBox.Show("Added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                LoadCustomers();
            }
            else
            {
                return;
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Update this user", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedUser != null)
                {
                    if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtFullname.Text) || String.IsNullOrEmpty(txtPhone.Text) || String.IsNullOrEmpty(txtStatus.Text) || String.IsNullOrEmpty(txtEmail.Text) || cbRole.SelectedItem == null)
                    {
                        MessageBox.Show("All field are required", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var updatedUser = new Customer
                    {
                        UserId = SelectedUser.UserId,
                        Username = txtUsername.Text,
                        Fullname = txtFullname.Text,
                        Phone = txtPhone.Text,
                        Address = txtEmail.Text,
                        IsActive = Convert.ToByte(txtStatus.Text),
                        Role = cbRole.SelectedItem as string,
                    };

                    _customerService.Update(updatedUser);
                    MessageBox.Show("Update successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    LoadCustomers();
                }
            }
            else
            {
                return;
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete this user", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedUser != null)
                {
                    _customerService.Remove(SelectedUser);
                    MessageBox.Show("Delete successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    LoadCustomers();
                    txtStatus.Text = Convert.ToString(SelectedUser.IsActive);
                }
            }
            else
            {
                return;
            }
        }

        private void lwCus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUser = lwCus.SelectedItem as Customer;
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserAdminWindow();
            Close();
            userWindow.Show();
        }

        private void koiBtn_Click(object sender, RoutedEventArgs e)
        {
            var koisWindow = new KoiAdminWindow();
            Close();
            koisWindow.Show();
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderAdminWindow();
            Close();
            orderWindow.Show();
        }
    }
}
