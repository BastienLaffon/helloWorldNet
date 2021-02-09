using System;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
namespace HelloWorldNET
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Port = 8889;
            builder.UserID = "bas";
            builder.Password = "bast";
            builder.Database = "helloWorld";

            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                String sql = "SELECT helloWorld FROM testHW WHERE id = 1 ";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}", reader.GetString(0));
                        }
                    }
                }
            }
        }
    }
}
