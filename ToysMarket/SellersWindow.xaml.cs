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
    /// Логика взаимодействия для SellersWindow.xaml
    /// </summary>
    public partial class SellersWindow : Window
    {
        public SellersWindow()
        {
            InitializeComponent();
            prodavesDataGrid.DataContext = App.ToysEntities.prodaves.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditSellersWindow window = new EditSellersWindow();
            window.ShowDialog();
            prodavesDataGrid.DataContext = null;
            prodavesDataGrid.DataContext = App.ToysEntities.prodaves.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (prodavesDataGrid.SelectedItem != null)
            {
                prodaves prodave = prodavesDataGrid.SelectedItem as prodaves;
                EditSellersWindow window = new EditSellersWindow(prodave);
                window.ShowDialog();
                prodavesDataGrid.DataContext = null;
                prodavesDataGrid.DataContext = App.ToysEntities.prodaves.ToList();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для изменения!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (prodavesDataGrid.SelectedItem != null)
            {
                prodaves prodave = prodavesDataGrid.SelectedItem as prodaves;
                App.ToysEntities.prodaves.Remove(prodave);
                App.ToysEntities.SaveChanges();
                prodavesDataGrid.DataContext = null;
                prodavesDataGrid.DataContext = App.ToysEntities.prodaves.ToList();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для удаления!");
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            prodavesDataGrid.ItemsSource = App.ToysEntities.prodaves.Where(x => x.address.Contains(Search.Text) || x.firstname.Contains(Search.Text) || x.lastname.Contains(Search.Text) || x.patronymic.Contains(Search.Text) || x.phone.Contains(Search.Text)).ToList();
        }
    }
}
