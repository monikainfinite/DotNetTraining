using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Day1_ASSIGNMENT
{
    internal class sumofsquares
    {
        public void  showResult() {
            List<int> nums = new List<int>() { 2, 3, 4 };
            WriteLine(nums.SumOfSquares());



        }

    }
    public static class Extensions1 {
        public static int SumOfSquares(this IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int i in numbers)
            {
                sum = sum + (i * i);
            }
            return sum;
        }
    }

}
