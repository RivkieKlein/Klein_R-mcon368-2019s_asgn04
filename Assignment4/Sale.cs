using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Sale
    {
        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping { get; set; }

        override
        public String ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(Item);
            output.AppendLine("Customer: " + Customer);
            output.AppendLine("Price: "+ PricePerItem);
            output.AppendLine("Quantity: " + Quantity);
            output.AppendLine("Address: "+Address);
            output.AppendLine("Expedited Shipping : " +ExpeditedShipping);
            return output.ToString();
        }
    }
}
