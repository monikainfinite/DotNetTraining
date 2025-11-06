using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_DemoApp1
{
    class StudentMarks
    {
        private int[] marks = new int[5];
        public int this[int index]
        {
            get
            {
                if(index<0 || index >= marks.Length)
                {
                    Console.WriteLine("invalid index");
                    return -1;
                }
                return marks[index];
            }
            set
            {
                if (index < 0 || index >= marks.Length) {
                    Console.WriteLine("invalid"); }
                else
                {
                    marks[index] = value;
                }
            }


        }
        public void display()
        {
            Console.WriteLine("marks of students");
            for(int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Student {i + 1}: {marks[i]}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           StudentMarks studentMarks = new StudentMarks();
            studentMarks[0] = 85;
            studentMarks[1] = 90;
            studentMarks[2] = 85;
            studentMarks[3] = 76;
            studentMarks[4] = 95;
            //studentMarks[5] = 0;//invalid msg will appear.
            //Console.WriteLine($"{ studentMarks[5]}");
            studentMarks.display();
          employyeelist employee = new employyeelist();
            Console.WriteLine($"employee[1]:{employee[1]}");
            Console.WriteLine($"employee[2]:{employee[2]}");
            Console.WriteLine($"employee[3]:{employee[3]}");
            employee[3] = "usha";
            Console.WriteLine($"employee[3]:{employee[3]}");
           
            Console.ReadLine();


        }
    }
}
