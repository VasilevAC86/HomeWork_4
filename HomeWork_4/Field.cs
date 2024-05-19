using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4
{
    public class Field // Класс "Игровое поле"
    {
        private const int size_ = 10; // Размер поля с учётом разграничителей игровых клеток и координат
                                      // (реальное * 2, т.е. для игры на поле 3х3 size_ = 6, 4х4 size_ = 8  и т.д.)
        private char[,] arr_ = new char[size_/2,size_/2]; // Массив ходов игроков
        public int Size() { return size_ / 2; }
        public void Arr(int row, int col, char sym) { this.arr_[row, col] = sym; } // Сеттер хода игрока
        public bool Check(int row, int col) // Метод проверки клетки поля на возможность хода
        {
            if (arr_[row, col] != ' ')
                return true;
            return false;
        }
        public bool Win(char sym) // Метод проверки условия выйгрыша
        {
            for (int i = 0; i < size_/2; ++i) // Цикл проверки при поиске влево, вниз от точки
                for (int j = 0; j < size_/2; ++j)                
                    if (arr_[i, j] == sym)
                    {
                        if (j + 2 >= size_ / 2) // Вышли за правую границу
                            if (i + 2 >= size_ / 2) // Вышли за нижнюю границу
                                break;
                            else // Если не вышли за нижнюю границу
                            {
                                if (arr_[i + 1, j] == sym && arr_[i + 2, j] == sym) // Проверка нижней вертикали
                                    return true;
                                if (j - 2 >= 0) // Если не вышли за левую границу
                                    if (arr_[i + 1, j - 1] == sym && arr_[i + 2, j - 2] == sym) // Влево вниз по диагонали
                                        return true;                                    
                            }
                        if (j + 2 < size_ / 2) // Если не вышли за правую границу
                        {
                            // Проверка справа горизонтали и нижней правой диагонали
                            if (arr_[i, j + 1] == sym && arr_[i, j + 2] == sym)
                                return true;
                            if (i + 2 < size_ / 2) // Если не вышли за нижнюю границу
                            { 
                                if (arr_[i + 1, j] == sym && arr_[i + 2, j] == sym) // Проверка нижней вертикали
                                    return true;
                                if (arr_[i + 1, j + 1] == sym && arr_[i + 2, j + 2] == sym) // Проверка нижней правой диагонали
                                    return true;
                                if (j - 2 >= 0) // Если не вышли за левую границу
                                    if (arr_[i + 1, j - 1] == sym && arr_[i + 2, j - 2] == sym) // Влево вниз по диагонали
                                        return true;
                            }
                        }
                    }                
            return false;
        }
        public Field() // Явно прописанный конструктор по умолчанию для заполнения массива пробелами
        { 
            for (int i = 0; i < size_ / 2; i++)
                for (int j = 0; j < size_ / 2; j++) 
                    arr_[i,j] = ' ';
        }
        public void Draw() // Метод отрисовки игрового поля с данными массива arr_
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nИгровое поле:\n");
            Console.ForegroundColor= ConsoleColor.White;
            int rows = 65; // Счётчик наименований строк
            int cols = 1; // Счётчик наименований столбцов
            for (int i = 0; i < size_ + 2; ++i)
            {
                for (int j = 0; j < size_ + 2; ++j)
                {
                    if (i == 0 && j == 0) 
                    {
                        Console.Write(' ');
                        continue;
                    }
                    if (i == 0 && j % 2 == 0)
                    {
                        Console.Write(cols);
                        cols++;
                        continue;
                    }
                    if (j == 0 && i % 2 == 0)
                    {
                        Console.Write((char)rows);
                        rows++;
                        continue;
                    }
                    if (j % 2 != 0 && i % 2 == 0)
                    {
                        Console.Write('|');
                        continue;
                    }
                    if (i % 2 != 0)
                    {
                        Console.Write('-');
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(arr_[(i - 2) / 2, (j - 2) / 2]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine();
            }            
        }
    }
}
