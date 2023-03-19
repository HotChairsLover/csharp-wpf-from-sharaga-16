using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Classes
{
    public class Item
    {
        public string name { get; set; }

        public int price { get; set; }

        public string src { get; set; }

        public string category { get; set; }

        public Item(string name, int price, string src, string category)
        {
            this.name = name;
            this.price = price;
            this.src = src;
            this.category = category;
        }
    }
}
