namespace _07.CreateXMLFromTextFile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    /* TASK 7
     * In a text file we are given the name, address 
     * and phone number of given person (each at a single line). 
     * Write a program, which creates new XML document,      * which contains these data in structured XML format.     */

    public class XMLCreator
    {
        private static string inputPath = "../../people.txt";

        private static string outputPath = "../../people.xml";

        static void Main()
        {
            using (var reader = new StreamReader(inputPath))
            {
                using (var writer = new XmlTextWriter(outputPath, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("people");

                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        var entries = line.Split(';').Select(entry => entry.Trim()).ToArray();
                        WritePerson(writer, name: entries[0], address: entries[1], phone: entries[2]);
                        line = reader.ReadLine();
                    }

                    writer.WriteEndDocument();
                    Console.WriteLine("XML file saved to {0}", outputPath);
                }
            }
        }

        public static void WritePerson(XmlWriter writer, string name, string address, string phone)
        {
            writer.WriteStartElement("person");
            {
                writer.WriteElementString("name", name);
                writer.WriteElementString("address", address);
                writer.WriteElementString("phone", phone);
            }

            writer.WriteEndElement();
        }
    }
}
