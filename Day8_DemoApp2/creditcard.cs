using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_DemoApp2
{
    public class creditcard:Payment {

        public override string Provider => "credit card Provider";
        public override bool processPayment(decimal amount)
        {
            base.processPayment(788);
            if(amount >0 && amount <= 5000)
            {
                Console.WriteLine($"Processing credit card payment of {amount:C} through {Provider}");
                return true;
            }
            else
            {
                Console.WriteLine("Credit card payment failed :Amount exceeds list or its invalid");
                return false;
            }
        }



    }

}
