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
    }
}
            
            
            
            

