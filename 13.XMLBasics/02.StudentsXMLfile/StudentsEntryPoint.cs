namespace _02.StudentsXMLfile
{
    using System.Globalization;
    using System.Text;

    /* 
     * TASK 2
     * Create XML document students.xml, which contains structured description of students. 
     * For each student you should enter information for:     * his name, sex, birth date, phone, email, course, specialty, faculty number      * and a list of taken exams (exam name, tutor, score).
     * 
     * TASK 5    
     * Add default namespace for the students "urn:students".
     * 
     * TASK 6
     * Create XSD Schema for the students.xml document. 
     * Add new elements in the schema: 
     * information for enrollment (date and exam score) and teacher's endorsements.
     * 
     * TASK 7
     * Write a XSL stylesheet to visualize the students as HTML. 
     * Test it in your favourite browser.
     */ 
    public class StudentsEntryPoint
    {
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-Us");

        private static string outputPath = "../../students.xml";

        public static void Main()
        {
            var creator = new XMLFileCreator(outputPath, Encoding.GetEncoding("windows-1251"));
            creator.CreateXMLFile(4);
        }
    }
}
