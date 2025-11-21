using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidprinciples
{
    public interface IWorker
    {
        void Work();
        void eat();
    }
    public interface IManager
    {
        void ManageTeam();
    }
    public class Worker : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Worker is working");
        }

        public void eat()
        {
            Console.WriteLine("Worker is eating");
        }
    }
    public class Manager : IWorker,  IManager
    {
        public void Work()
        {
            Console.WriteLine("Manager is working");
        }

        public void eat()
        {
            Console.WriteLine("Manager is eating");
        }

        public void ManageTeam()
        {
            Console.WriteLine("Manager is managing the team");
        }
    }
    internal class ISP
    {
        public static void Main(string[] args)
        {
            IWorker w = new Worker ();
            IWorker w1 = new Manager();
            IManager m = new Manager();
            w.Work();
            w.eat();
            w1.eat();
            w1.Work();
            m.ManageTeam();

        }
    }
}
