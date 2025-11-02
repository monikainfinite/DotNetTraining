using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bill_amount, final_amount ,gst=0,sc=0; 
            int total_people;
            Console.WriteLine("enter bill amount");
            bill_amount=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("enter total people");
            total_people = Convert.ToInt32(Console.ReadLine());
            if (bill_amount < 1000)
            {
                gst = 0;
                sc = 0;
            }
            else
            {
                gst = bill_amount * 0.1;
                sc = bill_amount * 0.05;
            }
            final_amount = (bill_amount + gst+sc) / total_people;
            Console.WriteLine($"each person should pay : {final_amount}");
            Console.ReadLine();

        }
    }
}
