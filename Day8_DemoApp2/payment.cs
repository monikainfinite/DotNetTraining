using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_DemoApp2
{
    public class Payment
    {
        public virtual string Provider => "Generic payament ";
        public virtual bool processPayment(decimal amount)
        {
            if (amount > 0)
            {
                Console.WriteLine($"processing payment of {amount:C} through {Provider} ");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void samplepayment()
        {
            Console.WriteLine("this is a sample payment method");
        }

    }
}