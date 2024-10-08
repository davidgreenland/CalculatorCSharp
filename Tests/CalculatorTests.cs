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
    }
}
