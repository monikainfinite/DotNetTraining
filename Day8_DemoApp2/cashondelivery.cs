using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_DemoApp2
{
    public class cashondelivery:Payment
    {

        public override string Provider => "payment through cash";
        //public override bool processPayment(decimal amount)
        //{
        //    if(amount >0 && amount <= 10000)
        //    {
        //        Console.WriteLine($"processing cash on delivery payment of {amount:C} through {Provider}");
        //        return true;
        //    }
        //    else 
        //    {
        //        Console.WriteLine($"cash on delivery failed");
        //        return false;
        //    }
        //}
    }
}
