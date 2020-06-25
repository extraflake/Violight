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
using Violigth.Client;
using Violigth.Data.Context;

namespace Violigth
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void RequestBTN_Click(object sender, RoutedEventArgs e)
        {
            MyContext myContext = new MyContext();
            var check = myContext.Accounts.Find(UsernameText.Text);
            if (check != null)
            {
                Master master = new Master();
                string myPassword = "V10l19h7";
                string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
                check.Password = myHash;
                myContext.Entry(check).State = EntityState.Modified;
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    master.SendEmail(check.Id, check.Password);
                    MessageBox.Show("Password sudah direset ke awal");
                    UsernameText.Text = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password tidak direset");
                    UsernameText.Text = "";
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Email tidak ditemukan");
                UsernameText.Text = "";
            }
        }
    }
}
