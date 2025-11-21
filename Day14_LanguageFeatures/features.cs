using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Day14_LanguageFeatures
{//.Net 4.x features
    internal class features
    {
        public delegate object mydel();//base type
        public delegate void mydel2(string str);//derived type
        public string cov() { return "hi"; }//derived type
        public void con(object ob) { WriteLine("hello"); }//base type
        public void hello()
        {
            mydel d = cov;
            WriteLine(d());
            mydel2 d2 = con;
            d2("hiiiii");
        }
        //Named parameter and optional parameter.
        //optional parameter:Assigning the default value or parameter.
        //for passing value to y in object then it is difficultso we will use named paraemter.
        //y:30 i.e,it assigns to y =30
        //it has some drawback that is when 2 methods are having same method names then the compiler prefer the one with no parameters 
        //although the other one have optioanl parameters..
        //in method overloading don't use named and optional parameter.
        public void NamedoptionalDemo(int x=10,int y=20)//optional parameter
        {
            int res = x + y;
            WriteLine(res);
        }
        public void NamedoptionalDemo()
        {
            
            WriteLine("hlo");//It will run first
        }
        //Feature:Covariance and contravariance
        public void Covariance_Contravariance()
        {
            //feature:to make delegates more  flexible 
            //.net 1.o we cant assign a list of strings to a object 
            //Co variance you can use a derived type instead of a base type.
            //Contravaraince is reverse of Co variance
            //string[] st = { "hlo", "welcome" };
            //object[] ob = st;
            //IEnumerable<string> names = new List<string>();
            //IEnumerable<object> objs = names;//Covariance-valid

            hello();
           
        }
        dynamic d;//we can declare it
        dynamic e = null;//we can assign null value
        public void dynamicDemo()//(dynamic a )we can pass as a parameter
        {//var:varient
            //var a = 100;//if we dont know what data type we have to asign then use var .
            //var b = "string";//datatype checked at compile time
            //var a2 = a * b;//at compile time it si checking
            //int p, q, r;//valid
            //var m, n, o;//invalid

            //b = "b";//valid
            //b = 2;//invalid

            //int x;
            //x = 10;//valid 
            //var p;
            //p = 10;//invalid

            //1.var cant be declared globally
            //2.multiple var variables not allowed in a single line.
            //3.you have to assign values ie,var a;a=10//invalid
            //4.null values cant be assignes ie,var a=null//invalid
            //5.cant be used as a function parameter ie,demo(var a )
            //dynamic m = 100;//more flexible than var
            ////datatype checked at runtime
            //dynamic n = "string";
            //dynamic o = m * n;//here it will not show error but while runtime it will
            dynamic n1 = 10;//integer
            WriteLine(n1);
            n1 = "hii";//string
            WriteLine(n1);
            n1 = 10.5;//double
            WriteLine(n1);

        }
    }
}
