using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit
{
    internal class assignment
    {
        public class Calculator
        {
            public int Square(int a) => a * a;
        }
        public class StringHelper
        {
            public string ToUpper(string input) => input.ToUpper();
        }
        public class MyMath()
        {
            public int Multiply(int a, int b) => a * b;

        }
        public class StudentService
        {
            public void ValidateAge(int age)
            {
                if (age < 0) throw new ArgumentException("Invalid age");
            }

        }
        public class NumberService
        {
            public List<int> GetEvenNumbers() => new List<int> { 2, 4, 6, 8 };
        }
        public class MarksService
        {
            public async Task<int> GetMarksAsync()
            {
                await Task.Delay(100);
                return 90;
            }
        }
       
    }
}
