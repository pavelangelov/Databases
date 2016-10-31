using System;

using MySqlServerConnections.Models;
using SqlServerConnections.Models;

namespace MySqlServerConnections
{
    public class Startup
    {
        public static void Main()
        {
            const string connectionString = "Server=localhost;Database=books_store;Uid=root;Pwd=yourPassword;";

            var logger = new ConsoleLogger();
            var mySqlConnection = new MySqlServerConnection(connectionString);

            // List all books
            var books = mySqlConnection.ListAllBooks();
            logger.WriteLine(books);

            // Add books to DB
            for (int i = 0; i < 5; i++)
            {
                var title = "Book title " + i;
                var author = "Author " + i;
                var date = DateTime.Now.AddDays(i);
                var ssbn = "No SSBN";

                var affectedRows = mySqlConnection.AddBook(title, author, date, ssbn);
                logger.WriteLine(affectedRows);
            }

            books = mySqlConnection.ListAllBooks();
            logger.WriteLine(books);

            // Get book info by book title
            var bookInfo = mySqlConnection.GetBookInfo("The Art of Unit Testing");
            logger.WriteLine(bookInfo);
        }
    }
}
