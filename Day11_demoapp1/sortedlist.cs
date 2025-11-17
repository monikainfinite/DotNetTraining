using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics.Eventing.Reader;

namespace Day11_demoapp1
{
    internal class sortedlist
    {
        static void Main(string[] args)
        {
        //    SortedList<int,string> products=new SortedList<int,string>();
        //    products.Add(101, "laptop");
        //    products.Add(102, "mobile");
        //    products.Add(103, "tab");
        //    foreach (var item in products)
        //    {
        //        Console.WriteLine("key: " + item.Key + "value :" + item.Value);
        //    }
            SortedList<int, string> inventory = new SortedList<int, string>();
            inventory.Add(202, "wheat-50kg");
            inventory.Add(201, "rice-30kg");
            inventory.Add(203, "ricebag-2");
            Console.WriteLine("items");
            Console.WriteLine("first item" + inventory.Keys[0]);
            Console.WriteLine("last item" + inventory.Values[inventory.Count-1]);

            foreach (var item in inventory)
            {
                Console.WriteLine("key" + item.Key + "value" + item.Value);
            }
            Console.WriteLine("enter key to search");
            int keyToSearch=Convert.ToInt32(Console.ReadLine());
            if (inventory.ContainsKey(keyToSearch))
            {
                Console.WriteLine("item found" + inventory[keyToSearch]);
            }
            else
            {
                Console.WriteLine("Item not found");
            }
            //search by value
            Console.WriteLine("enter value");
            string valueToSearch=Console.ReadLine();
            if (inventory.ContainsValue(valueToSearch)) {
                Console.WriteLine("item found" + inventory.IndexOfValue(valueToSearch));
            }
            else
            {
                Console.WriteLine("not found");
            }




             Console.WriteLine("enter the key to update");
            int keyToUpdate=Convert.ToInt32(Console.ReadLine());
            string newValue=Console.ReadLine();
            inventory[keyToUpdate]=newValue;
            Console.WriteLine("updated value" + inventory[keyToUpdate]);
            Console.WriteLine("remove ");
            inventory.Remove(203);
            Console.WriteLine("after removing");
            foreach (var item in inventory) {
                Console.WriteLine(item.Key + item.Value);
            }
            inventory.RemoveAt(0);
            Console.WriteLine("after removong at 0");
            foreach (var item in inventory) {
                Console.WriteLine(item.Key + item.Value);
            }
            //get index of key
            Console.WriteLine("Index of the 203" + inventory.IndexOfKey(203));
            inventory.Clear();
            Console.ReadLine();
        }
    }
}
