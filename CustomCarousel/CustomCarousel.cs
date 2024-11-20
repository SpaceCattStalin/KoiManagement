using Repositories.Models;
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

namespace CustomCarousel
{
    public class CustomCarousel : ContentControl
    {


        public List<KoiImage> Items
        {
            get { return (List<KoiImage>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
                    DependencyProperty.Register("Items", typeof(List<KoiImage>), typeof(CustomCarousel), new PropertyMetadata(null));

        //public bool IsSelected
        //{
        //    get { return (bool)GetValue(IsSelectedProperty); }
        //    set { SetValue(IsSelectedProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IsSelectedProperty =
        //    DependencyProperty.Register("IsSelected", typeof(bool), typeof(CustomCarousel), new PropertyMetadata(false));


        public ICommand SelectPreviousCommand
        {
            get { return (ICommand)GetValue(SelectPreviousCommandProperty); }
            set { SetValue(SelectPreviousCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectPreviousCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectPreviousCommandProperty =
            DependencyProperty.Register("SelectPreviousCommand", typeof(ICommand), typeof(CustomCarousel), new PropertyMetadata(null));

        public ICommand SelectNextCommand
        {
            get { return (ICommand)GetValue(SelectNextCommandProperty); }
            set { SetValue(SelectNextCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectNextCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectNextCommandProperty =
            DependencyProperty.Register("SelectNextCommand", typeof(ICommand), typeof(CustomCarousel), new PropertyMetadata(null));

        static CustomCarousel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCarousel), new FrameworkPropertyMetadata(typeof(CustomCarousel)));
        }


        //private void SelectFirstItem()
        //{
        //    foreach (var item in Items)
        //    {
        //        item.IsSelected = item == Items[0];
        //    }
        //}

        public void ShiftLeft()
        {
            var first = Items[0];
            Items.RemoveAt(0);
            Items.Add(first);
            //SelectFirstItem();
        }

        private void ShiftRight()
        {
            var last = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            Items.Insert(0, last);
            //SelectFirstItem();
        }
    }
}