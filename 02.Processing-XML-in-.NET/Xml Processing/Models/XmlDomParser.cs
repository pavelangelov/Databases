using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Xml_Processing.Models
{
    public class XmlDomParser
    {
        public IDictionary<string, int> GetAllUniqArtists(XmlElement catalog)
        {
            var result = new Dictionary<string, int>();

            foreach (XmlNode node in catalog.ChildNodes)
            {
                var artist = node["artist"].InnerText;
                if (result.ContainsKey(artist))
                {
                    result[artist] += 1;
                }
                else
                {
                    result[artist] = 1;
                }
            }

            return result;
        }

        public ICollection<string> GetAllUniqArtistsWithXPath(XmlDocument element)
        {
            var result = new HashSet<string>();
            string query = "descendant::al:album/al:artist ";
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(element.NameTable);
            nsmgr.AddNamespace("al", "urn:catalog-homework");

            XmlNodeList allArtists = element.SelectNodes(query, nsmgr);
            foreach (XmlNode item in allArtists)
            {
                result.Add(item.InnerText);
            }

            return result;
        }

        public void RemoveAlbumByPrice(XmlElement element, decimal maxPrice)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                decimal price = decimal.Parse(node["price"].InnerText);
                if (maxPrice < price)
                {
                    element.RemoveChild(node);
                }
            }
        }

        public void RemoveAlbumByPriceUsingXDocument(string url, decimal maxPrice)
        {
            XNamespace ns = "urn:catalog-homework";
            var xDoc = XDocument.Load(url).Document;
            xDoc.Descendants(ns + "album")
                .Where(x => decimal.Parse(x.Element(ns + "price").Value) > maxPrice)
                .Remove();

            // This is for showing that the album is removed :)
            //xDoc.Descendants(ns + "album")
            //                .Elements(ns + "artist")
            //                .Select(x => x.Value)
            //                .ToList()
            //                .ForEach(Console.WriteLine);
        }

        public void CreateXmlFromTextFile()
        {
            XElement root = new XElement("people");
            XElement person = new XElement("person");
            var fieldNames = new string[] { "name", "address", "phone" };
            var personInfo = new List<string>();
            var url = "../../TextFiles/person-info.txt";
            var startIndex = 0;
            foreach (var line in File.ReadAllLines(url))
            {
                XElement field = new XElement(fieldNames[startIndex]);
                field.Add(line);
                person.Add(field);
                startIndex++;
            }

            root.Add(person);
            root.Save("../../XmlDocs/people.xml");
        }
    }
}
