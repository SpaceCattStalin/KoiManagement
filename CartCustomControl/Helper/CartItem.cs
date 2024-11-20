using Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartCustomControl.Helper
{
    public class CartItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private decimal? totalPrice;
        public decimal? TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }


        private int? totalQuantity;

        public int? TotalQuantity
        {
            get { return totalQuantity; }
            set
            {
                totalQuantity = value;
                OnPropertyChanged(nameof(TotalQuantity));
            }
        }
        public KoiFish Koi { get; set; }
    }
}
