using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using RemoteTRn;
using static System.Console;

namespace ClientApp2
{
    internal class Program
    {
        static async Task  Main(string[] args)
        {
            RemotingConfiguration.Configure("Client.config", false);

            IStudentService proxy = (IStudentService)
                Activator.GetObject(typeof(IStudentService),
                "tcp://localhost:9999/StudentService");

            WriteLine("---- Student List From Server ----");
           
                proxy.ShowAllStudents();
            
          

            Write("\nEnter Student ID: ");
            int id = Convert.ToInt32(ReadLine());
            
            //var result = proxy.GetStudentAsync(id).Result;
            Student result = await Task.Run(() => proxy.GetStudent(id));
           WriteLine("\nResult from GetStudentAsync:");
           WriteLine(result);
        }
    }
}
