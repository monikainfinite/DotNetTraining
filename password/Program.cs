using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String password;
            Console.WriteLine("enter your password");
            password = Console.ReadLine();
            if (password.Length < 6)
                Console.WriteLine($"Password Strength is : Weak");
            else if (password.Length >= 6 && password.Length <= 10)
                Console.WriteLine($"Password Strength is : Medium");
            else
                Console.WriteLine($"Password Strength is : Strong");
            Console.ReadLine();
        }
    }
}
