using P; // Пространство имён с живым игроком (задачи 1 и 2)
using Comp; // Пространство имён с компьютером (задачи 1 и 2)
using Dictionary; // Пространство имён азбуки Морзе (задачи 3 и 4)
using Money_Product; // Пространство имён для классов Money и Product (задача 5)
using My_Devices; // Пространство имён для иерархии классов "Устройство" (задача 6)
using Musical_Instruments; // Пространство имён для иерархии классов "Миузыкальный инструмент" (задача 7)
using Workers; // Пространство имён для иерархии классов "Работник" (задача 8)
using System.Timers;
using System.Net.Http.Headers;

namespace HomeWork_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------- Задачи 1, 2 - Игра "Крестики-нолики"-------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Игра 'Крестики-нолики'\n");
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Введи своё имя -> ");
            Player p1 = new Player(); // Создание объекта класса "Игрок" в namespece P
            Field f = new Field(); // Создание объекта класса "Игровое поле"
            p1.Name = Console.ReadLine();
            Console.Write("\nВыберите, с кем будете играть.\nНажмите \'1\' для игры с другим игроком " +
                "или нажмите любую другую клавишу для игры с компьютером.\nВаш выбор -> ");
            char choice = Convert.ToChar(Console.ReadLine());
            int counter_moves = 0; // Счётчик ходов
            bool p1_win = false; // Флаг победы игрока 1
            bool p2_win = false; // Флаг победы игрока 2 или компьютера
            bool first_p1 = true; // По умолчанию, первый ход делает игрок 1
            Random r = new Random();
            if (r.Next(0, 2) == 0) // Определяем, кто делает первый ход
            {
                Console.WriteLine("\nПервый ход делает Ваш противник");
                first_p1 = false;
            }
            else
            {
                Console.WriteLine("\nПервый ход делает " + p1.Name);
                first_p1 = true;
            }            
            if (choice == '1') // Режим игры "Игрок против игрока"
            {
                Player p2 = new Player();
                Console.Write("\nВведи имя второго игрока -> ");
                p2.Name = Console.ReadLine();
                while (counter_moves <= f.Size() * f.Size() && !p1_win && !p2_win) // Цикл игры игрока с игроком
                {
                    Console.Write("\nДля продолжения нажмите любую клавишу ");
                    Console.ReadKey(true);
                    Console.Clear();
                    f.Draw();
                    if (first_p1)
                    {
                        if (counter_moves % 2 == 0)
                        {
                            p1.Move(f, 'X');
                            if (f.Win('X'))
                                p1_win = true;
                        }
                        else
                        {
                            p2.Move(f, 'O');
                            if (f.Win('O'))
                                p2_win = true;
                        }
                    }
                    else
                    {
                        if (counter_moves % 2 == 0)
                        {
                            p2.Move(f, 'X');
                            if (f.Win('X'))
                                p2_win = true;
                        }
                        else
                        {
                            p1.Move(f, 'O');
                            if (f.Win('O'))
                                p1_win = true;
                        }
                    }
                    counter_moves++;
                    Console.Clear();
                    Console.WriteLine("Результаты хода:");
                    f.Draw();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nИгра закончена!\n");
                if (p1_win)
                    Console.WriteLine("Победитель - " + p1.Name + "\n");
                else
                    if (p2_win)
                    Console.WriteLine("Победитель - " + p2.Name + "\n");
                else
                    Console.WriteLine("Ничья!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else // Режим игры игрок против компьютера
            {
                Computer comp = new Computer();
                while (counter_moves <= f.Size() * f.Size() && !p1_win && !p2_win) // Цикл игры "Игрок против компьютера"
                {
                    if (first_p1 && counter_moves % 2 == 0) // Когда первым ходит игрок
                    {
                        Console.Write("\nДля продолжения нажмите любую клавишу ");
                        Console.ReadKey(true);
                        Console.Clear();
                        f.Draw();
                        p1.Move(f, 'X');
                        if (f.Win('X'))
                            p1_win = true;
                        Console.Clear();
                        Console.WriteLine("Результаты хода:");
                        f.Draw();
                    }
                    else                    
                        if (!first_p1 && counter_moves % 2 != 0) // Когда игрок ходит вторым
                        {
                            Console.Write("\nДля продолжения нажмите любую клавишу ");
                            Console.ReadKey(true);
                            Console.Clear();
                            f.Draw();
                            p1.Move(f, 'O');
                            if (f.Win('O'))
                              p1_win = true;
                          Console.Clear();
                          Console.WriteLine("Результаты хода:");
                          f.Draw();
                    }                    
                    if (!first_p1 && counter_moves % 2 == 0) // Когда первым ходит компьютер
                    {
                        Console.Write("\nДля продолжения нажмите любую клавишу ");
                        Console.ReadKey(true);
                        comp.Move(f, 'X');
                        if (f.Win('X'))
                            p2_win = true;                                                                      
                    }
                    else                    
                        if (first_p1 && counter_moves % 2 != 0) // Когда компьютер ходит вторым
                        {
                            comp.Move(f, 'O');
                            if (f.Win('O'))
                                p2_win = true;
                        }                        
                    counter_moves++;                    
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nИгра закончена!\n");
                if (p1_win)
                    Console.WriteLine("Победитель - " + p1.Name + "\n");
                else
                    if (p2_win)
                    Console.WriteLine("Победитель - " + comp.Name + "\n");
                else
                    Console.WriteLine("Ничья!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            // ---------------- Задачи 3, 4 - Азбука Морзе --------------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nАзбука Морзе\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите текст на русском языке -> ");
            string str = Console.ReadLine().ToUpper();            
            string result = "";
            Morse m = new Morse();
            foreach (char el in str)
                result += m.Translate(Convert.ToString(el));
            Console.WriteLine("\nВведённый текст на азбуке Морзе:\n" + result + "\n\nОбратный перевод в русский язык:\n");
            str = ""; 
            for (int i = 0; i < result.Length; i++)
            {                
                if (result[i] == '1' || result[i] == '2')
                {
                    str += m.Translate_Back(result.Substring(0, i));
                    if (result[i] == '2' && i != 0)
                        str += ' ';                    
                    result = result.Remove(0, i + 1);                    
                    i = -1;
                }
            }
            Console.WriteLine(str);

            // ---------------- Задача 5 - Класс Money -------------------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 5 - Класс Money\n");
            Console.ForegroundColor = ConsoleColor.White;
            Money money = new Money();
            Console.Write("Введите целую часть денег без копеек -> ");
            money.Whole = Exception(Console.ReadLine());
            Console.Write("\nВведите дробную часть денег (копейки) -> ");
            money.Fraction = Exception(Console.ReadLine());            
            money.Print();
            Product p = new Product("Ноутбук", "Asus");
            p.Whole = 99999;
            p.Fraction = 99;
            Console.WriteLine();
            Console.Write(p.Type + ", " + p.Name);
            p.Print();
            Console.Write("Введите сумму скидки (от 0 до " + p.Total() + ") -> ");
            double discount = Convert.ToDouble(Console.ReadLine());
            while (discount > p.Whole || discount < 0) 
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Ошибка ввода!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите сумму скидки (от 0 до " + p.Total() + ") -> ");
                discount = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("\nС учётом скидки товар стоит: " + p.Discount((float)discount) + " рублей.");

            // ---------------- Задача 6 - Класс "Устройство" ---------------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 6 - Класс \'Устройства\'\n");
            Console.ForegroundColor = ConsoleColor.White;
            Kettle kettle = new Kettle("Чайник Tefal", "Для кипечения воды", "Бытовой прибор");
            Microwave microwave = new Microwave("Микроволновая печь Sumsung", "Для разогревания еды", "Бытовой прибор");
            Automobile automobile = new Automobile("Автомобиль Porshe Caen", "Для перевозки пассажиров", "Транспорт");
            Steamship steamship = new Steamship("Пароход \'Чёрная вдова\'", "Для круизных туров", "Транспорт");
            Console.WriteLine("Мой устройства:\n");
            kettle.Show();
            kettle.Desc();
            kettle.Sound();
            Console.WriteLine();
            microwave.Show();
            microwave.Desc();
            microwave.Sound();
            Console.WriteLine();
            automobile.Show();
            automobile.Desc();
            automobile.Sound();
            Console.WriteLine();
            steamship.Show(); 
            steamship.Desc();
            steamship.Sound();

            // ---------------- Задача 7 - Класс "Музыкальный инструмент" ---------------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 7 - Класс \'Музыкальный инструмент\'\n");
            Console.ForegroundColor = ConsoleColor.White;
            Violin violin = new Violin("Скрипка", "Музыкальный инструмент", "История насчитывает более двух тысячелетий. Появилась в Индии.");
            violin.Show();
            violin.Desc();
            violin.History();
            violin.Sound();
            Console.WriteLine();
            Trombone trombone = new Trombone("Тромбон", "Музыкальный инструмент", "Появление тромбона относится к XV веку. В основном использовались в церквях. Популярны стали в XX веке.");
            trombone.Show();
            trombone.Desc();
            trombone.History();
            trombone.Sound();
            Console.WriteLine();
            Ukulele ukulele = new Ukulele("Укулеле", "Музыкальный инструмент", "Изобретена португальцем Мануэлем Нуньесом в 1880-е годы. В основу нового инструмента он положил миниатюрную гитару и португальскую миниатюрную гитару.");
            ukulele.Show();
            ukulele.Desc(); 
            ukulele.History();
            ukulele.Sound();
            Console.WriteLine();
            Cello cello = new Cello("Виолончель", "Музыкальный инструмент", "Появилась к конце XV/начале XVI века в результате длительного развития народных смычковых инструментов.");
            cello.Show();
            cello.Desc();
            cello.History();
            cello.Sound();

            // ---------------- Задача 8 - Абстрактный класс "Worker" ---------------------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 8 - Абстрактный класс \'Worker\'\n");
            Console.ForegroundColor = ConsoleColor.White;
            President president = new President("Пупкин Иван Дмитриевич", "Генеральный деректор", 150000);
            president.Print();
            Securirty securirty = new Securirty("Онищенко Александр Сергеевич", "Охранник", 45000);
            securirty.Print();
            Manager manager = new Manager("Компотов Сергей Семёнович", "Менеджер", 85000);
            manager.Print();
            Engineer engineer = new Engineer("Васнецов Илья Алексееевич", "Инженер", 65000);
            engineer.Print();
        }
        static int Exception(string message) // Метод обработки введённого пользователем значения                                             
        {
            int number = 0;
            // Если введённое значение можно преобразовать в int, то записываем его в number
            if (int.TryParse(message, out number)) { }
            if (number < 1) // если введено не положительное целочисленное число, то 
            {
                while (!int.TryParse(message, out int value) || number < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Введённое некорректное значение! Введите целое число, больше нуля ещё один раз -> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    message = Console.ReadLine();
                    if (int.TryParse(message, out number)) { }
                }
            }
            return number;
        }
    }  
}