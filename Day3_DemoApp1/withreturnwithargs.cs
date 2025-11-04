using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_DemoApp1
{
    internal class withreturnwithargs
    {//function with return with args
        static void Main(string[] args)
        {
            int result = addition(2, 3);
            Console.WriteLine(result);
            int num1, num2, res1;
            Console.WriteLine("enter the numbers");
            num1=Convert.ToInt32(Console.ReadLine());
            num2=Convert.ToInt32(Console.ReadLine());
            res1 = addition(num1, num2);
            Console.WriteLine($"result is {res1}");
            Console.ReadLine();
        }
        static int addition(int a,int b)
        {
            int res = a + b;
            return res;
        }
    }
}
