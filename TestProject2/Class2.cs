using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2
{
    internal class Class2
    {
        //how TDD unit test works?? Test driven developemnt
        [Test]
        public void Test()
        {
            helloclass1 ob = new helloclass1();
            int res = ob.AddNums(10, 20);
            Assert.That(res, Is.EqualTo(30));
        }
        [Test]
        public void Test2()
        {
            helloclass1 ob = new helloclass1();
            int res = ob.Multiply(10, 20);
            Assert.That(res, Is.EqualTo(200));
        }
        }
}
