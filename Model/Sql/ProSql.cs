using System;
using System.Collections.Generic;
using bridge_api.Models.Professionals;
using MySql.Data.MySqlClient;

namespace bridge_api.Models.Sql
{
    public class ProSql : SqlCon
    {
        public void InsertProToDB(Professional pro)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"INSERT INTO `professionals` (`businessName`, `logoURL`, `address`, `city`, `postcode`, `email`, `pwd`, `phone`, `personOfContact`, `webiste`, `instagram`, `facebook`, `youtube`, `noOfContractsGot`, `dateCreated`, `isActive`) VALUES ('{pro.businessName}', '{pro.logoURL}', '{pro.address}','{pro.city}', '{pro.postcode}', '{pro.email}', '{pro.pwd}','{pro.phone}', '{pro.personOfContact}', '{pro.website}', '{pro.instagram}', '{pro.facebook}', '{pro.youtube}', 0,`{pro.dateCreated}`, TRUE );";
            
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

        public void UpdateProToDB(Professional pro)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `professionals` SET `businessName`=`{pro.businessName}`, `logoURL`={pro.logoURL}, `address`={pro.address}, `city`={pro.city}, `postcode`={pro.postcode}, `email`={pro.email}, `pwd`={pro.pwd}, `phone`={pro.phone}, `personOfContact`={pro.personOfContact}, `webiste`={pro.website}, `instagram`={pro.instagram}, `facebook`={pro.facebook}, `youtube`={pro.youtube} where `id`={pro.id};";          
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

        public Professional GetProFromDB(Professional pro)
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select * from professionals where `email` = {pro.email} and `pwd` = {pro.pwd};";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            Professional p = new Professional();
            while(result.Read())
            {
                p.id = Convert.ToUInt32(result["id"]);
                p.businessName = result["businessName"].ToString();
                p.logoURL = result["logoURL"].ToString();
                p.address = result["address"].ToString();
                p.city = result["city"].ToString();
                p.postcode = result["postcode"].ToString();
                p.email = result["email"].ToString();
                p.pwd = result["pwd"].ToString();
                p.phone = result["phone"].ToString();
                p.personOfContact = result["personOfContact"].ToString();
                p.website = result["website"].ToString();
                p.instagram = result["instagram"].ToString();
                p.youtube = result["youtube"].ToString();
                p.facebook = result["facebook"].ToString();
                p.noOfContractsGot = result["noofContractsGot"].ToString();
                p.dateCreated = result["dateCreated"].ToString();
                p.isActive = Convert.ToBoolean(result["isActive"]);
            }
            con.Close();
            return p;
        }

        public List<Professional> GetProListByCategoryFromDB(string txtPro, string selectedCity)
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"SELECT DISTINCT * from `professionals` join `catPro` on professionals.id = catPro.proId join `categories` on catPro.catId = categories.id where categories.category like '{txtPro}' and professionals.city = '{selectedCity}';";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            List<Professional> ProList = new List<Professional>();

            while(result.Read())
            {
                Professional p = new Professional();
                p.id = Convert.ToUInt32(result["id"]);
                p.businessName = result["businessName"].ToString();
                p.logoURL = result["logoURL"].ToString();
                p.address = result["address"].ToString();
                p.city = result["city"].ToString();
                p.postcode = result["postcode"].ToString();
                p.email = result["email"].ToString();
                p.pwd = result["pwd"].ToString();
                p.phone = result["phone"].ToString();
                p.personOfContact = result["personOfContact"].ToString();
                p.website = result["website"].ToString();
                p.instagram = result["instagram"].ToString();
                p.youtube = result["youtube"].ToString();
                p.facebook = result["facebook"].ToString();
                p.noOfContractsGot = result["noofContractsGot"].ToString();
                //p.dateCreated = result["dateCreated"].ToString();
                p.isActive = Convert.ToBoolean(result["isActive"]);
                ProList.Add(p);
            }
            con.Close();
            return ProList;
        }

        public void DeactivateClientToDB(Professional pro)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `professionals` set `isActive` = FALSE where `id` = {pro.id}";
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