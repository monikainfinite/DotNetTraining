using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
//Convert below code to follow OCP

//  public class DiscountService
//{
//    public decimal ApplyDiscount(string customerType)
//    {
//        if (customerType == "VIP") return 0.8m;
//        if (customerType == "Employee") return 0.5m;
//        else
//            return 0;
//    }
//}
namespace Solidprinciples
{
    public interface IDiscount 
    {
        
        decimal GetDiscount();
    }
    public class VipDiscount : IDiscount
    {
        
        public decimal GetDiscount()
        {
            return 1.5m;
        }
    }
    public class EmployeeDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 1.0m;
        }
    }
    public class NoDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 0;
        }
    }
    public class ManagerDiscount : IDiscount
    {
        public decimal GetDiscount()
        {
            return 1.25m;
        }
    }
   
    internal class OCp
    {
        public static void Main(string[] args)
        {
            
            IDiscount vip = new VipDiscount();
            WriteLine(vip.GetDiscount());
            IDiscount emp = new EmployeeDiscount();
            WriteLine(emp.GetDiscount());
            IDiscount no= new NoDiscount();
            WriteLine(no.GetDiscount());
            IDiscount mng = new ManagerDiscount();
            WriteLine(mng.GetDiscount());
        }
    }
}
