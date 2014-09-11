namespace _02.StudentsXMLfile
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum Sex
    {
        Male = 1,
        Female = 2
    }

    /// <summary>
    /// Generates all king of random data needed for a new student and exam
    /// </summary>
    public class RandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMOPQRSTUVWXYZabcdrfghijklmnopqrstuvwxyz";

        private const string Digits = "0123456789";

        private readonly string[] domains;

        private DateTime startDate = new DateTime(1980, 1, 1);

        private DateTime endDate = new DateTime(2010, 1, 1);

        private Random generator = new Random();

        public RandomDataGenerator()
        {
            this.domains = new string[] { "@abv.bg", "@yahoo.com", "@gmail.com" };
        }
        
        public long GenerateRandomNumber(int length)
        {
            StringBuilder number = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                number.Append(Digits[this.generator.Next(0, Digits.Length - 1)]);
            }

            return long.Parse(number.ToString());
        }

        public string GenerateName()
        {
            int length = this.generator.Next(5, 10);
            StringBuilder name = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                name.Append(Letters[this.generator.Next(0, Letters.Length - 1)]);
            }

            return name.ToString();
        }

        public string GenerateEmail(string name)
        {
            return name + this.domains[this.generator.Next(0, this.domains.Length - 1)];
        }

        public string GeneratePhone()
        {
            return this.GenerateRandomNumber(10).ToString();
        }

        public DateTime GenerateBirthDate()
        {
            int timeSpan = (int)(this.endDate - this.startDate).TotalDays;
            DateTime newDate = this.startDate.AddDays(this.generator.Next(0, timeSpan));
            return newDate;
        }

        public Sex GenerateSex()
        {
            return this.generator.Next(0, 2) == 1 ? Sex.Male : Sex.Female;
        }

        public IList<Exam> GenerateExams()
        {
            int count = this.generator.Next(0, 10);
            var listOfExams = new List<Exam>();
            for (int i = 0; i < count; i++)
            {
                listOfExams.Add(new Exam() { ExamName = this.GenerateName(), Tutor = this.GenerateName(), Score = this.generator.Next(2, 6) });
            }

            return listOfExams;
        }
    }
}
