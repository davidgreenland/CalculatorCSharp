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
        [TestCase(1, 2, -1)]
        [TestCase(1, -2, 3)]
        [TestCase(-5, 10, -15)]
        [TestCase(-5, -10, 5)]
        [TestCase(305, -12345, 12650)]
        public void Subtract_returns_zero_when_inputs_are_one_and_zero(int a, int b, int expected)
        {
            var result = _calculator.Subtract(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Subtract method did not return {expected}");
        }
    }
}