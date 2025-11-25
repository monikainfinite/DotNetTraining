using System.Security.Principal;
using static AssignmentNunit2.assignment;

namespace AssignmentNunit2
{
    public class Tests
    {//verifying balance is 500
      [Test]
      public void Test_Balance()
        {
            BankAccount acc = new BankAccount(500);
            Assert.That(acc.Balance, Is.EqualTo(500));
        }
        [Test]
        public void test_Deposit()
        {//checking final balance
            BankAccount acc = new BankAccount(1000);
            acc.Deposit(200);
            Assert.That(acc.Balance,Is.EqualTo(1200));
        }
        [Test]
        public void Test_Withdraw()
        {//if amount 300 is withdraen
            BankAccount acc = new BankAccount(500);
            acc.Withdraw(300);
            Assert.That(acc.Balance, Is.EqualTo(200));
        }
        [Test]
        public void Test_exception()
        {//if withdraw amount >balance
            BankAccount acc = new BankAccount(500);

            Assert.Throws<InvalidOperationException>(() => acc.Withdraw(600));
        }
        //using testcases
        [Test]
        [TestCase(100, 50, 150)]
        [TestCase(0, 100, 100)]
        [TestCase(500, 0, 500)]
        public void Deposit_Test(decimal opening, decimal deposit, decimal excepted)
        {
            BankAccount acc = new BankAccount(opening);
            acc.Deposit(deposit);
            Assert.That(excepted, Is.EqualTo(acc.Balance));

        }
        //transiction history count
        [Test]
        public void History_test()
        {
            BankAccount acc = new BankAccount(0);
            acc.Deposited(100);
            acc.Deposited(200);
            Assert.That(acc.History.Count, Is.EqualTo(2));
        }
        //using testcasesource
        public static IEnumerable<object[]> WithdrawalCases()
        {
            yield return new object[] { 1000m, 200m, 800m };
            yield return new object[] { 500m, 100m, 400m };
            yield return new object[] { 250m, 50m, 200m };
        }
        [Test]
        [TestCaseSource(nameof(WithdrawalCases))]
        public void Withdrawal(decimal opening, decimal withdrawal, decimal expected)
        {
            BankAccount acc = new BankAccount(opening);
            acc.Withdraw(withdrawal);
            Assert.That(acc.Balance, Is.EqualTo(expected));
        }
        //negative deposit
        [Test]
        public void Deposit_Negative()
        {
            BankAccount acc = new BankAccount(100);
            var ex = Assert.Throws<ArgumentException>(() => acc.Deposit(-10));
            Assert.That(ex.Message, Does.Contain("positive"));

        }
        [Test]
        public void Balance_never_negative()
        {
            BankAccount acc = new BankAccount(100);
            var ex = Assert.Throws<InvalidOperationException>(() => acc.Withdraw(200));
            Assert.That(acc.Balance, Is.EqualTo(100));
        }
        [Test]
        //interest
        public void Interest()
        {
            BankAccount acc = new BankAccount(1000);
            decimal rate = 0.05m;
            acc.ApplyInterest(rate);
            Assert.That(acc.Balance, Is.EqualTo(1050m));
        }
    }
}
