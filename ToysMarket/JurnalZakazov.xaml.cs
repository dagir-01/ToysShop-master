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
    /// Логика взаимодействия для JurnalZakazov.xaml
    /// </summary>
    public partial class JurnalZakazov : Window
    {
        public JurnalZakazov()
        {
            InitializeComponent();
            zakazDataGrid.ItemsSource = App.ToysEntities.zakaz.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
