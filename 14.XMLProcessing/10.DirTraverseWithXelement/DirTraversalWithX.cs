namespace _10.DirTraverseWithXelement
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    /* TASK 10
     * Rewrite the last exercises using XDocument, XElement and XAttribute.
     */ 

    public class DirTraversalWithX
    {
        private static string directoryPath = "../../..";

        private static string outputPath = "../../directories.xml";

        static void Main()
        {
            var rootXML = new XElement("directories");
            TraverseDirectory(rootXML, directoryPath);
            var document = new XDocument(rootXML);
            document.Save(outputPath);
            Console.WriteLine("XML file saved to {0}", outputPath);
        }

        private static void TraverseDirectory(XElement parentXML, string path)
        {
            var directoryXml = new XElement("dir", new XAttribute("name", FormatPath(path)));
            parentXML.Add(directoryXml);

            foreach (var directory in Directory.EnumerateDirectories(path))
            {
                TraverseDirectory(directoryXml, directory);
            }

            foreach (var file in Directory.EnumerateFiles(path))
            {
                directoryXml.Add(new XElement("file", FormatPath(file)));
            }
        }

        private static string FormatPath(string path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }
    }
}
