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
    /// Логика взаимодействия для JurnalPostavok.xaml
    /// </summary>
    public partial class JurnalPostavok : Window
    {
        public JurnalPostavok()
        {
            InitializeComponent();
            postavkiDataGrid.ItemsSource = App.ToysEntities.postavki.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DeliveriesEdit window = new DeliveriesEdit();
            window.ShowDialog();
            postavkiDataGrid.ItemsSource = null;
            postavkiDataGrid.ItemsSource = App.ToysEntities.postavki.ToList();
        }
    }
}
