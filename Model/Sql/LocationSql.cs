using bridge_api.Models.Locations;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace bridge_api.Models.Sql
{
    public class LocationSql : SqlCon
    {
        public void InsertCountryInDB(Location loc)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"INSERT INTO `countries` (`country`) VALUES (`{loc.country}`)";
            
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

        public List<string> GetCountryFromDB()
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select * from `countries`;";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            List<string> CountryList = new List<string>();
            while(result.Read())
            {
               CountryList.Add(result["country"].ToString());
            }
            con.Close();
            return CountryList;
        }

        public void UpdateCountryToDB(Location loc)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `countries` set `country`='{loc.country}' where id={loc.CountryID};";
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


        public void InsertCityInDB(Location loc)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"INSERT INTO `cities` (`city`, `countryId`) VALUES (`{loc.city}`, `{loc.CountryID}`)";
            
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

        public List<string> GetCityFromDB(String city)
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select DISTINCT * from cities where city like '{city}%';";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            List<string> CityList = new List<string>();
            while(result.Read())
            {
                Location loc = new Location();
                //loc.cityID = Convert.ToUInt32(result["id"]);
                CityList.Add(result["city"].ToString());
            }
            con.Close();
            return CityList;
        }

        public List<string> GetAllCitiesFromDB()
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select DISTINCT city from `cities` ORDER BY 'city';";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            List<string> CityList = new List<string>();
            while(result.Read())
            {
                Location loc = new Location();
                //loc.cityID = Convert.ToUInt32(result["id"]);
                loc.city = result["city"].ToString();
                CityList.Add(loc.city);
            }
            con.Close();
            return CityList;
        }

        public void UpdateCityToDB(Location loc)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `cities` set `city`='{loc.city}' where id={loc.cityID};";
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