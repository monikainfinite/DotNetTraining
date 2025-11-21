using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day11_demo
{
    internal class Taskdemo
    {
        public void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("method1 called");
                Thread.Sleep(1000);
            }
        }
        public void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("method2 called");
                Thread.Sleep(1000);
            }
        }
        public void Method3()
        {
            Task t1 = new Task(Method1);
            t1.Start();
            Task t2 = new Task(Method2);
            t2.Start();
        }
        public void Method4()
        {
            //unlike threads,to work with task class,u are not forced to crete a 
            var t1=Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("method1 called");
                    Thread.Sleep(1000);
                }
            });
            t1.Wait();
           var t2= Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("method2 called");
                    Thread.Sleep(1000);
                }
            });
            Task.WaitAll(t1, t2);//dont continue with next line intil t1 and t2
            Task.WaitAny(t1, t2);//continue next line.
            Console.WriteLine("both task completed sucessfully)");
            
        }
    }
}
