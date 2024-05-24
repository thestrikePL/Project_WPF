using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Project_WPF.Service
{
    internal class NoteService
    {
    }
}

public class NoteService
{
    private readonly string _connectionString;

    public NoteService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<NoteDto> GetAllNotes()
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            return connection.Query<NoteDto>("SELECT * FROM Notes").ToList();
        }
    }

    public void AddNote(NoteDto note)
    {
        using (var connection = new SQLiteConnection(_connectionString))
        {
            connection.Execute("INSERT INTO Notes (Title, Content, Category, CreationDate, ModificationDate) VALUES (@Title, @Content, @Category, @CreationDate, @ModificationDate)", note);
        }
    }

    // Inne metody (Update, Delete)...
}
