namespace StudentsSystemApp
{
    using System;
    using System.Data.Entity;
    using StudentsSystemModel;
    using StudentsSystemModel.Migrations;

    public class StudentsSystemTest
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemContext, Configuration>());

            using (var db = new StudentsSystemContext())
            {
                Console.WriteLine("********************** Students ************************");
                foreach (var student in db.Students)
                {
                    Console.WriteLine("ID: {0}; Name: {1}; Student number: {2}", student.Id, student.Name, student.Number);
                }

                Console.WriteLine("********************** Courses *************************");
                foreach (var course in db.Courses)
                {
                    Console.WriteLine("ID: {0}; Name: {1}; Description: {2}; Materials: {3}", course.Id, course.Name, course.Description, course.Materials);
                }
            }
        }
    }
}
