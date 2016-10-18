using System.Net;

namespace Processing_JSON.Models
{
    public static class FileDownloader
    {
        public static void DownloadRss(string rssUrl, string filePath)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(rssUrl, filePath);
        }
    }
}
