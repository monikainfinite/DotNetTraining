using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_DemoApp1
{
    internal class paramexample
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sumOfIntegers(10, 20));
            Console.WriteLine(sumOfIntegers(20, 30, 40, 50));
            Console.WriteLine(sumOfIntegers(30, 40, 50, 60, 10, 20));
            Console.WriteLine("enter number of elements you want to add");
            int count = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[count];
            for(int i = 0; i < count; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine(sumOfIntegers(nums));
            Console.ReadLine();
        }

        static int sumOfIntegers(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
    } 
}
