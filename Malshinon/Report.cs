using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public class Report
    {
        public Agent Agent { get; set; }
        public Target Target { get; set; }
        public int Id { get; set; }

        public int IdAgent { get; set; }
        public int IdTarget { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;

       

    }
}
