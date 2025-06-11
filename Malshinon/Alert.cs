using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public class Alert
    {
        
        public Target Target { get; set; }
        public int Id { get; set; }
        public int IdTarget { get; set; }
        public float TimeWindow { get; set; }
        public string Reason { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
