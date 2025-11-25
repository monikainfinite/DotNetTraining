using System;
using HRDataLib;
using HRservices;
namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeDataReader reader = new MockEmployeeDataReader();
            PayrollProcessor payroll = new PayrollProcessor(reader);

            // List of IDs you want to show
            int[] EmpIds = { 101, 102, 103, 111 };

            Console.WriteLine("Employee Details");
           

            foreach (var id in EmpIds)
            {
                var record = reader.GetEmployeeRecord(id);
                decimal total = payroll.CalculateTotalAmount(id);

                Console.WriteLine(
                    $"Employee ID: {record.Id}, Name: {record.Name}, Total Compensation: Rs {total}"
                );
            }

            
            Console.ReadLine();
        }
    }

}
        
    
