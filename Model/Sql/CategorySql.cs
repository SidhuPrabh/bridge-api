using bridge_api.Models.Categories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace bridge_api.Models.Sql
{
    public class CategorySql : SqlCon
    {
        public void InsertCatToDB(Category cat)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"INSERT INTO `categories` (category) VALUES (`{cat.category}`)";
            
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

        public List<String> GetCatFromDB()
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select * from `categories`;";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            List<string> CatList = new List<string>();
            while(result.Read())
            {
                Category c = new Category();
                //c.Id = Convert.ToUInt32(result["id"]);
                c.category = result["category"].ToString();
                CatList.Add(c.category);
            }
            con.Close();
            return CatList;
        }

        public void UpdateCatToDB(Category cat)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `categories` set `category`='{cat.category}' where id={cat.Id};";
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