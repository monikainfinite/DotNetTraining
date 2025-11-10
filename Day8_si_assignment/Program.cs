using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_si_assignment
{
    class Interest
    {
        public void InterestCalculate(double principle_amount,double rateOfInterest)
        {
            double interest = (principle_amount * rateOfInterest)/100;
            Console.WriteLine($"The SI for one year of amount {principle_amount} for {rateOfInterest} is {interest}");
        }
        public void InterestCalculate(double principle_amount, double rateOfInterest,double time)
        {
            double interest = (principle_amount * rateOfInterest*time)/100;
            Console.WriteLine($"The SI for {time} years of amount {principle_amount} for {rateOfInterest} is {interest}");
        }
        public void InterestCalculate(double principle_amount, double rateOfInterest,double time,int n)
        {
            double amount = principle_amount * Math.Pow((1 + (rateOfInterest / (n * 100))), n * time);
            double compoundInterest = amount - principle_amount;
            Console.WriteLine($"The CI for {time} years for principle amount of {principle_amount} of rate {rateOfInterest} for {n} times is {compoundInterest}");
        }





    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Interest interset= new Interest();  
            interset.InterestCalculate(1000,5);
            interset.InterestCalculate(10000, 5, 2);
            interset.InterestCalculate(10000, 5, 2,3);
        }
    }
}
