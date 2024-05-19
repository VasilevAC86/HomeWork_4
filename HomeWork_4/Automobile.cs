using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Devices
{
    public class Automobile:Device
    {
        public Automobile(string name, string description, string type) : base(name, description, type) { }

        public override void Sound() { Console.WriteLine(Name() + " шумит двигателем."); }
    }
}
