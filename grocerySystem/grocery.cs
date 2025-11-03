using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocerySystem
{
    internal class grocery
    {
        public string itemName;
        public int quantity;
        public double priceperUnit;
        public double CalculateItemTotal()
        {
            return quantity * priceperUnit;
        }
        public void CalculateDiscount(double total,out double discount,out double finalAmount)
        {
            if (total > 5000)
            {
                discount = total * 0.20;
            }
            else if (total>=2000 && total <= 4999)
            {
                discount = total * 0.10;

            }
            else if(total>=1000 && total <= 1999)
            {
                discount = total * 0.05;
            }
            else
            {
                discount=0;
            }
            finalAmount = total - discount;
        }
    }
}
