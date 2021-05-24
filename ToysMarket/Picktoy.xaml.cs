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
            toysDataGrid.ItemsSource = App.ToysEntities.toys.ToList();
        }

        public jurnal_zakazovs Toy { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = toysDataGrid.SelectedItem as toys;
            Toy = new jurnal_zakazovs { id_toys = t.id, quantity = int.Parse(QuantityTB.Text)}; 
            Close();
        }

  
    }
}
