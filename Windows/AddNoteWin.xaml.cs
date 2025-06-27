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
using Gubaeva.DB;

namespace Gubaeva.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNoteWin.xaml
    /// </summary>
    public partial class AddNoteWin : Window
    {
        public List<Notes> notes { get; set; }
        public AddNoteWin()
        {
            InitializeComponent();
            LoadCategories();
            LoadUsers();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitle.Text=="")
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            var selectedCategories = cmbCategories.SelectedItem as Categories;
            var selectedUser = cmbUsers.SelectedItem as Users;

            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            var newNote = new Notes
            {
                title = tbTitle.Text,
                category_id = selectedCategories.id,
                content = tbContent.Text,
                is_delete = false,
                user_id = selectedUser.id
            };

            DBClass.connect.Notes.Add(newNote);
            try
            {
                DBClass.connect.SaveChanges();
                MessageBox.Show("Успешное добавление!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так :( \n {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void LoadCategories()
        {
            cmbCategories.ItemsSource = DBClass.connect.Categories.ToList();
            cmbCategories.DisplayMemberPath = "name";
        }
        public void LoadUsers()
        {
            cmbUsers.ItemsSource = DBClass.connect.Users.ToList();
            cmbUsers.DisplayMemberPath = "username";
        }
        }
}
