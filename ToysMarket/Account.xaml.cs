using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public Account()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString.ToString();
        }


        private void enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = tUsername.Text;
                var password = tPassword.Password;

                var role = App.ToysEntities.Users.Where(x => x.Username == name && x.Password == password).FirstOrDefault();
                if (role == null)
                {
                    MessageBox.Show("Данного пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (role.Status == false)
                {
                    MessageBox.Show("Данный пользователь отключен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                App.User = role;
                Menu window = new Menu();
                window.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка подключения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow window = new RegistrationWindow();
            window.ShowDialog();
        }
    }
}
