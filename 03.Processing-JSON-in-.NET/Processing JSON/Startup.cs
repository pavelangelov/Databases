using System;
using System.IO;
using System.Text;

using Processing_JSON.Models;

namespace Processing_JSON
{
    public class Startup
    {
        public const string HtmlFileName = "index.html";

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var logger = new ConsoleLogger();
            var jsonParser = new JsonParser();

            var rssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var xmlRss = "../../DownloadedFiles/telerik-rss.xml";
            FileDownloader.DownloadRss(rssUrl, xmlRss);

            // Extract all videos titles
            var videoTitles = jsonParser.ExtractAllVideoTitles(xmlRss);
            logger.Print(string.Join(Environment.NewLine, videoTitles));

            // Create POCO`s from videos
            var videoObjects = jsonParser.ExtractVideoObjects(xmlRss);
            logger.Print(string.Join(Environment.NewLine, videoObjects));
            
            // Create HTML file with all videos
            using (StreamWriter wr = new StreamWriter($"../../{HtmlFileName}", false, Encoding.UTF8))
            {
                HtmlCreator.GenerateHtml(videoObjects, wr);
                logger.Print($"File {HtmlFileName} was created successfully!");
            }
        }
    }
}
