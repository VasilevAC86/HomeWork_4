using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Product
{
    public class Money
    {        
        public int Whole { get; set; } // Целая часть денег (рубль, доллар)
        public int Fraction { get; set; } // Дробная часть денег (копейки, центы)
        public float Total() { return Whole + (float)(Fraction) / 100; }
        public void Print() { Console.WriteLine("\nСумма денег = " + Total() + " рублей"); }
    }
}
