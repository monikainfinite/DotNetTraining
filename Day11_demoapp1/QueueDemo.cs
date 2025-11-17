using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Day11_demoapp1
{
    internal class QueueDemo
    {
        static void Main(string [] args)
        {
            Queue queue = new Queue();
            queue.Enqueue(109);
            queue.Enqueue("moni");
            queue.Enqueue(109.3);
            queue.Enqueue(true);
            foreach (Object item in queue)
            {
                Console.WriteLine(item+" ");
            }
            queue.Dequeue();//removes first element i.e,109
            Console.WriteLine("after dequeue the count is "+queue.Count);
            Console.WriteLine("top item"+queue.Peek());
            Console.ReadLine();
        }
        

    }
}
