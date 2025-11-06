using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentassignmant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.showmethods();
            Console.WriteLine("enter amount to pay");
            double amount=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("select payment method (1-credit card,2-UPI,3-wallet");
            int choice=Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                CreditCard paymentC = new CreditCard();
                paymentC.Process(amount);
            }
            else if (choice == 2)
            {
                UPI paymentUP = new UPI();
                paymentUP.Process(amount);
            }
            else if (choice == 3)
            {
                wallet paymentwallet = new wallet();
                paymentwallet.Process(amount);
            }

            else
            {
                Console.Write("invalid choice");
            }
            Console.WriteLine("payment sucessful");
            Console.ReadLine();
        }
    }
}

