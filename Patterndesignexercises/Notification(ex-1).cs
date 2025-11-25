using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Patterndesignexercises
{
    public interface INotification 
    { 
        void Send(string message);
    }
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            WriteLine("sending email notification" + message);
        }
    }
    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
           WriteLine("sending sms notification" + message);
        }
    }
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            WriteLine("sending push notification" + message);
        }
    }
    public class NotificationFactory
    {
        public static INotification GetNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SmsNotification();
                case "push":
                    return new PushNotification();
                default:
                    throw new Exception("Invalid notification type");

            }

        }
    }
        internal class Notification_ex_1_
    {
            public static void Main(string[] args)
            {
                WriteLine("Enter Notification Type (email / sms / push):");
                string type = ReadLine();
            INotification notification = NotificationFactory.GetNotification(type);
            notification.Send("Welcome Monika!");
        }
    }
    }

