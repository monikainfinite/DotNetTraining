using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_DemoApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Overloading overloading = new Overloading();
            overloading.GetEmployeeDetails(100);
            overloading.GetEmployeeDetails("monika");
            overloading.GetEmployeeDetails(101,"monika");
            overloading.GetEmployeeDetails("moni", 101);
            Console.ReadLine();  
        }
    }
}
