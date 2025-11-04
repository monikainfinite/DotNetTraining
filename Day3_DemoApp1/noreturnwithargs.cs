using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_DemoApp1
{//function without return with args
    internal class noreturnwithargs
    {
        static void Main(string[] args)
        {
            Addition(2, 3);
            int num1, num2;
            Console.WriteLine("enter values of num1 and num2");
            num1=Convert.ToInt32(Console.ReadLine());
            num2=Convert.ToInt32(Console.ReadLine());
            Addition(num1, num2);
            Console.ReadLine();
        }
        static void Addition(int a,int b)
        {
            int c = a + b;
            Console.WriteLine($"sum of a and b is {c}");
        }
    }
}
