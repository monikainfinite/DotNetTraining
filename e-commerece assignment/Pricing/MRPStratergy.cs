using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Pricing
{
    public class MRPStrategy : IPricingStrategy
    {
        public decimal CalculateTotal(ILineItem[] items)
        {
            decimal sum = 0;
            foreach (var item in items)
                sum += item.Price * item.Quantity;
            return sum;
        }
    }

}
