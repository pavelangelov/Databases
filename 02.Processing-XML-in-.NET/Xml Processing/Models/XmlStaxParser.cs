using System;
using System.Text;
using System.Xml;

namespace Xml_Processing.Models
{
    public class XmlStaxParser
    {
        public string ExtractAllSongsNames(string url)
        {
            var result = new StringBuilder("Founded songs:");
            using (XmlReader reader = XmlReader.Create(url))
            {
                while (reader.Read())
                {
                    var element = reader;
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        result.AppendLine(reader.ReadElementContentAsString());
                    }
                }
            }

            return result.ToString();
        }
    }
}
