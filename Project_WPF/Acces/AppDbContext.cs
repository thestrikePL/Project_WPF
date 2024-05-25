using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_WPF.Dto;

namespace Project_WPF.Access
{
    public class AppDbContext
    {
        private static readonly string DB_NAME = "Project_WPF";

        private readonly SqlConnection _sqlConnection;

        public AppDbContext(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlConnection.Open();
            InitDatabase();
        }

        private void InitDatabase()
        {
            CreateDatabaseIfNotExist();
            CreateTableIfNotExist();
        }

        public void CreateNewNote(NoteDto noteDto)
        {
            var insertCommand = "INSERT INTO Notes VALUES(@Title, @Content, @Category, @CreationDate, @ModificationDate);";
            _sqlConnection.Execute(insertCommand, noteDto);
        }

        public void DeleteNote(NoteDto noteDto)
        {
            var deleteCommand = "DELETE FROM Notes WHERE id = @Id;";
            _sqlConnection.Execute(deleteCommand, noteDto);
        }

        public void UpdateNote(NoteDto noteDto)
        {
            var updateCommand = "UPDATE Notes SET title = @Title, content = @Content, category = @Category, modificationDate = @ModificationDate;";
            _sqlConnection.Execute(updateCommand, noteDto);
        }

        public void ReadNote(NoteDto noteDto)
        {
            var readCommand = "SELECT * FROM Notes WHERE id = @Id";
            _sqlConnection.Execute(readCommand, noteDto);
        }

        public IEnumerable<T> GetFromDatabase<T>(string query)
        {
            return _sqlConnection.Query<T>(query);
        }

        private void CreateDatabaseIfNotExist()
        {
            var command = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '" + DB_NAME + "') BEGIN CREATE DATABASE " + DB_NAME + "; END;";
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = _sqlConnection;
            sqlCommand.ExecuteNonQuery();
            ChangeDatabase();
        }

        private void ChangeDatabase()
        {
            _sqlConnection.ChangeDatabase(DB_NAME);
        }

        private void CreateTableIfNotExist()
        {
            var command = """
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Notes' AND type = 'U')
                BEGIN
                    CREATE TABLE Notes(
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Title NVARCHAR(255),
                        Content NVARCHAR(MAX),
                        Category NVARCHAR(255),
                        CreationDate DATE,
                        ModificationDate DATE
                    );
                END;
                """;
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = _sqlConnection;
            sqlCommand.ExecuteNonQuery();
        }
    }
}