using System;
using System.Text;

using MySql.Data.MySqlClient;

namespace MySqlServerConnections.Models
{
    public class MySqlServerConnection
    {
        private string connectionString;

        public MySqlServerConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string AddBook(string title, string author, DateTime? publishDate = null, string ssbn = null)
        {
            var connection = this.CreateConnection();
            connection.Open();
            using (connection)
            {
                var commandStr = "INSERT INTO books (title, author, publish_date, ssbn)" +
                                   "VALUES(@title, @author, @publishDate, @ssbn)";
                var command = new MySqlCommand(commandStr, connection);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@publishDate", publishDate);
                command.Parameters.AddWithValue("@ssbn", ssbn);

                var rowsAffected = command.ExecuteNonQuery();

                return $"{rowsAffected} affected!";
            }
        }

        public string ListAllBooks()
        {
            var result = new StringBuilder();
            var connection = this.CreateConnection();
            connection.Open();
            using (connection)
            {
                var commandStr = "SELECT * FROM books";
                var command = new MySqlCommand(commandStr, connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var title = reader["title"];
                    var author = reader["author"];
                    result.AppendLine($"Title: {title}, Author: {author}");
                }
            }

            return result.ToString();
        }

        public string GetBookInfo(string bookTitle)
        {
            var result = new StringBuilder();
            var connection = this.CreateConnection();
            connection.Open();
            using (connection)
            {
                var commandStr = $"SELECT * FROM books WHERE books.title = '{bookTitle}'";
                var command = new MySqlCommand(commandStr, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var fieldName = reader.GetName(i);
                        var value = reader[fieldName];
                        result.AppendLine($"{fieldName} -> {value}");
                    }
                }

                return result.ToString();
            }
        }

        private MySqlConnection CreateConnection()
        {
            var connection = new MySqlConnection(this.connectionString);

            return connection;
        }
    }
}
