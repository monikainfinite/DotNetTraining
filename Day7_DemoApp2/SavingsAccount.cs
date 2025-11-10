using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_DemoApp2
{
    public class SavingsAccount : BankAccount {
        public SavingsAccount(string accountNumber, double initialbalance) : base(accountNumber, initialbalance)
        {
        }
      public override void CalculateInterest()
        {
            double Interest = Balance * 0.40;
            Balance += Interest;
            Console.WriteLine($"Interest of {Interest} added.New balance is {Balance}");

        }
    }

}
