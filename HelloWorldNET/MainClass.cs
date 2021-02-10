using System;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;
namespace HelloWorldNET
{
    class MainClass
    {
       
        public static String DBConnect()
        {
            StringBuilder data = new StringBuilder();

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Port = 8889;
            builder.UserID = "bas";
            builder.Password = "bast";
            builder.Database = "helloWorld";

            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                data.AppendLine("\nQuery data example:");
                data.AppendLine("=========================================\n");

                String sql = "SELECT helloWorld FROM testHW WHERE id = 1 ";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.AppendLine(reader.GetString(0));
                        }
                        return data.ToString();
                    }
                }
            }
        }
    }
}
