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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Violigth.Data.Context;

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
                    var getIncome = myContext.Receipts.Where(x => x.CreateDate.Day.Equals(to)).Sum(x => x.Total);
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
                    var getIncome = myContext.Receipts.Where(x => x.CreateDate.Day >= from && x.CreateDate.Day <= to).Sum(x => x.Total);
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
    }
}
