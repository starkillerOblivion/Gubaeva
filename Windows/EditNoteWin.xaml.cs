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
    /// Логика взаимодействия для EditNoteWin.xaml
    /// </summary>
    public partial class EditNoteWin : Window
    {
        public static Notes notes = new Notes();
        public static List<Categories> categories { get; set; }
        public EditNoteWin(Notes noteEdit)
        {
            InitializeComponent();
            categories = new List<Categories>(DBClass.connect.Categories.ToList());
            notes = noteEdit;
            tbTitle.Text = notes.title;
            tbContent.Text = notes.content;
            cmbCategories.SelectedItem = categories.FirstOrDefault(c => c.id == notes.Categories.id);
            this.DataContext = this;
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            notes.title = tbTitle.Text;
            notes.content = tbContent.Text;
            notes.category_id = (cmbCategories.SelectedItem as Categories).id;
            try
            {
                DBClass.connect.SaveChanges();
                MessageBox.Show("Успешное обновление данных!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так :( \n {ex.Message}", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
