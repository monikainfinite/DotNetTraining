using Moq;

namespace AssignmentMOQ
{
    public class Tests
    {
        public class CalculatorTest
        {
            [Test]
            public void CalcMoQ()
            {
                var mock = new Mock<ICalculator>();
                mock.Setup(m => m.Add(2, 3)).Returns(5);
                var result = mock.Object.Add(2, 3);
                Assert.That(result, Is.EqualTo(5));
                mock.Verify(m => m.Add(2, 3), Times.Once);
            }
        }
        public class Parser
        {
            [Test]
            public void Test_Parser()
            {
                var mockParser = new Mock<IParser>();

                int outValue = 123;
                mockParser.Setup(p => p.TryParse("123", out outValue))
             .Returns(true);
                int result;
                bool parsed = mockParser.Object.TryParse("123", out result);
                Assert.That(parsed, Is.True);
                Assert.That(result, Is.EqualTo(123));
                mockParser.Verify(p => p.TryParse("123", out outValue), Times.Once);

            }

        }


    }
}
