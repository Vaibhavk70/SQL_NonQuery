using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Concurrent;


namespace SQL_NonQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["SQL_Non"].ConnectionString;
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(cs))
                {
                    Console.WriteLine("Student ID: "); // Sometimes no need to write this for ID because ID is auto-incremented.
                    String ID = Console.ReadLine();
                    Console.WriteLine("Student FName: ");
                    String FName = Console.ReadLine();
                    Console.WriteLine("Student LName: ");
                    String LName = Console.ReadLine();
                    Console.WriteLine("Student Marks: ");
                    String Marks = Console.ReadLine();
                    Console.WriteLine("Student City: ");
                    String City = Console.ReadLine();

                    // For Insert the DATA.
                    // string query = "insert into Student values(@ID, @FName, @LName, @Marks, @City)"; 

                    // For Update the DATA.
                    String query = "update Student set FName=@FName, LName=@LName, Marks=@Marks, City=@City where ID=@ID";

                    //For Delet the Data from the table.
                    //String query = "delete from Student where ID=@ID";

                    SqlCommand cmd= new SqlCommand(query,connection);

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@FName", FName);
                    cmd.Parameters.AddWithValue("@LName", LName);
                    cmd.Parameters.AddWithValue("@Marks", Marks);
                    cmd.Parameters.AddWithValue("@City", City);

                    connection.Open();
                    int a = cmd.ExecuteNonQuery();

                    if (a>0)
                    {
                        Console.WriteLine("Data Update SuccessFully");
                    }
                    else
                    {
                        Console.WriteLine("Data Updation Failed...!");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close(); 
            }
        }

    }
}
