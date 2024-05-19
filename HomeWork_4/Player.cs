using HomeWork_4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P
{
    public class Player // Класс "Игрок"
    {
        public string Name { get; set; }
        public void Move(Field obj, char sym)
        {            
            Console.Write("\n" + Name + "! Делайте ход!\nВведите координату клетки поля.\nВведите " +
                "координату столбца (от 1 до " + obj.Size() + ") -> ");
            int col = Exc_int(Console.ReadLine(), obj.Size());
            Console.Write("\nВведите координату строки (от А до " + (char)(64 + obj.Size()) + ") -> ");
            char row = Exc_char(Console.ReadLine(), obj.Size());            
            while (obj.Check((int)(row - 64) - 1, col - 1)) 
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Клетка занята! Сделайте ход в другую клетку!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nВведите координату клетки поля.\nВведите координату столбца (от 1 до " + obj.Size() + ") -> ");
                col = Exc_int(Console.ReadLine(), obj.Size());
                Console.Write("\nВведите координату строки (от А до " + (char)(64 + obj.Size()) + ") -> ");
                row = Exc_char(Console.ReadLine(), obj.Size());
            }
            obj.Arr((int)(row - 64) - 1, col - 1, sym); // Записываем в массив ход игрока            
        }
        static int Exc_int(string message, int size) // Метод обработки введённого пользователем значения                                             
        {
            int number = 0;
            // Если введённое значение можно преобразовать в int, то записываем его в number
            if (int.TryParse(message, out number)) { }
            if (number < 1 || number > size) 
            {
                while (!int.TryParse(message, out int value) || number < 1 || number > size)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Введённое некорректное значение! Введите координату столбца (от 1 до " + size + ") ещё раз -> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    message = Console.ReadLine();
                    if (int.TryParse(message, out number)) { }
                }
            }
            return number;
        }
        static char Exc_char(string message, int size) // Метод обработки введённого пользователем значения                                             
        {
            char sym = (char)0;
            // Если введённое значение можно преобразовать в int, то записываем его в number
            if (char.TryParse(message.ToUpper(), out sym)) { }
            if (sym < 'A' || sym > (char)(64 + size))
            {
                while (!char.TryParse(message, out char value) || sym < 'A' || sym > (char)(64 + size))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Введённое некорректное значение! Введите координату строки (от А до " + (char)(64 + size) + ") ещё раз -> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    message = Console.ReadLine();
                    if (char.TryParse(message.ToUpper(), out sym)) { }
                }
            }
            return sym;
        }
    }    
}
