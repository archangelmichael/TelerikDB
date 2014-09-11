namespace _02.TestToListInvoking
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using TelerikAcademyDatabase;
    /*
     * Using Entity Framework write a query that selects all employees from the Telerik Academy database, 
     * then invokes ToList(), then selects their addresses, then invokes ToList(), 
     * then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". 
     * Rewrite the same in more optimized way and compare the performance.
     */
    public class TestToList
    {
        private static Stopwatch watch = new Stopwatch();

        private static TelerikAcademyEntities databaseContext = new TelerikAcademyEntities();

        public static void Main(string[] args)
        {
            watch.Start();
            var selectSofiaTowns = databaseContext.Employees.ToList()
                .Select(employee => employee.Address).ToList()
                .Select(address => address.Town.Name).ToList()
                .Where(town => town == "Sofia");
            Console.WriteLine("Search with ToList on every step in: {0}", watch.Elapsed);

            watch.Restart();
            var selectSofiaTownsFast = databaseContext.Employees
                .Select(employee => employee.Address)
                .Select(address => address.Town.Name)
                .Where(town => town == "Sofia").ToList();
            Console.WriteLine("Search with ToList at the end in: {0}", watch.Elapsed);

            watch.Restart();
            var selectSofiaTownsNoToList = databaseContext.Employees
                .Select(employee => employee.Address)
                .Select(address => address.Town.Name)
                .Where(town => town == "Sofia");
            Console.WriteLine("Search with no ToList in: {0}", watch.Elapsed);

        }
    }
}
