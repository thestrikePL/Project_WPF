using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_WPF.Dto
{
    public class NoteDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string CreationDate { get; set; }
        public string ModificationDate { get; set; }

        public NoteDto(string title, string content, string category, string creationDate, string modificationDate)
        {
            Title = title;
            Content = content;
            Category = category;
            ModificationDate = creationDate;
            ModificationDate = modificationDate;
        }
    }
}