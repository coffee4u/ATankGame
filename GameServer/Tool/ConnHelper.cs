using System;
using MySql.Data.MySqlClient;
namespace GameServer.Tool
{
    public class ConnHelper
    {
        public const string ConnectionString = "datasource=127.0.0.1;port=3306;database=game01;user=root;pwd=Cb080200";
        public static MySqlConnection Connect()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                return conn;

            }
            catch (Exception e)
            {
                Console.WriteLine("connect database failed.");
            }
            return null;
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();

                }
                else
                {
                    Console.WriteLine("conn database is null.");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("close database failed.");

            }
        }
        public ConnHelper()
        {
        }
    }
}
