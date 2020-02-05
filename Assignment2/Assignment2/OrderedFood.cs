using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class OrderedFood
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name,-30}\t{Quantity,-3}\t{Price,10:c}";
        }
    }
}
