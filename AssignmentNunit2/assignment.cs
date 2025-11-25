using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentNunit2
{
    internal class assignment
    {
        public class BankAccount
        {
            public decimal Balance { get; private set; }

            public BankAccount(decimal openingBalance) => Balance = openingBalance;

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                    throw new ArgumentException("Amount must be positive");
                else
                    Balance += amount;
            }
            public void Withdraw(decimal amount)
            {
                if (amount > Balance)
                    throw new InvalidOperationException("Insufficient funds");
                Balance -= amount;
            }
            public List<string> History { get; } = new List<string>();
            public void Deposited(decimal amount1)
            {
                Balance += amount1;
                History.Add("Deposit " + amount1);
            }
            public void ApplyInterest(decimal rate)
            {
                Balance += Balance * rate;
            }
        }
    }
}
