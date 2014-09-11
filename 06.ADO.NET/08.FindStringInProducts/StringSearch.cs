namespace _08.FindStringInProducts
{
    using System;
    using System.Data.SqlClient;

    /* 
    TASK8. Write a program that reads a string from the console 
    and finds all products that contain this string. 
    Ensure you handle correctly characters like ', %, ", \ and _. 
    */
    public class StringSearch
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your product search: ");
            string pattern = Console.ReadLine();

            using (var databaseConnection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true"))
            {
                databaseConnection.Open();

                var cmdSearch = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @Pattern", databaseConnection);

                // Use square brackets [] to escape the special characters, e.g. 50% -> [50%]
                pattern = pattern
                    .Replace("%", "[%]")
                    .Replace("'", "[']")
                    .Replace("\"", "[\"]")
                    .Replace("_", "[_]")
                    .ToLower();

                cmdSearch.Parameters.AddWithValue("@Pattern", "%" + pattern + "%");

                var reader = cmdSearch.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader["ProductName"]);
                }
            }
        }
    }
}
