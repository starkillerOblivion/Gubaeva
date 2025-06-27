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
using Gubaeva.Pages;
using Gubaeva.DB;

namespace Gubaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisPage.xaml
    /// </summary>
    public partial class RegisPage : Page
    {
        public RegisPage()
        {
            InitializeComponent();
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            if (tbUserName.Text==""||passwordBox.Password==null||confirmPasswordBox.Password == null)
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            else
            {
                string username = tbUserName.Text;
                string password = passwordBox.Password;
                string confirmPassword = confirmPasswordBox.Password;

                if (password != confirmPassword)
                {
                    tbMessage.Text = "Пароли не совпадают.";
                    return;
                }
                var newUser = new Users
                {
                    username = tbUserName.Text,
                    password_hash = passwordBox.Password
                };
                DBClass.connect.Users.Add(newUser);
                try
                {
                    DBClass.connect.SaveChanges();
                    tbMessage.Text = "Регистрация успешна!";
                    tbMessage.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                    ClearFields();
                    NavigationService.Navigate(new AuthorPage());
                }
                catch(Exception ex)
                {
                    tbMessage.Text = "Ошибка регистрации. Что-то пошло не так :( \n {ex.Message}";
                    tbMessage.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
                }
            }
        }

        private void ClearFields()
        {
            tbUserName.Clear();
            passwordBox.Clear();
            confirmPasswordBox.Clear();
            tbMessage.Text = string.Empty;
        }
    }
}
