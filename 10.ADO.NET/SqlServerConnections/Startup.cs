using SqlServerConnections.Models;

namespace SqlServerConnections
{
    public class Startup
    {
        public const string ConnectionString = "Server = .\\SQLEXPRESS; Database=Northwind;Trusted_Connection=True;";

        public static void Main()
        {
            var logger = new ConsoleLogger();
            var sqlConnection = new SqlServerConnection(ConnectionString);

            //// Task 1. Write a program that retrieves the number of rows in the Categories table.
            //var tableName = "Categories";
            //var rows = sqlConnection.ExtractNumberOfRows(tableName);
            //logger.WriteLine(rows);

            //// Task 2. Write a program that retrieves the name and description of all categories.
            //var columnNamesToExtract = new string[] { "CategoryName", "Description" };
            //var fullInfo = sqlConnection.GetFullInfoFromTable(tableName, columnNamesToExtract);
            //logger.WriteLine(fullInfo);

            // Task 3. Write a program that retrieves all product categories and the names of the products in each category.
            //var data = sqlConnection.ExtractJoinedTables();
            //logger.WriteLine(data);

            // Task 4. Write a method that adds a new product in the products table
            //sqlConnection.AddnewProduct("Tomatos", false);

            // Task 5. Write a program that retrieves the images for all categories and stores them as JPG files in the file system.
            sqlConnection.SaveLocalyAllImages();
            logger.WriteLine("Check saved in bin/Debug folder.");
        }
    }
}
