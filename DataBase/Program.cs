using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Globalization;
namespace DataBase
{
    internal class Program
    {

        static SqlConnection connection;
        static SqlCommand command;
        static void Main(string[] args)
        {
            int ch = Menu();
            switch (ch)
            {
                case 1: GetRecords(); break;
                case 2: AddRecord(); break;
                case 3: DeleteRecord(); break;
                case 4: EditRecord(); break;
                default:
                    Console.WriteLine("something error happened"); break;
            }
        }
        static SqlConnection GetConnection()
        {
            string ConnectionString = "server=DESKTOP-S5G37QB;database=PracticeDB;integrated security=true";
            connection = new SqlConnection(ConnectionString);
            return connection;
        }

        static int Menu()
        {
            Console.WriteLine("1. Get Records");
            Console.WriteLine("2.Insert Records");
            Console.WriteLine("3.Delete Records");
            Console.WriteLine("4.Edit Records");
            Console.WriteLine("enter your choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;

        }

        static void GetRecords()
        {

            string connectionString = "server=DESKTOP-S5G37QB;database=PracticeDB;integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "select * from Student";
            command.Connection = connection;


            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4] + " " + reader[5]);
                }
            }
            else
            {
                Console.WriteLine("there are no records");
                reader.Close();
                connection.Close();
            }
        }

        static void AddRecord()
        {
            string connectionString = "server=DESKTOP-S5G37QB;database=PracticeDB;integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "insert into student values (1,'Swapnil','22-08-1999',78,'A','.Net-React')";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    
        static void DeleteRecord()
        {
            string connectString = "server=DESKTOP-S5G37QB;database=practiceDB;integrated security=true";
            connection = new SqlConnection(connectString);
            command = new SqlCommand();
            command.CommandText = "delete from Student where id=1";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        static void EditRecord()
        {
            string connectString = "server=DESKTOP-S5G37QB;database=practiceDB;integrated security=true";
            connection = new SqlConnection(connectString);
            command= new SqlCommand();
            command.CommandText = "update Student set marks=90 where id=1";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        }
    }



