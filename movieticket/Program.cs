using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movieticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            double show_time;
            Console.WriteLine("enter your age");
            age=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter show time (24-hr format)");
            show_time = Convert.ToDouble(Console.ReadLine());
            if (age < 12)
                Console.WriteLine("Ticket Price : Rs.150");
            else
                if (show_time < 18.00)
                Console.WriteLine("TicketPrice : Rs.250");
                else
                Console.WriteLine("Ticketprice : Rs.300");



        }
    }
}
