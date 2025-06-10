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
        public static Report NewReport(Agent agent, Target target)
        {
            Report report = new Report();
            report.Agent = agent;
            report.Target = target;
            report.IdAgent = agent.Id;
            report.IdTarget = target.Id;
            report.Text = AuxiliaryFunctions.Input("What is the report?");

            return report;
        }
        public static Target NewTarget()
        {
            Target target = new Target();
            target.FullName = AuxiliaryFunctions.Input("Enter name of target");
            Add.AddTarget(target);

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
