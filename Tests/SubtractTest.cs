using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class SubtractTests
    {
        [Test]
        public void Subtract_returns_zero_when_inputs_are_one_and_zero()
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(1, 1);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Subtract_returns_three_when_inputs_are_five_and_two()
        {
            var calculator = new Calculator();

            var result = calculator.Subtract(5, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}