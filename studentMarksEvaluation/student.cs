using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentMarksEvaluation
{
    internal class student
    {
        public string Name;
        public int[] subjectMarks = new int[3];
        public void CalculateResult(out int total, out double average,out string grade)
        {
            total = 0;
            for (int i = 0; i < subjectMarks.Length; i++)
            {
                total += subjectMarks[i];
            }
            average=(total)/ subjectMarks.Length;
            if (average >= 90)
            {
                grade = "A+";
            }
            else if (average >= 80)
            {
                grade = "A";
            }
            else if (average >= 70)
            {
                grade = "B";
            }
            else if (average >= 60)
            {
                grade = "c";

            }
            else if (average >= 50)
            {
                grade = "D";
            }
            else
            {
                grade = "F";
            }
        }
        public void DisplayResult(string Name,int total,double average,string grade)
        {
            Console.WriteLine($"Name   : {Name}");
            Console.WriteLine($"Total Marks  : {total}");
            Console.WriteLine($"Average : {average}");
            Console.WriteLine($"Grade : {grade}");


        }

    }
}
