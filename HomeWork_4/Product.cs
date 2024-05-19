using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Product
{
    public class Product:Money
    {      
        public string Type { get; set; } // Название типа товара (еда, машина)
        public string Name { get; set; } // Наименование товара
        public Product(string type_, string name_)
        {
            this.Type = type_;
            this.Name = name_;            
        }
        public float Discount(float val) { return Total() - val; }
    }
}
