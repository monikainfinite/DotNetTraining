using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8_assignment2log
{
    class Logger {
     public void Log(string message)
        {
            Console.WriteLine($"the message is {message}");
        }
        public void Log(string message,int level)
        {
            Console.WriteLine($"the msg is {message} and level is {level}");
        }
        public void Log(string message,DateTime time)
        {
            Console.WriteLine($"The time is {time} : message {message}");
        }
        public void Log(string message,int level, DateTime time)
        {
            Console.WriteLine($"The time is {time} : message {message} and the level is {level}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger=new Logger();
            logger.Log("program starting....");
            logger.Log("program", 2);
            logger.Log("program",DateTime.Now);
            logger.Log("program", 2, DateTime.Now);
            Console.ReadLine();
        }
    }
}
