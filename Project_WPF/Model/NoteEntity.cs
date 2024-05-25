
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ID, Title, Content, Category, CreationDate, ModificationDate

namespace Project_WPF.Model
{
    public class NoteEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

        public NoteEntity(int id, string title, string content, string category, DateTime creationDate, DateTime modificationDate)
        {
            Id = id;
            Title = title;
            Content = content;
            Category = category;
            ModificationDate = creationDate;
            ModificationDate = modificationDate;
        }

    }
}
