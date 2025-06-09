using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon
{
    public static class MalshinonDAL
    {
        static string stringConnection =
            "server=localhost;" +
            "user=root;" +
            "database=malshinon;" +
            "port=3306;";

        public static bool IsExsist(string tablt, int id)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"SELECT CASE WHEN EXISTS (SELECT 1 FROM {tablt} WHERE id = {id}) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            return (bool)cmd.ExecuteScalar();
        }

        public static bool IsDangerous(Target target)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"SELECT isDangrous, numberOfReports FROM targets WHERE id = {target.Id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            int reportsNumber = reader.GetInt16("numberOfReports");
            return reader.GetBoolean("isDangerous") || reportsNumber >= 20;
        }



        public static void AddTarget(Target target)
        {
           
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"INSERT INTO targets(fullName, numberOfReports)" +
                $"VALUES(@fullName, @numberOfreports";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@fullname", target.FullName);
            cmd.Parameters.AddWithValue("@numberOfReports", target.NumberOfReports);
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public static void AddReport(Report report)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"INSERT INTO reports(idAgent, idTarget, text, timeStamp)" +
                $"VALUES(@idAgent, @idTarget, @text, @timeStamp";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idAgent", report.IdAgent);
            cmd.Parameters.AddWithValue("@idTarget", report.IdTarget);
            cmd.Parameters.AddWithValue("@text", report.Text);
            cmd.Parameters.AddWithValue("@timeStamp", report.TimeStamp);
            cmd.ExecuteNonQuery ();
            conn.Close();

        }

        public static void AddAlert(Alert alert)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"INSERT INTO alerts(idTarget,timeWindow, reason, timeStamp)" +
                $"VALUES(@idTarget, @timeWindow, @reason, @timeStamp)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tineWindow", alert.TimeWindow);
            cmd.Parameters.AddWithValue("@idTarget", alert.IdTarget);
            cmd.Parameters.AddWithValue("@reason", alert.Reason);
            cmd.Parameters.AddWithValue("@timeStamp", alert.TimeStamp);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void UpdateNumberReportsByTarget(Target target)
        {
            MySqlConnection conn = new MySqlConnection (stringConnection);
            conn.Open();
            string query = $"UPDATE targets SET numberOfreports = numberOfreports + 1 WHERE id = {target.Id}";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateTargetStatus(Target target)
        {
            MySqlConnection conn = new MySqlConnection (stringConnection);
            conn.Open();
            string query = $"UPDATE targets SET isDangerous = 1 WHERE id = {target.Id}";
            MySqlCommand cmd = new MySqlCommand (query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Target> GetTargets()
        {
            List<Target> targests = new List<Target>();
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = "SELECT * FROM targets";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

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
            conn.Close();
            return targests;

        }

                



           
            

            


        





        
        
            
    }
}
