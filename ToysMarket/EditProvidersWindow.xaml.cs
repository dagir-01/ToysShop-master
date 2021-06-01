using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void Errors()
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                Error.Text = "Введите  почту";
                Ok.IsEnabled = false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(faxTextBox.Text))
                {
                    Error.Text = "Введите факс";
                    Ok.IsEnabled = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                    {
                        Error.Text = "Введите имя";
                        Ok.IsEnabled = false;
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
                        {
                            Error.Text = "Введите номер";
                            Ok.IsEnabled = false;
                        }
                        else
                        {          
                                Error.Text = "";
                                Ok.IsEnabled = true;
                        }
                    }
                }
            }
        }
        private void phoneTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void phoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Errors();
        }
    }
}

