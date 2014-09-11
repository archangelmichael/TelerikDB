namespace StudentsSystemModel
{
    using System.Data.Entity;
    using StudentsSystemClasses;

    public class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext()
            : base("StudentsSystemDb")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}
