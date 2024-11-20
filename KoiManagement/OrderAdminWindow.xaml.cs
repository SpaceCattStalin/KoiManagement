using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrderAdminWindow.xaml
    /// </summary>
    public partial class OrderAdminWindow : Window, INotifyPropertyChanged
    {
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
                OnPropertyChanged(nameof(Orders));
            }
        }

        private readonly IOrderService _orderService;

        public OrderAdminWindow()
        {
            InitializeComponent();
            DataContext = this;
            _orderService = new OrderService();
            orderBtn.Background = (Brush)new BrushConverter().ConvertFromString("#1b1918");
            LoadOrders();
        }

        private void LoadOrders()
        {
            Orders = _orderService.GetAll();
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderAdminWindow();
            Close();
            orderWindow.Show();
        }

        private void koiBtn_Click(object sender, RoutedEventArgs e)
        {
            var koisWindow = new KoiAdminWindow();
            Close();
            koisWindow.Show();
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserAdminWindow();
            Close();
            userWindow.Show();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = usernameSearch.Text;
            if (String.IsNullOrEmpty(searchTerm))
            {
                LoadOrders();
            }
            else
            {
                LoadOrders();
                Orders = Orders.Where(o => o.User.Username.Contains(searchTerm)).ToList();
            }
        }

        private void ApplyDateFilter()
        {
            DateTime? start = startDate.SelectedDate;
            DateTime? end = endDate.SelectedDate;

            if (start == null || end == null)
            {
                LoadOrders();
            }
            else
            {
                LoadOrders();

                Orders = Orders.Where(order => order.CreatedAt.Date >= start.Value.Date && order.CreatedAt.Date <= end.Value.Date).ToList();
            }
        }

        private void startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyDateFilter();
        }

        private void endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyDateFilter();
        }
    }
}
