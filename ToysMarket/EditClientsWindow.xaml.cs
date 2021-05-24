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
    /// Логика взаимодействия для EditClientsWindow.xaml
    /// </summary>
    public partial class EditClientsWindow : Window
    {
        private bool isedit = false;
        private clients client;
        public EditClientsWindow(clients clients = null)
        {
            InitializeComponent();

            if (clients == null)
            {
                isedit = false;
                client = new clients();
            }
            else
            {
                isedit = true;
                client = clients;
            }
            grid1.DataContext = client;

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
                    App.ToysEntities.clients.Add(client);
                    App.ToysEntities.SaveChanges();
                }
                
                Close();

            }
            catch (Exception)
            {

                Error.Text = "Ошибка ввода данных. Проверте правильность введеных данных";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
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

        public void Errors()
        {
            if (string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                Error.Text = "Введите  адрес";
                Ok.IsEnabled = false;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(firstnameTextBox.Text))
                {
                    Error.Text = "Введите имя";
                    Ok.IsEnabled = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(lastnameTextBox.Text))
                    {
                        Error.Text = "Введите фамилию";
                        Ok.IsEnabled = false;
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(patronymicTextBox.Text))
                        {
                            Error.Text = "Введите отчество";
                            Ok.IsEnabled = false;
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
                            {
                                Error.Text = "Введите телефон";
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
        }
    }
}