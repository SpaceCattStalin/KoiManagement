using CartCustomControl.Helper;
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
    public partial class CustomerHomeWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Customer currentUser;

        public Customer CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private List<KoiFish> kois;

        public List<KoiFish> Kois
        {
            get { return kois; }
            set
            {
                kois = value;
                OnPropertyChanged(nameof(Kois));
            }
        }

        private ObservableCollection<CartItem> koisInCart;

        public ObservableCollection<CartItem> KoisInCart
        {
            get { return koisInCart; }
            set
            {
                koisInCart = value;
                OnPropertyChanged(nameof(KoisInCart));
            }
        }

        private decimal? totalPriceOfCart;
        public decimal? TotalPriceOfCart
        {
            get { return totalPriceOfCart; }
            set
            {
                totalPriceOfCart = value;
                OnPropertyChanged(nameof(TotalPriceOfCart));
            }
        }

        private List<KoiBreedType> koisBreed;

        public List<KoiBreedType> KoisBreed
        {
            get
            {
                return koisBreed;
            }
            set
            {
                koisBreed = value;
                OnPropertyChanged(nameof(KoisBreed));
            }
        }

        private bool isCartOpen;

        public bool IsCartOpen
        {
            get { return isCartOpen; }
            set
            {
                isCartOpen = value;
                OnPropertyChanged(nameof(IsCartOpen));
            }
        }

        private KoiBreedType selectedBreed;
        public KoiBreedType SelectedBreed
        {
            get
            {
                return selectedBreed;
            }
            set
            {
                selectedBreed = value;
                OnPropertyChanged(nameof(SelectedBreed));
            }
        }

        private readonly IKoiFIshService _koiService;
        private readonly IOrderService _orderService;

        //private readonly ICartService _cartService;
        private readonly CartService _cartService;
        public CustomerHomeWindow(Customer user)
        {
            InitializeComponent();
            DataContext = this;
            _koiService = new KoiFishService();
            _orderService = new OrderService();
            _cartService = CartService.Instance;

            headerComponent.ShowUserAccountRequest += ShowUserAccountRequest;
            headerComponent.OpenCartRequest += OpenCartRequest;
            headerComponent.ShowOrderRequest += ShowOrdersRequest;
            _cartService.CartChanged += OnCartChanged;

            CurrentUser = user;
            IsCartOpen = false;
            KoisInCart = _cartService.CartItems;
            TotalPriceOfCart = _cartService.TotalPrice;
            LoadKois();
            LoadBreeds();
        }

        private void LoadBreeds()
        {
            var listWithAllOption = _koiService.GetAllBreedTypes();
            listWithAllOption.Insert(0, new KoiBreedType { BreedName = "All", BreedTypeId = -1 });
            KoisBreed = listWithAllOption;
        }
        private void LoadKois()
        {
            Kois = _koiService.GetAllKois();
        }

        private void ApplyFilter()
        {
            if (SelectedBreed.BreedTypeId == -1)
            {
                LoadKois();
            }
            else
            {
                Kois = _koiService.GetAllKois().Where(k => k.BreedTypeId == SelectedBreed.BreedTypeId).ToList();
            }
        }

        private void OpenCartRequest(object sender, EventArgs e)
        {
            IsCartOpen = !IsCartOpen;
        }

        private void OnCartChanged(object sender, EventArgs e)
        {
            KoisInCart = _cartService.CartItems;
            TotalPriceOfCart = _cartService.TotalPrice;
        }

        private void ShowUserAccountRequest(object sender, EventArgs e)
        {
            var userAccount = new UserAccount(CurrentUser);
            userAccount.Show();
            Close();
        }

        private void ShowOrdersRequest(object sender, EventArgs e)
        {
            var orders = new OrdersWindow(currentUser);
            Close();
            orders.Show();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is KoiFish addedKoi)
            {

                var cartItem = new CartItem
                {
                    Koi = addedKoi,
                    TotalPrice = addedKoi.Price,
                    TotalQuantity = 1
                };
                _cartService.AddToCart(cartItem);

                MessageBox.Show($"{addedKoi.Name} has been added to your cart!", "Added to Cart", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void checkoutBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var order = new Order
                {
                    CreatedAt = DateTime.Now,
                    TotalAmount = TotalPriceOfCart,
                    UserId = CurrentUser.UserId,
                };
                _orderService.CreateOrder(order);

                var orderDetails = new List<OrderDetail>();

                foreach (var item in KoisInCart)
                {
                    var orderDetail = new OrderDetail
                    {
                        KoiId = item.Koi.KoiId,
                        OrderId = order.OrderId,
                        Price = (decimal)item.Koi.Price,
                        Quantity = item.TotalQuantity
                    };
                    orderDetails.Add(orderDetail);
                }
                _orderService.UpdateOrder(order, orderDetails);

                _cartService.ClearCart();
                KoisInCart.Clear();
                MessageBox.Show("Order placed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating order: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void detailBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is KoiFish currentKoi)
            {
                var detailWindow = new KoiDetailWindow(currentKoi, currentUser);
                Close();
                detailWindow.Show();
            }
        }


        private void breedCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBreed = breedCb.SelectedItem as KoiBreedType;
            ApplyFilter();
        }
    }
}
