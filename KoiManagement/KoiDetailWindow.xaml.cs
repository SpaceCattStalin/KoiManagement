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
using System.Windows.Threading;

namespace KoiManagement
{
    /// <summary>
    /// Interaction logic for KoiDetailWindow.xaml
    /// </summary>
    public partial class KoiDetailWindow : Window, INotifyPropertyChanged
    {
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

        private KoiFish currentKoi;

        public KoiFish CurrentKoi
        {
            get { return currentKoi; }
            set
            {
                currentKoi = value;
                OnPropertyChanged(nameof(CurrentKoi));
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

        private KoiImage primaryImage;
        public KoiImage PrimaryImage
        {
            get { return primaryImage; }
            set
            {
                primaryImage = value;
                OnPropertyChanged(nameof(PrimaryImage));
            }
        }

        private ObservableCollection<KoiImage> koiImages;

        public ObservableCollection<KoiImage> KoiImages
        {
            get { return koiImages; }
            set
            {
                koiImages = value;
                OnPropertyChanged(nameof(KoiImages));
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private readonly DispatcherTimer _carouselTimer;

        private readonly CartService _cartService;
        private readonly IImageService _service;
        private readonly IOrderService _orderService;

        private int currentIndex = 0;


        public KoiDetailWindow(KoiFish koiFish, Customer user)
        {
            InitializeComponent();

            CurrentKoi = koiFish;
            CurrentUser = user;

            DataContext = this;

            _service = new ImageService();
            _orderService = new OrderService();
            _cartService = CartService.Instance;

            _carouselTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            _carouselTimer.Tick += (s, e) => ShiftRight();
            _carouselTimer.Start();

            headerComponent.OpenCartRequest += OpenCartRequest;
            _cartService.CartChanged += OnCartChanged;
            TotalPriceOfCart = _cartService.TotalPrice;
            LoadKoisInCart();
            LoadImages();
        }

        private void OpenCartRequest(object sender, EventArgs e)
        {
            IsCartOpen = !IsCartOpen;
        }

        private void LoadKoisInCart()
        {
            KoisInCart = _cartService.CartItems;
        }

        private void LoadImages()
        {
            KoiImages = _service.GetImagesForKoi(currentKoi.KoiId);
            if (KoiImages != null && KoiImages.Count > 0)
            {
                currentIndex = 0;
                PrimaryImage = KoiImages[currentIndex];
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShiftLeft()
        {
            if (KoiImages == null || KoiImages.Count == 0) return;

            currentIndex = (currentIndex - 1 + KoiImages.Count) % KoiImages.Count;
            PrimaryImage = KoiImages[currentIndex];
        }

        private void ShiftRight()
        {
            if (KoiImages == null || KoiImages.Count == 0) return;

            currentIndex = (currentIndex + 1) % KoiImages.Count;
            PrimaryImage = KoiImages[currentIndex];
        }

        private void Thumbnail_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image && image.DataContext is KoiImage selectedImage)
            {
                PrimaryImage = selectedImage;
                currentIndex = KoiImages.IndexOf(selectedImage);
            }
        }

        private void OnCartChanged(object sender, EventArgs e)
        {
            KoisInCart = _cartService.CartItems;
            TotalPriceOfCart = _cartService.TotalPrice;
        }

        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            ShiftLeft();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            ShiftRight();
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
            var detailWindow = new KoiDetailWindow(currentKoi, currentUser);
            Close();
            detailWindow.Show();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            var homeWindow = new CustomerHomeWindow(CurrentUser);
            Close();
            homeWindow.Show();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
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
    }
}
