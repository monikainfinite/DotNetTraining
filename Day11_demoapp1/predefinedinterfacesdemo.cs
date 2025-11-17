using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_demoapp1
{
    internal class predefinedinterfacesdemo
    {
        static void Main(string[] args)
        {
            ArrayList items = new ArrayList() { "apple", "banna", "cherry", "guava" };
            IEnumerator enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("items in arraylist");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }  
    }
    //public class Product:IComparable<Product>
    //{
    //    public int ProductId {  get; set; }
    //    public string ProductName {  get; set; }
    //    public decimal Price { get; set; }
    //    public int CompareTo
    //}
}
