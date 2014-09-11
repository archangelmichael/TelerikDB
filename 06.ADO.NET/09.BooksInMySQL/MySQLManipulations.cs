namespace _09.BooksInMySQL
{
    using System;
    using MySql.Data.MySqlClient;

    /*
     * Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) 
     * and MySQL Workbench GUI administration tool . 
     * Create a MySQL database to store Books (title, author, publish date and ISBN). 
     * Write methods for listing all books, finding a book by name and adding a book.
     */ 
    public class MySQLManipulations
    {
        private static MySqlConnection connection;

        public static void Main(string[] args)
        {
            //// WARNING! TO TEST THE PROGRAM FIRST EXECUTE THE SQL FILE Create-books-Database-In-MySQL.sql 
            //// TO CREATE AND POPULATE THE DATABASE!!!
            Console.WriteLine("--- TASK 9 ---");
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();
            string connectionStr = "Server=localhost;Port=3307;Database=books;Uid=root;Pwd=" + pass + ";";
            connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                //// TEST LIST ALL BOOKS FUNCTION
                ListAllBooks();
                //// TEST FINDING BOOK BY TITLE, WHICH EXSISTS
                FindBookByTitle("As Red as Blood");
                //// TEST FINDING BOOK BY TITLE, WHICH DOES NOT EXSIST
                FindBookByTitle("In the jungle");
                //// TEST ADDING NEW BOOK BY TITLE, WHICH EXSISTS
                AddBook("New Book Title", "New Book Author", DateTime.Now, 826346324);
            }
        }

        private static void FindBookByTitle(string bookTitle)
        {
            Console.WriteLine("--- SEARCH FOR BOOK {0} ---", bookTitle);
            MySqlCommand command = new MySqlCommand("select Title, Author, ReleaseDate, ISBN from library", connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader[0].ToString() == bookTitle)
                    {
                        Console.WriteLine("Book found!");
                        PrintBookInfo(reader);
                        return;
                    }
                }
            }

            Console.WriteLine("Search was unsuccessful! There is no such book in the database!");
        }

        private static void ListAllBooks()
        {
            Console.WriteLine("--- BOOKS LIST ---");
            MySqlCommand command = new MySqlCommand("select * from library", connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PrintBookInfo(reader);
                }
            }
        }

        private static void PrintBookInfo(MySqlDataReader reader)
        {
            Console.WriteLine("Title: {0}, Author: {1}, ReleaseDate: {2}, ISBN: {3} ", reader[0], reader[1], reader[2], reader[3]);
        }

        private static void AddBook(string title, string author, DateTime publishDate, int isbn)
        {
            Console.WriteLine("--- ADDING NEW BOOK ---");
            Console.WriteLine("Title: {0}, Author: {1}, ReleaseDate: {2}, ISBN: {3} ", title, author, publishDate, isbn);
            if (title == null || author == null || publishDate == null)
            {
                throw new ArgumentNullException("Cant create book with null entries!");
            }

            MySqlCommand insertBookCommand = new MySqlCommand(
                "INSERT INTO library(Title, Author, ReleaseDate, ISBN) " +
                "VALUES (@title, @author, @date, @isbn)",
                connection);
            PopulateCommandParameter("@title", title, insertBookCommand);
            PopulateCommandParameter("@author", author, insertBookCommand);
            PopulateCommandParameter("@date", publishDate, insertBookCommand);
            PopulateCommandParameter("@isbn", isbn, insertBookCommand);
            insertBookCommand.ExecuteNonQuery();
            Console.WriteLine("Book with Title \"{0}\" was successfully added!", title);
        }

        private static void PopulateCommandParameter<T>(string parameter, T value, MySqlCommand command)
        {
            MySqlParameter currentParameter = new MySqlParameter(parameter, value);
            command.Parameters.Add(currentParameter);
        }
    }
}
