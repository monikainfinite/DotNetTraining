using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Day9_DemoApp3
{
    internal class AgeException:ApplicationException
    {
        string message;
        public AgeException(int msg)
        {
            message = msg + "is invalid age.";
        }
        public override string ToString()
        {
            return message;
        }

    }
}
