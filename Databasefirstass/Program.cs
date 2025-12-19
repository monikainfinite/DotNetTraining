using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasefirstass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            crud dc=new crud();
           // dc.AddEmployee();
           // dc.ShowAllEmployees();
            dc.UpdateRecord();
        }
    }
}
