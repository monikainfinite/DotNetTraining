using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8_assignment2log
{ public abstract class ShippingCalculator
    {
        public abstract decimal Calculator(decimal weight, string zone);
        public virtual string Label()
        {
            return "Generic Shipping service";
        }
    }
    public class StandardShipping : ShippingCalculator
    {
        public override decimal Calculator(decimal weight, string zone)
        {
            decimal baseRate =zone=="ZoneA"? 50m:100m;
            decimal costPerKg = 10m;
            return baseRate + (weight * costPerKg);
        }
        public override string Label()
        {
            return "Standard Shipping (3–5 Business Days)";
        }
    }
    public class ExpressShipping : ShippingCalculator
    {
        public override decimal Calculator(decimal weight, string zone)
        {
            decimal baseRate = zone=="ZoneB"?100m:150m;
            decimal costPerKg = 20m;
            return baseRate + (costPerKg * baseRate);
        }
        public override string Label()
        {
            return "Express Shipping (1–2 Business Days)";
        }
    }
    public class InternationalShipping : ShippingCalculator { 
     public override decimal Calculator(decimal weight, string zone)
        {
            decimal baseRate = 20m;
            decimal ratePerKg = zone == "US" ? 30m : 40m;
            return baseRate + (weight * ratePerKg);

        }
        public override string Label()
        {
            return "International Shipping (5–10 Business Days)";
        }
    }


    internal class shipping
    {
        static void Main(string[] args)
        {
            ShippingCalculator standard = new StandardShipping();
            ShippingCalculator express = new ExpressShipping();
            ShippingCalculator international = new InternationalShipping();
            Console.WriteLine($"{standard.Label()} => Cost: {standard.Calculator(5, "zoneA")}");
        Console.WriteLine($"{express.Label()} => Cost: {express.Calculator(3,"ZoneB" )}");
        Console.WriteLine($"{international.Label()} => Cost: {international.Calculator(2, "US")}");
            Console.ReadLine();
        }
    }
}

