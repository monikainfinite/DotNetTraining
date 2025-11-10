using e_commerece_assignment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerece_assignment.Notifications
{
    public class SmsNotifier : INotifier
    {
        public void Notify(string to, string message)
        {
           
            System.Console.WriteLine("[SMS to {0}]: {1}", to, message);
        }
    }
}
