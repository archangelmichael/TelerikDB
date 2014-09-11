namespace _06_07.ExcelAndOLEDB
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class OLEDBManipulations
    {
        private static OleDbConnection databaseConn;

        public static void Main(string[] args)
        {
            //// ATTENTION! Excel file must be open in order for the program to work
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\..\ScoreBoard.xlsx;Extended Properties='Excel 8.0;HDR=Yes'";
            databaseConn = new OleDbConnection(connectionString);
            databaseConn.Open();
            using (databaseConn)
            {
                /* TASK 6.Create an Excel file with 2 columns: name and score: 
                Write a program that reads your MS Excel file 
                through the OLE DB data provider and displays the 
                name and score row by row. */
                Console.WriteLine("--- TASK 6 ---");
                GetAllRowsFromEXCEL("[sheet1$]");

                /*TASK 7.Implement appending new rows to the Excel file. */
                Console.WriteLine("--- TASK 7 ---");
                AppendNewRowToEXCEL("[sheet1$]", "Gosho", 34);
                AppendNewRowToEXCEL("[sheet1$]", "Pesho", 24);
            }
        }

        private static void AppendNewRowToEXCEL(string sheet, string name, int score)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = databaseConn;
            cmd.CommandText = "INSERT INTO " + sheet + "(Name, Score) VALUES('" + name + "', " + score + ");";
            cmd.ExecuteNonQuery();
        }

        private static void GetAllRowsFromEXCEL(string sheet)
        {
            Console.WriteLine("--- TASK 6 ---");
            OleDbCommand readAllTableRows = new OleDbCommand("Select Name, Score from " + sheet, databaseConn);
            OleDbDataReader reader = readAllTableRows.ExecuteReader();
            using (reader)
            {
                Console.WriteLine("--- Name => Score ---");
                while (reader.Read())
                {
                    string playerName = (string)reader["Name"];
                    double playerScore = (double)reader["Score"];
                    Console.WriteLine("{0} => {1}", playerName, playerScore);
                }
            }
        }

        private static void WriteExcelFile()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = databaseConn;

            ////cmd.CommandText = "CREATE TABLE [sheet1$] (Name VARCHAR, Score INT);";
            ////cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO [sheet1$](Name, Score) VALUES('Gosho', 23);";
            cmd.ExecuteNonQuery();
            ////cmd.CommandText = "UPDATE [sheet1$] SET Name = 'DDDD' WHERE Score = 23;";
            ////cmd.ExecuteNonQuery();
        }

        private static DataSet ReadExcelFile()
        {
            DataSet ds = new DataSet();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = databaseConn;

            // Get all Sheets in Excel File
            DataTable dataSheet = databaseConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            // Loop through all Sheets to get data
            foreach (DataRow dr in dataSheet.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();

                if (!sheetName.EndsWith("$"))
                {
                    continue;
                }

                // Get all rows from the Sheet
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                DataTable dt = new DataTable();
                dt.TableName = sheetName;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                ds.Tables.Add(dt);
            }

            cmd = null;

            return ds;
        }
    }
}
