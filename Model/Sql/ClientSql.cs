using System;
using bridge_api.Models.Clients;
using MySql.Data.MySqlClient;

namespace bridge_api.Models.Sql
{
    public class ClientSql : SqlCon
    {
        public void InsertClientToDB(Client client)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"INSERT INTO `clients`(`name`, `email`, `address`, `city`, `postcode`, `pwd`, `phone`, `marketingEmail`, `dateCreated`, `isActive`, `points`) VALUES ('{client.name}', '{client.email}', '{client.address}',`{client.city}`,'{client.postcode}', '{client.pwd}', '{client.phone}', {client.emailMarketing}, {client.dateCreated}, {client.isActive}, {client.points});";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        public Client GetClientFromDB(Client client)
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select * from `clients` where `email` = {client.email} and `pwd` = {client.pwd};";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            Client c = new Client();
            while(result.Read())
            {
                c.id = Convert.ToUInt32(result["id"]);
                c.name = result["name"].ToString();
                c.email = result["email"].ToString();
                c.pwd = result["pwd"].ToString();
                c.address = result["address"].ToString();
                c.city = result["city"].ToString();
                c.postcode = result["postcode"].ToString();
                c.phone = result["phone"].ToString();
                c.emailMarketing = Convert.ToBoolean(result["emailMarketing"]);
                c.dateCreated = result["dateCreated"].ToString();
                c.isActive = Convert.ToBoolean(result["isActive"]);
                c.points = Convert.ToUInt32(result["points"]);
            }
            con.Close();
            return c;
        }

        public void UpdateClientToDB(Client client)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `clients` set `name`='{client.name}', `address`='{client.address}', `phone`='{client.phone}') where `id` = {client.id};";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        public void DeactivateClientToDB(Client client)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `clients` set `isActive` = FALSE where `id` = {client.id}";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}