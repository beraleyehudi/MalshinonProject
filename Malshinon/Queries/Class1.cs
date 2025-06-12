using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Queries
{
    internal class Class1
    {
        string Name;
        public Class1(string name)
        {
            this.Name = name;
        }

    }
    interface Beral
    {

    }
    internal class Class2 : Class1
    {
        public Class2(string name) : base(name)
        {
           
            
        }
    }
}
