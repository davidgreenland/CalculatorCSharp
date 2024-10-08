using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class SubtractTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup() => _calculator = new Calculator();

        [TestCase(1, 0, 1)]
        [TestCase(5, 2, 3)]
        public void Subtract_returns_zero_when_inputs_are_one_and_zero(int a, int b, int expected)
        {
            var _calculator = new Calculator();

            var result = _calculator.Subtract(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Subtract method did not return {expected}");
        }
    }
}