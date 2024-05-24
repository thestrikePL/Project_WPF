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
using System;
using System.Windows;
namespace Project_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy UpdateNoteWindow.xaml
    /// </summary>
    public partial class UpdateNoteWindow : Window
    {
        public UpdateNoteWindow()
        {
            InitializeComponent();
        }
    }
}


namespace Project_WPF
{
    public partial class UpdateNoteWindow : Window
    {
        private readonly NoteDto _note;

        public UpdateNoteWindow(NoteDto note)
        {
            InitializeComponent();
            _note = note;
            TitleTextBox.Text = note.Title;
            ContentTextBox.Text = note.Content;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            _note.Title = TitleTextBox.Text;
            _note.Content = ContentTextBox.Text;
            _note.ModificationDate = DateTime.Now;

            // Implementacja logiki aktualizacji notatki w bazie danych

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
