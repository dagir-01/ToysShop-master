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

namespace ToysMarket.Views
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SellersWindow window3 = new SellersWindow();
            window3.ShowDialog();
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
