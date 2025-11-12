using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day_10DemoApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arraylist = new ArrayList();
            Console.WriteLine("initial capacity" + arraylist.Capacity);
            arraylist.Add(10);
            arraylist.Add(10.6);
            arraylist.Add(12);
            Console.WriteLine(arraylist.Capacity);
            arraylist.Add("monika");
            //Console.WriteLine(arraylist.Capacity);
            arraylist.Add(true);
            arraylist.Insert(1, "new item");
            Console.WriteLine(arraylist.Capacity);
            foreach (var item in arraylist)
            {
                Console.WriteLine(item);
            }
            arraylist.Remove(true);
            Console.WriteLine(arraylist.Capacity);
            foreach(var item in arraylist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arraylist.Capacity);
            ArrayList arraylist2= new ArrayList();
            arraylist2.Add("first");
            arraylist2.Add("second");
            arraylist.AddRange(arraylist2);
            Console.WriteLine(arraylist.Capacity);
            ArrayList depList = new ArrayList() { "It", "hr", "tr" };
            arraylist.InsertRange(2, depList);
            foreach( var item in arraylist)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arraylist.Capacity);
            Console.WriteLine($"to know whether a value contains or not {arraylist.Contains("It")}");
            Console.WriteLine("count"+arraylist.Count);
            Console.WriteLine(arraylist[5]);
            ArrayList arraylist3 = arraylist.GetRange(3, 5);
            Console.WriteLine("getrange");
            foreach(var item in arraylist3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("reverse");
            arraylist3.Reverse();
            foreach( var item in arraylist3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("remove range");
            arraylist3.RemoveRange(2, 2);
          
            foreach (var item in arraylist3)
            {
                Console.WriteLine(item);
            }
            arraylist3.RemoveAt(2);
            foreach (var item in arraylist3)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();


        }
    }
}
