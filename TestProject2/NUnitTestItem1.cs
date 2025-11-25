namespace TestProject2;

public class NUnitTestItem1
{
    [SetUp]//calls before running each test
    public void T1()
    {//logic(are u admin or not)
        var res = File.AppendText("C:\\example\\app.txt");
        res.WriteLine("setup method ");
        res.Dispose();
    }
    [TearDown]//calls after running the test
    public void T2()
    {
        //do loggong activities
        var res = File.AppendText("C:\\example\\app.txt");
        res.WriteLine("teardown method ");
        res.Dispose();
    }
    [OneTimeSetUp]//calls before running test
    public void T3()
    {
        //database connection logic goes here
        var res = File.AppendText("C:\\example\\app.txt");
        res.WriteLine("onetimesetup method ");
        res.Dispose();
    }
    [OneTimeTearDown]//calls after all the test is executed
    public void T4()
    {
        //close database connection
        var res = File.AppendText("C:\\example\\app.txt");
        res.WriteLine("onetimeteardown method ");
        res.Dispose();
    }
    [Test]
    public void Add()
    {
        var res = File.AppendText("C:\\example\\app.txt");
        res.WriteLine("add method ");
        res.Dispose();
        Assert.Pass();
    }
    [Test]
    public void Multiply()
    {
        var res = File.AppendText("C:\\example\\app.txt");
        res.WriteLine("multiply method ");
        res.Dispose();
        Assert.Pass();

    }
}
