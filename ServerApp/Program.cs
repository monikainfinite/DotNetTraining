using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("server.config", false);
            Console.WriteLine("Server Started... Waiting for client...");
            Console.ReadLine();
        }
    }
}
