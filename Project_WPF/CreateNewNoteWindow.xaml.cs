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

namespace Project_WPF
{
    /// <summary>
    /// Interaction logic for CreateNewNoteWindow.xaml
    /// </summary>
    public partial class CreateNewNoteWindow : Window
    {
        public string NewNoteTitle { get; set; }
        public string NewNoteCategory { get; set; }
        public string NewNoteContent { get; set; }
        public string NewCreationDate { get; set; }
        public string NewModificationDate { get; set; }
        public bool IsNoteCreateRequest { get; set; } = false;
        public CreateNewNoteWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string sqlTimeAsString = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            IsNoteCreateRequest = true;
            NewNoteTitle = NewNoteTitle_TextBox.Text;
            NewNoteCategory = NewNoteCategory_TextBox.Text;
            NewNoteContent = NewNoteContent_TextBox.Text;
            NewModificationDate = sqlTimeAsString;
            NewCreationDate = sqlTimeAsString;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}