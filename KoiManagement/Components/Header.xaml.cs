using CartCustomControl.Helper;
using Repositories.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KoiManagement.Components
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public event EventHandler ShowUserAccountRequest;
        //public event EventHandler CheckoutRequest;
        public event EventHandler OpenCartRequest;
        public event EventHandler ShowOrderRequest;
        public Customer User
        {
            get { return (Customer)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for User.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(Customer), typeof(Header), new PropertyMetadata(null));



        public double CartWidth
        {
            get { return (double)GetValue(CartWidthProperty); }
            set { SetValue(CartWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CartWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartWidthProperty =
            DependencyProperty.Register("CartWidth", typeof(double), typeof(Header), new PropertyMetadata(double.NaN));



        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double), typeof(Header), new PropertyMetadata(double.NaN));


        public List<CartItem> KoisList
        {
            get { return (List<CartItem>)GetValue(KoisListProperty); }
            set { SetValue(KoisListProperty, value); }
        }


        public static readonly DependencyProperty KoisListProperty =
            DependencyProperty.Register("KoisList", typeof(List<CartItem>), typeof(Header), new PropertyMetadata(null));



        public decimal? TotalAmount
        {
            get { return (decimal?)GetValue(TotalAmountProperty); }
            set { SetValue(TotalAmountProperty, value); }
        }

        public static readonly DependencyProperty TotalAmountProperty =
            DependencyProperty.Register("TotalAmount", typeof(decimal?), typeof(Header), new PropertyMetadata(null));


        public bool IsLoggined
        {
            get { return (bool)GetValue(IsLogginedProperty); }
            set { SetValue(IsLogginedProperty, value); }
        }

        public static readonly DependencyProperty IsLogginedProperty =
            DependencyProperty.Register("IsLoggined", typeof(bool), typeof(Header), new PropertyMetadata(false));



        public bool IsCartOpen
        {
            get { return (bool)GetValue(IsCartOpenProperty); }
            set { SetValue(IsCartOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCartOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCartOpenProperty =
            DependencyProperty.Register("IsCartOpen", typeof(bool), typeof(Header), new PropertyMetadata(false));



        public Header()
        {
            InitializeComponent();
            cartControl.IsOpenChanged += IsCartOpenChanged;
        }

        private void IsCartOpenChanged(object sender, EventArgs e)
        {
            OpenCartRequest?.Invoke(this, EventArgs.Empty);
            IsCartOpen = !IsCartOpen;
        }

        private void accountBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowUserAccountRequest?.Invoke(this, EventArgs.Empty);
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowOrderRequest?.Invoke(this, EventArgs.Empty);
        }

        //private void checkoutBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    CheckoutRequest?.Invoke(this, EventArgs.Empty);
        //}
    }
}
