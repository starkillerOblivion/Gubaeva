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
using Gubaeva.DB;
using Gubaeva.Pages;

namespace Gubaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        public AuthorPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = DBClass.connect.Users.Where(c => c.username == tbUserName.Text && c.password_hash == passwordBox.Password).FirstOrDefault();
            if (tbUserName.Text != "" && passwordBox.Password != null)
            {
                if (user != null)
                {
                    MessageBox.Show("Успешный вход!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new NotePage(user));
                }
                else
                {
                    tbMessage.Text = "Неправильное имя пользователя или пароль.";
                }
            }
            else
            {
                tbMessage.Text = "Поля не заполнены";
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisPage());
        }
    }
}
