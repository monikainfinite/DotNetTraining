using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Day1_ASSIGNMENT
{
    internal class isupper
    {  public void show()
        {
            string name = "Monika";
            WriteLine(name.IsUpper());
            string name2 = "MONIKA";
            WriteLine(name2.IsUpper());
        }
    }
}
    public static class ExtensionsDemo
    {
        public static bool IsUpper(this string str)
        {
            if(string.IsNullOrEmpty(str)) return false;
            return str.Equals(str.ToUpper());
        }
    }

