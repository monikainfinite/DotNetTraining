using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_DemoApp1
{
    internal class outwithdiscard
    {
        static void Main(string[] args)
        {//discard is _ it is for discarding the unusefuo varaible ,if we dont want that variable to be used we make it DISCARD.
            //calculate(100, 400, out int sum, out _, out _);
            //Console.WriteLine($"sum = {sum}");
            //Console.ReadLine();
            //calculate(100, 400,  out _, out int diff, out _);
            //Console.WriteLine($"diff = {diff}");
            //Console.ReadLine();
            calculate(100, 400, out _, out int diff, out int product);
            Console.WriteLine($"diff = {diff}");
            Console.WriteLine($"pro = {product}");
            Console.ReadLine();
        }
    
    static void calculate(int a, int b, out int sum, out int diff, out int product)
        {
            sum = a + b;
            diff = a - b;
            product = a * b;
        }
    }
}

