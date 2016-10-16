using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xml_Processing.Contracts;

namespace Xml_Processing.Models
{
    public class ConsoleLogger : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void PrintDictonary<Tkey, Tvalue>(IDictionary<Tkey, Tvalue> dictonary, string valueName)
        {
            foreach (var key in dictonary)
            {
                Console.WriteLine($"{key.Key} => {key.Value} {valueName}.");
            }
        }

        public void PrintStringCollection(ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
