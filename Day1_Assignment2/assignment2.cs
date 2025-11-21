using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Assignment2
{
    internal class assignment2
    {
        Random rand = new Random();
        public void Execute2()
        {
            Task<int> t1 = Task.Run(() => rand.Next(1, 100));
            Task<int> t2 = Task.Run(() => rand.Next(1, 100));
            Task<int> t3 = Task.Run(() => rand.Next(1, 100));
            var allTasks = Task.WhenAll(t1, t2, t3);
            allTasks.ContinueWith(task =>
            {
                int sum = t1.Result + t2.Result + t3.Result;
                Console.WriteLine($"Random numbers: {t1.Result}, {t2.Result}, {t3.Result}");
                Console.WriteLine("Sum = " + sum);
            }).Wait();

        }
    }
}
