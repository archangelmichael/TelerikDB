namespace _10.BooksSQLite
{
    using System;
    using System.Windows.Forms;
    using Finisar.SQLite;

    public partial class Library : Form
    {
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader reader;
        private string title;
        private string author;
        private string release;
        private int isbn;

        public Library()
        {
            this.InitializeComponent();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.connection = new SQLiteConnection("Data Source=library.db;Version=3;New=False;Compress=True;");
            try
            {
                this.connection.Open();
                MessageBox.Show("You have established connection with the database!");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot connect to database! " + exc.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            this.connection = new SQLiteConnection("Data Source=library.db;Version=3;New=False;Compress=True;");
            this.connection.Open();
            this.command = this.connection.CreateCommand();
            this.command.CommandText = "SELECT Title, Author, ReleaseDate, ISBN FROM books";
            this.reader = this.command.ExecuteReader();
            while (this.reader.Read())
            {
                var output = string.Format(
                    "Title: {0}, Author: {1}, ReleaseDate: {2}, ISBN: {3} ", 
                    this.reader[0], 
                    this.reader[1], 
                    this.reader[2], 
                    this.reader[3]);
                MessageBox.Show(output);
            }

            this.connection.Close();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            this.connection = new SQLiteConnection("Data Source=library.db;Version=3;New=False;Compress=True;");
            this.connection.Open();
            this.command = this.connection.CreateCommand();
            this.command.CommandText = "SELECT Title, Author, ReleaseDate, ISBN FROM books";
            this.reader = this.command.ExecuteReader();
            this.title = "\"" + titleInput.Text + "\"";
            while (this.reader.Read())
            {
                if (this.reader[0].ToString() == this.title)
                {
                    MessageBox.Show("Book Has Been Found!");
                    var output = string.Format(
                        "Title: {0}, Author: {1}, ReleaseDate: {2}, ISBN: {3} ",
                        this.reader[0], 
                        this.reader[1], 
                        this.reader[2].ToString(), 
                        this.reader[3]);
                    MessageBox.Show(output);
                    return;
                }
            }

            MessageBox.Show("No Book With Title: " + this.titleInput.Text);
            this.connection.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.connection = new SQLiteConnection("Data Source=library.db;Version=3;New=False;Compress=True;");
            try
            {
                this.connection.Open();
                this.command = this.connection.CreateCommand();
                this.title = this.titleInput.Text;
                this.author = this.authorInput.Text;

                DateTimePicker date = releaseDateInput;
                DateTime value = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
                this.release = value.ToString("yyyy-MM-dd");
                this.isbn = (int)this.isbnInput.Value;
                string newBookData = string.Format(
                    "('\"{0}\"', '\"{1}\"', \"{2}\", \"{3}\")",
                    this.title, 
                    this.author, 
                    this.release, 
                    this.isbn);
                this.PopulateDatabaseWith(this.command, newBookData);
                MessageBox.Show("New Book Added Successfully!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void CreateDatabase_Click(object sender, EventArgs e)
        {
            this.connection = new SQLiteConnection("Data Source=library.db;Version=3;New=True;Compress=True;");
            try
            {
                this.connection.Open();
                this.command = this.connection.CreateCommand();
                this.command.CommandText =
                    "CREATE TABLE books " +
                    "(Title varchar(50) not null, " +
                    "Author varchar(50) not null, " +
                    "ReleaseDate date not null, " +
                    "ISBN integer primary key);";
                this.command.ExecuteNonQuery();
                MessageBox.Show("Database has been successfully created!");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot create database! " + exc.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void PopulateDatabase_Click(object sender, EventArgs e)
        {
            this.connection = new SQLiteConnection("Data Source=library.db;Version=3;New=False;Compress=True;");
            try
            {
                this.connection.Open();
                this.command = this.connection.CreateCommand();
                this.PopulateDatabaseWith(this.command, "('\"Introduction to Programming\"', '\"Stormy Attaway\"', \"2013-06-17\", \"125456789\")");
                this.PopulateDatabaseWith(this.command, "('\"As Red as Blood\"', '\"Stormy Attaway\"', \"2012-12-31\", \"765432543\")");
                this.PopulateDatabaseWith(this.command, "('\"Body Count\"', '\"Barbara Nadel\"', \"2013-08-01\", \"234567891\")");
                this.PopulateDatabaseWith(this.command, "('\"A Shadow Of Light\"', '\"Bella Forrest\"', \"2013-07-30\", \"567893454\")");
                MessageBox.Show("Defaul test entries have been added to database!");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Defaul entries have already been added! " + exc.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void PopulateDatabaseWith(SQLiteCommand command, string value)
        {
            command.CommandText =
                        "INSERT INTO books (Title, Author, ReleaseDate, ISBN) " +
                        "VALUES " + value;
            command.ExecuteNonQuery();
        }

        private void TitleInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void AuthorInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void ReleaseDateInput_ValueChanged(object sender, EventArgs e)
        {
        }

        private void IsbnInput_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
