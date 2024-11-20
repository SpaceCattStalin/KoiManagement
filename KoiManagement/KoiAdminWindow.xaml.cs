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
    public partial class KoiAdminWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly IKoiFIshService _service;

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

        private KoiFish selectedKoi;

        public KoiFish SelectedKoi
        {
            get { return selectedKoi; }
            set
            {
                selectedKoi = value;
                OnPropertyChanged(nameof(SelectedKoi));
            }
        }

        private List<KoiBreedType> breeds;

        public List<KoiBreedType> Breeds
        {
            get { return breeds; }
            set
            {
                breeds = value;
                OnPropertyChanged(nameof(Breeds));
            }
        }


        public KoiAdminWindow()
        {
            InitializeComponent();
            DataContext = this;
            koiBtn.Background = (Brush)new BrushConverter().ConvertFromString("#1b1918");
            _service = new KoiFishService();
            LoadKois();
        }

        private void LoadKois()
        {
            Kois = _service.GetAllKois();
            Breeds = _service.GetAllBreedTypes();
        }

        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserAdminWindow();
            Close();
            userWindow.Show();
        }

        private void koiBtn_Click(object sender, RoutedEventArgs e)
        {
            var koisWindow = new KoiAdminWindow();
            Close();
            koisWindow.Show();
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderAdminWindow();
            Close();
            orderWindow.Show();
        }

        private void koiLw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedKoi = koiLw.SelectedItem as KoiFish;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Add this koi", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {


                if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtAge.Text) || String.IsNullOrEmpty(txtColor.Text) || String.IsNullOrEmpty(txtSize.Text) || String.IsNullOrEmpty(txtStatus.Text) || String.IsNullOrEmpty(txtStock.Text))
                {
                    MessageBox.Show("All field required", "Error", MessageBoxButton.OK);
                    return;
                }

                var breed = cbBreed.SelectedItem as KoiBreedType;

                var addedKoi = new KoiFish
                {
                    Name = txtName.Text,
                    Age = Convert.ToInt32(txtAge.Text),
                    Color = txtColor.Text,
                    BreedTypeId = breed.BreedTypeId,
                    IsListed = Convert.ToByte(txtStatus.Text),
                    Origin = txtOrigin.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Size = Convert.ToDecimal(txtSize.Text),
                    StockQuantity = Convert.ToInt32(txtStock.Text),
                };

                _service.Add(addedKoi);
                MessageBox.Show("Successfully", "Success", MessageBoxButton.OK);
                LoadKois();
                //Clear();

            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Update this koi", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedKoi != null)
                {
                    if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtAge.Text) || String.IsNullOrEmpty(txtColor.Text) || String.IsNullOrEmpty(txtSize.Text) || String.IsNullOrEmpty(txtStatus.Text) || String.IsNullOrEmpty(txtStock.Text))
                    {
                        MessageBox.Show("All field required", "Error", MessageBoxButton.OK);
                        return;
                    }

                    var breed = cbBreed.SelectedItem as KoiBreedType;

                    var updatedKoi = new KoiFish
                    {
                        KoiId = SelectedKoi.KoiId,
                        Name = txtName.Text,
                        Age = Convert.ToInt32(txtAge.Text),
                        Color = txtColor.Text,
                        BreedTypeId = breed.BreedTypeId,
                        IsListed = Convert.ToByte(txtStatus.Text),
                        Origin = txtOrigin.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Size = Convert.ToDecimal(txtSize.Text),
                        StockQuantity = Convert.ToInt32(txtStock.Text),
                    };

                    _service.Update(updatedKoi);
                    MessageBox.Show("Successfully", "Success", MessageBoxButton.OK);
                    LoadKois();
                    //Clear();
                }
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete this user", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedKoi != null)
                {
                    _service.Delete(SelectedKoi);
                    MessageBox.Show("Delete successfully", "Delete", MessageBoxButton.OK);
                    LoadKois();
                    //Clear();
                }
            }
            else
            {
                return;
            }
        }

        //private void Clear()
        //{
        //    koiImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/placeholder.jpg"));
        //    txtName.Text = "";
        //    txtAge.Text = "";
        //    txtColor.Text = "";
        //    txtSize.Text = "";
        //    txtStock.Text = "";
        //}

        //private void clrBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    koiImg.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/placeholder.jpg"));
        //    txtName.Text = "";
        //    txtAge.Text = "";
        //    txtColor.Text = "";
        //    txtSize.Text = "";
        //    txtStock.Text = "";
        //}
    }
}
