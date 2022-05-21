using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using Violigth.Data.Model;
using Violigth.Data.ViewModel;

namespace Violigth.Client
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class Transaction : UserControl
    {
        MyContext myContext = new MyContext();

        public Transaction()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TempReceiptText.Text = DateTimeOffset.Now.LocalDateTime.ToString("ddmmyyyy") + RandomString(5);
            CategoryCombo.ItemsSource = myContext.Categories.ToList();
        }

        #region Search

        private void CategoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductGrid.ItemsSource = myContext.Items.Where(x => (x.Category.Id.ToString() == CategoryCombo.SelectedValue.ToString()) && x.Stock > 0).ToList();
        }

        private void ProductText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ProductGrid.ItemsSource = myContext.Items.Where(x => (x.Category.Name.ToString().Contains(ProductText.Text) || x.Name.Contains(ProductText.Text)) && x.Stock > 0).ToList();
        }

        private void ProductGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = ProductGrid.SelectedItem;
            try
            {
                TempNameText.Text = (ProductGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                QuantityValidationText.Text = (ProductGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {
                
            }
        }

        #endregion Search

        #region Add To Cart

        private void AddCartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TempNameText.Text))
            {
                MessageBox.Show("Pilih Produk terlebih dahulu.");
            }
            else if (QuantityText.Value == 0)
            {
                MessageBox.Show("Masukkan jumlah item");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TempReceiptText.Text))
                {

                }
                else
                {
                    var getId = myContext.Receipts.Find(TempReceiptText.Text);
                    if (getId == null)
                    {
                        ReceiptVM receiptVM = new ReceiptVM() { Id = TempReceiptText.Text, Total = 0 };
                        var pushone = new Receipt(receiptVM);
                        pushone.Payment = myContext.Payments.Find(1);
                        myContext.Receipts.Add(pushone);
                        var resultone = myContext.SaveChanges();
                        if (resultone > 0)
                        {
                            var getItem = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameText.Text));
                            var getReceipt = myContext.Receipts.Find(TempReceiptText.Text);
                            SellVM sellVM = new SellVM() { Price = getItem.Price, Quantity = Convert.ToInt16(QuantityText.Value), SubTotal = getItem.Price * Convert.ToInt16(QuantityText.Value) };
                            var pushtwo = new Sell(sellVM);
                            pushtwo.Item = getItem;
                            pushtwo.Receipt = getReceipt;
                            myContext.Sells.Add(pushtwo);
                            var resulttwo = myContext.SaveChanges();
                            if (resulttwo > 0)
                            {
                                MessageBox.Show(QuantityText.Value + " produk bertambah", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                                SellGrid.ItemsSource = myContext.Sells.Include("Item").Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                                var pull = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameText.Text));
                                pull.Stock -= Convert.ToInt16(QuantityText.Value);
                                myContext.Entry(pull).State = EntityState.Modified;
                                myContext.SaveChanges();
                                try
                                {
                                    var get = myContext.Items.Where(x => (x.Category.Id.ToString() == CategoryCombo.SelectedValue.ToString()) && x.Stock > 0).ToList();
                                    ProductGrid.ItemsSource = get;
                                }
                                catch (Exception)
                                {
                                    var get = myContext.Items.Where(x => x.Name.Contains(ProductText.Text) && x.Stock > 0).ToList();
                                    ProductGrid.ItemsSource = get;
                                }
                                var getSubTotal = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).Sum(x => x.Price*x.Quantity);
                                SubTotalText.Text = getSubTotal.ToString();
                                GrandTotalText.Text = getSubTotal.ToString();
                            }
                            else
                            {
                                MessageBox.Show("0 produk bertambah", "Gagal", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("0 produk bertambah", "Gagal", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        var getItem = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameText.Text));
                        var getCart = myContext.Sells.SingleOrDefault(x => x.Receipt.Id.Equals(getId.Id) && x.Item.Id.Equals(getItem.Id));
                        if (getCart != null)
                        {
                            getCart.Quantity += Convert.ToInt16(QuantityText.Value);
                            getCart.SubTotal = getCart.Quantity * getCart.Price;
                            myContext.Entry(getCart).State = EntityState.Modified;
                            var result = myContext.SaveChanges();
                            if (result > 0)
                            {
                                MessageBox.Show("1 produk bertambah", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                                SellGrid.ItemsSource = myContext.Sells.Include("Item").Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                                var pull = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameText.Text));
                                pull.Stock -= Convert.ToInt16(QuantityText.Value);
                                myContext.Entry(pull).State = EntityState.Modified;
                                myContext.SaveChanges();
                                try
                                {
                                    var get = myContext.Items.Where(x => (x.Category.Id.ToString() == CategoryCombo.SelectedValue.ToString()) && x.Stock > 0).ToList();
                                    ProductGrid.ItemsSource = get;
                                }
                                catch (Exception)
                                {
                                    var get = myContext.Items.Where(x => x.Name.Contains(ProductText.Text) && x.Stock > 0).ToList();
                                    ProductGrid.ItemsSource = get;
                                }
                                var getSubTotal = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).Sum(x => x.Price * x.Quantity);
                                SubTotalText.Text = getSubTotal.ToString();
                                GrandTotalText.Text = getSubTotal.ToString();
                            }
                        }
                        else
                        {
                            var getItems = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameText.Text));
                            var getReceipt = myContext.Receipts.Find(TempReceiptText.Text);
                            SellVM sellVM = new SellVM() { Price = getItems.Price, Quantity = Convert.ToInt16(QuantityText.Value), SubTotal = getItems.Price * Convert.ToInt16(QuantityText.Value) };
                            var pushtwo = new Sell(sellVM);
                            pushtwo.Item = getItems;
                            pushtwo.Receipt = getReceipt;
                            myContext.Sells.Add(pushtwo);
                            var resulttwo = myContext.SaveChanges();
                            if (resulttwo > 0)
                            {
                                MessageBox.Show(QuantityText.Value + " produk bertambah", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                                SellGrid.ItemsSource = myContext.Sells.Include("Item").Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                                var pull = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameText.Text));
                                pull.Stock -= Convert.ToInt16(QuantityText.Value);
                                myContext.Entry(pull).State = EntityState.Modified;
                                myContext.SaveChanges();
                                try
                                {
                                    var get = myContext.Items.Where(x => (x.Category.Id.ToString() == CategoryCombo.SelectedValue.ToString()) && x.Stock > 0).ToList();
                                    ProductGrid.ItemsSource = get;
                                }
                                catch (Exception)
                                {
                                    var get = myContext.Items.Where(x => x.Name.Contains(ProductText.Text) && x.Stock > 0).ToList();
                                    ProductGrid.ItemsSource = get;
                                }
                                var getSubTotal = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).Sum(x => x.Price * x.Quantity);
                                SubTotalText.Text = getSubTotal.ToString();
                                GrandTotalText.Text = getSubTotal.ToString();
                            }
                            else
                            {
                                MessageBox.Show("0 produk bertambah", "Gagal", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void QuantityText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
            try
            {
                if (Convert.ToInt16(QuantityText.Value) > Convert.ToInt16(QuantityValidationText.Text))
                {
                    QuantityText.Value = Convert.ToDouble(QuantityValidationText.Text);
                }
            }
            catch (Exception)
            {
                
            }
        }

        #endregion Add To Cart
        
        #region Remove From Cart

        private void SellGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = SellGrid.SelectedItem;
            try
            {
                TempNameCartText.Text = (SellGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception ex)
            {

            }
        }

        private void RemoveCartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TempNameText.Text))
            {
                MessageBox.Show("Pilih Produk terlebih dahulu.");
            }
            else
            {
                try
                {
                    var getCart = myContext.Sells.SingleOrDefault(x => x.Item.Name.Equals(TempNameCartText.Text) && x.Receipt.Id.Equals(TempReceiptText.Text));
                    if (getCart.Quantity == 1)
                    {
                        myContext.Sells.Remove(getCart);
                        var result = myContext.SaveChanges();
                        if (result > 0)
                            MessageBox.Show("1 Produk Dibatalkan");
                        SellGrid.ItemsSource = myContext.Sells.Include("Item").Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                        var pull = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameCartText.Text));
                        pull.Stock += 1;
                        myContext.Entry(pull).State = EntityState.Modified;
                        myContext.SaveChanges();
                        try
                        {
                            var get = myContext.Items.Where(x => (x.Category.Id.ToString() == CategoryCombo.SelectedValue.ToString()) && x.Stock > 0).ToList();
                            ProductGrid.ItemsSource = get;
                        }
                        catch (Exception)
                        {
                            var get = myContext.Items.Where(x => x.Name.Contains(ProductText.Text) && x.Stock > 0).ToList();
                            ProductGrid.ItemsSource = get;
                        }
                        var getSubTotal = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).Sum(x => x.Price * x.Quantity);
                        SubTotalText.Text = getSubTotal.ToString();
                        GrandTotalText.Text = getSubTotal.ToString();
                    }
                    else
                    {
                        getCart.Quantity -= 1;
                        getCart.SubTotal = getCart.Quantity * getCart.Price;
                        myContext.Entry(getCart).State = EntityState.Modified;
                        var result = myContext.SaveChanges();
                        if (result > 0)
                            MessageBox.Show("1 Produk telah dikurangi");
                        SellGrid.ItemsSource = myContext.Sells.Include("Item").Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                        var pull = myContext.Items.SingleOrDefault(x => x.Name.Equals(TempNameCartText.Text));
                        pull.Stock += 1;
                        myContext.Entry(pull).State = EntityState.Modified;
                        myContext.SaveChanges();
                        try
                        {
                            var get = myContext.Items.Where(x => (x.Category.Id.ToString() == CategoryCombo.SelectedValue.ToString()) && x.Stock > 0).ToList();
                            ProductGrid.ItemsSource = get;
                        }
                        catch (Exception)
                        {
                            var get = myContext.Items.Where(x => x.Name.Contains(ProductText.Text) && x.Stock > 0).ToList();
                            ProductGrid.ItemsSource = get;
                        }
                        var getSubTotal = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).Sum(x => x.Price * x.Quantity);
                        SubTotalText.Text = getSubTotal.ToString();
                        GrandTotalText.Text = getSubTotal.ToString();
                    }
                }
                catch (Exception)
                {
                    SubTotalText.Text = "";
                }
            }
        }

        #endregion Remove From Cart

        #region Pay

        private void PayCartBtn_Click(object sender, RoutedEventArgs e)
        {
            var getReceipt = myContext.Receipts.Find(TempReceiptText.Text);
            getReceipt.Total = Convert.ToDecimal(GrandTotalText.Text);
            getReceipt.Discount = Convert.ToDecimal(DiscountText.Text);
            myContext.Entry(getReceipt).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                Invoice invoice = new Invoice(TempReceiptText.Text);
                invoice.Show();
                try
                {
                    TempReceiptText.Text = DateTimeOffset.Now.LocalDateTime.ToString("ddmmyyyy") + RandomString(5);
                    SellGrid.ItemsSource = myContext.Sells.Include("Item").Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                    SubTotalText.Text = "";
                    DiscountText.Text = "";
                    CashText.Text = "";
                    GrandTotalText.Text = "";
                    ChangeText.Text = "";
                }
                catch (Exception)
                {
                }                
            }
            else
            {
                MessageBox.Show("Penjualan Gagal");
            }
        }

        #endregion Pay

        #region Cancel

        private void CancelCartBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var getCart = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                myContext.Sells.RemoveRange(getCart);
                var resultone = myContext.SaveChanges();
                if (resultone > 0)
                {
                    var getReceipt = myContext.Receipts.Find(TempReceiptText.Text);
                    myContext.Receipts.Remove(getReceipt);
                    var resulttwo = myContext.SaveChanges();
                    if (resulttwo > 0)
                    {
                        MessageBox.Show("Terminated");
                        SellGrid.ItemsSource = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text)).ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Canceled");
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion Cancel

        #region Result

        private void DiscountText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var getCart = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text) && x.Item.Category.Type.Id.Equals(2)).ToList();
                var getSubTotalJasa = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text) && x.Item.Category.Type.Name.Equals("Jasa")).ToList();
                double resultJasa = getSubTotalJasa.Sum(x => x.Price * x.Quantity);
                var getSubTotalProduct = myContext.Sells.Where(x => x.Receipt.Id.Equals(TempReceiptText.Text) && x.Item.Category.Type.Name != "Jasa").ToList();
                double resultProduct = getSubTotalProduct.Sum(x => x.Price * x.Quantity);
                if (getSubTotalJasa.Count() == 0)
                {
                    GrandTotalText.Text = resultProduct.ToString();
                }
                else if (getSubTotalProduct.Count() == 0)
                {
                    GrandTotalText.Text = (Convert.ToDouble(resultJasa) - (Convert.ToDouble(resultJasa) * (Convert.ToDouble(DiscountText.Text) / 100))).ToString();
                }
                else
                {
                    GrandTotalText.Text = (Convert.ToDouble(resultProduct) + (Convert.ToDouble(resultJasa) - (Convert.ToDouble(resultJasa) * (Convert.ToDouble(DiscountText.Text) / 100)))).ToString();
                }
            }
        }

        #endregion Result

        #region Payment

        private void CashText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangeText.Text = (Convert.ToDouble(CashText.Text) - Convert.ToDouble(GrandTotalText.Text)).ToString();
            }
        }

        #endregion Payment
    }
}
