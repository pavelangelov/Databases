using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    }
}
