using CartCustomControl.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICartService
    {
        public void AddToCart(CartItem item);
        public void RemoveFromCart(CartItem item);
        public void UpdateTotalPrice();
        public void ClearCart();
    }
}
