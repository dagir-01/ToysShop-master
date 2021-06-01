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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToysMarket.Models;

namespace ToysMarket
{
    /// <summary>
    /// Логика взаимодействия для ToysWindow.xaml
    /// </summary>
    public partial class ToysWindow : Window
    {
        public ToysWindow()
        {
            InitializeComponent();
            SearchSort_Changed();
            ToysLv.DataContext = App.ToysEntities.toys.ToList();
            Refresh();
        }
 

        public void SearchSort_Changed()
        {
            var toy = App.ToysEntities.toys.AsQueryable();

            if (IsLoaded == false) return;

            if (Sort.SelectedIndex == 1)
            {
                toy = toy.OrderBy(p => p.price);
            }
            else
            {
                toy = toy.OrderByDescending(p => p.price);
            }

            toy = toy.Where(x => x.name.Contains(Search.Text) || x.brends.name.Contains(Search.Text) || x.categories.name.Contains(Search.Text) || x.type_toys.name.Contains(Search.Text));

            ToysLv.ItemsSource = App.ToysEntities.toys.Where(x => x.name.Contains(Search.Text) || x.categories.name.Contains(Search.Text) || x.brends.name.Contains(Search.Text) || x.type_toys.name.Contains(Search.Text)).ToList();



            ToysLv.ItemsSource = toy.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditToysWindow window = new EditToysWindow();
            window.ShowDialog();
            ToysLv.DataContext = null;
            ToysLv.DataContext = App.ToysEntities.toys.ToList();
            Refresh();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSort_Changed();
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchSort_Changed();
        }

        public void Refresh()
        {
            ToysLv.ItemsSource = null;
            ToysLv.ItemsSource = App.ToysEntities.toys.ToList();
            SearchSort_Changed();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button ed)
            {
                if (ed.DataContext is toys product)
                {
                    App.ToysEntities.toys.Remove(product);
                    App.ToysEntities.SaveChanges();
                    Refresh();
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {        
            var ed = sender as Button;
            if (ed == null)
            {
                return;
            }
            var toys = ed.Tag as toys;
            if (toys == null)
            {
                return;
            }
            var pv = new EditToysWindow(toys);
            pv.ShowDialog();
            Refresh();
        }
    }
}
