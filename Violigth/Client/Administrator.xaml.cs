using System;
using System.Collections.Generic;
using System.Configuration;
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
using Violigth.Data.ViewModel;
using Violigth.Properties;
using Violigth.ViewModels;

namespace Violigth.Client
{
    /// <summary>
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        MyContext myContext = new MyContext();
        string name = "";

        public Administrator()
        {
            InitializeComponent();
        }

        public Administrator(string lastName, string role, string password)
        {
            InitializeComponent();
            AccountText.Text = lastName;
            if (!role.Equals("Admin"))
            {
                Master.Visibility = Visibility.Visible;
            }
            if (password.Equals("V10l19h7"))
            {
                MessageBox.Show("Demi keamanan akun anda, Segera mengganti password di panel Profile");
            }
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Apa anda yakin?", "Permohonan Keluar dari Aplikasi", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)  // error is here
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void GridAdministrator_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void TransactionBTN_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SellVM();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProfileVM();
            //Profile profile = new Profile(AccountText.Text);
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings.Add("userID", name);
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["userID"].Value = AccountText.Text;
            configuration.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void ReportBTN_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportVM();
        }

        private void Master_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MasterVM();
        }
    }
}
