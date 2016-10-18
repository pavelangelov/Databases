using System.Collections.Generic;
using System.Linq;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Processing_JSON.Models
{
    public class JsonParser
    {
        private XmlDocument doc = new XmlDocument();

        public IEnumerable<JToken> ExtractAllVideoTitles(string xmlUrl)
        {
            this.doc.Load(xmlUrl);
            var jsonRss = JsonConvert.SerializeXmlNode(this.doc, Newtonsoft.Json.Formatting.Indented);
            var jsonObj = JObject.Parse(jsonRss);
            var videoTitles = jsonObj.Descendants()
                                    .OfType<JProperty>()
                                    .Where(x => x.Name == "media:title")
                                    .Select(x => x.Value);

            return videoTitles;
        }

        public IEnumerable<VideoItem> ExtractVideoObjects(string xmlUrl)
        {
            this.doc.Load(xmlUrl);
            var jsonRss = JsonConvert.SerializeXmlNode(this.doc, Newtonsoft.Json.Formatting.Indented);
            var jsonObj = JObject.Parse(jsonRss);
            var videoObjects = jsonObj["feed"]["entry"]
                                    .Select(entry => JsonConvert.DeserializeObject<VideoItem>(entry.ToString()));

            return videoObjects;
        }
    }
}
