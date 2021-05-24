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
    /// Логика взаимодействия для OrderEdit.xaml
    /// </summary>
    public partial class OrderEdit : Window
    {
        zakaz _zakaz = new zakaz();
        bool isedit = false;
        public OrderEdit(zakaz zakaz = null)
        {
            InitializeComponent();
            _zakaz.jurnal_zakazovs = new List<jurnal_zakazovs>();
            id_clientTextBox.ItemsSource = App.ToysEntities.clients.ToList();
            id_prodavesTextBox.ItemsSource = App.ToysEntities.prodaves.ToList();
            if (zakaz != null)
            {
                isedit = true;
                _zakaz = zakaz;
              
            }

            grid1.DataContext = _zakaz;
            jurnal_zakazovsDataGrid.ItemsSource = _zakaz.jurnal_zakazovs;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pick = new Picktoy();
            pick.ShowDialog();
            if (pick.Toy != null)
            {
                _zakaz.jurnal_zakazovs.Add(pick.Toy);
                jurnal_zakazovsDataGrid.ItemsSource = null;
                jurnal_zakazovsDataGrid.ItemsSource = _zakaz.jurnal_zakazovs;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
