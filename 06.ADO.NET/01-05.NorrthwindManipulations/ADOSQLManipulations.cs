namespace _01_05.NorrthwindManipulations
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing.Imaging;
    using System.IO;

    public class ADOSQLManipulations
    {
        public static void Main(string[] args)
        {
            SqlConnection databaseCon = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            databaseCon.Open();
            using (databaseCon)
            {
                /* TASK1. Write a program that retrieves from the Northwind sample database 
                in MS SQL Server the number of rows in the Categories table. */
                GetCategoriesRowsCount(databaseCon);

                /* TASK2. Write a program that retrieves the name 
                 * and description of all categories in the Northwind DB. */
                GetCategoriesNamesAndDescriptions(databaseCon);
                
                /* TASK3. Write a program that retrieves from the Northwind database all product categories 
                 * and the names of the products in each category. 
                 * Can you do this with a single SQL query (with table join)? */
                GetProductsNamesInCategories(databaseCon);

                /* TASK4. Write a method that adds a new product in the 
                 * products table in the Northwind database. 
                 * Use a parameterized SQL command. */
                AddNewProduct(databaseCon, "Banana", null, null, null, null, null, null, null, false);

                /* TASK5. Write a program that retrieves the images for all 
                categories in the Northwind database and stores 
                them as JPG files in the file system.*/
                GetAndSaveCategoriesImages(databaseCon);
            }
        }
        
        private static void GetAndSaveCategoriesImages(SqlConnection connectedDB)
        {
            Console.WriteLine("--- TASK 5 ---");
            SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", connectedDB);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                byte[] rawData = (byte[])reader["Picture"];
                string fileName = reader["CategoryName"].ToString().Replace('/', '_') + ".jpg";
                int len = rawData.Length;
                int header = 78;
                byte[] imgData = new byte[len - header];
                Array.Copy(rawData, 78, imgData, 0, len - header);

                MemoryStream memoryStream = new MemoryStream(imgData);
                System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                image.Save(new FileStream(fileName, FileMode.Create), ImageFormat.Jpeg);
            }

            Console.WriteLine("Images saved successfully!");
        }

        private static void AddNewProduct(SqlConnection connectedDB, params object[] list)
        {
            Console.WriteLine("--- TASK 4 ---");
            SqlCommand insertProductCommand = new SqlCommand(
                "INSERT INTO Products(ProductName, SupplierID, CategoryID, " + 
                "QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@name, @suppID, @categoryID, @quantity, @unitPrice, " + 
                "@unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", 
                connectedDB);
            string[] parameters = 
            { 
                "@name", "@suppID", "@categoryID", 
                "@quantity", "@unitPrice", "@unitsInStock", 
                "@unitsOnOrder", "@reorderLevel", "@discontinued" 
            };
            for (int i = 0; i < list.Length; i++)
            {
                SqlParameter currentSQLParameter = new SqlParameter(parameters[i], list[i]);
                if (list[i] == null)
                {
                    currentSQLParameter.Value = DBNull.Value;
                }

                insertProductCommand.Parameters.Add(currentSQLParameter);
            }
            
            insertProductCommand.ExecuteNonQuery();
            Console.WriteLine("New product {0} successfully added!", list[0].ToString());
        }

        private static void GetProductsNamesInCategories(SqlConnection connectedDB)
        {
            Console.WriteLine("--- TASK 3 ---");
            SqlCommand getCategoriesNameAndDescriptionCommand = new SqlCommand(
                "SELECT c.CategoryName, p.ProductName From Categories c JOIN Products p ON c.CategoryID = p.CategoryID", connectedDB);
            SqlDataReader reader = getCategoriesNameAndDescriptionCommand.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("--- CATEGORY NAME => PRODUCT NAME ---");
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} => {1}", categoryName, productName);
                }
            }
        }

        private static void GetCategoriesNamesAndDescriptions(SqlConnection connectedDB)
        {
            Console.WriteLine("--- TASK 2 ---");
            SqlCommand getCategoriesNameAndDescriptionCommand = new SqlCommand(
                "select CategoryName as [Category Name], [Description] from Categories", connectedDB);
            SqlDataReader reader = getCategoriesNameAndDescriptionCommand.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("--- CATEGORY => DESCRIPTION ---");
                while (reader.Read())
                {
                    string categoryName = (string)reader["Category Name"];
                    string categoryDescription = (string)reader["Description"];
                    Console.WriteLine("{0} => {1}", categoryName, categoryDescription);
                }
            }
        }

        private static void GetCategoriesRowsCount(SqlConnection connectedDB)
        {
            Console.WriteLine("--- TASK 1 ---");
            SqlCommand categoriesRowsCountCommand = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", connectedDB);
            int categoriesRowsCount = (int)categoriesRowsCountCommand.ExecuteScalar();
            Console.WriteLine("Categories table rows count: {0} ", categoriesRowsCount);
        }
    }
}
