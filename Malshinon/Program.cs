using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Malshinon.Queries;

namespace Malshinon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent("berale");
            agent.wordsAverage = 9.9f;
            agent.NumberOfReports = 13;
            agent.Id = 212319164;


            if (!MalshinonDAL.IsExsist("agents", "id" ,agent.Id))
            {

                Add.AddAgent(agent);
            }
            else
            {
                Console.WriteLine("is exsist");
            }


            Logic.AddReport(agent);

            //string time = DateTime.Now.ToString();  
            //Console.WriteLine(time);
            //string s = "14:23:22";
            //Console.WriteLine();
        }
    }
}
           
            
            

           

