using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Queries
{
    public static class Get
    {
        public static Target[] GetTargets()
        {
            List<Target> targests = new List<Target>();
            string query = "SELECT * FROM targets";
            MySqlDataReader reader = MalshinonDAL.Get(query);

            while (reader.Read())
            {
                Target target = new Target();
                target.Id = reader.GetInt32("id");
                target.FullName = reader.GetString("fullName");
                target.NumberOfReports = reader.GetInt16("numberOfreports");
                target.IsDangerous = reader.GetBoolean("isDangerous");
                targests.Add(target);
            }
            reader.Close();
            return targests.ToArray();
        }

        public static Target[] GetTargetsByAgent(int Idagent)
        {
            List<Target> targests = new List<Target>();
            string query = "SELECT DISTINCT t.fullName, t.id" +
                "FROM targets t" +
                "INNER JOIN reports r ON t.id = r.idTarget" +
                "INNER JOIN agents a ON a.id = r.idAgent" +
                $"WHERE a.id = {Idagent}";
               
           
            MySqlDataReader reader = MalshinonDAL.Get(query);

            while (reader.Read())
            {
                Target target = new Target();
                target.Id = reader.GetInt32("id");
                target.FullName = reader.GetString("fullName");
                targests.Add(target);
            }
            reader.Close();
            return targests.ToArray();
        }

        public static Agent[] GetAgents()
        {
            List<Agent> agents = new List<Agent>();
            string query = "SELECT * FROM agents";
            MySqlDataReader reader = MalshinonDAL.Get(query);

            while (reader.Read())
            {
                Agent agent = new Agent(reader.GetString("fullName"));
                agent.Id = reader.GetInt32("id");
                agent.NumberOfReports = reader.GetInt16("numberOfreports");
                agents.Add(agent);
            }
            reader.Close();
            return agents.ToArray();
        }





        public static Report[] GetReports()
        {
            List<Report> reports = new List<Report>();
            string query = "SELECT * FROM reports";
            MySqlDataReader reader = MalshinonDAL.Get(query);

            while (reader.Read())
            {
                Report report = new Report();
                report.IdAgent = reader.GetInt32("idAgent");
                report.IdTarget = reader.GetInt16("idTarget");
                report.Text = reader.GetString("text");
                reports.Add(report);
            }
            reader.Close();
            return reports.ToArray();

        }

        public static DateTime[] GetTimeWindow(int idTarget)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            string query = "SELECT timeStamp FROM `reports`" +
                $"WHERE idTarget = {idTarget} " +
                "ORDER BY timeStamp DESC LIMIT 3";
            MySqlDataReader reader = MalshinonDAL.Get(query);
            while (reader.Read())
            {
                dateTimes.Add(reader.GetDateTime("timeStamp"));
            }
            return dateTimes.ToArray();
        }


    }
}
            
            
            
            

