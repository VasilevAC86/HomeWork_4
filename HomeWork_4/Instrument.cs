using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Instruments
{
    public class Instrument // Базовый класс "Музыкальный инструмент"
    {
        private string _name; // Название инструмента
        private string _description; // Описание инструмента
        private string _history; // История инструмента
        public string Name() { return _name; }
        public Instrument(string name, string description, string history)
        {
            this._name = name;
            this._description = description;
            this._history = history;
        }
        public virtual void Sound() { } // Виртуальный метод издавания звуков
        public void Show() { Console.WriteLine(_name); }
        public void Desc() { Console.WriteLine(_description); }
        public void History() { Console.WriteLine(_history); }
    }
}
