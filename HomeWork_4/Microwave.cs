using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Devices
{
    public class Microwave:Device
    {
        public Microwave(string name, string description, string type) : base(name, description, type) { }

        public override void Sound() { Console.WriteLine(Name() + " громко пищит."); }
    }
}
