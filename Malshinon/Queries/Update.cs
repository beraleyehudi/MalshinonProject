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
        public static void UpdateNumberReportsBySpecificTarget(int idTarget)
        {
           string query = $"UPDATE targets SET numberOfreports = numberOfreports + 1 WHERE id = {idTarget}";
           MalshinonDAL.Update(query);
        }
           
            

        public static void UpdateNumberReportsBySpecificAgent(int idAgent)
        {
           
            string query = $"UPDATE agents SET numberOfreports = numberOfreports + 1 WHERE id = {idAgent}";
            MalshinonDAL.Update(query);
        }

        public static void UpdateTargetStatus(int idTarget)
        {
           
            string query = $"UPDATE targets SET isDangerous = 1 WHERE id = {idTarget}";
            MalshinonDAL.Update(query);
        }

        public static void UpdateWordsAverage(int idAgent, int wordsNumber)
        {

            string query = $"UPDATE agents SET wordsAverage = wordsAverage + {wordsNumber}/numberOfReports WHERE id = {idAgent}";
            MalshinonDAL.Update(query);
        }

        public static void UpdateagentStatus(Agent agent)
        {

            string query = $"UPDATE agents SET ispotenTial = 1 WHERE id = {agent.Id}";
            MalshinonDAL.Update(query);
        }
    }
}
