using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args, TcpChannel channel)
        {// an application who wants to consume the service

            TcpChannel channel = new TcpChannel(8085);//i am using tcp protocol
            //HttpChannel for http protocol
            ChannelServices.RegisterChannel(channel, false); he path, no security

            // Connect to remote object
            IMyinter ob = (IMyinter)Activator.GetObject(
                typeof(IMyinter),
                "tcp://localhost:8085/Hi");

            Console.WriteLine("Connected to remote object...");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            string result = ob.Show(name);
            Console.WriteLine(result);


            Console.Read();

        }
    }
}
