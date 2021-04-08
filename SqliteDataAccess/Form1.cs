using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.IO;


namespace SqliteDataAccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //step1. To reach the db file, 
            string currDirectory = Directory.GetCurrentDirectory();

            string dataFilePath = Path.Combine(currDirectory, "SQliteDemo.db");


            //step 2 Creating a db connection to the db file
            using (SqliteConnection myDBConnection = new SqliteConnection($"Filename={dataFilePath}")) 
            {

                //step 3 Open DB Connection
                myDBConnection.Open();
                //Step 4 Construct the SQLITE command.

                SqliteCommand myInsertCommand = new SqliteCommand();

                myInsertCommand.Connection = myDBConnection;


                myInsertCommand.CommandType = CommandType.Text;

                myInsertCommand.CommandText="INSERT INTO StudentInfo VALUES (NULL, @regofst, @nameofst);";

                myInsertCommand.Parameters.AddWithValue("@regofst", textBox1.Text);
                myInsertCommand.Parameters.AddWithValue("@nameofst", textBox2.Text);

                //step 5 execute the command

                var resultoftheCommand= myInsertCommand.ExecuteReader();

                //step 6 Close the connection
                myDBConnection.Close();



            }





        }
    }
}
