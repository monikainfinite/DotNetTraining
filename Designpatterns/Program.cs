using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designpatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ob = Singleton.GetInstance;
            //ob.Method();
            //var ob = factory.GetInstance(3);
            //var result = ob.ShowData();
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            // user -1
            //Class1 ob = new Class1();
            //ob.p1 = 100;
            //ob.p2 = 200;
            //Console.WriteLine(ob.p1);
            //Console.WriteLine(ob.p2);
            //Console.WriteLine("====================");

            //// user-2
            ////Class1 ob2 = ob; // single object
            //Class1 ob2 = (Class1)ob.Clone(); //2 objects
            //ob2.p2 = 500;
            //Console.WriteLine(ob2.p1);
            //Console.WriteLine(ob2.p2);

            //Console.WriteLine("==================");
            //Console.WriteLine(ob.p1);// 100
            //Console.WriteLine(ob.p2);//500
            //// why user1 data is getting updated?



            books obj = new onlinedelivary();
            obj.ProcessData();
            Console.WriteLine("==================");
            obj = new physicaldevlivary();
            obj.ProcessData();

        }
    }
}
