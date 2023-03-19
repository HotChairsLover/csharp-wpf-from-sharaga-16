using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Classes
{
    public class ItemInBox
    {
        public string name { get; set; }

        public int price { get; set; }

        public string src { get; set; }

        public string count { get; set; }

        public ItemInBox(string name, int price, string src, string count)
        {
            this.name = name;
            this.price = price;
            this.src = src;
            this.count = count;
        }
    }
}
