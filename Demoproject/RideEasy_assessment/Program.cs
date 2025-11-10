using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideEasy_assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customer c = new customer("Monika", "7396585838", 100);
            vehicle v = new vehicle("seden", 100, 12);
            ride r = new ride(c,v,12.5m,DateTime.Now);
            r.PrintInvoice("child-seat", "priority-pickup","extra-luggage");
            Console.ReadLine();
        }
    }
}
