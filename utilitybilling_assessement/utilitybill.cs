using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilitybilling_assessement
{
    internal class utilitybill
    {
        public int CustomerId;
        public string CustomerName;
        public static int ratePerUnit = 5;
        public static double GetServiceCharge()
        {
            return 50;
        }
        public static double GetTaxRate(double total)
        {
            if (total > 1000)
                return 0.1;
            else
                return 0.05;
        }
        public int TotalUsage(params int[] readings)
        {
            int totalreading = 0;
            foreach (int reading in readings)
            {
                totalreading += reading;
            }
            return totalreading;
        }
        public void CalculateBill(int ratePerUnit,out double total,out double tax,out double netPayable,params int[] readings)
        {
            int usage = TotalUsage(readings);
            total = usage * ratePerUnit;
            double taxRate = GetTaxRate(total);
            tax = total * taxRate;
            double servicecharge = GetServiceCharge();
            netPayable = total + tax + servicecharge;

  
        }
    }
}
