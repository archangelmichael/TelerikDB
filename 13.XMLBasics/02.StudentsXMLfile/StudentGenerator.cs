namespace _02.StudentsXMLfile
{
    /// <summary>
    /// Generates new Student with random values
    /// </summary>
    public class StudentGenerator
    {
        private static RandomDataGenerator generator;

        public StudentGenerator(RandomDataGenerator dataGenerator)
        {
            generator = dataGenerator;
        }

        public Student CreateStudent()
        {
            return new Student()
            {
                Name = generator.GenerateName(),
                Sex = generator.GenerateSex(),
                BirthDate = generator.GenerateBirthDate(),
                Phone = generator.GeneratePhone(),
                Email = generator.GenerateEmail(generator.GenerateName()),
                Course = generator.GenerateName(),
                Specialty = generator.GenerateName(),
                FacultyNumber = generator.GenerateRandomNumber(10),
                Exams = generator.GenerateExams()
            };
        }
    }
}
