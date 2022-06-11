using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using Violigth.Data.Context;

using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Violigth.Client
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        MyContext myContext = new MyContext();

        public Report()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //var get = myContext.Receipts.Where(x => x.CreateDate.Day.Equals(30)).ToList();
                //ReportGrid.ItemsSource = get;
            }
            catch (Exception)
            {
            }
            
        }

        private void DetailBTN_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice(ReceiptTempText.Text);
            invoice.Show();
        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int from = FromDate.SelectedDate.Value.Day;
            int to = ToDate.SelectedDate.Value.Day;
            if (from.Equals(to))
            {
                try
                {
                    var get = myContext.Receipts.Where(x => x.CreateDate.Day.Equals(to)).ToList();
                    var detailReceipt = myContext.Sells.Include("Item").Include("Receipt").Where(x => x.CreateDate.Day.Equals(to)).ToList();
                    var getIncome = myContext.Receipts.Where(x => x.CreateDate.Day.Equals(to)).Sum(x => x.Total);
                    ReportDetailGrid.ItemsSource = detailReceipt;
                    ReportGrid.ItemsSource = get;
                    IncomeText.Text = getIncome.ToString();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    var get = myContext.Receipts.Where(x => x.CreateDate.Day >= from && x.CreateDate.Day <= to).ToList();
                    var detailReceipt = myContext.Sells.Include("Item").Include("Receipt").Where(x => x.CreateDate.Day >= from && x.CreateDate.Day <= to).ToList();
                    var getIncome = myContext.Receipts.Where(x => x.CreateDate.Day >= from && x.CreateDate.Day <= to).Sum(x => x.Total);
                    ReportDetailGrid.ItemsSource = detailReceipt;
                    ReportGrid.ItemsSource = get;
                    IncomeText.Text = getIncome.ToString();
                }
                catch (Exception)
                {
                }
            }
        }

        private void ReportGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = ReportGrid.SelectedItem;
            try
            {
                ReceiptTempText.Text = (ReportGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < ReportDetailGrid.Columns.Count - 1; j++)
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = ReportDetailGrid.Columns[j].Header;
            }

            for (int i = 0; i < ReportDetailGrid.Columns.Count - 1; i++)
            {
                for (int j = 0; j < ReportDetailGrid.Items.Count; j++)
                {
                    TextBlock b = ReportDetailGrid.Columns[i].GetCellContent(ReportDetailGrid.Items[j]) as TextBlock;
                    Range myRange = (Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }
    }
}
