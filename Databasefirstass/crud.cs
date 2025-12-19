using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasefirstass
{
    internal class crud
    {
        sportsdbEntities d = new sportsdbEntities();
        public void AddEmployee()
        {
            Employee emp = new Employee();
            Console.WriteLine("Enter EmpID:");
            emp.EmpId = Console.ReadLine();

            Console.WriteLine("Enter Name:");
            emp.EmpName = Console.ReadLine();

            Console.WriteLine("Enter Department Name:");
            emp.DepartmentName = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            emp.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Year of Joining:");
            emp.YearOfJoining = Convert.ToInt32(Console.ReadLine());
            d.Employees.Add(emp);
            d.SaveChanges();
            Console.WriteLine("Employee added successfully!");

        }
        public void ShowAllEmployees()
        {
            var employees = d.Employees.ToList();
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.EmpId} {e.EmpName} {e.DepartmentName} {e.Salary} {e.YearOfJoining}");
            }
        }
        public void UpdateRecord()
        {
            Console.WriteLine("Enter EmpID to update:");
            string empId = Console.ReadLine();
            var emp = d.Employees.FirstOrDefault(e => e.EmpId == empId);
            Console.WriteLine("enter salary");
            int sal = Convert.ToInt32(Console.ReadLine());
            emp.Salary = sal;
            int rowsAffected = d.SaveChanges();
            Console.WriteLine("Record updated successfully! Total rows affected: " + rowsAffected);
        }


    }
}
