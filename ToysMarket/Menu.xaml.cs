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

namespace ToysMarket
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToysWindow window = new ToysWindow();
            window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientsWindow window1 = new ClientsWindow();
            window1.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProvidersWindow window2 = new ProvidersWindow();
            window2.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SellersWindow window3 = new SellersWindow();
            window3.ShowDialog();
        } 

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            JurnalZakazov window4 = new JurnalZakazov();
            window4.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            JurnalPostavok window4 = new JurnalPostavok();
            window4.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Account window5 = new Account();
            window5.Show();
            Close();
        }


    }
}
