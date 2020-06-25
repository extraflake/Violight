using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using Violigth.Data.Repository;
using Violigth.Data.Repository.Interface;
using Violigth.Data.ViewModel;

namespace Violigth.Client
{
    /// <summary>
    /// Interaction logic for Master.xaml
    /// </summary>
    public partial class Master : UserControl
    {
        ITypeRepository typeRepository = new TypeRepository();
        IItemRepository itemRepository = new ItemRepository();
        ICategoryRepository categoryRepository = new CategoryRepository();
        IRoleRepository roleRepository = new RoleRepository();
        IPaymentRepository paymentRepository = new PaymentRepository();
        IUserRepository userRepository = new UserRepository();
        IRoleUserRepository roleUserRepository = new RoleUserRepository();
        IAccountRepository accountRepository = new AccountRepository();

        // Email Configuration
        SmtpClient smtpClient;
        NetworkCredential networkCredential;
        MailMessage mailMessage;

        bool result = false;

        public Master()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Grid
            TypeGrid.ItemsSource = typeRepository.Get();
            ItemGrid.ItemsSource = itemRepository.Get();
            CategoryGrid.ItemsSource = categoryRepository.Get();
            RoleGrid.ItemsSource = roleRepository.Get();
            PaymentGrid.ItemsSource = paymentRepository.Get();
            UserGrid.ItemsSource = userRepository.Get();
            RoleUserGrid.ItemsSource = roleUserRepository.Get();

            // ComboBox
            TypeComboBox.ItemsSource = typeRepository.Get();
            CategoryComboBox.ItemsSource = categoryRepository.Get();
            UserComboBox.ItemsSource = userRepository.GetDropdown();
            RoleComboBox.ItemsSource = roleRepository.Get();
        }

