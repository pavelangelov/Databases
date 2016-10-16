﻿using System;
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
            var printer = new ConsoleLogger();

            doc.Load(url);
            var catalog = doc.DocumentElement;
            var artists = domParser.GetAllUniqArtists(catalog);

            printer.PrintDictonary(artists, "albums");

            var allArtists = domParser.GetAllUniqArtistsWithXPath(doc);
            printer.PrintStringCollection(allArtists);

            decimal maxPrice = 30.2m;
            Console.WriteLine($"Artists after removing these with price greater than ${maxPrice}");
            domParser.RemoveAlbumByPrice(catalog, maxPrice);

            domParser.RemoveAlbumByPriceUsingXDocument(url, maxPrice);

            domParser.CreateXmlFromTextFile();
        }
    }
}
