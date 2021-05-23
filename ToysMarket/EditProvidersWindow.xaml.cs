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
    /// Логика взаимодействия для EditProvidersWindow.xaml
    /// </summary>
    public partial class EditProvidersWindow : Window
    {
        private bool isedit = false;
        private postavshik postavshik1;
        public EditProvidersWindow(postavshik postavshiks = null)
        {
            InitializeComponent();

            if (postavshiks == null)
            {
                isedit = false;
                postavshik1 = new postavshik();
            }
            else
            {
                isedit = true;
                postavshik1 = postavshiks;
            }
            grid1.DataContext = postavshik1;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isedit == true)
                {
                    App.ToysEntities.SaveChanges();
                }
                else
                {
                    App.ToysEntities.postavshik.Add(postavshik1);
                    App.ToysEntities.SaveChanges();
                }
                MessageBox.Show("Успешно");
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Введены неверные данные!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
