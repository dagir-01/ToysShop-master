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
    /// Логика взаимодействия для JurnalPostavok.xaml
    /// </summary>
    public partial class JurnalPostavok : Window
    {
        public JurnalPostavok()
        {
            InitializeComponent();
            postavkiDataGrid.ItemsSource = null;
            postavkiDataGrid.ItemsSource = App.ToysEntities.postavki.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DeliveriesEdit window = new DeliveriesEdit();
            window.ShowDialog();
            postavkiDataGrid.ItemsSource = null;
            postavkiDataGrid.ItemsSource = App.ToysEntities.postavki.ToList();
        }

        private void EditButton_Click1(object sender, RoutedEventArgs e)
        {
            if (postavkiDataGrid.SelectedItem is Models.postavki item)
            {
                DeliveriesEdit window = new DeliveriesEdit(item);
                window.ShowDialog();
                postavkiDataGrid.ItemsSource = null;
                postavkiDataGrid.ItemsSource = App.ToysEntities.postavki.ToList();
            }
        }

        private void EditButton_Click2(object sender, RoutedEventArgs e)
        {
            if (postavkiDataGrid.SelectedItem is Models.postavki item)
            {
                foreach (var jp in item.Jurnal_postavok.ToList())
                {
                    App.ToysEntities.Jurnal_postavok.Remove(jp);
                }
                App.ToysEntities.postavki.Remove(item);
                App.ToysEntities.SaveChanges();
                postavkiDataGrid.ItemsSource = null;
                postavkiDataGrid.ItemsSource = App.ToysEntities.postavki.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

            int row = 0;


            var list = App.ToysEntities.postavki.Where(x => x.date_postavki > SortirovkaOT.SelectedDate).Where(x => x.date_postavki < SortirobkaDO.SelectedDate).Include(x => x.Jurnal_postavok).ToList();

            foreach (var postavki in list)
            {
                ++row;
                sheet1.Cells[row, 1] = "Дата поставки";
                sheet1.Cells[row, 2] = "Наименование поставщика";
                sheet1.Cells[++row , 1] = postavki.date_postavki;
                sheet1.Cells[row, 2] = postavki.postavshik.name;

                int j = 0;
                foreach (var tmp in postavki.Jurnal_postavok)
                {
                    var jp = App.ToysEntities.Jurnal_postavok.Include(x => x.toys).FirstOrDefault(x => x.id == tmp.id);
                    sheet1.Cells[++row, 1] = jp.toys.name;
                    sheet1.Cells[row, 2] = jp.count;
                    j += 2;
                }
                ++row;

            }
            excel.Visible = true;
            excel.GetSaveAsFilename("Отчет.xls");
        }


    }
}
