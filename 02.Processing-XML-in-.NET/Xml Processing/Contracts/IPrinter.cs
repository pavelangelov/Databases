using System.Collections.Generic;

namespace Xml_Processing.Contracts
{
    public interface IPrinter
    {
        void PrintStringCollection(ICollection<string> collection);

        void PrintDictonary<Tkey, Tvalue>(IDictionary<Tkey, Tvalue> dictonary, string valueName);
    }
}
