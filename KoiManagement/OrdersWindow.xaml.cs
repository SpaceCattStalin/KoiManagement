using Microsoft.VisualBasic.ApplicationServices;
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
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window, INotifyPropertyChanged
    {
        private readonly Customer _user;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Order> orders;

        public List<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(orders));
            }
        }

        private readonly IOrderService _orderService;

        public OrdersWindow(Customer user)
        {
            InitializeComponent();
            DataContext = this;
            orderBtn.Background = (Brush)new BrushConverter().ConvertFromString("#b8c2cc");
            headerComponent.ShowOrderRequest += ShowOrdersRequest;
            headerComponent.ShowUserAccountRequest += ShowUserAccountRequest;
            _user = user;
            _orderService = new OrderService();
            LoadOrders();
        }

        private void LoadOrders()
        {
            Orders = _orderService.GetAll(_user.UserId);
        }

        private void ShowUserAccountRequest(object sender, EventArgs e)
        {
            var userAccount = new UserAccount(_user);
            userAccount.Show();
            Close();
        }

        private void ShowOrdersRequest(object sender, EventArgs e)
        {
            var orders = new OrdersWindow(_user);
            Close();
            orders.Show();
        }

        private void accBtn_Click(object sender, RoutedEventArgs e)
        {
            var account = new UserAccount(_user);
            Close();
            account.Show();
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            var orders = new OrdersWindow(_user);
            Close();
            orders.Show();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            var home = new CustomerHomeWindow(_user);
            Close();
            home.Show();
        }
    }
}
