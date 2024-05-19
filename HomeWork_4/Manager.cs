using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Manager:Worker
    {
        public Manager(string name, string job, int salary) : base(name, job, salary) { }
        public override void Print() { Console.WriteLine(Name + ". " + Job + ". Заработная плата = " + Salary + " рублей."); }
    }
}
