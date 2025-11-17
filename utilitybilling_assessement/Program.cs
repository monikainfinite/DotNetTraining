using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilitybilling_assessement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number of customers");
            int count=Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter details for customer {i + 1}");
                utilitybill utilitybill = new utilitybill();
                Console.Write("Enter customer ID     ");
                utilitybill.CustomerId=Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter customer Name    ");
                utilitybill.CustomerName = Console.ReadLine();
                Console.Write("enter number of usage readings    ");
                int readcount=Convert.ToInt32(Console.ReadLine());
                int[] readings=new int[readcount];
                for(int j=0;j<readcount; j++)
                {
                    Console.Write($"enter usage rading {j + 1}    ");
                    readings[j] = Convert.ToInt32(Console.ReadLine());
                }
                utilitybill.CalculateBill( utilitybill.ratePerUnit,out double total, out double tax, out double netPayable, readings);
                Console.WriteLine($"Customer ID     :{utilitybill.CustomerId}");
                Console.WriteLine($"Customer Name   :{utilitybill.CustomerName}");
                Console.WriteLine($"Service charge  :Rs.{utilitybill.GetServiceCharge()}");
                Console.WriteLine($"Total Usage     :Rs.{total}");
                Console.WriteLine($"Tax Applied     :Rs.{tax}");
                Console.WriteLine($"Net payable     :Rs.{netPayable}");
                Console.WriteLine("Thankyou!");
                Console.ReadLine();
            }
        }
    }
}
