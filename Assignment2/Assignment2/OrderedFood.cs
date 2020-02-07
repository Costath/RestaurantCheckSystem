using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// Each item added to the Check
    /// </summary>
    class OrderedFood
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Price
        {
            get
            {
                return String.Format("{0:c}", Price);
            }
            set { }
        }

        public override string ToString()
        {
            return $"{Name,-30}\t{Quantity,-3}\t{Price,10:c}";
        }
    }
}
