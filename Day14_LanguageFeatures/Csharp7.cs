using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_LanguageFeatures
{
    internal class Csharp7
    {
        public (int,string) tupledemo()
        {//Features:using tuple we can return multiple values
            //now its standards
            int id = 100;
            string name = "Monika";
            return (id,name);   
        }
        public void outdemo()
        {//Minimising out variable
            //Feature:better way to typecast and safest way ..
            //converting from string to integer we have to use parsemethod
            //int.Parse;//converts string to integer
            //double.Parse//converts string to double
            //float.Parse //Converts string to float
            //int a = int.Parse(Console.ReadLine());//here when we enter a string it will throw a error
            //int x;
            //TryParse will avoid run time errors
            var res=int.TryParse(Console.ReadLine(), out int x);
            if (res == true)
                Console.WriteLine(x);
            else Console.WriteLine("failed");
        }
        public void patternMatching()
        {
            //Feature : avoid typecasting 
            //will also make code look compact
            //very widely used in switch case and if condition
            // object shape = "Circle";
            ////without patternmatching

            // Console.WriteLine(shape.GetType().Name);

            // switch (shape.GetType().Name)

            // {

            //     case "Int32":

            //         int n = (int)shape;

            //         if (n > 0)

            //             Console.WriteLine("Positive number");

            //         else

            //             Console.WriteLine("Unknown");

            //         break;

            //     case "String":

            //         string s = (string)shape;

            //         if (s == "Circle")

            //             Console.WriteLine("It's a circle");

            //         else

            //             Console.WriteLine("Unknown");

            //         break;

            //     default:

            //         Console.WriteLine("Unknown");

            //         break;

            // }
            object shape = "Circle";
            switch (shape)
            {
                case int n when n > 0:
                    Console.WriteLine("positive");
                    break;
                case string s when s == "Circle":
                    Console.WriteLine("circle");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
            //int marks = 82;
            //string res = marks switch
            //{
            //    >= 90 => "excellent",
            //    >=75=>Good,
            //    >=50 => "avg",
            //    _=>"Fail"//default
            //};
            //Console.WriteLine(res);
            //works in .net 9.0

        }
        //Feature :readability improvement with literal
        public void Readability()
        {//Feature:better readabiloity
            int x = 1_00_000;//valid we can replace , with (_) ..
            Console.WriteLine(x);

        }
        //Feature:Local Functions
        public string localFunction(int a)
        {
            //Feature:how to nest the function (function inside function)
            //use this feature if the function grows too long
            string greatest(int x)//the value from parent function
            {
                if (x > 10)
                    return "x is greater than 10";
                else return "x is not greater than 10";
            }
            return greatest(a);
        }
        public void throwexpdemo()
        {
            string st = null;
            //older way
            //if (st == null)
            //    throw new ArgumentException("exp occured");
            //new way(assign the value of st to res ,only if it is not null by using ??)
            string res=
                st ?? throw new ArgumentException("exp occured");
        }
    }
}
