using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_demoDelegate
{
    //public delegate string SampleFunctionDelegate(int x, int y);
    internal class Funcdelegate
    {

        static void Main(string[] args)
        {
            //SampleFunctionDelegate sampleFunDel = Add;
            //string result = sampleFunDel(10, 20);
            //Console.WriteLine(result);
            Func<int, int, string> funDelegate = Add;
            string res = funDelegate(100, 200);
            Console.WriteLine(res);
            Func<int, string> funDel = delegate (int a)
            {
                return "hello" + (a).ToString();
            };Console.WriteLine("with anonymous delegate"+funDel(500));
            Func<int, string> funDelLambda = a => "hello from lambda" + (a).ToString();

            Console.WriteLine("Function woth lambda expression" + funDelLambda(75));
            Console.ReadLine();
        }
        public static string Add(int a,int b)
        {
            return (a+b).ToString();
        }
    }
}
