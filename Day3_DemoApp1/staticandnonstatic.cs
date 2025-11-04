using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_DemoApp1
{//for static methods or variables to acess we need not create a obj we can directly acess or callit.
    //for non static methods we need to call it through object only.
    internal class staticandnonstatic
    {
        static int x;
        int y;
        void NonstaticMethod()
        {
            Console.WriteLine("Non static function");

        }
        static void staticMethod()
        {
            Console.WriteLine("static function");
        }
        static void Main(string[] args)
        {
            x = 900;
            staticandnonstatic obj=new staticandnonstatic();
            obj.y = 200;
            Console.WriteLine("calling static method without object");

            staticMethod();
            Console.WriteLine("calling nonstatic method with object");
            obj.NonstaticMethod();
            Console.WriteLine("static variable accessing without object  "+ x);
            Console.WriteLine("Non static variable accessing through object  "+ obj.y);
            Console.ReadLine();


        }
    }
}
