using System;

using Processing_JSON.Contracts;

namespace Processing_JSON.Models
{
    public class ConsoleLogger : ILogger
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
