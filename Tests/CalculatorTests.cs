using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class CalculatorTests
    {
        [Test]
        public void Add_returns_zero_when_both_inputs_are_zero()
        {
            var calculator = new Calculator();

            var result = calculator.Add(0, 0);

            Assert.That(result, Is.EqualTo(0), "Calculator did not return zero");
        }

        [Test]
        public void Add_returns_three_when_inputs_are_one_and_two()
        {
            var calculator = new Calculator();

            var result = calculator.Add(1, 2);

            Assert.That(result, Is.EqualTo(3), "Basic addition did not return 3");
        }
    }
}
