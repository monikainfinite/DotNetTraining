using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {//first priority is for static constructor and later it will folow the order we called..
            //we will use static for welcome msgs we will go for static
           department dep=new department();
          //we will get nefault values .
            dep.DisplayDepartmentInfo();
            //dep.getDepartmentInfo();
            //dep.DisplayDepartmentInfo();
            department dep1= new department(201,"MR","vizag");
            dep1.DisplayDepartmentInfo();
            department dep2 = new department(102, "hr", "chennai");
            department dep3 = new department(dep2);
            dep3.DisplayDepartmentInfo();
            Console.ReadLine();

        }
    }
}
