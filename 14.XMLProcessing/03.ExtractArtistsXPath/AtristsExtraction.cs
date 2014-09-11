namespace _03.ExtractArtistsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    /* TASK 3
     * Implement the previous using XPath.
     */ 
    public class AtristsExtraction
    {
        private static string filePath = "../../../catalogue.xml";

        public static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            string XPathQuery = "catalogue/album/artist";
            XmlNodeList artistNames = document.SelectNodes(XPathQuery);
            var artists = artistNames.OfType<XmlElement>().GroupBy(e => e.InnerText).ToDictionary(gr => gr.Key, gr => gr.Count());
            PrintArtistsAlbumsCount(artists);
        }

        private static void PrintArtistsAlbumsCount(Dictionary<string, int> artists)
        {
            foreach (var key in artists.Keys)
            {
                Console.WriteLine("Author {0} : {1} {2}", key, artists[key], artists[key] > 1 ? "albums" : "album");
            }
        }
    }
}
