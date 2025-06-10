using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Malshinon.Queries
{
    public static class Add
    {
        public static void AddAgent(Agent agent)
        {
            string table = "agents";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("fullName", agent.FullName);
            parameters.Add("numberOfReports", agent.NumberOfReports.ToString());
            MalshinonDAL.Add(table, parameters);
        }



        public static void AddTarget(Target target)
        {
            string table = "targets";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("fullName", target.FullName);
            parameters.Add("numberOfReports", target.NumberOfReports.ToString());
            MalshinonDAL.Add(table, parameters);
        }



        public static void AddReport(Report report)
        {
            string table = "reports";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idAgent", report.IdAgent.ToString());
            parameters.Add("idTarget", report.IdTarget.ToString());
            parameters.Add("text", report.Text);
            parameters.Add("@timeStamp", report.TimeStamp.ToString());
            MalshinonDAL.Add(table, parameters);

        }

        public static void AddAlert(Alert alert)
        {

            string table = "agents";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idTarget", alert.IdTarget.ToString());
            parameters.Add("timeStamp", alert.TimeStamp.ToString());
            MalshinonDAL.Add(table, parameters);

        }



    }
}
