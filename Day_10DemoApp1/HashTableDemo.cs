using System;
using System.Collections;
namespace Day_10DemoApp1
{
    internal class HashTableDemo
    {
        static void Main(string[] args)
        {
           Hashtable ht = new Hashtable();
            ht.Add(1, "anvith");
            ht.Add(2, "keerthana");
            ht.Add("eid", 109);
            ht.Add("dept", "IT");
            ht["email"] = "sample@mail.com";
            ht.Add("location", "hyd");
            ht[56] = "test value";
            Console.WriteLine("first value" + ht[1]);
            Console.WriteLine("count" + ht.Count);
            Console.WriteLine("the key 56 " + ht.ContainsKey(56));
            Console.WriteLine("the value sample.com is available" + ht.ContainsValue("sample@mail.com"));
            Console.WriteLine("the keys are");
            foreach(var item in ht.Keys)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("the value are");
            foreach (var item in ht.Values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("both keys and values");
            foreach (DictionaryEntry item in ht)
            
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
            object[] keysArray=new object [ht.Keys.Count];
            ht.Keys.CopyTo(keysArray,0);
            Console.WriteLine("after copying");
            foreach (var key in keysArray)
            {
                Console.WriteLine(key);
            }Hashtable ht2= new Hashtable();
            foreach(DictionaryEntry item in ht)
            {
                ht2[item.Key] = item.Value;
            }

            ht.Clear();
            Console.WriteLine("after cleaming " + ht.Count);
            Console.ReadLine();

        }
    }
}
