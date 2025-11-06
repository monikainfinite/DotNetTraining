using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day6_multipleinherirance
{//c# doesnt support multiple inheritance.For that we will use the concept of interfaces here like we will use in java..

    internal class Program
    {
        static void Main(string[] args)
        {
          Customer customer = new Customer();
            customer.GetProductInfo();
            customer.GetReviews();
            customer.DisplayProductInfo();
            customer.DisplayReviews();
            Console.ReadLine();
         }
    }
   
}