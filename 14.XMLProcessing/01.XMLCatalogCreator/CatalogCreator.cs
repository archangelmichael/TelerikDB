namespace _01.XMLCatalogCreator
{
    using System.Globalization;
    using System.Text;

    /*
     * TASK 1
     * Create a XML file representing catalogue. 
     * The catalogue should contain albums of different artists. 
     * For each album you should define: name, artist, 
     * year, producer, price and a list of songs. 
     * Each song should be described by title and duration.
     */
    public class CatalogCreator
    {
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-Us");

        private static string outputPath = "../../../catalogue.xml";

        public static void Main(string[] args)
        {
            var fileCreator = new XMLFileCreator(outputPath, Encoding.GetEncoding("windows-1251"));
            fileCreator.CreateXMLFile();
        }
    }
}
