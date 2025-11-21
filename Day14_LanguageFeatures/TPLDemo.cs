using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day14_LanguageFeatures
{
    internal class TPLDemo
    {
        public void NonParallel()
        {
            //runs slower
            //does not use library
            //i want to keep tracj how much time it took to run the loop
            Stopwatch sw = new Stopwatch();
            sw.Start();//timer starts
            for (int i = 0; i < 16; i++)
            {//by default its uses single thread to do the job
                //by default it using single core or processor to do the job
                Console.WriteLine("non parallel method running"+Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
            sw.Stop();  //timer ends
            Console.WriteLine("Total milliseconds took is" + sw.ElapsedMilliseconds);
        }
        public void Pareller()
        {
            //runs faster
            //uses library
            Stopwatch sw = new Stopwatch();
            sw.Start();//timer starts
            Parallel.For(0, 16, i =>
            { //by default it using single core or processor to do the job
                Console.WriteLine("parallel method running" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            });

            sw.Stop();  //timer ends
            Console.WriteLine("Total milliseconds took is" + sw.ElapsedMilliseconds);
        }
            //1.It uses multiple threads behind the scene
            //2.The loop broken into multiple parts,each part runs simultaneously from different cors
            //3.each part of the loop is called as task
            //4.internally it uses task class,to run simultaneously 
            //5.each task has its own thread
            //6.Task always uses threadpool
            //7.threadpool is a pool of threads already running in the memory
            //real time usage:
            //you have send an email to 10000 people simultaneously
            // you want to log to database 
            //send alerts or sms for all users simultaneously
            public async void TASKDEMO()
{
//job-1
await Task.Run(() =>
{
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Method1 Called");
                Thread.Sleep(1000);
            }

        });
 
// await : is a simplified way to wa
 
// job -2
await Task.Run(() =>
{
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Method2 Called");
                Thread.Sleep(1000);
            }
        });
 
//Task. WaitAll(t1, t2);//dont continue with next line until t1 and t2 are done with job
//Task.WaitAny(t1, t2);// continue next line , if any 1 task completed
Console.WriteLine("Both The task Completed successfully");
 
}

}
 
        }

    

