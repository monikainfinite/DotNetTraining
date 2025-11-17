using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssignment
{
    public class Employee
    {
       public int EmpId {  get; set; }
        public string Name { get; set; }
        public string Department {  get; set; }
        public double Salary {  get; set; }
        public int Experience {  get; set; }
        public override string ToString()
        {
            return $"EMPID={EmpId}, Name={Name}, Department={Department}, Salary={Salary}, Experience={Experience}";
        }

    }
    public static class EmployeeFilters 
    {
        public delegate bool EmployeeCondition(Employee e);
        public static List<Employee> FilterEmployees(List<Employee> list, EmployeeCondition condition)
        {
            List<Employee> result = new List<Employee>();
            foreach (Employee emp in list)
            {
                if (condition(emp))
                {
                    result.Add(emp);
                }
               
            }
            return result;
        }
    }
    
    
    


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee() {EmpId=101,Name="Monika",Department="IT",Salary=18000,Experience=2},
                new Employee() {EmpId=102,Name="Teja sri",Department="HR",Salary=180000,Experience=12},
                new Employee() {EmpId=103,Name="Akshara",Department="Finance",Salary=58000,Experience=1},
                new Employee() {EmpId=104,Name="Manogna",Department="Sales",Salary=20000,Experience=5},
                new Employee() {EmpId=105,Name="sai",Department="IT",Salary=15000,Experience=4},
                new Employee() {EmpId=106,Name="Varshini",Department="IT",Salary=35000,Experience=10},
                new Employee() {EmpId=107,Name="Krishna",Department="HR",Salary=80000,Experience=8},
                new Employee() {EmpId=108,Name="Priya",Department="Finance",Salary=130000,Experience=3},
                new Employee() {EmpId=109,Name="Laxmi",Department="HR",Salary=230000,Experience=7},
                new Employee() {EmpId=110,Name="Prasanna",Department="Sales",Salary=65000,Experience=9}
            };
            Console.WriteLine("All employees");
            foreach(Employee emp in employeeList)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n Employees whose salary >50000 ");
            var highSalary = EmployeeFilters.FilterEmployees(employeeList, e => e.Salary > 50000);
            foreach(Employee emp in highSalary)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n Employees who work in IT department");
            var itEmployess = EmployeeFilters.FilterEmployees(employeeList, e => e.Department == "IT");
            foreach(Employee emp in itEmployess)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n Employees whose experience >5 years ");
            var senior = EmployeeFilters.FilterEmployees(employeeList, e => e.Experience > 5);
            foreach(Employee emp in senior)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n Employees whose name start with 'A");
            var startWithA = EmployeeFilters.FilterEmployees(employeeList, e => e.Name.StartsWith("A"));
            foreach (Employee emp in startWithA)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n Sorting by Name");
           employeeList.Sort((e1,e2)=>e1.Name.CompareTo(e2.Name));
            foreach(Employee emp in employeeList)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n sort by salary ");
            employeeList.Sort((e1, e2) => e2.Salary.CompareTo(e1.Salary));
            foreach (Employee emp in employeeList)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n sort by experience");
            employeeList.Sort((e1,e2)=>e1.Experience.CompareTo(e2.Experience));
            foreach (Employee emp in employeeList)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine("\n promotion list");
            var promotionList = EmployeeFilters.FilterEmployees(employeeList, e => e.Experience > 5 || e.Salary > 60000);
            foreach (Employee emp in promotionList)
            {
                Console.WriteLine(emp);
            }
            Console.ReadLine();

        }
    }
}
