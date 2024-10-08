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

            var result = calculator.Subtract(1, 0);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}