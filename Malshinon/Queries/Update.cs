using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Queries
{
    public static class Update
    {
        public static void UpdateNumberReportsBySpecificTarget(Target target)
        {
           string query = $"UPDATE targets SET numberOfreports = numberOfreports + 1 WHERE id = {target.Id}";
        }
           
            

        public static void UpdateNumberReportsBySpecificAgent(Agent agent)
        {
           
            string query = $"UPDATE agents SET numberOfreports = numberOfreports + 1 WHERE id = {agent.Id}";
          
        }

        public static void UpdateTargetStatus(Target target)
        {
           
            string query = $"UPDATE targets SET isDangerous = 1 WHERE id = {target.Id}";
           
        }

    }
}
