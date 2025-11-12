using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day9_assignment_Minibankingsystem
{
    public class BankAccount
    {
        public string AccNumber { get;set; }
        public string AccHolder {  get;set; }   
        public decimal Balance { get;set; } 
        public BankAccount(string accNumber, string accHolder, decimal balance)
        {
            AccNumber = accNumber;
            AccHolder = accHolder;
            Balance = balance;
        }
        public static BankAccount operator+(BankAccount a, BankAccount b)
        {
            return new BankAccount("ACC"+a.AccNumber,a.AccHolder,a.Balance+b.Balance);
        }
        public static BankAccount operator -(BankAccount a, decimal amount)
        {
            if (amount > a.Balance)
            {
                Console.WriteLine($"Transcation failed");
                return a;
            }
            else
            {
                return new BankAccount(a.AccNumber, a.AccHolder, a.Balance-amount);   
            }

        }
        public static bool operator==(BankAccount a, BankAccount b)
        {
            return a.Balance==b.Balance;
        }
        public static bool operator !=(BankAccount a, BankAccount b)
        {
            return a.Balance!=b.Balance;
        }
        public static bool operator >(BankAccount a, BankAccount b)
        {
            return a.Balance>b.Balance;
        }
        public static bool operator <(BankAccount a, BankAccount b)
        {
            return a.Balance < b.Balance;
        }
        public override bool Equals(object obj)
        {
            if (obj is BankAccount other)
                return this.Balance == other.Balance;
            return false;
        }
        public override string ToString()
        {
            return $"Account Holder:{AccHolder},Account Number :{AccNumber} and Balance:{Balance}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Ac101", "Monika", 25000);
            BankAccount acc2 = new BankAccount("Ac102", "Teja sri", 50000);
            Console.WriteLine("enter amount to withdraw");
            decimal amount =Convert.ToDecimal( Console.ReadLine());
            Console.WriteLine(acc1);
            Console.WriteLine(acc2);
            Console.WriteLine("Merging account (using +)");
            BankAccount mereged = acc1 + acc2;
            Console.WriteLine($"Combined Balance : {mereged}");
            Console.WriteLine("comparing balances");
            Console.WriteLine($"AC101 < AC102 : {acc1 < acc2}");
            Console.WriteLine($"AC101 > AC102 : {acc1 > acc2}");
            Console.WriteLine($"AC101 == AC102 : {acc1 == acc2}");
            Console.WriteLine("Withdrawal operation (using -):");

            BankAccount withdraw = acc1 - amount;
            Console.WriteLine($"New Balance of {acc1.AccHolder}: {withdraw.Balance}");
            Console.ReadLine();


        }
    }
}
