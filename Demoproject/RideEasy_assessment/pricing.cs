using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideEasy_assessment
{
    internal class pricing
    {
       public static decimal CalculateGST(decimal amount)
        {
            return amount * 0.18m;
        }
        public static bool TryGetWeekendSurcharge(DateTime rideDate, out decimal percent)
        {
            if (rideDate.DayOfWeek == DayOfWeek.Saturday || rideDate.DayOfWeek == DayOfWeek.Sunday)
            {
                percent = 0.10m;
                return true;
            }
            percent = 0;
            return false;

        }
        public static decimal AddOnsCost(params string[] addOns)
        {
            decimal cost = 0;
            foreach(string add in addOns)
            {
                switch (add.ToLower())
                {
                    case "child-seat":
                        cost += 100;
                        break;
                    case "fast-tag":
                        cost += 50;
                        break;
                    case "priority-pickup":
                        cost += 150;
                        break;
                    case "extra-luggage":
                        cost += 75;
                        break;

                }    }
            return cost;
        }
        public static bool TryApplyCoupon_ByValue(decimal total,decimal couponAmount)
        {
            if(couponAmount>0 && couponAmount < total)
            {total-=couponAmount;
                return true;

            }
            return false;
        }
       public static void ApplyCoupon_ByRef(ref decimal total, decimal couponAmount)
        {
            if (couponAmount > 0 && couponAmount < total)
            {
                total -= couponAmount;
                Console.WriteLine($"Coupon (by REF):   - applied {couponAmount:0.00}");
            }
        }
        public static void RedeemLoyalty(ref int points, ref decimal total)
        {
            if(points > 0)
            {

                int redeemable;
                if(points<(int)(total/10))
                    redeemable = points;
                else
                    redeemable = (int)(total/10);
                total-=redeemable;
                points-=redeemable;
                Console.WriteLine("Loyalty redeem:    - applied up to available points");
            }
        }
        

        }
}
