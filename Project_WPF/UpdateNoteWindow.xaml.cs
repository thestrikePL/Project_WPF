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
    /// Interaction logic for UpdateNoteWindow.xaml
    /// </summary>
    public partial class UpdateNoteWindow : Window
    {
        public string UpdateNoteTitle { get; set; }
        public string UpdateNoteCategory { get; set; }
        public string UpdateNoteContent { get; set; }
        public string UpdateCreationDate { get; set; }
        public string UpdateModificationDate { get; set; }
        public UpdateNoteWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string sqlTimeAsString = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");

            UpdateNoteTitle = UpdateNoteTitle_TextBox.Text;
            UpdateNoteCategory = UpdateNoteCategory_TextBox.Text;
            UpdateNoteContent = UpdateNoteContent_TextBox.Text;
            UpdateModificationDate = sqlTimeAsString;
            UpdateCreationDate = UpdateCreationDate;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}