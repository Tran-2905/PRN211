using ResearchProjectManagement_BLL.Service;
using ResearchProjectManagement_SE180242_DAL.Entity;
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

namespace ResearchProjectManagement_SE180242
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserAccountService userAccountService;
        public LoginWindow()
        {
            InitializeComponent();
            userAccountService = new UserAccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = txEmail.Text;
            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            UserAccount account = this.userAccountService.ValidateCredentials(email, password);
            if (account != null)
            {
                if (account.Role == 4)
                {
                    MessageBox.Show("You are not authorized to access this application.", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
