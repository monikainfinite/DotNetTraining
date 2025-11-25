using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentMOQ
{
    public interface ICalculator
    {
        int Add(int a, int b);
    }
    public interface IParser
    {
        bool TryParse(string input, out int number);
    }
    internal class assignment
    {
    }
}
