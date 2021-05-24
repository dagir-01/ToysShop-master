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
    /// Логика взаимодействия для EditClientsWindow.xaml
    /// </summary>
    public partial class EditClientsWindow : Window
    {
        private bool isedit = false;
        private clients client;
        public EditClientsWindow(clients clients = null)
        {
            InitializeComponent();

            if (clients == null)
            {
                isedit = false;
                client = new clients();
            }
            else
            {
                isedit = true;
                client = clients;
            }
            grid1.DataContext = client;

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
                    App.ToysEntities.clients.Add(client);
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
