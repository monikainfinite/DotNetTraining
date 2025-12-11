using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            connectdemo ob=new connectdemo();

            //ob.AddEmployee();
            //ob.DeleteEmployee();
            //ob.updateEmployee();
            //ob.showEmployee();
            //ob.showprocedure();
            ob.EmpTransaction();
            Console.ReadLine();
        }
    }
}
