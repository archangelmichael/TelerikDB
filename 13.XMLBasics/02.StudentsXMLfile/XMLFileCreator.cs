namespace _02.StudentsXMLfile
{
    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class XMLFileCreator
    {
        private static Encoding encoding;
        private string outputPath;
        private RandomDataGenerator dataGenerator;
        private StudentGenerator studentGenerator;

        public XMLFileCreator(string output, Encoding encode)
        {
            this.outputPath = output;
            encoding = encode;
            this.dataGenerator = new RandomDataGenerator();
            this.studentGenerator = new StudentGenerator(this.dataGenerator);
        }

        public void CreateXMLFile(int entriesCount)
        {
            using (var writer = new XmlTextWriter(this.outputPath, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("students");
                XNamespace defaultNS = "urn:students";
                writer.WriteAttributeString("xmlns", "urn:students"); //// Default namespace
                for (int i = 0; i < entriesCount; i++)
                {
                    this.WriteAlbum(writer);
                }

                writer.WriteEndDocument();
            }

            Console.WriteLine("Document saved to {0}", this.outputPath);
        }

        private void WriteAlbum(XmlWriter writer)
        {
            var student = this.studentGenerator.CreateStudent();
            writer.WriteStartElement("student");
            writer.WriteElementString("name", student.Name);
            writer.WriteElementString("sex", student.Sex.ToString());
            writer.WriteElementString("birthdate", student.BirthDate.Date.ToString());
            writer.WriteElementString("phone", student.Phone);
            writer.WriteElementString("email", student.Email);
            writer.WriteElementString("course", student.Course);
            writer.WriteElementString("specialty", student.Specialty);
            writer.WriteElementString("faculty-number", student.FacultyNumber.ToString());
            if ((student.Exams != null) && (student.Exams.Count > 0))
            {
                writer.WriteStartElement("exams");
                foreach (var exam in student.Exams)
                {
                    writer.WriteStartElement("exam");
                    writer.WriteElementString("name", exam.ExamName);
                    writer.WriteElementString("tutor", exam.Tutor);
                    writer.WriteElementString("score", exam.Score.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
