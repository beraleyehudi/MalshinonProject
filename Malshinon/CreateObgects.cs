using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Queries;

namespace Malshinon
{
    public static class CreateObgects
    {
        public static void NewReport(int idAgent, int idTarget)
        {
            Report report = new Report();
            //report.Agent = agent;
            //report.Target = target;
            report.IdAgent = idAgent;
            report.IdTarget = idTarget;
            report.Text = AuxiliaryFunctions.Input("What is the report?");
            report.WordsLength = AuxiliaryFunctions.WordsLength(report.Text);
            Add.AddReport(report);
            Update.UpdateNumberReportsBySpecificTarget(idTarget);
            Update.UpdateNumberReportsBySpecificAgent(idAgent);
            Update.UpdateWordsAverage(idAgent, report.WordsLength);

            
        }
        public static Target NewTarget()
        {
            Target target = new Target();
            target.FullName = AuxiliaryFunctions.Input("Enter name of target");
            target.Id = int.Parse(AuxiliaryFunctions.Input("Enter his id"));
            

            return target;
        }
        public static Alert NewAlert(Target target)
        {

            AuxiliaryFunctions.AlertMessage();
            Alert alert = new Alert();
            alert.Target = target;
            alert.IdTarget = target.Id;
            //alert.Reason = Input("Enter a reason");
            Add.AddAlert(alert);
            return new Alert();
        }

    }
}
