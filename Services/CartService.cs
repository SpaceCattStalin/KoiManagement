using CartCustomControl.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CartService : ICartService
    {
        private static readonly CartService _instance = new CartService();

        public static CartService Instance { get { return _instance; } }

        private decimal? _totalPrice;
        public event EventHandler CartChanged;

        private static ObservableCollection<CartItem> _cartItems;

        public ObservableCollection<CartItem> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                UpdateTotalPrice();
                CartChanged.Invoke(this, EventArgs.Empty);
            }
        }
        public decimal? TotalPrice => _totalPrice;

        private CartService()
        {
            _cartItems = new ObservableCollection<CartItem>();
            _totalPrice = 0;
        }

        public void AddToCart(CartItem item)
        {
            var existingKoi = _cartItems.FirstOrDefault(k => k.Koi.KoiId == item.Koi.KoiId);
            if (existingKoi != null)
            {
                existingKoi.TotalQuantity++;
                existingKoi.TotalPrice += item.TotalPrice;
            }
            else
            {
                _cartItems.Add(item);
            }
            UpdateTotalPrice();
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ClearCart()
        {
            _cartItems.Clear();
            UpdateTotalPrice();
            CartChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveFromCart(CartItem item)
        {
            throw new NotImplementedException();
        }

        public void UpdateTotalPrice()
        {
            _totalPrice = _cartItems.Sum(x => x.TotalPrice);
        }
    }
}
