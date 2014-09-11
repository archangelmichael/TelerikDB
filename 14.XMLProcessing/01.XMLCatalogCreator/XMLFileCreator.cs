namespace _01.XMLCatalogCreator
{
    using System;
    using System.Text;
    using System.Xml;
    using CatalogData;

    public class XMLFileCreator
    {
        private static Encoding encoding;
        private string outputPath;
        private RandomDataGenerator dataGenerator;
        private CatalogGenerator catalogGenerator;

        public XMLFileCreator(string output, Encoding encode)
        {
            this.dataGenerator = new RandomDataGenerator();
            this.catalogGenerator = new CatalogGenerator(this.dataGenerator);
            this.outputPath = output;
            encoding = encode;
        }

        public void CreateXMLFile()
        {
            var catalog = this.catalogGenerator.CreateCatalog();
            using (var writer = new XmlTextWriter(this.outputPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("catalogue");
                writer.WriteAttributeString("xmlns", "urn:catalogue"); //// Default namespace
                foreach (var album in catalog.Albums)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("name", album.Name);
                    writer.WriteElementString("artist", album.Artist);
                    writer.WriteElementString("year", album.Year.ToString());
                    writer.WriteElementString("producer", album.Producer);
                    writer.WriteElementString("price", album.Price.ToString());
                    writer.WriteStartElement("songs");
                    foreach (var song in album.Songs)
                    {
                        writer.WriteStartElement("song");
                        writer.WriteElementString("title", song.Title);
                        writer.WriteElementString("duration", song.Duration.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

                Console.WriteLine("Document saved to {0}", this.outputPath);
            }
        }
    }
}
