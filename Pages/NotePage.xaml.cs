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
using Gubaeva.Windows;

namespace Gubaeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        public List<Notes> notes { get; set; }
        public List<Categories> categories { get; set; }
        public NotePage(Users users)
        {
            InitializeComponent();
            notes = new List<Notes>(DBClass.connect.Notes.Where(c => c.is_delete != true));
            categories = new List<Categories>(DBClass.connect.Categories).ToList();
            categories.Insert(0, new Categories() { id = -1, name = "All" });
            this.DataContext = this;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var noteEdit = (sender as Button).DataContext as Notes;
            EditNoteWin edit = new EditNoteWin(noteEdit);
            edit.Show();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            notes = new List<Notes>(DBClass.connect.Notes.Where(c => c.is_delete != true));
            lvNote.ItemsSource = notes;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteNote = (sender as Button).DataContext as Notes;
            var deleteNoteMessage = MessageBox.Show($"Вы уверены, что хотите удалить {deleteNote.title}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (deleteNoteMessage == MessageBoxResult.Yes)
            {
                deleteNote.is_delete = true;
                DBClass.connect.SaveChanges();
                notes = new List<Notes>(DBClass.connect.Notes.Where(c => c.is_delete != true)).ToList();
                lvNote.ItemsSource = notes;
            }
        }
        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategories = cmbCategory.SelectedItem as Categories;
            if (selectedCategories.id != -1)
            {
                lvNote.ItemsSource = notes.Where(c => c.category_id == selectedCategories.id).ToList();
            }
            else
            {
                lvNote.ItemsSource = notes;
            }
        }
        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            var addNoteWindow = new AddNoteWin();
            addNoteWindow.Show();
        }
    }
}
