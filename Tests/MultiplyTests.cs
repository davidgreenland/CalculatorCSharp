using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class MultiplyTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup() => _calculator = new Calculator();

        [Test]
        public void Multiply_returns_one_when_inputs_are_both_one()
        {
            var result = _calculator.Multiply(1, 1);

            Assert.That(result, Is.EqualTo(1), $"Basic multiplication did not return one");
        }
    }
}