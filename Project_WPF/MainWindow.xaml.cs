using Project_WPF.Access;
using Project_WPF.Model;
using Project_WPF.Service;
using Project_WPF;
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

namespace Project_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NoteService _noteService;

        public ObservableCollection<NoteEntity> ObservableNotes { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-RAT220IN;Integrated Security=True";
            AppDbContext appDbContext = new AppDbContext(connectionString);
            ObservableNotes = new ObservableCollection<NoteEntity>();
            Notes_ListView.ItemsSource = ObservableNotes;
            _noteService = new NoteService(appDbContext);
            UpdateNotes();
        }

        private void CreateNote_Button_Click(object sender, RoutedEventArgs e)
        {
            CreateNewNoteWindow createNewNoteWindow = new CreateNewNoteWindow();
            createNewNoteWindow.Activate();
            createNewNoteWindow.Show();
            createNewNoteWindow.Closing += CreateNoteEventHandler;
        }

        private void CreateNoteEventHandler(object sender, CancelEventArgs e)
        {
            CreateNewNoteWindow eventSender = (CreateNewNoteWindow)sender;
            if (eventSender.IsNoteCreateRequest)
            {
                _noteService.CreateNote(new Dto.NoteDto(eventSender.NewNoteTitle,
                    eventSender.NewNoteCategory,
                    eventSender.NewNoteContent,
                    eventSender.NewCreationDate,
                    eventSender.NewModificationDate));
                UpdateNotes();
            }
        }

        private void UpdateNotes()
        {
            ObservableNotes.Clear();
            var existingNotes = _noteService.GetNotes();
            foreach (var note in existingNotes)
            {
                ObservableNotes.Add(note);
            }
        }

        private void Notes_ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NoteEntity selectedPerson = (NoteEntity)Notes_ListView.SelectedItem;

            ReadNoteWindow readNoteWindow = new ReadNoteWindow(selectedPerson);
            readNoteWindow.Activate();
            readNoteWindow.Show();
            readNoteWindow.Closing += ReadNoteEventHandler;
        }

        private void ReadNoteEventHandler(object sender, CancelEventArgs e)
        {
            UpdateNotes();
        }
    }
}