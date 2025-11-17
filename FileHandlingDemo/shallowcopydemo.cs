using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingDemo
{
    public class Adress
    {
        public string City { get; set; }
        public string street { get; set; }
        public Adress DeepCopy()
        {
            return new Adress
            {
                City = this.City,
                street = this.street
            };
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Adress HomeAddress { get; set; }
        //public Employee ShallowCopy()
        //{
        //    return (Employee)this.MemberwiseClone();
        //}
        public Employee DeepCopy()
        {
            Employee clonedEmployee = (Employee)this.MemberwiseClone();
            clonedEmployee.HomeAddress = this.HomeAddress.DeepCopy(); // fix reference
            return clonedEmployee;
        }

    }
        internal class shallowcopydemo
        {
            static void Main(string[] args)
            {
                Employee emp1 = new Employee { Name = "moni", Age = 30, HomeAddress = new Adress { City = "hyd", street = "5th" } };
                Employee emp2 = emp1.DeepCopy();

                emp2.Name = "Doe";
                emp2.HomeAddress.City = "Los Angeles";

                Console.WriteLine("emp1.name" + emp1.Name);
                Console.WriteLine($"emp1.Home address" + emp1.HomeAddress.City);

                Console.WriteLine("emp2.name" + emp2.Name);
                Console.WriteLine($"emp2.Home address" + emp2.HomeAddress.City);
                Console.ReadLine();
            }
        }
    
}
