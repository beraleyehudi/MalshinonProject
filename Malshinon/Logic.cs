using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using Malshinon.Queries;

namespace Malshinon
{
    public static class Logic
    {
        public static void AddReport(Agent agent)
        {
            string[] options = {"chioce specific target", "add new target" };
            string exit = "";
            do
            {
            string choice = AuxiliaryFunctions.PrintMenu("add report", options);
            Target target = null;


                switch (choice)
                {
                    case "chioce specific target":
                        // the following condition is for 
                        //Refinement of functionality - prevent the agent from 
                        //accessing reports that do not belong to him

                        //if (MalshinonDAL.IsExsist("reports", "idAgent" ,agent.Id))
                        //{

                        //Console.WriteLine("report by agent is exsist"); // for log
                        //Target[] targets = Get.GetTargetsByAgent(agent.Id);

                        Target[] targets = Get.GetTargets();
                        for (int i = 0; i < targets.Length; i++)
                        {
                            Console.Write($"{i + 1}: ");
                            targets[i].DisplayInfoForAgent();

                        }
                        int choice2 = int.Parse(AuxiliaryFunctions.Input("choice"));
                        target = targets[choice2 - 1];
                        //}
                        //else
                        //{
                        //    Console.WriteLine("no target that exsist");
                        //    target = CreateObgects.NewTarget();
                        //}

                        break;

                    case "add new target":
                        target = CreateObgects.NewTarget();
                        break;
                }
                if (MalshinonDAL.IsExsist("targets", "id", target.Id))
                {
                    Console.WriteLine("exsist");
                    //if (MalshinonDAL.IsDangerous(target) && !MalshinonDAL.IsExsist("alerts", "idTarget", target.Id))
                    //{
                    //    CreateObgects.NewAlert(target);

                    //}
                }
                else
                {
                    Add.AddTarget(target);
                }


                CreateObgects.NewReport(agent.Id, target.Id);
                DateTime[] timeWindow = Get.GetTimeWindow(target.Id);
                if (timeWindow.Length == 3)
                {
                    if (AuxiliaryFunctions.TimeWindowCheck(timeWindow[2], timeWindow[0]))
                    {
                        Update.UpdateTargetStatus(target.Id);
                        CreateObgects.NewAlert(target, $"{timeWindow[2].ToString()} - {timeWindow[0].ToString()}");
                    }

                }
                if (MalshinonDAL.IsPotenTial(agent))
                {
                    Console.WriteLine("potential");
                    Update.UpdateagentStatus(agent);
                }

                exit = AuxiliaryFunctions.Input("enter * if you want exit");

            } while (exit != "*");


        }


    }
}
            
           
           

                    
                    




                    

                   
                    





