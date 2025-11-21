using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//creational Design Pattern
//how to create singleton object(for not duplicating the object)
//1.the class is selaed//so that no inheritance
//2.make the class constructor private // so that we cant create object for that class
//3.create static property to generate instance
namespace Designpatterns
{
    internal sealed class Singleton
    {
        private Singleton() { }
        static Singleton s = null;
        public static Singleton GetInstance
        {
            get
            {
                if (s == null)//first request for object creation
                {
                    s = new Singleton();
                    return s;
                }
                else //second request
                    return s;
            }

        }
        public void Method()
        {
            Console.WriteLine("database code triggered");
        }
    }
    class abc
    {
        public void hi()
        {
            var res = Singleton.GetInstance;
            res.Method();

        }

    }
}
