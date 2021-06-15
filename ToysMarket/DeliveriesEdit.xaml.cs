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
    /// Логика взаимодействия для DeliveriesEdit.xaml
    /// </summary>
    public partial class DeliveriesEdit : Window
    {
        postavki _postavki = new postavki();
        bool isedit = false;
        public DeliveriesEdit(postavki postavki = null)
        {
            InitializeComponent();
            _postavki.Jurnal_postavok = new List<Jurnal_postavok>();
            id_postavshikTextBox.ItemsSource = App.ToysEntities.postavshik.ToList();
            if (postavki != null)
            {
                isedit = true;
                _postavki = postavki;

            }

            grid1.DataContext = _postavki;
            jurnal_postavokDataGrid.ItemsSource = _postavki.Jurnal_postavok;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var pick = new Picktoypostavok();
            pick.ShowDialog();
            if (pick.Toy != null)
            {
                _postavki.Jurnal_postavok.Add(pick.Toy);
                jurnal_postavokDataGrid.ItemsSource = null;
                jurnal_postavokDataGrid.ItemsSource = _postavki.Jurnal_postavok;
            }
        }

        private void Dell_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult deletemess = MessageBox.Show("Вы действительно хотите удалить?", "Удаление", MessageBoxButton.YesNo);
                if (deletemess == MessageBoxResult.Yes)
                {
                    var item = jurnal_postavokDataGrid.SelectedItem as Models.Jurnal_postavok;
                    if (item != null)
                    {
                        _postavki.Jurnal_postavok.Remove(item);
                        var tmp = App.ToysEntities.Jurnal_postavok.FirstOrDefault(x => x.id == item.id);
                        if (tmp != null)
                        {
                            App.ToysEntities.Jurnal_postavok.Remove(tmp);
                        }
                        jurnal_postavokDataGrid.ItemsSource = null;
                        jurnal_postavokDataGrid.ItemsSource = _postavki.Jurnal_postavok.ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
            
        }

        private void Accept_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isedit == false)
                {
                    foreach (var jp in _postavki.Jurnal_postavok.ToList())
                    {
                        jp.toys.quantity += jp.count;
                    }
                    App.ToysEntities.postavki.Add(_postavki);
                    App.ToysEntities.SaveChanges();

                }
                else
                {
                    App.ToysEntities.SaveChanges();
                }
                MessageBox.Show("Успешно");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены неверные данные");
            }
        }

        private void Close_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
