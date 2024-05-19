using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public abstract class Worker // Абстрактный класс "Работник"
    {   
        public string Name { get; set; } // ФИО
        public string Job { get; set; } // Должность
        public int Salary { get; set; } // Зарплата
        public Worker(string name, string job, int salary)
        {
            Name = name;
            Job = job;
            Salary = salary;
        }

        public abstract void Print();
    }
}
