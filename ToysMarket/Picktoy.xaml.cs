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
    /// Логика взаимодействия для Picktoy.xaml
    /// </summary>
    public partial class Picktoy : Window
    {
        public Picktoy()
        {
            InitializeComponent();
        }

        public toys Toy { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource toysViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("toysViewSource")));
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            // toysViewSource.Source = [универсальный источник данных]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Toy = toysDataGrid.SelectedItem as toys;
            Close();
        }
    }
}
