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
using System.Windows;

namespace Project_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy ReadNoteWindow.xaml
    /// </summary>
    public partial class ReadNoteWindow : Window
    {
        public ReadNoteWindow()
        {
            InitializeComponent();
        }
    }
}


namespace Project_WPF
{
    public partial class ReadNoteWindow : Window
    {
        public ReadNoteWindow(NoteDto note)
        {
            InitializeComponent();
            TitleTextBox.Text = note.Title;
            ContentTextBox.Text = note.Content;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
