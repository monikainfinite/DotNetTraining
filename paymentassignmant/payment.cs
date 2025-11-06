using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentassignmant
{
     interface PaymentGateway
    {
        void Process(double amount);

    }
    public static class Helper {
        public static void Transcation(double amount)
        {
            Console.WriteLine($"Payment of {amount} processed.");

        }
        public static void showmethods()
        {
            Console.WriteLine("payment methods");
            Console.WriteLine("1.credit card");
            Console.WriteLine("2.UPI");
            Console.WriteLine("3.Wallet");
        }

    }

    public class CreditCard : PaymentGateway {

        public void Process(double amount) {

            Console.WriteLine($"processing {amount} via creditcard");
            Helper.Transcation(amount);
        }

    }
    public class UPI : PaymentGateway
    {

        public void Process(double amount)
        {

            Console.WriteLine($"processing {amount} via UPI");
            Helper.Transcation(amount);
        }

    }
    public class wallet : PaymentGateway
    {

        public void Process(double amount)
        {

            Console.WriteLine($"processing {amount} via wallet");
            Helper.Transcation(amount);
        }

    }


    internal class payment
    {
    }
}
