using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Day1_ASSIGNMENT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assignment 1 \n ");
            student1 student = new student1();
            student.DisplayDetails();
            WriteLine("\nAssignment 2 \n ");
            isupper ob=new isupper();
            ob.show();
            WriteLine("\nAssignment 4 \n ");
            sumofsquares s=new sumofsquares();
            s.showResult();
        }
    }
}
