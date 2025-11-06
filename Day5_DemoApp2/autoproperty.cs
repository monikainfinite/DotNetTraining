using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_DemoApp2
{
   
        class Customer
        {//Auto-Implemented properties;
            public int customerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerPhone { get; set; }
            public void displayCustomerInfo()
        {
            Console.WriteLine($"Customer Id :{customerId}\n Customer Name: {CustomerName} \n Customer Email:{CustomerEmail} \n Customer Phone{CustomerPhone}");
        }
        }
    internal class autoproperty
    {static void Main(string[] args)
        {
            Customer customer = new Customer();
            Console.WriteLine("enter customerId");
            customer. customerId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter customerName");

            customer. CustomerName = Console.ReadLine();
            Console.WriteLine("enter email");
            customer. CustomerEmail = Console.ReadLine();
            Console.WriteLine("enter phonenumber");
            customer. CustomerPhone = Console.ReadLine();
            customer.displayCustomerInfo();
        }

    }
}
