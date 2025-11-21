using ClassLibrary1;
using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_LanguageFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //features ob=new features();
            //ob.NamedoptionalDemo(50);//it takes for x =50
            //ob.NamedoptionalDemo(y: 50);//named parameter
            //ob.NamedoptionalDemo();//output:hlo (because the method has no aprameters )
            //ob.Covariance_Contravariance();
            //ob.dynamicDemo();
            //TPLDemo t = new TPLDemo();
            //////t.NonParallel();
            ////t.Pareller();
            //t.TASKDEMO();
            //Csharp7 ob = new Csharp7();
            ////var res=ob.tupledemo();//without deconstruction
            ////deconstruction
            //(var id,var name)= ob.tupledemo();
            ////Console.WriteLine("id "+res.Item1);
            ////Console.WriteLine("name "+res.Item2);
            //Console.WriteLine("id " + id);
            //Console.WriteLine("name " + name);
            //ob.outdemo();
            //ob.patternMatching();

            //Console.WriteLine(ob.localFunction(100));
            //ob.throwexpdemo();
            Class1 c = new Class1();
            var a=c.Add(2, 3);
            Console.WriteLine(a);
            Class2 c2=new Class2();
            var c3 = c2.sub(5, 3);
            Console.WriteLine(c3);
        }
    }
}
