using System.Collections.Generic;
using System.Xml;

namespace Xml_Processing.Models
{
    public class XmlDomParser
    {
        private XmlDocument xmlDoc = new XmlDocument();

        public IDictionary<string, int> GetAllUniqArtists(string url)
        {
            xmlDoc.Load(url);
            var root = xmlDoc.DocumentElement;
            var result = GetAllArtists(root);

            //foreach (XmlNode node in root.ChildNodes)
            //{
            //    var artist = node["artist"].InnerText;
            //    if (result.ContainsKey(artist))
            //    {
            //        result[artist] += 1;
            //    }
            //    else
            //    {
            //        result[artist] = 1;
            //    }
            //}

            return result;
        }

        public ICollection<string> GetAllUniqArtistsWithXPath(string url)
        {
            var result = new HashSet<string>();
            xmlDoc.Load(url);
            string query = "descendant::al:album/al:artist ";
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("al", "urn:catalog-homework");

            XmlNodeList allArtists = xmlDoc.SelectNodes(query, nsmgr);
            foreach (XmlNode item in allArtists)
            {
                result.Add(item.InnerText);
            }

            return result;
        }

        public IDictionary<string, int> RemoveAlbumByPrice(string url, decimal maxPrice)
        {
            xmlDoc.Load(url);
            var root = xmlDoc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                decimal price = decimal.Parse(node["price"].InnerText);
                if (maxPrice < price)
                {
                    root.RemoveChild(node);
                }
            }

            var artists = GetAllArtists(root);

            return artists;
        }

        private IDictionary<string, int> GetAllArtists(XmlElement root)
        {
            var result = new Dictionary<string, int>();

            foreach (XmlNode node in root.ChildNodes)
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
    }
}
