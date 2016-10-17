using Xml_Processing.Models;

namespace Xml_Processing
{
    public class Startup
    {
        public static void Main()
        {
            var separator = new string('*', 40);
            var url = "../../XmlDocs/catalog.xml";
            var domParser = new XmlDomParser();
            var staxParser = new XmlStaxParser();
            var linqXml = new LinqToXml();
            var printer = new ConsoleLogger();

            printer.Print(separator);
            printer.Print("Task 2. extracts all different artists");
            var artists = domParser.GetAllUniqArtists(url);
            printer.PrintDictonary(artists, "albums");
            printer.Print(separator);
            
            printer.Print("Task 3. extracts all different artists using XPath");
            var allArtists = domParser.GetAllUniqArtistsWithXPath(url);
            printer.PrintStringCollection(allArtists);
            printer.Print(separator);
            
            printer.Print("Task 4. delete from catalog.xml all albums having price > 30.2");
            decimal maxPrice = 30.2m;
            var artistsAfter = domParser.RemoveAlbumByPrice(url, maxPrice);
            printer.PrintDictonary(artistsAfter, "albums");
            // Task 4. Rewrite the same using XDocument and LINQ query.
            linqXml.RemoveAlbumByPriceUsingXDocument(url, maxPrice);
            printer.Print(separator);
            
            printer.Print("Task 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.");
            printer.Print(staxParser.ExtractAllSongsNames(url));
            printer.Print(separator);

            printer.Print("Task 6. Rewrite the same using XDocument and LINQ query.");
            printer.Print(linqXml.ExtractAllSongsTitles(url));
            printer.Print(separator);

            /* Task 7. Write a program, which creates new XML document,
             *  which contains data from person-info.txt in structured XML format. */
            printer.Print("Task 7. Write a program, which creates new XML document");
            var textUrl = "../../TextFiles/person-info.txt";
            printer.Print(linqXml.CreateXmlFromTextFile(textUrl).ToString());
            printer.Print(separator);

            printer.Print("Task 8. Write a program, which reads the file catalog.xml and creates the file album.xml");
            var albumsUrl = "../../XmlDocs/albums.xml";
            var resultMsg = staxParser.ExtractAlbumsInNewFile(url, albumsUrl);
            printer.Print(resultMsg);
            printer.Print(separator);

            var dirUrl = "../../";
            var dir = new System.IO.DirectoryInfo(dirUrl);
            var result = linqXml.GetDirectoryXml(dir);
            result.Save($"../../XmlDocs/{dir.Name}.xml");
        }
    }
}
