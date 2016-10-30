using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExelOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Fix external table error!
            var connectionString = @"Provider=Microsoft.Jet.OLEDB.12.0;Data Source=../../ExelFiles/Results.xlsx;" +
                                      @"Extended Properties=Excel 12.0;";
            var oleDb = new OleDbConnection(connectionString);

            oleDb.Open();
            using (oleDb)
            {
                OleDbCommand command = new OleDbCommand("select * from [Name$]", oleDb);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row1Col0 = dr[0];
                        Console.WriteLine(row1Col0);
                    }
                }
            }
        }
    }
}
