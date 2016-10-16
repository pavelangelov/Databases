using System;
using System.Xml;
using Xml_Processing.Models;

namespace Xml_Processing
{
    public class Startup
    {
        public static void Main()
        {
            var url = "../../XmlDocs/catalog.xml";
            XmlDocument doc = new XmlDocument();
            var domParser = new XmlDomParser();
            var staxParser = new XmlStaxParser();
            var printer = new ConsoleLogger();

            // Task 2. extracts all different artists
            doc.Load(url);
            var catalog = doc.DocumentElement;
            var artists = domParser.GetAllUniqArtists(catalog);
            printer.Print("Task 2.");
            printer.PrintDictonary(artists, "albums");

            // Task 3. extracts all different artists using XPath
            var allArtists = domParser.GetAllUniqArtistsWithXPath(doc);
            printer.Print("Task 3.");
            printer.PrintStringCollection(allArtists);

            // Task 4. delete from catalog.xml all albums having price > 30.2
            decimal maxPrice = 30.2m;
            printer.Print("Task 4.");
            domParser.RemoveAlbumByPrice(catalog, maxPrice);
            // Task 4. Rewrite the same using XDocument and LINQ query.
            domParser.RemoveAlbumByPriceUsingXDocument(url, maxPrice);

            // Task 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.
            printer.Print("Task 5.");
            printer.Print(staxParser.ExtractAllSongsNames(url));

            /* Task 7. Write a program, which creates new XML document,
             *  which contains data from person-info.txt in structured XML format. */
            domParser.CreateXmlFromTextFile();
        }
    }
}
