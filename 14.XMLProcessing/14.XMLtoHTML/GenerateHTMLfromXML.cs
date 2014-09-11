namespace _14.XMLtoHTML
{
    using System;
    using System.Xml.Xsl;
    /* TASK 14
     * Write a C# program to apply the XSLT stylesheet transformation 
     * on the file catalog.xml 
     * using the class XslTransform.
     */
 
    public class GenerateHTMLfromXML
    {
        private static string inputFile = "../../../catalogue.xml";
        private static string outputFile = "../../../catalogue.html";
        private static string stylesheet = "../../../catalogue.xsl";

        public static void Main()
        {
            //// if there is an error try removing namespace from the xml file manually
            var xslt = new XslCompiledTransform();
            xslt.Load(stylesheet);
            xslt.Transform(inputFile, outputFile);

            Console.WriteLine("HTML file saved to {0}", outputFile);
        }
    }
}
