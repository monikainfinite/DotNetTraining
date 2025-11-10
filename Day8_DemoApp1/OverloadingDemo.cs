using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_DemoApp1
{
    public class Overloading
    {//overloading is compile time polymorphism..
      public void GetEmployeeDetails(int id)
        {
            Console.WriteLine("empid" + id);
        }
        public void GetEmployeeDetails(string name)
        {
            Console.WriteLine("empname   " + name);
        }
        public void GetEmployeeDetails(string name,int id)
        {
            Console.WriteLine($"empname: {name} and empid:{id}");
        }

        public void GetEmployeeDetails( int id,string name)
        {
            Console.WriteLine($"empname: {name} and empid:{id}");
        }

    }
    

}
