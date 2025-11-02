using System;
using System.Security.Cryptography;
namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Console.ReadLine();
            int n1 = 0;
            int n2 = 10;
            float avg_score = 67.45f;
            double precise = 1234.6745;
            char grade = 'A';
            string msg = "hello";
            Console.WriteLine("num1" + n1);
            //Here we are writing indexes here .
            //here we are writing {0} for avg_score and also msg because it is 
            //diff variables here and we are writing separate timess.
            Console.WriteLine("num1 {0}", avg_score);
            Console.WriteLine("message is {0}", msg);
            //interpolation
            //here we are writing in same writeLine so we are using diff indexes..
            Console.WriteLine($"num value is {0} \n num2 is {1}", n1, n2);
            Console.WriteLine($"num value is {n1} \n num2 = {n2} \n double ={precise}", $"\n grade= {grade}");





        }
    }
}