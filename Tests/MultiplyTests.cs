using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class MultiplyTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup() => _calculator = new Calculator();

        [TestCase(1, 1, 1)]
        [TestCase(3, 4, 12)]
        [TestCase(-3, 4, -12)]
        [TestCase(-3, -4, 12)]
        [TestCase(98, 1423, 139454)]
        public void Multiply_returns_expected_result_for_given_inputs(int a, int b, int expected)
        {
            var result = _calculator.Multiply(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Multiplication did not return {expected}");
        }
    }
}