using System;
using System.Collections.Generic;
using System.Linq;
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
            string choice = AuxiliaryFunctions.PrintMenu("add report", options);
            Target target = null;

            switch(choice)
            {
                case "chioce specific target":
                    Target[] targets = Get.GetTargets();
                    for (int i = 0; i < targets.Length; i++)
                    {
                        Console.Write($"{i + 1}: ");
                        targets[i].DisplayInfo();

                    }
                    int choice2 = int.Parse(AuxiliaryFunctions.Input("choice"));
                    target = targets[choice2 - 1];
                    break;

                case "add new target":
                    target = CreateObgects.NewTarget(); 
                    break;
            }
            if (MalshinonDAL.IsExsist("targets", target.Id))
            {
                Console.WriteLine("exsist");
                if (MalshinonDAL.IsDangerous(target) && !MalshinonDAL.IsExsist("alerts", target.Id))
                {
                    CreateObgects.NewAlert(target);

                }
            }
            else
            {
                Add.AddTarget(target);
            }
            CreateObgects.NewReport(agent.Id, target.Id);
            if (MalshinonDAL.IsPotenTial(agent))
            {
                Console.WriteLine("potential");
                Update.UpdateagentStatus(agent);
            }


        }


    }
}
            
           
           

                    
                    




                    

                   
                    





