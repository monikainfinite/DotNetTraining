using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trafficlight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string color, action="";
            Console.WriteLine("enter light color: ");
            color= Console.ReadLine();
            if (color == "Red")
                action = "Stop";
            else if (color == "Yellow")
                action = "Get Ready";
            else if(color=="Green")
                action = "Go";
            Console.WriteLine($"Action: {action}"); 
        }
    }
}