        #region Type

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes) 
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    var delete = typeRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        MessageBox.Show("Berhasil di Hapus");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }

        private void SaveOrUpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TypeTextT.Text))
            {
                MessageBox.Show("Kolom Nama Tipe Harus Diisi!");
            }
            else
            {
                TypeVM typeVM = new TypeVM();
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    typeVM.Name = TypeTextT.Text;
                }
                else
                {
                    typeVM.Id = Convert.ToInt32(IdTempText.Text);
                    typeVM.Name = TypeTextT.Text;
                }
                if (typeVM.Id == 0)
                {
                    result = typeRepository.Insert(typeVM);
                }
                else
                {
                    result = typeRepository.Update(typeVM.Id, typeVM);
                }
                if (result)
                {
                    MessageBox.Show("Data telah Tersimpan");
                    UserControl_Loaded(sender, e);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Data tidak Tersimpan");
                    Clear();
                }
            }
        }

        private void TypeGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = TypeGrid.SelectedItem;
            try
            {
                TypeTextT.Text = (TypeGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                var get = typeRepository.Check(TypeTextT.Text);
                IdTempText.Text = get.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Type

        #region Category

        private void CategoryGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = CategoryGrid.SelectedItem;
            try
            {
                CategoryText.Text = (CategoryGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                var get = categoryRepository.Check(CategoryText.Text);
                IdTempText.Text = get.Id.ToString();
                TypeComboBox.SelectedValue = get.Type.Id;
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveOrUpdateCBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryText.Text))
            {
                MessageBox.Show("Kolom Nama Kategori Harus Diisi!");
            }
            else
            {
                CategoryVM categoryVM = new CategoryVM();
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    categoryVM.Name = CategoryText.Text;
                    categoryVM.Type_Id = Convert.ToInt32(TypeComboBox.SelectedValue);
                }
                else
                {
                    categoryVM.Id = Convert.ToInt32(IdTempText.Text);
                    categoryVM.Name = CategoryText.Text;
                    categoryVM.Type_Id = Convert.ToInt32(TypeComboBox.SelectedValue);
                }
                if (categoryVM.Id == 0)
                {
                    result = categoryRepository.Insert(categoryVM);
                }
                else
                {
                    result = categoryRepository.Update(categoryVM.Id, categoryVM);
                }
                if (result)
                {
                    MessageBox.Show("Data telah Tersimpan");
                    UserControl_Loaded(sender, e);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Data tidak Tersimpan");
                    Clear();
                }
            }
        }

        private void DeleteCBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    var delete = categoryRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        MessageBox.Show("Berhasil di Hapus");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }

        #endregion Category

        #region Role

        private void RoleGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = RoleGrid.SelectedItem;
            try
            {
                RoleText.Text = (RoleGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                var get = roleRepository.Check(RoleText.Text);
                IdTempText.Text = get.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveOrUpdateRBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoleText.Text))
            {
                MessageBox.Show("Kolom Nama Role Harus Diisi!");
            }
            else
            {
                RoleVM roleVM = new RoleVM();
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    roleVM.Name = RoleText.Text;
                }
                else
                {
                    roleVM.Id = Convert.ToInt32(IdTempText.Text);
                    roleVM.Name = RoleText.Text;
                }
                if (roleVM.Id == 0)
                {
                    result = roleRepository.Insert(roleVM);
                }
                else
                {
                    result = roleRepository.Update(roleVM.Id, roleVM);
                }
                if (result)
                {
                    MessageBox.Show("Data telah Tersimpan");
                    UserControl_Loaded(sender, e);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Data tidak Tersimpan");
                    Clear();
                }
            }
        }

        private void DeleteRBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    var delete = roleRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        MessageBox.Show("Berhasil di Hapus");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }

        #endregion Role

        #region Payment
        private void PaymentGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = PaymentGrid.SelectedItem;
            try
            {
                PaymentText.Text = (PaymentGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                var get = paymentRepository.Check(PaymentText.Text);
                IdTempText.Text = get.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveOrUpdatePBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PaymentText.Text))
            {
                MessageBox.Show("Kolom Nama Payment Harus Diisi!");
            }
            else
            {
                PaymentVM paymentVM = new PaymentVM();
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    paymentVM.Name = PaymentText.Text;
                }
                else
                {
                    paymentVM.Id = Convert.ToInt32(IdTempText.Text);
                    paymentVM.Name = PaymentText.Text;
                }
                if (paymentVM.Id == 0)
                {
                    result = paymentRepository.Insert(paymentVM);
                }
                else
                {
                    result = paymentRepository.Update(paymentVM.Id, paymentVM);
                }
                if (result)
                {
                    MessageBox.Show("Data telah Tersimpan");
                    UserControl_Loaded(sender, e);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Data tidak Tersimpan");
                    Clear();
                }
            }
        }

        private void DeletePBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    var delete = paymentRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        MessageBox.Show("Berhasil di Hapus");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }
        #endregion Payment

        #region Item

        private void ItemGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = ItemGrid.SelectedItem;
            try
            {
                ItemText.Text = (ItemGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                StockText.Value = Convert.ToDouble((ItemGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                PriceText.Value = Convert.ToDouble((ItemGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                CategoryComboBox.Text = (ItemGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                var get = itemRepository.Check(ItemText.Text);
                IdTempText.Text = get.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteIBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    var delete = itemRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        MessageBox.Show("Berhasil di Hapus");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }

        private void SaveOrUpdateIBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ItemText.Text))
            {
                MessageBox.Show("Kolom Nama Barang Harus Diisi!");
            }
            else if (string.IsNullOrWhiteSpace(PriceText.Value.ToString()))
            {
                MessageBox.Show("Kolom Harga Barang Harus Diisi!");
            }
            else if (string.IsNullOrWhiteSpace(StockText.Value.ToString()))
            {
                MessageBox.Show("Kolom Stok Barang Harus Diisi!");
            }
            else if (Convert.ToInt16(CategoryComboBox.SelectedValue) == 0)
            {
                MessageBox.Show("Kolom Kategori Barang Harus Diisi!");
            }
            else
            {
                ItemVM itemVM = new ItemVM();
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    itemVM.Name = ItemText.Text;
                    itemVM.Price = Convert.ToDouble(PriceText.Value);
                    itemVM.Stock = Convert.ToDouble(StockText.Value);
                    itemVM.Category = Convert.ToInt32(CategoryComboBox.SelectedValue);
                }
                else
                {
                    itemVM.Id = Convert.ToInt32(IdTempText.Text);
                    itemVM.Name = ItemText.Text;
                    itemVM.Price = Convert.ToDouble(PriceText.Value);
                    itemVM.Stock = Convert.ToDouble(StockText.Value);
                    itemVM.Category = Convert.ToInt32(CategoryComboBox.SelectedValue);
                }
                if (itemVM.Id == 0)
                {
                    result = itemRepository.Insert(itemVM);
                }
                else
                {
                    result = itemRepository.Update(itemVM.Id, itemVM);
                }
                if (result)
                {
                    MessageBox.Show("Data telah Tersimpan");
                    UserControl_Loaded(sender, e);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Data tidak Tersimpan");
                    Clear();
                }
            }
        }

        #endregion Item

        #region User
        private void UserGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = UserGrid.SelectedItem;
            try
            {
                FirstNameText.Text = (UserGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                LastNameText.Text = (UserGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                EmailText.Text = (UserGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                var get = userRepository.Check(EmailText.Text);
                IdTempText.Text = get.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveOrUpdateUBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameText.Text))
            {
                MessageBox.Show("Nama Depan harus diisi !");
            }
            else if (string.IsNullOrWhiteSpace(LastNameText.Text))
            {
                MessageBox.Show("Nama Belakang harus diisi !");
            }
            else
            {
                UserVM userVM = null;
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    userVM = new UserVM()
                    {
                        FirstName = FirstNameText.Text,
                        LastName = LastNameText.Text,
                        Email = EmailText.Text
                    };
                }
                else
                {
                    userVM = new UserVM()
                    {
                        Id = Convert.ToInt32(IdTempText.Text),
                        FirstName = FirstNameText.Text,
                        LastName = LastNameText.Text,
                        Email = EmailText.Text
                    };
                }
                if (userVM.Id == 0)
                {
                    var push = userRepository.Insert(userVM);
                    if (push)
                    {
                        MessageBox.Show("Data telah tersimpan");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal tersimpan");
                        Clear();
                    }
                }
                else
                {
                    var pull = userRepository.Update(userVM.Id, userVM);
                    if (pull)
                    {
                        MessageBox.Show("Data telah tersimpan");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Data gagal tersimpan");
                        Clear();
                    }
                }
            }
        }

        private void DeleteUBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    var delete = userRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        MessageBox.Show("Berhasil di Hapus");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }
        #endregion User

        #region RoleUser

        private void RoleUserGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            object item = RoleUserGrid.SelectedItem;
            try
            {
                UserComboBox.Text = (RoleUserGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                RoleComboBox.Text = (RoleUserGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                var get = roleUserRepository.Check(Convert.ToInt32(UserComboBox.SelectedValue), Convert.ToInt32(RoleComboBox.SelectedValue));
                IdTempText.Text = get.Id.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteURBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Konfirmasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(IdTempText.Text))
                {
                    MessageBox.Show("Id is null");
                }
                else
                {
                    MyContext myContext = new MyContext();
                    var getUser = myContext.RoleUsers.Include("User").SingleOrDefault(x => x.Id.Equals(IdTempText.Text.ToString()));
                    var delete = roleUserRepository.Delete(Convert.ToInt32(IdTempText.Text));
                    if (delete)
                    {
                        var getAccount = myContext.Accounts.Find(getUser.User.Email);
                        var deleteAccount = myContext.Accounts.Remove(getAccount);
                        var result = myContext.SaveChanges();
                        if (result > 0)
                        {
                            MessageBox.Show("Berhasil di Hapus");
                            UserControl_Loaded(sender, e);
                            Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Gagal di Hapus");
                        Clear();
                    }
                }
            }
        }

        private void SaveOrUpdateURBTN_Click(object sender, RoutedEventArgs e)
        {
            int user = Convert.ToInt32(UserComboBox.SelectedValue);
            int role = Convert.ToInt32(RoleComboBox.SelectedValue);
            var roleUser = new RoleUser() { User_Id = user, Role_Id = role };
            var push = roleUserRepository.Insert(roleUser);
            if (push)
            {
                var get = userRepository.GetbyId(user);
                if(get != null)
                {
                    var getAccount = accountRepository.Get(get.Email);
                    if(getAccount != null)
                    {
                        MessageBox.Show("Data berhasil tersimpan, hak akses sudah ditambahkan");
                        UserControl_Loaded(sender, e);
                        Clear();
                    }
                    else
                    {
                        string password = "V10l19h7";
                        var accountVM = new AccountVM() { Id = get.Email, Password = password };
                        var pushAccount = accountRepository.Insert(accountVM);
                        if (pushAccount)
                        {
                            SendEmail(get.Email, password);
                            MessageBox.Show("Data berhasil tersimpan, silahkan cek email penerima");
                            UserControl_Loaded(sender, e);
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Data akun gagal tersimpan");
                            Clear();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data berhasil tersimpan, hak akses sudah ditambahkan");
                    UserControl_Loaded(sender, e);
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Data gagal tersimpan");
                Clear();
            }
        }

        #endregion RoleUser

        #region Clearance 

        private void Clear()
        {
            // TextBox
            IdTempText.Text = "";
            TypeTextT.Text = "";
            CategoryText.Text = "";
            RoleText.Text = "";
            PaymentText.Text = "";
            ItemText.Text = "";
            StockText.Value = 0;
            PriceText.Value = 0;
            FirstNameText.Text = "";
            LastNameText.Text = "";
            EmailText.Text = "";

            // ComboBox
            TypeComboBox.Text = "Pilih Tipe";
            CategoryComboBox.Text = "Pilih Kategori";
            UserComboBox.Text = "Pilih Karyawan";
            RoleComboBox.Text = "Pilih Jabatan";
        }

        #endregion Clearance

        private void ClearanceBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        public void SendEmail(string emailto, string password)
        {
            string FilePath = @"EmailTemplate\EmailSendPassword.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("[EMAIL]", emailto.Trim());
            MailText = MailText.Replace("[PASSWORD]", password.Trim());

            networkCredential = new NetworkCredential("violightbeauty@gmail.com", "dimanadia88");
            smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = Convert.ToInt32("587");
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = networkCredential;
            smtpClient.UseDefaultCredentials = true;
            mailMessage = new MailMessage { From = new MailAddress("violightbeauty@gmail.com", "Violight Admin", Encoding.UTF8) };
            mailMessage.To.Add(new MailAddress(emailto));
            mailMessage.Subject = "Notification Password";
            mailMessage.Body = MailText;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending";
            smtpClient.SendAsync(mailMessage, userstate);
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send canceled.", e.UserState), "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public string getId(int length)
        {
            string id = string.Empty;
            string random = generateRandomID(length);
            while (isUserExistById(random) == true)
            {
                random = generateRandomID(length);
            }
            id = random;
            return id;
        }

        public bool isUserExistById(string id)
        {
            bool status = false;
            var get = userRepository.GetbyId(Convert.ToInt64(id));
            if (get != null)
            {
                status = true;
            }
            return status;
        }

        private string generateRandomID(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
    }
}
