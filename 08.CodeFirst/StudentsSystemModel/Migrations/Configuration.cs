namespace StudentsSystemModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentsSystemClasses;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentsSystemContext context)
        {
            context.Courses.AddOrUpdate(new Course { Name = "DSA", Materials = "google search", Description = "Data Structures And Algorithms" });
            context.Courses.AddOrUpdate(new Course { Name = "DB", Materials = "wikipedia", Description = "Databases Fundamentals" });

            context.Students.AddOrUpdate(new Student { Name = "Database GURU", Number = 700 });
            context.Students.AddOrUpdate(new Student { Name = "Algorithms GURU", Number = 007 });
        }
    }
}
