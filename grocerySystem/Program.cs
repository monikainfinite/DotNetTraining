using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace grocerySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Smart Grocery Billing Sysytem");
            Console.WriteLine("Enter how many items you want to add:");
            int count=Convert.ToInt32(Console.ReadLine());
            double grandTotal = 0;
            for(int i = 0; i < count; i++)
            {
                Console.Write($"\n enter details of item {i + 1}");
                grocery item=new grocery();
                Console.Write("Item Name: ");
                item.itemName = Console.ReadLine();
                Console.Write("Quantity: ");
                item.quantity=Convert.ToInt32(Console.ReadLine());
                Console.Write("Price per Unit: ");
                item.priceperUnit = Convert.ToInt32(Console.ReadLine());
                double itemTotal = item.CalculateItemTotal();
                grandTotal+=itemTotal;
                Console.WriteLine($"Total amount for {item.itemName}: {itemTotal}");

            }
            grocery bill=new grocery();
            bill.CalculateDiscount(grandTotal, out double discount, out double finalAmount);
            Console.WriteLine("\n=== FINAL BILL ===");
            Console.WriteLine($"Grand Total : {grandTotal}");
            Console.WriteLine($"Discount Applied : {discount}");
            Console.WriteLine($"Amount to Pay : {finalAmount}");
            Console.WriteLine("\nThank you for shopping with us!");
            Console.ReadLine();
        }
    }

}
