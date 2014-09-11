namespace _01.UsingEFOnNorthwind
{
    using EntityFrameworkNorthwindModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    public class Program
    {
        private static Random generator = new Random();

        public static void Main(string[] args)
        {
            NorthwindEntities northContext = new NorthwindEntities();
            /* TASK 1.
             * Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database */
            //// IMPLEMENTED IN EntityFrameworkNorthwindModel project

            /* TASK 2.
             * Create a DAO class with static methods 
             * which provide functionality for inserting, modifying and deleting customers. 
             * Write a testing class.
             */
            //// IMPLEMENTED IN CustomerManipulator Class
            Console.WriteLine("---------------------- TASK 2 --------------------------");
            string insertionID = "ID" + generator.Next(100);
            ////Place "PrintCollection(northContext.Customers);" where you want to see all customers to check output
            InsertCustomer(northContext, insertionID, "Name" + insertionID);
            ModifyCustomerWithID(northContext, insertionID, "Modified Name");
            DeleteCustomerWithID(northContext, insertionID);
            //PrintCollection(northContext.Customers);

            /* TASK 3.
             * Write a method that finds all customers who have orders made in 1997 and shipped to Canada.             */
            Console.WriteLine("---------------------- TASK 3 --------------------------");
            FindCustomersWithOrders(northContext, 1997, "Canada");

            /* TASK 4.
             * Implement previous by using native SQL query and executing it through the DbContext.             */
            Console.WriteLine("---------------------- TASK 4 --------------------------");
            FindCustomersWithOrdersMade(northContext, 1997, "Canada");

            /* TASK 5.
             * Write a method that finds all the sales by specified region and period (start / end dates).
             */
            Console.WriteLine("---------------------- TASK 5 --------------------------");
            FindSalesByRegionAndPeriod(northContext, "RJ", 1996, 1996);

            /* TASK 6.
             * Create a database called NorthwindTwin with the same structure as Northwind 
             * using the features from DbContext. 
             * Find for the API for schema generation in MSDN or in Google.
             */
            Console.WriteLine("---------------------- TASK 6 --------------------------");
            CloneDatabase(northContext);

            /* TASK 7.
             * Try to open two different data contexts and perform concurrent changes on the same records. 
             * What will happen at SaveChanges()? How to deal with it?             */
            Console.WriteLine("---------------------- TASK 7 --------------------------");
            //// Both context have same database reference, so changes in one match in the other.
            //// To deal with it we must detach from the database, work with the objects and attach afterwards
            NorthwindEntities database1 = new NorthwindEntities();
            NorthwindEntities database2 = new NorthwindEntities();
            InsertCustomer(database1, "5555", "R2D2");
            database1.SaveChanges();
            ModifyCustomerWithID(database2, "5555", "Modified Name");
            PrintCollection(database2.Customers);

            /* TASK 8.
             * By inheriting the Employee entity class create a class 
             * which allows employees to access their 
             * corresponding territories as property of type EntitySet<T>.
             */
            Console.WriteLine("---------------------- TASK 8 --------------------------");
            //Employee extended = new Employee();
            //extended = northContext.Employees.Find(1);
            //foreach (var item in extended.EntityTeritories)
            //{
            //    Console.WriteLine("Teritory description - {0}", item.TerritoryDescription);
            //}

            /* TASK 9.
             *Create a method that places a new order in the
             *Northwind database. The order should contain 
             *several order items. 
             *Use transaction to ensure the data consistency.
             */
            Console.WriteLine("---------------------- TASK 9 --------------------------");
            ProcessTransaction(northContext);
            
            /* TASK 10.
             * Create a stored procedures in the Northwind
             * database for finding the total incomes for given 
             * supplier name and period (start date, end date). 
             * Implement a C# method that calls the stored 
             * procedure and returns the retuned record set.
             */
            Console.WriteLine("---------------------- TASK 10 --------------------------");
            GetTotalIncome(northContext, new DateTime(1995, 1, 1), new DateTime(1997, 1, 1), "Mère Paillarde");

        }

        private static void ProcessTransaction(NorthwindEntities northContext)
        {
            using (var transaction = northContext.Database.BeginTransaction())
            {
                var order = new Order()
                {
                    CustomerID = "Michael",
                    EmployeeID = 4
                };

                northContext.Orders.Add(order);

                var orderDetails1 = new Order_Detail()
                {
                    OrderID = order.OrderID,
                    ProductID = 5,
                    UnitPrice = 12.34m,
                    Quantity = 100,
                    Discount = 0.2f
                };

                var orderDetails2 = new Order_Detail()
                {
                    OrderID = order.OrderID,
                    ProductID = 3,
                    UnitPrice = 12.34m,
                    Quantity = 100,
                    Discount = 0.2f
                };

                var orderDetails3 = new Order_Detail()
                {
                    OrderID = order.OrderID,
                    ProductID = 4,
                    UnitPrice = 12.34m,
                    Quantity = 100,
                    Discount = 0.2f
                };

                northContext.Order_Details.AddRange(new[] { orderDetails1, orderDetails2, orderDetails3 });

                try
                {
                    northContext.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex);
                    transaction.Rollback();
                }

                transaction.Commit();
            }
        }

        private static void InsertOrder(
            string shipName, string shipAddress,
            string shipCity, string shipRegionm,
            string shipPostalCode, string shipCountry,
            string customerID = null, int? employeeID = null,
            DateTime? orderDate = null, DateTime? requiredDate = null,
            DateTime? shippedDate = null, int? shipVia = null,
            decimal? freight = null)
        {
            using (NorthwindEntities context = new NorthwindEntities())
            {
                Order newOrder = new Order
                {
                    ShipAddress = shipAddress,
                    ShipCity = shipCity,
                    ShipCountry = shipCountry,
                    ShipName = shipName,
                    ShippedDate = shippedDate,
                    ShipPostalCode = shipPostalCode,
                    ShipRegion = shipRegionm,
                    ShipVia = shipVia,
                    EmployeeID = employeeID,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    Freight = freight,
                    CustomerID = customerID
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();
                Console.WriteLine("Row is inserted.");
            }
        }

        private static void CloneDatabase(NorthwindEntities northContext)
        {
            IObjectContextAdapter context = new NorthwindEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            string createNorthwindCloneDB = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
            "(NAME = NorthwindTwin, " +
            "FILENAME = 'E:\\NorthwindTwin.mdf', " +
            "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            "LOG ON (NAME = NorthwindTwinLog, " +
            "FILENAME = 'E:\\NorthwindTwin.ldf', " +
            "SIZE = 1MB, " +
            "MAXSIZE = 5MB, " +
            "FILEGROWTH = 10%)";

            SqlConnection dbConForCreatingDB = new SqlConnection(
                "Server=.; " +
                "Database=master; " +
                "Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                SqlCommand createDB = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                createDB.ExecuteNonQuery();
            }

            SqlConnection dbConForCloning = new SqlConnection(
                "Server=.; " +
                "Database=NorthwindTwin; " +
                "Integrated Security=true");

            dbConForCloning.Open();

            using (dbConForCloning)
            {
                SqlCommand cloneDB = new SqlCommand(cloneNorthwind, dbConForCloning);
                cloneDB.ExecuteNonQuery();
            }
        }

        private static void GetTotalIncome(NorthwindEntities context, DateTime startYear, DateTime endYear, string companyName)
        {
            //// FIRST EXECUTE THE COMMAND TO CREATE THE PROCEDURE
            //context.Database.ExecuteSqlCommand(
            //    "CREATE PROC usp_FindTotalIncomeByName (@start_date date,  @end_date date, @company_name nvarchar(50)) " + 
            //    "AS " +
            //    "SELECT SUM(details.Quantity*details.UnitPrice) AS TotalIncome " +
            //    "FROM Suppliers s " +
            //    "INNER JOIN Products p " +
            //    "ON s.SupplierID = p.SupplierID " +
            //    "INNER JOIN [ORDER Details] details " +
            //    "ON details.ProductID = p.ProductID " +
            //    "INNER JOIN Orders o " +
            //    "ON details.OrderID = o.OrderID " +
            //    "WHERE s.CompanyName = @company_name AND ((o.OrderDate) >= @start_date AND (o.OrderDate) <= @end_date);");
            var income = context.usp_FindTotalIncomeByName(startYear, endYear, companyName).FirstOrDefault();
            Console.WriteLine("Company's {0} total income is: {1}", companyName, income);
        }

        private static void FindSalesByRegionAndPeriod(NorthwindEntities context, string region, int startYear, int endYear) 
        {
            var fullOrderDetails = context.Orders.
                    Join(context.Order_Details,
                    (order => order.OrderID), 
                    (details => details.OrderID), 
                    (order, details) =>
                    new
                    {
                        Order = order.OrderID,
                        Quantity = details.Quantity,
                        StartDate = order.OrderDate,
                        EndDate = order.ShippedDate, 
                        Region = order.ShipRegion,
                        Country = order.ShipCountry
                    });
            var sales = fullOrderDetails.Where(order => order.Region == region && order.StartDate.Value.Year == startYear && order.EndDate.Value.Year == endYear);
            foreach (var sale in sales)
            {
                Console.WriteLine("Sale: {0}, Region: {1}, Country: {2}, Quantity: {3}", sale.Order, sale.Region, sale.Country, sale.Quantity);
            }
        }

        private static void DeleteCustomerWithID(NorthwindEntities context, string id)
        {
            CustomerManipulator.Delete(context, id);
        }

        private static void ModifyCustomerWithID(NorthwindEntities context, string id, string name)
        {
            CustomerManipulator.Modify(context, id, name);
        }

        private static void InsertCustomer(NorthwindEntities context, string id, string name)
        {
            var testCustomer = new Customer();
            testCustomer.CustomerID = id;
            testCustomer.CompanyName = name;
            CustomerManipulator.Insert(context, testCustomer);
        }

        private static void FindCustomersWithOrders(NorthwindEntities context, int p1, string p2)
        {
            var specificOrders = context.Orders
                .Where(order => order.OrderDate.Value.Year == 1997 && order.ShipCountry == "Canada");
            foreach (var order in specificOrders)
            {
                Console.WriteLine("Order made by: {0} with CustomerId: {1}", order.Customer.CompanyName, order.Customer.CustomerID);
            }
        }

        private static void FindCustomersWithOrdersMade(NorthwindEntities context, int year, string country)
        {
            string sqlQuery = @"SELECT c.ContactName from Customers" +
                              " c INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                              "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";
            object[] parameters = { year, country };
            var sqlQueryResult = context.Database.SqlQuery<string>(sqlQuery, parameters);
            foreach (var order in sqlQueryResult)
            {
                Console.WriteLine(order);
            }
        }

        private static void PrintCollection(DbSet<Customer> collection)
        {
            Console.WriteLine(new string('*', 30) + "START" + new string('*', 30));
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine(new string('*', 30) + "END" + new string('*', 30));
        }        
    }
}
