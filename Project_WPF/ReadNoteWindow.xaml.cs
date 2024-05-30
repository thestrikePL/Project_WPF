
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

    }


}

