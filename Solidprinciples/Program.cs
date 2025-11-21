using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
//convert to srp.
//public class Invoice
//{
//    public void GenerateInvoice()
//    {
//        // Code to generate the invoice
//    }

//    public void SaveToDatabase()
//    {
//        // Code to save invoice data to the database
//    }

//    public void SendEmail()
//    {
//        // Code to send the invoice via email
//    }
//}
namespace Solidprinciples
{
    public class Invoice
    {
        public void GenerateInvoice()
        {
            WriteLine("Invoice generation logic here");
        }
    }
    public class DatabaseRepository
    {
        public void SaveToDataBase()
        {
            WriteLine("saved to database");
        }
    }
    public class Email 
    { 
        public void SendToVoiceEmail()
        {
            WriteLine("sending email");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Invoice invoice = new Invoice();
            //invoice.GenerateInvoice();
            //DatabaseRepository database= new DatabaseRepository();  
            //database.SaveToDataBase();
            //Email email = new Email();
            //email.SendToVoiceEmail();

            // injector code

            //Mathcls ob = new Mathcls(new service());// constructor injection

            Mathcls ob = new Mathcls();
            //ob.GetInstance = new service();// property injection
            ob.show(new service());// method injection

        }
    }
}
