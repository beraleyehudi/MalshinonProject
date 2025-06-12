using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

namespace Malshinon
{
    public static class MalshinonDAL
    {
        static string stringConnection =
            "server=localhost;" +
            "user=root;" +
            "database=malshinon;" +
            "port=3306;";

        public static bool IsExsist(string tablt, string condition ,int id)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"SELECT * FROM {tablt} WHERE {condition} = {id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            
            return cmd.ExecuteScalar() != null;
            
        }

        public static bool IsPotenTial(Agent agent)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"SELECT wordsAverage, numberOfReports FROM agents WHERE id = {agent.Id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                int numberOfReports = reader.GetInt16("numberOfReports");
                float wordsAverage = reader.GetFloat("wordsAverage");
                return wordsAverage >= 100 && numberOfReports >= 10;
            }
            catch
            {
                return false;
            }

        }

        public static bool IsDangerous(Target target)
        {
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            string query = $"SELECT isDangerous, numberOfreports FROM targets WHERE id = {target.Id}";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                int reportsNumber = reader.GetInt16("numberOfreports");
                return reader.GetBoolean("isDangerous") || reportsNumber >= 20;
            }
            catch
            {
                return false;
            }
        }

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

        public static void Update(string query)
        {
            MySqlConnection conn = new MySqlConnection (stringConnection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

       
       
        public static MySqlDataReader Get(string query)
        {
            
            MySqlConnection conn = new MySqlConnection(stringConnection);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
           
            MySqlDataReader reader = cmd.ExecuteReader();
   

            
           
            return reader;

        }

    }
}

                



           
            

            


        





        
        



