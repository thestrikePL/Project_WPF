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
using System.Windows.Controls;
using System.Windows.Media;

namespace Project_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy CreateNewNoteWindow.xaml
    /// </summary>
    public partial class CreateNewNoteWindow : Window
    {
        public CreateNewNoteWindow()
        {
            InitializeComponent();
        }
    }
}


namespace Project_WPF
{
    public partial class CreateNewNoteWindow : Window
    {
        private readonly NoteService _noteService;

        public event EventHandler<NoteDto> NoteCreated;

        public CreateNewNoteWindow(NoteService noteService)
        {
            InitializeComponent();
            _noteService = noteService;
            AddPlaceholderText(TitleTextBox, "Tytuł");
            AddPlaceholderText(ContentTextBox, "Treść");
        }

        private void AddPlaceholderText(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.Foreground = Brushes.Gray;
        }

        private void RemovePlaceholderText(TextBox textBox)
        {
            textBox.Text = string.Empty;
            textBox.Foreground = Brushes.Black;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                RemovePlaceholderText(textBox);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                AddPlaceholderText(textBox, textBox == TitleTextBox ? "Tytuł" : "Treść");
            }
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            var note = new NoteDto
            {
                Title = TitleTextBox.Text == "Tytuł" ? string.Empty : TitleTextBox.Text,
                Content = ContentTextBox.Text == "Treść" ? string.Empty : ContentTextBox.Text,
                Category = "Default",
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };

            _noteService.AddNote(note);
            NoteCreated?.Invoke(this, note);
            this.Close();
        }
    }
}
