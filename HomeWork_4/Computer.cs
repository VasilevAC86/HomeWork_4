using HomeWork_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp
{
    public class Computer // Класс "Игрок - Компьютер"
    {
        private string name_ = "Компьютер";
        public string Name { get { return name_; } }
        public void Move(Field obj, char sym)
        {
            Random rnd = new Random();
            int row = rnd.Next(0, obj.Size());
            int col = rnd.Next(0, obj.Size());
            while (obj.Check(row, col)) // Пока координата (row, col) не будет свободна
            {
                row = rnd.Next(0, obj.Size());
                col = rnd.Next(0, obj.Size());
            }
            obj.Arr(row, col, sym);
            Console.Clear();
            obj.Draw();
            Console.WriteLine("\n" + name_ + " сделал ход в клетку (" + (col + 1) + ", " + (char)(65 + row) + ").");            
        }
    }
}
