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
            string query = $"SELECT * FROM {tablt} WHERE id = {id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
            return cmd.ExecuteScalar() != null;
            
        }

        public static bool IsDangerous(Target target)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"SELECT isDangerous, numberOfReports FROM targets WHERE id = {target.Id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int reportsNumber = reader.GetInt16("numberOfReports");
            return reader.GetBoolean("isDangerous") || reportsNumber >= 20;
        }

        //public static void AddGeneral(string table, string[] parameters, string[] values )
        //{

        //}

        public static void Add(string table, Dictionary<string, string> parameters)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string parameter = $"INSERT INTO {table}(";
            string value = "VALUES(";
            string query = "";

            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                parameter += kvp.Key + ",";
                value += "@" + kvp.Key + ",";
            }
            parameter = AuxiliaryFunctions.ReplaceLastChar(parameter, ')');
            value = AuxiliaryFunctions.ReplaceLastChar(value, ')');
            
            query += parameter + value;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            foreach(KeyValuePair<string, string> kvp in parameters)
            {
                cmd.Parameters.AddWithValue($"@{kvp.Key}", kvp.Value);
            }
            Console.WriteLine(query);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateNumberReportsBySpecificTarget(Target target)
        {
            MySqlConnection conn = new MySqlConnection (stringConnection);
            conn.Open();
            string query = $"UPDATE targets SET numberOfreports = numberOfreports + 1 WHERE id = {target.Id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateNumberReportsBySpecificAgent(Agent agent)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"UPDATE agents SET numberOfreports = numberOfreports + 1 WHERE id = {agent.Id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
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

        public static Target[] GetTargets()
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
            return targests.ToArray();

        }
            
    }
}

                



           
            

            


        





        
        



