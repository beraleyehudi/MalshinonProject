using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Queries;

namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent("berale2");
            agent.wordsAverage = 9.9f;
            agent.NumberOfReports = 13;


            Add.AddAgent(agent);


            Logic.AddReport(agent);
        }
    }
}

           

