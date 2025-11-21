using RemotingTrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
namespace ClientApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {// an application who wants to consume the service
                RemotingConfiguration.Configure("Client.config", false);
                //TcpChannel channel = new TcpChannel();// i want to communicate using binary format
                //                                      //TcpChannel channel1 = channel;
                //ChannelServices.RegisterChannel(channel, false);// register the the path, no security

                //// Connect to remote object
                //IMyInter ob = (IMyInter)Activator.GetObject(
                //    typeof(IMyInter),
                //    "tcp://localhost:8085/Hii");
                // Get all registered client types
                var entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();

                if (entries.Length == 0)
                {
                    Console.WriteLine("No client types registered in config.");
                    return;
                }
                // Use the registered URL from config
                var remoteType = entries[0];// read the first data  
                IMyInter ob = (IMyInter)Activator.GetObject(remoteType.ObjectType, remoteType.ObjectUrl);
                Console.WriteLine("Connected to remote object...");
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();

                string result = ob.Show(name);
                Console.WriteLine(result);


                Console.Read();

            }
        }
    }

    
}
