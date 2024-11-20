using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CartCustomControl
{
    public class CartCustomControl : ContentControl
    {
        public event EventHandler IsOpenChanged;

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set
            {
                SetValue(IsOpenProperty, value);
                OnIsOpenChanged();
            }
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(CartCustomControl), new PropertyMetadata(false, OnIsOpenPropertyChanged));

        private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CartCustomControl;
            control?.OnIsOpenChanged();
        }

        protected virtual void OnIsOpenChanged()
        {
            IsOpenChanged?.Invoke(this, EventArgs.Empty);
        }


        static CartCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CartCustomControl), new FrameworkPropertyMetadata(typeof(CartCustomControl)));
        }
    }
}