
using Project_WPF.Model;
using Project_WPF.Service;
using Project_WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace Project_WPF
{

    /// <summary>
    /// Interaction logic for ReadNoteWindow.xaml
    /// </summary>


    public partial class ReadNoteWindow : Window
    {
        private readonly NoteService _noteService;
        public ReadNoteWindow(NoteEntity note)
        {
            InitializeComponent();
            DataContext = note;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateNoteWindow updateNewNoteWindow = new UpdateNoteWindow();
            updateNewNoteWindow.Activate();
            updateNewNoteWindow.Show();
            updateNewNoteWindow.Closing += UpdateNoteEventHandler;
        }

        private void UpdateNoteEventHandler(object? sender, CancelEventArgs e)
        {
            UpdateNoteWindow eventSender = (UpdateNoteWindow)sender;
            _noteService.UpdateNote(new Dto.NoteDto(eventSender.UpdateNoteTitle,
                eventSender.UpdateNoteCategory,
                eventSender.UpdateNoteContent,
                eventSender.UpdateCreationDate,
                eventSender.UpdateModificationDate));
            this.Close();
        }
    }
}
