using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double salary,total_salary,years_of_service,bonus=0;
            
            Console.WriteLine("Enter Salary");
            salary=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("enter years of service");
            years_of_service = Convert.ToDouble(Console.ReadLine());
            if(years_of_service>10)
            {
                bonus = salary * 0.2;
            }
            else if(years_of_service>=5 && years_of_service<=10)
            {
                bonus = salary * 0.1;
            }
            else
                bonus = salary * 0.05;
               
            

            total_salary = salary + bonus;
            Console.WriteLine($"Final salary after adding bonus is {total_salary}");
            Console.ReadLine();
        }
    }
}
