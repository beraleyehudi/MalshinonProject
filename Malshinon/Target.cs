using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public class Target
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int NumberOfReports { get; set; } = 0;
        public bool IsDangerous { get; set; }

 
        public void DisplayInfo()
        {
            Console.WriteLine($"full name: {FullName} |" +
                              $" number of reports {NumberOfReports} |" +
                              $" is dangerous: {IsDangerous}");
        }
      
    }
}
