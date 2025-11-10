using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideEasy_assessment
{
    internal class ride
    {
        public customer customer;
        public vehicle vehicle;
        public decimal distance;
        public DateTime rideDate;

        public ride(customer c, vehicle v, decimal dist, DateTime date)
        {
            customer = c;
            vehicle = v;
            distance = dist;
            rideDate = date;
        }

        public void ComputeBill(out decimal subtotal, out decimal gst, out decimal total, params string[] addOns)
        {
            subtotal = vehicle.baseFare + (vehicle.perKmRate * distance);
            subtotal += pricing.AddOnsCost(addOns);

           
            if (pricing.TryGetWeekendSurcharge(rideDate, out decimal percent))
            {
                subtotal += subtotal * percent / 100;
            }

            gst = pricing.CalculateGST(subtotal);
            total = subtotal + gst;
        }

        public void PrintInvoice(params string[] addOns)
        {
            
            ComputeBill(out decimal subtotal, out decimal gst, out decimal total, addOns);

            
            //decimal.TryParse("123", out _);

            decimal beforeCoupon = total;
            decimal couponAmount = 50m;

            Console.WriteLine("========== RideEasy Invoice ==========");
            Console.WriteLine($"Date: {rideDate:dd-MMM-yyyy}");
            Console.WriteLine($"Customer: {customer.customerName} ({customer.mobile})");
            Console.WriteLine($"Vehicle: {vehicle.type}");
            Console.WriteLine($"Distance: {distance} km");
            Console.WriteLine($"Add-Ons: {string.Join(", ", addOns)}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Subtotal:        {subtotal:0.00}");
            Console.WriteLine($"GST (18%):       {gst:0.00}");
            Console.WriteLine($"Total (before):  {total:0.00}");

           
            pricing.ApplyCoupon_ByRef(ref total, couponAmount);

         
            pricing.RedeemLoyalty(ref customer.loyaltyPoints, ref total);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Final Payable:    {total:0.00}");
            Console.WriteLine("--------------------------------------");

            
            decimal testTotal = beforeCoupon;
            if (pricing.TryApplyCoupon_ByValue(testTotal, couponAmount))
            {
                Console.WriteLine($"(Demonstration) Call-by-VALUE coupon attempt did NOT change total: {beforeCoupon:0.00}");
            }

            Console.WriteLine($"Remaining Loyalty Points: {customer.loyaltyPoints}");
            Console.WriteLine("======================================");
        }
    }
}
