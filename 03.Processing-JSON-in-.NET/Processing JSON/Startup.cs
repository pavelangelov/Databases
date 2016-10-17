using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Processing_JSON.Contracts;
using Processing_JSON.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Processing_JSON
{
    public class Startup
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var logger = new ConsoleLogger();
            //var rssUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            //var webClient = new WebClient();
            var fileUrl = "../../DownloadedFiles/telerik-rss.xml";
            var xmlFile = new XmlDocument();
            xmlFile.Load(fileUrl);
            //webClient.DownloadFile(rssUrl, fileUrl);

            // Extract all videos titles
            var jsonRss = JsonConvert.SerializeXmlNode(xmlFile, Newtonsoft.Json.Formatting.Indented);
            var jObj = JObject.Parse(jsonRss);
            var videoTitles = jObj.Descendants()
                                    .OfType<JProperty>()
                                    .Where(x => x.Name == "media:title")
                                    .Select(x => x.Value)
                                    .ToList();
            logger.Print(string.Join(Environment.NewLine, videoTitles));
            
            // Create POCO`s from videos
            var videoObjects = jObj["feed"]["entry"]
                                    .Select(entry => JsonConvert.DeserializeObject<VideoItem>(entry.ToString()));

            logger.Print(string.Join(Environment.NewLine, videoObjects));

            var html = CreateHtml(videoObjects);
            StreamWriter wr = new StreamWriter("../../index.html", false, Encoding.UTF8);
            wr.Write(html);
            wr.Close();
            
        }

        private static string CreateHtml(IEnumerable<IVideoItem> videos)
        {
            var result = new StringBuilder();
            result.Append("<html><head></head><body>");
            foreach (var video in videos)
            {
                result.Append($"<h1>{video.Title}</h1>");
                result.Append($"<iframe src=\"http://www.youtube.com/embed/{video.Id}?autoplay=0\" allowfullscreen></iframe>");
                result.Append($"<a href=\"{video.Title}\">Watch in YouTube</a>");
            }
            result.Append("</body></html>");

            return result.ToString();
        }
    }
}
