using System;

using SqlServerConnections.Contracts;

namespace SqlServerConnections.Models
{
    public class ConsoleLogger : ILogger
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
