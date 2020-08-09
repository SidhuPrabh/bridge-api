using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using bridge_api.Models.Leads;

namespace bridge_api.Models.Sql
{
    public class LeadsSql : SqlCon
    {
        public void InsertLeadToDB(Lead lead)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"INSERT INTO `leads` (`cId`, `bId`, `CatId`, `dateTimeCreated`, `status`, `city`, `workDetails`, `dateTimeDelivery`, `isHired`, `quoteRequest`, `quoteSent`, `quoteRequestedDateTime`, `quoteSentDateTime`) VALUES ({lead.cId}, {lead.bId}, {lead.catId}, `{lead.dateTimeCreated}` '{lead.status}', '{lead.city}' '{lead.workDetails}', '{lead.dateTimeDelivery}', {lead.isHired}, {lead.quoteRequested}, {lead.quoteSent}, {lead.quoteRequestedDateTime}, {lead.quoteSentDateTime});";
            
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

        public void UpdateLeadStatusToDB(Lead lead)
        {
            MySqlConnection con = CreateConnection();
            string cmdText = $"UPDATE `leads` SET `status`='{lead.status}' where `id`={lead.id};";          
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

        public List<Lead> GetLeadsFromDB(int bId)
        {
            MySqlConnection con = this.CreateConnection();
            string cmdText = $"select * from `leads` where `bId` = {bId};";
            MySqlCommand cmd = new MySqlCommand(cmdText, con);
            var result = cmd.ExecuteReader();
            List<Lead> leadList = new List<Lead>();
            while(result.Read())
            {
                Lead l = new Lead();
                
                l.id = Convert.ToUInt32(result["id"]);
                l.cId = Convert.ToUInt32(result["cId"]);
                l.bId = Convert.ToUInt32(result["bId"]);
                l.catId = Convert.ToUInt32(result["cId"]);
                l.dateTimeCreated = result["dateTimeCreated"].ToString();
                l.status = result["status"].ToString();
                l.city = Convert.ToUInt32(result["city"]);
                l.dateTimeDelivery = result["dateTimeDelivery"].ToString();
                l.workDetails = result["details"].ToString();
                l.isHired = Convert.ToBoolean(result["isHired"]);
                l.quoteRequested = Convert.ToBoolean(result["quoteRequested"]);
                l.quoteSent = Convert.ToBoolean(result["quoteSent"]);
                l.quoteRequestedDateTime = result["quoteRequestedDateTime"].ToString();
                l.quoteSentDateTime = result["quoteSentDateTime"].ToString();

                leadList.Add(l);
            }
            con.Close();
            return leadList;
        }

    }
}