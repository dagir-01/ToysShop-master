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
    /// Логика взаимодействия для ProvidersWindow.xaml
    /// </summary>
    public partial class ProvidersWindow : Window
    {
        public ProvidersWindow()
        {
            InitializeComponent();
            postavshikDataGrid.DataContext = App.ToysEntities.postavshik.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditProvidersWindow window = new EditProvidersWindow();
            window.ShowDialog();
            postavshikDataGrid.DataContext = null;
            postavshikDataGrid.DataContext = App.ToysEntities.postavshik.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (postavshikDataGrid.SelectedItem != null)
            {
                postavshik postavshiks = postavshikDataGrid.SelectedItem as postavshik;
                EditProvidersWindow window = new EditProvidersWindow(postavshiks);
                window.ShowDialog();
                postavshikDataGrid.DataContext = null;
                postavshikDataGrid.DataContext = App.ToysEntities.postavshik.ToList();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для изменения!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (postavshikDataGrid.SelectedItem != null)
            {
                postavshik postavshiks = postavshikDataGrid.SelectedItem as postavshik;
                App.ToysEntities.postavshik.Remove(postavshiks);
                App.ToysEntities.SaveChanges();
                postavshikDataGrid.DataContext = null;
                postavshikDataGrid.DataContext = App.ToysEntities.postavshik.ToList();
            }
            else
            {
                MessageBox.Show("Не выбран элемент для удаления!");
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            postavshikDataGrid.ItemsSource = App.ToysEntities.postavshik.Where(x => x.email.Contains(Search.Text) || x.fax.Contains(Search.Text) || x.phone.Contains(Search.Text) || x.name.Contains(Search.Text)).ToList();
        }
    }
}
