using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace ToysMarket
{
    /// <summary>
    /// Логика взаимодействия для JurnalZakazov.xaml
    /// </summary>
    public partial class JurnalZakazov : Window
    {
        public JurnalZakazov()
        {
            InitializeComponent();
            zakazDataGrid.ItemsSource = App.ToysEntities.zakaz.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            OrderEdit window = new OrderEdit();
            window.ShowDialog();
            zakazDataGrid.ItemsSource = null;
            zakazDataGrid.ItemsSource = App.ToysEntities.zakaz.ToList();

        }

        private void EditButton_Click1(object sender, RoutedEventArgs e)
        {
            
            if (zakazDataGrid.SelectedItem is Models.zakaz item)
            {
                OrderEdit window = new OrderEdit(item);
                window.ShowDialog();
                zakazDataGrid.ItemsSource = null;
                zakazDataGrid.ItemsSource = App.ToysEntities.zakaz.ToList();
            }
        }

        private void EditButton_Click2(object sender, RoutedEventArgs e)
        {
            
            if (zakazDataGrid.SelectedItem is Models.zakaz item)
            {
                foreach (var jp in item.jurnal_zakazovs.ToList())
                {
                    App.ToysEntities.jurnal_zakazovs.Remove(jp);
                }
                App.ToysEntities.zakaz.Remove(item);
                App.ToysEntities.SaveChanges();
                zakazDataGrid.ItemsSource = null;
                zakazDataGrid.ItemsSource = App.ToysEntities.zakaz.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            sheet1.Cells[1, 1] = "Дата покупки";
            sheet1.Cells[1, 2] = "Клиент";
            sheet1.Cells[1, 3] = "Продавец";

            var list = App.ToysEntities.zakaz.Where(x => x.date_pokupki > SortirovkaOT.SelectedDate).Where(x => x.date_pokupki < SortirobkaDO.SelectedDate).Include(x=>x.prodaves).Include(x=>x.clients).Include(x => x.jurnal_zakazovs).ToList();
            int row = 0;
            foreach (var postavki in list)
            {
                ++row;
                sheet1.Cells[row, 1] = "Дата поставки";
                sheet1.Cells[row, 2] = "Клиент";
                sheet1.Cells[row, 3] = "Продавец";
                sheet1.Cells[++row, 1] = postavki.date_pokupki;
                sheet1.Cells[row, 2] = $"{postavki.clients.lastname} {postavki.clients.firstname} {postavki.clients.patronymic}";
                sheet1.Cells[row, 3] = $"{postavki.prodaves.lastname} {postavki.prodaves.firstname} {postavki.prodaves.patronymic}";

                int j = 0;
                foreach (var tmp in postavki.jurnal_zakazovs)
                {
                    var jp = App.ToysEntities.jurnal_zakazovs.Include(x => x.toys).FirstOrDefault(x => x.id == tmp.id);
                    sheet1.Cells[++row, 1] = jp.toys.name;
                    sheet1.Cells[row, 2] = jp.quantity;
                    j += 2;
                }
                ++row;

            }
            excel.Visible = true;
            excel.GetSaveAsFilename("Отчет.xls");
        }
    }
}
