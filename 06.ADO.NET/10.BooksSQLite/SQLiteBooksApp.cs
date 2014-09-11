namespace _10.BooksSQLite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /*
    Re-implement the previous task with SQLite embedded DB.
    Create a SQLite database to store Books (title, author, publish date and ISBN). 
    Write methods for listing all books, finding a book by name and adding a book. 
    */

    public static class SQLiteBooksApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Library());
        }
    }
}
