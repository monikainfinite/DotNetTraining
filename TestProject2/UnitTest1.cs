//namespace TestProject2
//{//attributes:test,testcase,testcase source
//    //ignore,category,onetimesetup,onetimeteardown,
//    //setup,teardown
//    public class Tests
//    {//Nunit test
//     //this is where unit testing happens
//     //what to test?
//     //how to do unit testing steps are:
//        [SetUp]//calls before running each test
//        public void T1()
//        {//logic(are u admin or not)
//        }
//        [TearDown]//calls after running the test
//        public void T2()
//        {
//            //do loggong activities
//        }
//        [OneTimeSetUp]//calls before running test
//        public void T3()
//        {
//            //database connection logic goes here
//        }
//        [OneTimeTearDown]//calls after all the test is executed
//        public void T4()
//        {
//            //
//        }




//        [Test]
//        //[TestCase(10,10,20)]//parameterized test
//        //[TestCase(5, 7, 12)]
//        //[TestCase(-10, 10, 0)]
//        //[TestCase(-5, 1, -4)]
//        //[TestCaseSource(nameof(MyCombination))]
//        [TestCaseSource(nameof(GetDataFrom))]
      
//        public void Test1(int a,int b,int c)
//        {//how  to test add method?
//            //1)step-1 Arrange
//            //keepimg obj and required parameters ready
//            //what ever its requires to test Add keep all ready.
//            MyMath ob = new MyMath();
//            //int a = 5;
//            //int b = 10;

  
//            //2)step-2:Act
//            //we will execute add method and retrive the result
//            int result=ob.Add(a, b);



//            //3)Assert
//            //here unit testing happens
//             //i am excepting output as 15(a=5,b=10)
//             //whether program will return same output or not 
//             //assert is a static class
//            Assert.That(result,Is.EqualTo(c));//excepted and output


//            //this test method is crated to test add method
//        }
//        //private static object[] MyCombination =
//        //    {
//        //    new object[] { 1, 2, 3 },
//        //    new object[] { 4, 5,9 },
//        //    new object[] { 6, 7,13 },
//        //    new object[] { 8, 9,17 }



//        //};
//        static IEnumerable<object[]> GetDataFrom()
//        {
//            foreach (var line in File.ReadAllLines(@"C:\example\data.csv"))
//            {
//                var parts = line.Split(',');
//                yield return new object[] 
//                {
//                int.Parse(parts[0]),
//                int.Parse(parts[1]),
//                int.Parse(parts[2])
//                };

//            }
//        }

//        [Test]
//        [Ignore("not yet ready")]
//        [Category("Simple Math")]
//        public void Test2()
//        {
//            //thos test method is crated to test multiply method
//            MyMath ob2=new MyMath();
//            int c = 5;
//            int d = 10;
//            int res=ob2.Multiply(c, d);
//            Assert.That(res, Is.EqualTo(50));
//        }
//        [Test]
//        [Category("db")]
//        public void Test3()
//        {
//            MyMath ob=new MyMath();
//            var res = ob.Database(10, 5);
//            Assert.That(res, Is.EqualTo(2));
//        }
//        //[Test]
//        //[Category("Files")]
//        //public void Test4()
//        //{
//        //    MyMath ob = new MyMath();
//        //    var res = ob.Filehandling(10, 5);
//        //    Assert.That(res, Is.EqualTo(2));
//        //}
//        //[Test]
//        //[Category("Simple Math")]
//        //public void Test5()
//        //{
//        //    MyMath ob = new MyMath();
//        //    var res = ob.Subtract(10, 5);
//        //    Assert.That(res, Is.EqualTo(5));
//        //}
//        //[Test]
//        //[Category("simple Math")]
//        //public void Test6()
//        //{
//        //    MyMath ob = new MyMath();
//        //    var res = ob.Divide(10, 5);
//        //    Assert.That(res, Is.EqualTo(2));
//        //}
//    }
//}
