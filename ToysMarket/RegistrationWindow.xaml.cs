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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private bool isedit = false;
        private Users _user;
        public RegistrationWindow(Users user = null)
        {
            InitializeComponent();
            if (user == null)
            {
                isedit = false;
                _user = new Users();
            }
            else
            {
                isedit = true;
                _user = user;
            }
            grid1.DataContext = _user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
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
                    App.ToysEntities.Users.Add(_user);
                    App.ToysEntities.SaveChanges();
                }

                Close();

            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка ввода данных. Проверте правильность введеных данных");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
