using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Xml_Processing.Models
{
    public class LinqToXml
    {
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

        public XElement CreateXmlFromTextFile(string textUrl)
        {
            XElement root = new XElement("people");
            XElement person = new XElement("person");
            var fieldNames = new string[] { "name", "address", "phone" };
            var personInfo = new List<string>();
            var startIndex = 0;
            foreach (var line in File.ReadAllLines(textUrl))
            {
                XElement field = new XElement(fieldNames[startIndex]);
                field.Add(line);
                person.Add(field);
                startIndex++;
            }

            root.Add(person);
            root.Save("../../XmlDocs/people.xml");

            return root;
        }

        public string ExtractAllSongsTitles(string url)
        {
            XNamespace ns = "urn:catalog-homework";
            var root = XDocument.Load(url).Document;
            var result = root.Descendants(ns + "title")
                            .Select(x => x.Value);

            return string.Join(Environment.NewLine, result);
        }
    }
}
