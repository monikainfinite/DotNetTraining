using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_DemoApp2
{
    internal class Employee
    {
        private int empId;
        private string empName;
        private string designation;
        //public void AcceptEmployeeDetails(int id, string name, string designation = "ase")
        //here we are using default parameter we should put it at last otherwise it will throw a error.
        public void AcceptEmployeeDetails(int id,string name,string designation="ase")
        {
            this.empId=id;
            this.empName=name;
            this.designation=designation;

        }
        public void DisplayEmployeeDetails()
        {
            Console.WriteLine("EMployee Id  " + empId);
            Console.WriteLine("Employee name  " + empName);
            Console.WriteLine("Employee designaton  " + designation);
        }
    }
}
