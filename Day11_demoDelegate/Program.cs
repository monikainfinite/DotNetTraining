using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_demoDelegate
{
    public delegate void PrintNumberDelegate(int number);
    public delegate string GreetDelegate(string str);

    internal class Program
    {
        static void Main(string[] args)
        {   //singlecast Delegate
            PrintNumberDelegate printnumberdelegate = PrintNumber;
            GreetDelegate greet = GreetMsg;
            printnumberdelegate(15000);
            printnumberdelegate(9000);
            //multicast delegate
            //printnumberdelegate += DisplayMsg;
            Console.WriteLine("multicast deligate");
            printnumberdelegate(3000);
            

            printnumberdelegate += DisplayMsg;
            printnumberdelegate += showDate;
            printnumberdelegate(3000);
            //removing a method
            printnumberdelegate -= DisplayMsg;
            printnumberdelegate(3000);

            Console.WriteLine(greet("monika"));
            Console.ReadLine();
        }
        public static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }
        public static void DisplayMsg(int customerid)
        {
            Console.WriteLine("hello from"+customerid);
        }
        public static void showDate(int dummy)
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
        public static string GreetMsg(string str)
        {
            return "hlo"+str;
        }
    }
}
