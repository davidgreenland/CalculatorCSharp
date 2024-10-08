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
        public void Multiply_returns_one_when_inputs_are_both_one(int a, int b, int expected)
        {
            var result = _calculator.Multiply(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Multiplication did not return {expected}");
        }
    }
}