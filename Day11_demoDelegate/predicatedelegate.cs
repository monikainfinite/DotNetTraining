using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_demoDelegate
{
    public class Employee { 
    public int EmpId { get; set; }
    public string Name { get; set; }
        public int experience { get; set; }

    
    }

    internal class predicatedelegate
    {
        static void Main(string [] args)
        {
            List<Employee> employees = new List<Employee>() {
            new Employee{ EmpId = 1,Name="moni",experience=5},
            new Employee{ EmpId = 2,Name="moniteja sri",experience=3},
            new Employee{ EmpId = 3,Name="teja sri",experience=2},
            new Employee{ EmpId = 4,Name="sri",experience=6}
            };
            Predicate<Employee> IsEligible = emp => emp.experience >= 3;
            var eligibleEmployees=employees.FindAll(IsEligible);
            foreach(Employee employee in eligibleEmployees)
            {
                Console.WriteLine($"EmpId:{employee.EmpId},Name:{employee.Name},Experience:{employee.experience}");
            }
            Console.ReadLine();
        }
    }
}
