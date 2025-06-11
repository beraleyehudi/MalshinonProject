using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;

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
            // עכשווי רק כדי לקשר בין האיי די
            Agent[] agents = Get.GetAgents();
            agent.Id = agents[agents.Length - 1].Id;
        }


        public static void AddTarget(Target target)
        {
            string table = "targets";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("fullName", target.FullName);
            parameters.Add("numberOfReports", target.NumberOfReports.ToString());
            MalshinonDAL.Add(table, parameters);
            // עכשווי רק כדי לקשר בין האיי די
            Target[] targets = Get.GetTargets();
            target.Id = targets[targets.Length - 1].Id;


        }

        public static void AddReport(Report report)
        {
            string table = "reports";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idAgent", report.IdAgent.ToString());
            parameters.Add("idTarget", report.IdTarget.ToString());
            parameters.Add("text", report.Text);
            MalshinonDAL.Add(table, parameters);

        }

        public static void AddAlert(Alert alert)
        {

            string table = "agents";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idTarget", alert.IdTarget.ToString());
            MalshinonDAL.Add(table, parameters);

        }





    }
}
