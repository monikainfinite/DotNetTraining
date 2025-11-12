using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_DemoApp1
{//indexer overloading
    public class EmployeeDirectory
    {
        private string[] EmpNames = { "moni", "usha", "anvith" };
        private int[] EmpId = { 101, 102, 103 };
        public string this[int index]
        {
            get { return EmpNames[index]; }
            set { EmpNames[index] = value; }
        }
        public string this[string Empid]
        {
            get
            {
                for (int i = 0; i < EmpId.Length; i++)
                {
                    if (EmpId[i].ToString() == Empid)
                        return EmpNames[i];
                }
                return "Employee Not Found";
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
EmployeeDirectory empDirectory = new EmployeeDirectory();
            Console.WriteLine(empDirectory[1]);
            Console.WriteLine(empDirectory["103"]);
            Console.WriteLine(empDirectory[0]);
       
            Console.WriteLine(empDirectory["104"]);
            Console.WriteLine(empDirectory[4]);
            Console.ReadLine();
        }
    }
}
