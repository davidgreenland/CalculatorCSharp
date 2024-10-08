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

        [TestCase(1, 2, 3)]
        public void Add_returns_expected_result_for_given_inputs(int a, int b, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Basic addition did not return {expected}");
        }
    }
}
