namespace _01.SimpleSQLQueries
{
    using System;
    using System.Diagnostics;
    using TelerikAcademyDatabase;
    /*
     * Using Entity Framework write a SQL query to select all employees 
     * from the Telerik Academy database and later print their name, department and town. 
     * Try the both variants: with and without .Include(…). 
     * Compare the number of executed SQL statements and the performance.
     */ 
    public class TestSQLQueries
    {
        private static Stopwatch watch = new Stopwatch();

        private static TelerikAcademyEntities databaseContext = new TelerikAcademyEntities();

        public static void Main(string[] args)
        {
            watch.Start();
            SlowQuery(); //// EXECUTES QUERY FOR EACH EMPLOYEE
            FastQuery(); //// EXECUTES SINGLE QUIRY
            SlowQuery();
            FastQuery();
        }

        private static void SlowQuery()
        {
            Console.WriteLine("Slow Query");
            watch.Restart();
            foreach (var employee in databaseContext.Employees)
            {
                var Name = employee.LastName;
                var Department = employee.Department.Name;
                var Town = employee.Address.Town.Name;
            }

            Console.WriteLine("Slow query time: {0}", watch.Elapsed);
        }

        private static void FastQuery()
        {
            Console.WriteLine("Fast Query");
            watch.Restart();
            foreach (var employee in databaseContext.Employees.Include("Department").Include("Address.Town"))
            {
                var Name = employee.LastName;
                var Department = employee.Department.Name;
                var Town = employee.Address.Town.Name;
            }
            Console.WriteLine("Fast query time: {0}", watch.Elapsed);
        }
    }
}
