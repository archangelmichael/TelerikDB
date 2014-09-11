namespace _05.ExtractSongTitles
{
    using System;
    using System.Xml;
    /* TASK 5
     * Write a program, which using XmlReader extracts all song titles from catalog.xml.     */

    public class SongTitlesDeletion
    {
        private static string filePath = "../../../catalogue.xml";

        public static void Main()
        {
            using (var reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "song")
                    {
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            }
        }
    }
}
