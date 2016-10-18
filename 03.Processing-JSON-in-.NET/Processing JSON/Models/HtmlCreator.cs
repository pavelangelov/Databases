using System.Collections.Generic;
using System.IO;
using System.Text;

using Processing_JSON.Contracts;

namespace Processing_JSON.Models
{
    public static class HtmlCreator
    {
        public static void GenerateHtml(IEnumerable<IVideoItem> videos, TextWriter writer)
        {
            var html = CreateHtml(videos);
            writer.Write(html);
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
