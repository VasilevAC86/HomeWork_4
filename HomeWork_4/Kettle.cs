using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Devices
{
    public class Kettle:Device // Класс "Чайник"
    {
        public Kettle(string name, string description, string type) :base(name,description,type) { }
        
        public override void Sound() { Console.WriteLine(Name() + " свистит."); }
    }
}
