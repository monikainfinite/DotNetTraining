using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_assignemt
{
    class ProductDetails 
    {
        List<Products> li = new List<Products>()
 {
 new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
 new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
 new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
 new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
 new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
 new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
 };

    public void show2()
        {
            //1.find second highest price
            var res1 = li.OrderByDescending(p => p.price).Skip(1).Take(1);
            Console.WriteLine("second highest price");
            foreach(var r1 in res1)
            {
                Console.WriteLine(r1.price);
            }
            // 2.display top 3 highest price
            var res2 = li.OrderByDescending(p => p.price).Take(3);
            Console.WriteLine("top 3 highest price");
            foreach (var r2 in res2)
            {
                Console.WriteLine($" {r2.pname} {r2.price}");
            }
            //  3.find the sum of price where product names contains letter 'O'
            var res3 = li.Where(p => p.pname.Contains("o")).Sum(p => p.price);
            Console.WriteLine($"the sum is {res3}");
            // find the product name ends with e and display only pid and pname(filter by column name))
            var res4 = li.Where(p => p.pname.EndsWith("e")).Select(p => new { p.pid, p.pname });
            Console.WriteLine("ending with e");
            foreach (var r4 in res4)
            {
                Console.WriteLine($"{r4.pid} {r4.pname}");
            }
            // 5.group all records by qty find max of pric
            var res5 = li.GroupBy(p => p.qty).Select(g => new { Qty = g.Key, Maxprice = g.Max(p => p.price) });
            Console.WriteLine("group records and find max proce");
            foreach (var r5 in res5)
            {
                Console.WriteLine($"{r5.Qty} {r5.Maxprice}");
            }
            // Q5.Find sum of price of all products.
            var res6 = li.Sum(p => p.price);
            Console.WriteLine("the sum of all products "+res6);
            //Q6.Find count of products where price > 5000.
            var res7 = li.Count(p => p.price > 5000);
            Console.WriteLine("the count of products having price greater than 5000 is " + res7);
        }
    }
    class arrays
    {
        List<int> listA = new List<int> { 10, 20, 30, 40, 50, 20, 30 };
        List<int> listB = new List<int> { 30, 40, 50, 60, 70, 40 };
        List<string> names1 = new List<string> { "Akshay", "Aasritha", "Deepa", "Kiran",
"Kiran" };
        List<string> names2 = new List<string> { "Kiran", "Manikanta", "Deepa", "Naveen"
};
        public void show3()
        {//Q1.Write a LINQ query to fetch unique values from listA.
            var res1 = listA.Distinct();
            Console.WriteLine("unique values");
            foreach(var r1 in res1)
            {
                Console.WriteLine(r1);
            }
           // Q2.Combine values from listA and listB without duplicate
           var res2=listA.Union(listB);
            Console.WriteLine("Combined values without duplicates:");
            foreach (var r2 in res2)
            {
                Console.WriteLine(r2);
            }
            //Q3.Find items common in listA and listB.
            var res3=listA.Intersect(listB);
            Console.WriteLine("Common values :");
            foreach (var r3 in res3)
            {
                Console.WriteLine(r3);
            }
           // Q4.Find names present in names1 but not in names2
           var res4=names1.Except(names2);
            Console.WriteLine("present in names1 but not in names2");
            foreach (var r4 in res4)
            {
                Console.WriteLine(r4);
            }
            //Q7.Find the highest value in listA.
            var res7 = listA.Max();
            Console.WriteLine("the max value in listA is "+res7);
            // Q8.Write a LINQ query to find numbers divisible by 3
            int[] numbers = { 1, 4, 9, 16, 25, 36 };
            var res8 = numbers.Where(n => n % 3 == 0);
            Console.WriteLine("divisible by 3");
            foreach(var r8 in res8)
            {
                Console.WriteLine(r8);
            }
            //9.Write a Linq to query to sort based on string Length
            string[] st = { "India", "Srilanka", "canada", "Singapore" };
            var res9 = st.OrderBy(s => s.Length);
            Console.WriteLine("sorted by len");
            foreach(var r9 in res9)
            {
                Console.WriteLine(r9);
            }

        }
    }
}
