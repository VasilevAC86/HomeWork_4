using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Devices
{
    public class Device // Базовый класс "Устройство"
    {
        private string _name; // Название устройства
        private string _description; // Описание
        private string _type; // Тип устройства
        public string Name() { return _name; }
        public Device(string name, string description, string type)
        {
            this._name = name;
            this._description = description;
            this._type = type;
        }
        public virtual void Sound() { } // Виртуальный метод издавания звуков
        public void Show() { Console.WriteLine(_type + ". " + _name); }
        public void Desc() { Console.WriteLine(_description); }
    }
}
