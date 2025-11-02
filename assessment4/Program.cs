using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string student_name,grade;
            double marks;
          
            Console.WriteLine("enter your name");
            student_name = Console.ReadLine();
            Console.WriteLine("enter your marks");
            marks=Convert.ToDouble(Console.ReadLine());
            if (marks >= 90)
                grade = "A+";
            else if (marks >= 80 && marks <= 89)
                grade = "A";
            else if (marks >= 70 && marks <= 79)
                grade = "B";
            else if (marks >= 60 && marks <= 69)
                grade = "C";
            else if (marks >= 50 && marks <= 59)
                grade = "D";
            else
                grade = "Fail";
            if(grade=="Fail")
                Console.WriteLine($"your name is {student_name} and your marks are {marks} and sorry you are Fail ! Better luck next time");
            else
                Console.WriteLine($"your name is {student_name} and your marks are {marks} and grade is {grade}");
            Console.ReadLine();


        }
    }
}
