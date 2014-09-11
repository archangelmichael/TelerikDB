﻿namespace _04.DeleteAlbums
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;
    /* TASK 4
     * Using the DOM parser write a program to delete      * from catalog.xml all albums having price > 20.     */ 
    public class AlbumDeletion
    {
        private static string filePath = "../../../catalogue.xml";

        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-Us");

        public static void Main()
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);
            XmlNode rootNode = document.DocumentElement;
            var nodesToRemove = new List<XmlNode>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                decimal price = decimal.Parse(node["price"].InnerText, NumberStyles.Currency, culture);
                if (price > 20)
                {
                    nodesToRemove.Add(node);
                }
            }

            foreach (var node in nodesToRemove)
            {
                rootNode.RemoveChild(node);
            }

            document.Save(filePath);
        }
    }
}
