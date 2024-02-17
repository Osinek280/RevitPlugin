using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace RevitPlugin.xamls
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void SignUp_Clicked(object sender, MouseButtonEventArgs e)
        {
            Process.Start(Config.SignUpUrl);
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TaskDialog.Show("df", "Please enter both email and password.");
                return;
            }

            if (email == "user@example.com" && password == "password")
            {
                TaskDialog.Show("df", "Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }
    }
}
