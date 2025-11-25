using System.Security.Cryptography.X509Certificates;
using static AssignmentNunit.assignment;

namespace AssignmentNunit
{
    public class Tests
    {//exercise-1
        [Test]
        public void CalculatorTest()
        {
            Calculator cal = new Calculator();
            int res = cal.Square(2);
            Assert.That(res, Is.EqualTo(4));

        }
        [Test]
        public void StringHelperTest()
        {
            StringHelper s = new StringHelper();
            string res = s.ToUpper("Hello");
            Assert.That(res.Length, Is.EqualTo(5));
            Assert.That(res[0], Is.EqualTo('H'));
            Assert.That(res, Is.EqualTo("HELLO"));
        }
        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(-1, 5, -5)]
        [TestCase(0, 19, 0)]
        public void MultiplyTest(int a, int b, int c)
        {
            MyMath m = new MyMath();

            int res = m.Multiply(a, b);
            Assert.That(res, Is.EqualTo(c));
        }

        [Test]
        public void StudentTest()
        {
            StudentService s = new StudentService();
            Assert.Throws<ArgumentException>(() => s.ValidateAge(-10));
        }
        
        public class MyTests
        {
            // This method runs **before each test**
            [SetUp]
            public void T1()
            {
                Console.WriteLine("Setup method is called");
            }

            // This method runs **after each test**
            [TearDown]
            public void T2()
            {
                Console.WriteLine("Teardown method is called");
            }

            // Test 1
            [Test]
            public void Test1()
            {

                Console.WriteLine("test 1 is called");
                Assert.Pass();
            }

            // Test 2
            [Test]
            public void Test2()
            {
                Console.WriteLine("test 2 is called");
                Assert.Pass();
            }
        }

        [Test]
        public void NumbersTest()
        {
            NumberService n=new NumberService();
            var res = n.GetEvenNumbers();
            Assert.That(res.Count,Is.EqualTo(4));
            for (int i = 0; i < res.Count - 1; i++)
            {
                Assert.That(res[i], Is.LessThanOrEqualTo(res[i + 1]));
            }
            foreach (var r in res)
            {
                Assert.That(r % 2, Is.EqualTo(0));
            }
        }
        [Test]
        public void string_Test() 
        {
            string text = "NUnitFramework";
            Assert.That(text,Does.StartWith("NUnit"));
            Assert.That(text, Does.EndWith("work"));
            Assert.That(text, Does.Contain("Frame"));
            Assert.That(text, Has.Length.EqualTo(14));
        }
        [Test]
        public async Task Test_GetMarks()
        {
            MarksService m = new MarksService();
            int res =await  m.GetMarksAsync();
            Assert.That(res, Is.EqualTo(90));

        }
        private static object[] Mycombination =
{
    new object[] { 45 },
    new object[] { 50},
    new object[] { 60 }
};
        [Test]
        [TestCaseSource(nameof(Mycombination))]
        public void Test_Marks_GreaterThan40(int mark)
        {
            Assert.That(mark, Is.GreaterThan(40));
        }

    }
}

