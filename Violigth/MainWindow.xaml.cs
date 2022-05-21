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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Violigth.Client;
using Violigth.Data.Context;
using WhatsAppApi;

namespace Violigth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext myContext = new MyContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            bool status = false;
            var getUser = myContext.Users.SingleOrDefault(x => x.Email.Equals(UsernameText.Text));
            var getAccount = myContext.Accounts.SingleOrDefault(x => x.Id.Equals(getUser.Id.ToString()));
            var getUserRole = myContext.RoleUsers.Include("User").Include("Role").Where(x => x.User_Id.Equals(getUser.Id)).ToList();
            if (BCrypt.Net.BCrypt.Verify(PasswordText.Password, getAccount.Password))
            {
                string role = "";
                foreach (var item in getUserRole)
                {
                    if (item.Role.Name.Equals("Admin"))
                    {
                        role = item.Role.Name;
                        status = true;
                    }
                }
                if (status)
                {
                    Administrator call = new Administrator(getUser.LastName, role, PasswordText.Password);
                    call.Show();
                    this.Hide();
                }
                else
                {
                    Administrator call = new Administrator(getUser.LastName, role, PasswordText.Password);
                    call.Show();
                    this.Hide();
                }
            }
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
        }
    }
}
