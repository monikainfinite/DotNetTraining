using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_DemoApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Addition();
            Console.ReadLine();
        }//if we didint use the static then when we write addition() it will throw a error.
        //function without parameter..
        static void Addition()
        {
            int num1, num2,sum;
            Console.WriteLine("enter the first number");
            num1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the second number");
            num2=Convert.ToInt32(Console.ReadLine());
            sum = num1 + num2;
            Console.WriteLine($"sum is {sum}");
        }
    }
}
