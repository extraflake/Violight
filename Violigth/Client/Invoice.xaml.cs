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
using Violigth.Data.Context;

namespace Violigth.Client
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        MyContext myContext = new MyContext();

        public Invoice()
        {
            InitializeComponent();
        }

        public Invoice(string id)
        {
            InitializeComponent();
            DateIssuedText.Text = DateTime.Now.ToLocalTime().ToString();
            InvoiceText.Text = id;
            var getCart = myContext.Sells.Include("Item").Include("Receipt").Where(x => x.Receipt.Id.Equals(id)).ToList();
            var getReceipt = myContext.Receipts.Find(id);
            InvoiceGrid.ItemsSource = getCart;
            DiscountText.Text = getReceipt.Discount.ToString() + "%";
            TotalDueText.Text = "Rp. " + getReceipt.Total.ToString();
        }

        private void PrintBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Invoice");
                }
            }
            catch (Exception)
            {
                this.IsEnabled = true;
                throw;
            }
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
