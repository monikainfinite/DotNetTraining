using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Assignment2
{
    internal class assignment3
    {
        public void Execute3(int num)
        {
            Task<int> factorialTask = Task.Run(() => Factorial(num));
            Console.WriteLine($"Factorial of {num} = {factorialTask.Result}");
        }
        private int Factorial(int num)
        {
            int fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}
