using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_DemoApp2
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(string accountNumber, double initialBalance) : base(accountNumber, initialBalance) { }
        public override void CalculateInterest()
        {
            Console.WriteLine("current account do not earn interest");
}
        }
    }

