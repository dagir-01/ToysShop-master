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
    /// Логика взаимодействия для Picktoypostavok.xaml
    /// </summary>
    public partial class Picktoypostavok : Window
    {
        public Picktoypostavok()
        {
            InitializeComponent();
            toysDataGrid.ItemsSource = App.ToysEntities.toys.ToList();
        }
        public Jurnal_postavok Toy { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var t = toysDataGrid.SelectedItem as toys;
            if (t != null)
            {
                Toy = new Jurnal_postavok { id_toys = t.id, count = int.Parse(QuantityTB.Text) };
                Close();
            }
            else
            {
                MessageBox.Show("Не выбрал!");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
