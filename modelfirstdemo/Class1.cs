using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelfirstdemo
{
    internal class Class1
    {
        Model1Container ob = new Model1Container();
        public void Addpizza()
        {
            Pizzas p = new Pizzas() { PizzaId = 200, Pizzaname = "corns veg", Price = 300, Description = "made with corns", Type = "veg" };
            ob.Pizzas.Add(p);
            int i = ob.SaveChanges();
            Console.WriteLine("rows affected" + i);
            foreach (var item in ob.Pizzas)
            {
                Console.WriteLine($"{item.PizzaId} {item.Pizzaname} {item.Price} {item.Description} {item.Type}");
            }

        }
        //extension methods
       public void EvenODD()
        {
           
            string st = "hello world";
            //isupper 
            int i = 10;
           Console.WriteLine( i.IsEven());
        }
    }
}
//for creating our own methods
//the class and method has to be static
//it must take atleast one parameter

static class myclass
{
    static public bool IsEven(this int i )
    {
        return i % 2 == 0;
    }
}
