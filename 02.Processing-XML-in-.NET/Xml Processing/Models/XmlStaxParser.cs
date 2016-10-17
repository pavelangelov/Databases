using System;
using System.Text;
using System.Xml;

namespace Xml_Processing.Models
{
    public class XmlStaxParser
    {
        public string ExtractAllSongsNames(string url)
        {
            var result = new StringBuilder("Founded songs:");
            using (XmlReader reader = XmlReader.Create(url))
            {
                while (reader.Read())
                {
                    var element = reader;
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        result.AppendLine(reader.ReadElementContentAsString());
                    }
                }
            }

            return result.ToString();
        }

        public string ExtractAlbumsInNewFile(string currentFileUrl, string newFileUrl)
        {
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter(newFileUrl, encoding);
            var docName = "albums";

            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement(docName);

            bool hasTitle = false;
            bool hasArtist = false;
            string title = "";
            string artist = "";

            using (XmlReader reader = XmlReader.Create(currentFileUrl))
            {
                while (reader.Read())
                {
                    var element = reader;
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                    {
                        title = reader.ReadElementContentAsString();
                        hasTitle = true;
                    }
                    else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist"))
                    {
                        artist = reader.ReadElementContentAsString();
                        hasArtist = true;
                    }

                    if (hasTitle && hasArtist)
                    {
                        AddAlbum(writer, title, artist);
                        hasTitle = false;
                        hasArtist = false;
                    }
                }
            }

            writer.Close();
            return $"Created XML Document -> {docName}.xml";
        }

        private void AddAlbum(XmlWriter writer, string title, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("title", title);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}
