namespace _06.ExtractSongsWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    /* TASK 6
     * Rewrite the same using XDocument and LINQ query.     */

    public class ExtractingSongs
    {
        private static string filePath = "../../../catalogue.xml";

        public static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value,
                };

            foreach (var song in songs)
            {
                Console.WriteLine("Song Title {0}", song.Title);
            }
        }
    }
}
