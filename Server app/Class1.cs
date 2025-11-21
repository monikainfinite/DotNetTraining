using RemoteLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Server_app
{
    public class ServerClass
    {
        //make the class library public (host the library file)
       
            public static void Main()
        {//tcp is faster than http protocol
         //all communcations happens in binary format
         //disadvantages:It is not platform-independent
         //http:advantages:it is platform dependent
         //any client can make a request (java,python)
         //all communication happen in Xml format.
            RemotingConfiguration.Configure("server.config", false);
            //TcpChannel channel = new TcpChannel(8085);//i am using tcp protocol
            ////HttpChannel for http protocol
            //ChannelServices.RegisterChannel(channel, false);
            ////channel means path/route.we are saying to server that pls use this path
            ////tcp route ,as it is tcp the comm happens in binary format.
            //RemotingConfiguration.RegisterWellKnownServiceType(
            //    typeof(ServiceClass),//which class we want to register
            //    "Hii",
            //    WellKnownObjectMode.Singleton);//single object is used for the client
            //                                //server creates object for each client
            Console.WriteLine("server started... Listening on port 8085");
            Console.WriteLine("Press enter to stop");
            Console.ReadLine();
           
        }
    }
}

