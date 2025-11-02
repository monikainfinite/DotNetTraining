using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount, final_amount,discount=0;
            Console.WriteLine("enter purchase amount");
            amount=Convert.ToDouble(Console.ReadLine());
            if (amount < 1000)
                discount = 0;
            else if (amount >= 1000 && amount <= 5000)
                discount = amount * 0.1;
            else
                discount = amount * 0.2;
            final_amount = amount - discount;
            if (discount == 0)
                Console.WriteLine($"sorry! there is no discount , Final amount after discount is Rs.{final_amount}");
            else
                Console.WriteLine($" Final amount after discount is Rs.{final_amount}");
            Console.ReadLine();

        }
    }
}
