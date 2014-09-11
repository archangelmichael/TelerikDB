namespace _12.GetAlbumPriceWithLINQ
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    /* TASK 12
     * Rewrite the previous using LINQ query.
     */
    public class GetAlbumPriceWithLINQ
    {
        private static string filePath = "../../../catalogue.xml";

        static void Main()
        {
            int year = DateTime.Now.Year - 5;
            var doc = XElement.Load(filePath);
            var albums = from album in doc.Elements("album")
                         where int.Parse(album.Element("year").Value) < (year)
                         select new
                         {
                             title = album.Element("name").Value,
                             year = album.Element("year").Value,
                             price = album.Element("price").Value
                         };

            foreach (var album in albums)
            {
                Console.WriteLine("Album {0} published in {1} costs {2}", album.title, album.year, album.price);
            }
        }
    }
}
