namespace _02.ExtractDifferentArtists
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /*
     * TASK 2
     * Write program that extracts all different artists 
     * which are found in the catalog.xml. 
     * For each author you should print the number of albums in the catalogue.      * Use the DOM parser and a hash-table.     */ 
    public class ArtistAlbumsExtraction
    {
        private static string sourcePath = "../../../catalogue.xml";

        public static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load(sourcePath);

            XmlNode node = document.DocumentElement;
            var artistsAlbumsCount = new Dictionary<string, int>();
            
            GetArtistAlbumsCount(artistsAlbumsCount, node);

            PrintArtistsAlbumsCount(artistsAlbumsCount);
        }

        private static void GetArtistAlbumsCount(Dictionary<string, int> artists, XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                string artistName = child["artist"].InnerText;
                int count;
                artists[artistName] = artists.TryGetValue(artistName, out count) ? count + 1 : 1;
            }
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
