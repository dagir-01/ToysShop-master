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
using System.Windows.Shapes;
using ToysMarket.Models;
using MaterialDesignColors;
using MaterialDesignThemes;
using Microsoft.Win32;
using System.IO;

namespace ToysMarket
{
    /// <summary>
    /// Логика взаимодействия для EditToysWindow.xaml
    /// </summary>
    public partial class EditToysWindow : Window
    {
        private bool isedit = false;
        private toys toy;
        public EditToysWindow(toys toys = null)
        {
            InitializeComponent();
            id_brendsTextBox.ItemsSource = App.ToysEntities.brends.ToList();
            id_categoryTextBox.ItemsSource = App.ToysEntities.categories.ToList();
            id_type_toysTextBox.ItemsSource = App.ToysEntities.type_toys.ToList();
            if (toys == null)
            {
                isedit = false;
                toy = new toys();
            }
            else
            {
                isedit = true;
                toy = toys;
            }
            grid1.DataContext = toy;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isedit == true)
                {
                    App.ToysEntities.SaveChanges();
                }
                else
                {
                    App.ToysEntities.toys.Add(toy);
                    App.ToysEntities.SaveChanges();
                }
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Введены неверные данные!");
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Choose your pic";
            if (ofd.ShowDialog() == true)
            {
                var file = File.ReadAllBytes(ofd.FileName);
                toy.image = null;
                toy.image = file;
                imageImage.Source = null;
                imageImage.Source = toy.image.ByteToImage();
              
            }

        }
      






    }
    public static class ByteImageConverter
    {
        public static ImageSource ByteToImage(this byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }
    }
}
