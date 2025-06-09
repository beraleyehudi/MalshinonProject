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
        public int NumberOfReports { get; set; }
        public bool IsDangerous { get; set; }

        //public Target(string fullName, int numberOfReports, bool isDangerous)
        //{
        //    FullName = fullName;
        //    NumberOfReports = numberOfReports;
        //    IsDangerous = isDangerous;
        //}
    }
}
