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

            //ToysLv.ItemsSource = App.ToysEntities.toys.Where(x => x.brends.Contains(Search.Text) || x.fax.Contains(Search.Text) || x.phone.Contains(Search.Text) || x.name.Contains(Search.Text)).ToList();

            //toy = toy.Where(x => x.brends(Search.Text) || x.id_category.ToString(Search.Text));

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ToysLv.SelectedItem != null)
            {
                toys toy = ToysLv.SelectedItem as toys;
                EditToysWindow window = new EditToysWindow(toy);
                window.ShowDialog();
                ToysLv.DataContext = null;
                ToysLv.DataContext = App.ToysEntities.toys.ToList();
                Refresh();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для изменения!");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ToysLv.SelectedItem != null)
            {
                toys toy = ToysLv.SelectedItem as toys;
                App.ToysEntities.toys.Remove(toy);
                App.ToysEntities.SaveChanges();
                ToysLv.DataContext = null;
                ToysLv.DataContext = App.ToysEntities.toys.ToList();
                Refresh();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для удаления!");
            }
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
            if (sender is Button btn)
            {
                if (btn.DataContext is toys product)
                {
                    App.ToysEntities.toys.Remove(product);
                    App.ToysEntities.SaveChanges();
                    Refresh();
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null)
            {
                return;
            }
            var toys = btn.Tag as toys;
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
