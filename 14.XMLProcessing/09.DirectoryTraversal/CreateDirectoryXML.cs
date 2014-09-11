namespace _09.DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /*
     * Write a program to traverse given directory and 
     * write to a XML file its contents together with all subdirectories and files. 
     * Use tags <file> and <dir> with appropriate attributes. 
     * For the generation of the XML document use the class XmlWriter.
     */
    public class CreateDirectoryXML
    {
        private static string directoryPath = "../../..";

        private static string outputPath = "../../directories.xml";

        static void Main()
        {
            using (XmlTextWriter writer = new XmlTextWriter(outputPath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                TraverseDirectory(writer, directoryPath);
                writer.WriteEndDocument();
                Console.WriteLine("XML file saved to {0}", outputPath);
            }
        }

        /// <summary>
        /// Recurrsively traverses the directories
        /// </summary>
        /// <param name="writer"> XML writer </param>
        /// <param name="path"> currently traversing directory</param>
        private static void TraverseDirectory(XmlWriter writer, string path)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", FormatPath(path));

            foreach (var directory in Directory.EnumerateDirectories(path))
            {
                TraverseDirectory(writer, directory);
            }

            foreach (var file in Directory.EnumerateFiles(path))
            {
                writer.WriteElementString("file", FormatPath(file));
            }

            writer.WriteEndElement();
        }

        /// <summary>
        /// Returns first subdirectory from a given path
        /// </summary>
        /// <param name="path"> the path to traverse </param>
        /// <returns> first subdirectory of the given directory </returns>
        private static string FormatPath(string path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }
    }
}
