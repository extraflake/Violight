using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Violigth.Data.Context;

namespace Violigth.Client
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        MyContext myContext = new MyContext();

        public Profile()
        {
            InitializeComponent();
        }

        private void ChangePasswordBTN_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordActionGroup.Visibility = Visibility.Visible;
            ChangePasswordGroup.Visibility = Visibility.Visible;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string name = ConfigurationManager.AppSettings["userID"].ToString();
            var getUser = myContext.Users.SingleOrDefault(x => x.LastName.Equals(name));
            Name.Text = getUser.FirstName + " " + getUser.LastName;
            Email.Text = getUser.Email;
            JoinDate.Text = getUser.JoinDate.ToString();
        }

        private void SaveCPBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!NewPassword.Password.Equals(ReNewPassword.Password))
            {
                MessageBox.Show("Konfirmasi Password tidak sama dengan Password Baru");
            }
            else
            {
                var getUser = myContext.Users.SingleOrDefault(x => x.Email.Equals(Email.Text));
                var check = myContext.Accounts.SingleOrDefault(x => x.Id.Equals(getUser.Email));
                if (BCrypt.Net.BCrypt.Verify(OldPassword.Password, check.Password))
                {
                    string myPassword = NewPassword.Password;
                    string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                    string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
                    check.Password = myHash;
                    myContext.Entry(check).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if(result > 0)
                    {
                        MessageBox.Show("Ganti Password Berhasil");
                        NewPassword.Password = "";
                        OldPassword.Password = "";
                        ReNewPassword.Password = "";
                        ChangePasswordActionGroup.Visibility = Visibility.Hidden;
                        ChangePasswordGroup.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Ganti Password Gagal");
                    }
                }
                else
                {
                    MessageBox.Show("Password Lama salah, silahkan coba lagi");
                }
            }
        }
    }
}
