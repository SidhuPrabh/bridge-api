using System;
using MySql.Data.MySqlClient;

namespace bridge_api.Models.Sql
{
    public class SqlCon
    {
        protected MySqlConnection CreateConnection()
        {
            string connection = "server=localhost;database=bridge;user=ps;password=root;port=3306";
            MySqlConnection con = new MySqlConnection(connection);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }

            return con;
        }
    }
}