using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instruments
{
    public class Cello:Instrument
    {
        public Cello(string name, string description, string history) : base(name, description, history) { }

        public override void Sound() { Console.WriteLine(Name() + " играет виолончель."); }
    }
}
