namespace _11.AlbumPricesWithXPath
{
    using System;
    using System.Xml;

    /* TASK 11
     * Write a program, which extract 
     * from the file catalog.xml the prices 
     * for all albums, published 5 years ago or earlier. 
     * Use XPath query.
     */
    public class GetPricesWithXpath
    {
        private static string filePath = "../../../catalogue.xml";

        static void Main()
        {
            int year = DateTime.Now.Year - 5;
            var doc = new XmlDocument();
            doc.Load(filePath);
            string XPathQuery = string.Format("/catalogue/album[year<{0}]", year);
            XmlNodeList albums = doc.SelectNodes(XPathQuery);
            foreach (XmlNode album in albums)
            {
                Console.WriteLine(
                    "Album {0} published in {1} costs {2}",
                    album["name"].InnerText,
                    album["year"].InnerText,
                    album["price"].InnerText);
            }
        }
    }
}
