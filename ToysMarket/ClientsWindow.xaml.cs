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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            clientsDataGrid.DataContext = App.ToysEntities.clients.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditClientsWindow window = new EditClientsWindow();
            window.ShowDialog();
            clientsDataGrid.DataContext = null;
            clientsDataGrid.DataContext = App.ToysEntities.clients.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (clientsDataGrid.SelectedItem != null)
            {
                clients client = clientsDataGrid.SelectedItem as clients;
                EditClientsWindow window = new EditClientsWindow(client);
                window.ShowDialog();
                clientsDataGrid.DataContext = null;
                clientsDataGrid.DataContext = App.ToysEntities.clients.ToList();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для изменения!");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (clientsDataGrid.SelectedItem != null)
            {
                clients client = clientsDataGrid.SelectedItem as clients;
                App.ToysEntities.clients.Remove(client);
                App.ToysEntities.SaveChanges();
                clientsDataGrid.DataContext = null;
                clientsDataGrid.DataContext = App.ToysEntities.clients.ToList();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для удаления!");
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            clientsDataGrid.ItemsSource = App.ToysEntities.clients.Where(x => x.firstname.Contains(Search.Text) || x.phone.Contains(Search.Text) || x.address.Contains(Search.Text) || x.lastname.Contains(Search.Text) || x.patronymic.Contains(Search.Text)).ToList();
        }
    }
}
