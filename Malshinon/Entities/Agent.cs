﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    public class Agent
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }

        public int NumberOfReports { get; set; }

        public float wordsAverage { get; set; }

        public Agent(string fullName)
        {

            FullName = fullName;
            
        }
    }
}
