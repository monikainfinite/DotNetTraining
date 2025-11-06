using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_DemoApp1
{
    class Employee {
    public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGender { get; set; }
    }

    internal class employyeelist
    {
        List<Employee> employeelist = new List<Employee>()
        {
        new Employee() { EmployeeId = 1,EmployeeName="monika",EmployeeGender="Female"},
        new Employee() { EmployeeId = 2,EmployeeName="monika1",EmployeeGender="Female"},
        new Employee() { EmployeeId = 3,EmployeeName="monika2",EmployeeGender="Female"},
        };
        public string this[int empid]
        {
            get
            {
                return employeelist.FirstOrDefault(e => e.EmployeeId == empid)?.EmployeeName;
            }
            set
            {
                employeelist.FirstOrDefault(e => e.EmployeeId == empid).EmployeeName = value;
            }
            
        }
            
        
    }
}
