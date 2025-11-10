using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_DemoApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            creditcard creditcard= new creditcard();
            creditcard.processPayment(3000);
            creditcard.samplepayment();
            Console.WriteLine($"{creditcard.Provider}");
            cashondelivery cashondelivery = new cashondelivery();
            cashondelivery.processPayment(7000);
            Console.ReadLine();
        }
    }
}
