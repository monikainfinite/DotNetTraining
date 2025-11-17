using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day11_demoapp1
{//stacks
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push("test");
            stack.Push(3.14);
            Console.WriteLine("Items in stack");
            foreach(var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("top of the item"+stack.Peek());
            stack.Pop();
            Console.WriteLine("Total item in the stack"+stack.Count);
            Console.WriteLine("the test is there are or not" + stack.Contains("test"));
            stack.Clear();
            Console.WriteLine("the count" +stack.Count);
            Console.ReadLine();
        }
    }
}
