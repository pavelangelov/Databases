using Processing_JSON.Contracts;
using System;

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
