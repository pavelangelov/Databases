using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SqlServerConnections.Models
{
    public class SqlServerConnection
    {
        public readonly string connectionString;

        public SqlServerConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ExtractNumberOfRows(string tableName)
        {
            var result = String.Empty;
            var connection = CreateNewConnection();

            connection.Open();
            using (connection)
            {
                var sqlCommand = $"SELECT COUNT(*) AS [NumberOfRows] FROM {tableName}";
                var command = new SqlCommand(sqlCommand, connection);

                var reader = command.ExecuteReader();
                reader.Read();

                var numberOfRows = reader["NumberOfRows"];
                result = $"{tableName} table has {numberOfRows} rows.";
            }

            return result;
        }

        public string GetFullInfoFromTable(string tableName, IEnumerable<string> columnNames)
        {
            var result = new StringBuilder();
            var connection = CreateNewConnection();

            connection.Open();
            using (connection)
            {
                var joinedColNames = string.Join(", ", columnNames);
                var commandString = $"SELECT {joinedColNames} FROM {tableName}";
                var command = new SqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var line = new StringBuilder();
                    foreach (var columnName in columnNames)
                    {
                        line.AppendLine($"{columnName}: {reader[columnName]}");
                    }
                    result.AppendLine(line.ToString());
                }
            }

            return result.ToString();
        }

        public string ExtractJoinedTables()
        {
            var result = new StringBuilder();
            var values = new Dictionary<string, string>();
            var connection = CreateNewConnection();

            connection.Open();
            using (connection)
            {
                var commandString = "SELECT c.CategoryName, p.ProductName from Categories c" +
                                    "    JOIN Products p" +
                                    "    ON p.CategoryID = c.CategoryID";
                var command = new SqlCommand(commandString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var categoryName = reader["CategoryName"].ToString();
                    var productName = reader["ProductName"].ToString();
                    if (values.ContainsKey(categoryName))
                    {
                        values[categoryName] += "\r\n" + productName;
                    }
                    else
                    {
                        values.Add(categoryName, productName);
                    }
                }
            }

            foreach (var value in values)
            {
                result.AppendLine(new string('-', 60));
                result.AppendLine($"Category Name: {value.Key}");
                result.AppendLine($"         Products: \r\n{value.Value}");
            }

            return result.ToString();
        }

        private SqlConnection CreateNewConnection()
        {
            var connection = new SqlConnection(this.connectionString);

            return connection;
        }
    }
}
