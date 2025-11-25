using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment2;
using HRservices;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeDataReader reader = new MockEmployeeDataReader();
            PayrollProcessor payroll = new PayrollProcessor(reader);

            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            decimal total = payroll.CalculateTotalCompensation(id);

            Console.WriteLine($"Total Compensation for Employee {id} = {total:C}");
        }
    }
}
