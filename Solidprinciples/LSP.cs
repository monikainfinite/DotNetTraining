using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidprinciples
{
    public class EmployeeBase
    {
        public int Empid {  get; set; }
        public string EmpName { get; set; }
        public string EmpDept {  get; set; }
    }
    public interface IBonus
    {
        decimal GetBonus(decimal salary);
    }
    public class PermanentEmployee : EmployeeBase, IBonus
    {
        public decimal GetBonus(decimal salary)
        {
            return salary * 2.5m;
        }
    }
    public class ContractEmployee : EmployeeBase
    {
        public void show()
        {
            Console.WriteLine("sry! you are not eligible for bonus");
        }
    }

    internal class LSP
    { public static void Main(string[] args) {
            PermanentEmployee pe = new PermanentEmployee();
            Console.WriteLine(pe.GetBonus(100000));
            ContractEmployee c=new ContractEmployee();
            c.show();
    }
    }
}
