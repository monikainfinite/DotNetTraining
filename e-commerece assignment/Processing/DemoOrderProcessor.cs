using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Processing
{
    public class DemoOrderProcessor : OrderProcessorBase
    {
        protected override void Validate(IOrder order)
        {
            foreach (var item in order.Items)
            {
                if (item.Quantity <= 0 || item.Price <= 0)
                    throw new System.ArgumentException("Invalid line item");
            }
            System.Console.WriteLine("Order validated!");
        }

        
    }
}
