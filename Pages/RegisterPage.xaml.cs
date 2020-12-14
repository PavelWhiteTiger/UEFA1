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
using UEFA.Windows;

namespace UEFA.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public MainWindow main;
        public RegisterPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void RegButton(object sender, RoutedEventArgs e)
        {
            if (LoginBT.Text.ToLower() =="Admin".ToLower() &&  passBox.Password == "Admin")
            {
                new MenuWindow().Show();
                main.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль не верный");
            }
        }
    }
}
