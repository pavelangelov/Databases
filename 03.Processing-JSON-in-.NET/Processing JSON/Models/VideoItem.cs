using System.Text;

using Newtonsoft.Json;

using Processing_JSON.Contracts;

namespace Processing_JSON.Models
{
    public class VideoItem : IVideoItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Title: {this.Title}");
            result.AppendLine($"Url: {this.Link.Href}");
            result.AppendLine($"Thumbnail: {this.Id}");

            return result.ToString();
        }
    }
}
