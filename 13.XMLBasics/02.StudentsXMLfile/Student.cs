namespace _02.StudentsXMLfile
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Hold all student data
    /// </summary>
    public class Student
    {
        private string studentData = 
            "********* Student Name: {0} \n Sex: {1} \n Birthdate: {2} \n Phone: {3}" +
            " \n Email: {4} \n Course: {5} \n Specialty: {6} \n Faculty Number: {7} \n Exams: \n {8} \n ***********";
        
        public string Name { get; set; }

        public Sex Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Course { get; set; }

        public string Specialty { get; set; }

        public long FacultyNumber { get; set; }

        public ICollection<Exam> Exams { get; set; }

        public override string ToString()
        {
            return string.Format(
                this.studentData,
                this.Name,
                this.Sex,
                this.BirthDate.Date,
                this.Phone,
                this.Email,
                this.Course,
                this.Specialty,
                this.FacultyNumber,
                string.Join(" \n ", this.Exams));
        }
    }
}
