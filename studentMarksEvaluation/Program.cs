using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentMarksEvaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== student marks evaluation system");
            Console.WriteLine("Enter no of students:");
            int noofStudents = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noofStudents; i++) {
                Console.WriteLine($"enter details of student {i + 1}");
                student student = new student();
                Console.WriteLine("Enter student name: ");
                student.Name = Console.ReadLine();
                student.subjectMarks = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"enter marks for subjects {j + 1}: ");
                    student.subjectMarks[j] = Convert.ToInt32(Console.ReadLine());
                }
                student.CalculateResult(out int total, out double average, out string grade);
                    student.DisplayResult( total, average, grade);
                }
            Console.ReadLine();
            }
        }

        }
    

