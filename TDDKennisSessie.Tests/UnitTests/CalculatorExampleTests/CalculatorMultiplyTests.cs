using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDKennisSessie.TddExamples;

namespace TDDKennisSessie.Tests.UnitTests.CalculatorExampleTests
{
    [TestClass]
    public class CalculatorMultiplyTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void WhenMultiplingFiveByFiveThenTheResultShouldBeTwentyFive()
        {
            _calculator.Multiply(5, 5).Should().Be(25);
        }

        //Assignment 1
        //Implement multiple testscenario's like the tests above.
        //Alter the multiply method in a way that your tests will pass.
    }
}