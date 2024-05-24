using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows;

namespace Project_WPF
{
    public partial class MainWindow : Window
    {
        private readonly NoteService _noteService;
        public ObservableCollection<NoteDto> Notes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _noteService = new NoteService("Data Source=notes.db;Version=3;");
            LoadNotes();
        }

        private void LoadNotes()
        {
            var notes = _noteService.GetAllNotes();
            Notes = new ObservableCollection<NoteDto>(notes);
            NotesList.ItemsSource = Notes;
        }

        private void CreateNewNote_Click(object sender, RoutedEventArgs e)
        {
            var createNoteWindow = new CreateNewNoteWindow(_noteService);
            createNoteWindow.NoteCreated += CreateNoteWindow_NoteCreated;
            createNoteWindow.ShowDialog();
        }

        private void CreateNoteWindow_NoteCreated(object sender, NoteDto note)
        {
            Notes.Add(note);
        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            // Logika usuwania notatki
        }

        private void EditNote_Click(object sender, RoutedEventArgs e)
        {
            // Logika edytowania notatki
        }
    }
}
