using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_assignmentRestaurant
{
    public class Order
    {
        public int OrderId {  get; set; }
        public string CustomerName {  get; set; }
        public decimal TotalAmount {  get; set; }
        public override string ToString()
        {
            return $"OrderId :{OrderId}, Customer:{CustomerName} ,Total Amount :{TotalAmount}";
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList orderList = new ArrayList();
            Order newOrder = new Order();
            orderList.Add(new Order{ OrderId=101,CustomerName="Monika",TotalAmount=350.50m});
            orderList.Add(new Order { OrderId = 102, CustomerName = "Monika", TotalAmount = 350.50m });
            orderList.Add(new Order { OrderId = 103, CustomerName = "Monika", TotalAmount = 350.50m });
            while (true)
            {
                Console.WriteLine("\n====== FOODIFY - Restaurant Order Management ======");
                Console.WriteLine("1. Add New Order");
                Console.WriteLine("2. Display All Orders");
                Console.WriteLine("3. Search Order by ID");
                Console.WriteLine("4. Remove Order by ID");
                Console.WriteLine("5. Show Total Number of Orders");
                Console.WriteLine("6. Sort Orders by Amount");
                Console.WriteLine("7. Reverse Order List (Latest First)");
                Console.WriteLine("8. Exit");
                Console.WriteLine("\n Enter your choice");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("enter order Id,customer name and amount");
                        newOrder.OrderId = Convert.ToInt32(Console.ReadLine());
                        newOrder.CustomerName = Console.ReadLine();
                        newOrder.TotalAmount = Convert.ToDecimal(Console.ReadLine());
                        orderList.Add(newOrder);
                        Console.WriteLine("order added sucessfully");
                        break;
                    case 2:
                        if (orderList.Count == 0)
                        {
                            Console.WriteLine("NO orders found");
                        }
                        else
                        {
                            Console.WriteLine("orders");
                            foreach (Order order in orderList)
                            {
                                Console.WriteLine(order);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Order Id to search");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        bool found = false;
                        foreach (Order order in orderList)
                        {
                            if (order.OrderId == searchId)
                            {
                                Console.WriteLine("Order Found");
                                Console.WriteLine(order);
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                            Console.WriteLine(" Order not found!");
                        break;
                    case 4:
                        Console.WriteLine("enter orderId to remove");
                        int removeId= Convert.ToInt32(Console.ReadLine());
                        Order orderToRemove = null;
                        foreach (Order order in orderList)
                        {
                            if (order.OrderId == removeId)
                            {
                                orderToRemove = order;
                                break;
                            }
                        }
                        if (orderToRemove != null)
                        {
                            orderList.Remove(orderToRemove);
                            Console.WriteLine(" Order removed successfully!");
                        }
                        break;
                    case 5:
                        Console.WriteLine($"Total number of orders: {orderList.Count}");
                        break;
                    case 6:
                        orderList.Sort(new OrderAmountComparer());
                        Console.WriteLine("sorted");
                        foreach (Order order in orderList)
                        {
                            Console.WriteLine(order);

                        }
                        break;
                    case 7:
                        orderList.Reverse();
                        Console.WriteLine("orders reversed");
                        foreach(Order order in orderList)
                        {
                            Console.WriteLine(order);
                        }
                        break;
                    case 8:
                        Console.WriteLine("Thankyou");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
    public class OrderAmountComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Order o1 = (Order)x;
            Order o2 = (Order)y;
            return o1.TotalAmount.CompareTo(o2.TotalAmount);
        }
    }
}
