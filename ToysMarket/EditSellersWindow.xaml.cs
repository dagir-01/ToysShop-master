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

namespace ToysMarket
{
    /// <summary>
    /// Логика взаимодействия для EditSellersWindow.xaml
    /// </summary>
    public partial class EditSellersWindow : Window
    {
        private bool isedit = false;
        private prodaves prodave1;
        public EditSellersWindow(prodaves prodaves = null)
        {
            InitializeComponent();

            if (prodaves == null)
            {
                isedit = false;
                prodave1 = new prodaves();
            }
            else
            {
                isedit = true;
                prodave1 = prodaves;
            }
            grid1.DataContext = prodave1;
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
                    App.ToysEntities.prodaves.Add(prodave1);
                    App.ToysEntities.SaveChanges();
                }
                MessageBox.Show("Успешно");
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
    }
}
