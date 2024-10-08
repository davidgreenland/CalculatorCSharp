using NUnit.Framework;
using CalculatorProject;

namespace Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup() => _calculator = new Calculator();

        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 3)]
        [TestCase(3, 8, 11)]
        [TestCase(0, 8, 8)]
        [TestCase(-3, 10, 7)]
        [TestCase(-7, -9, -16)]
        [TestCase(6789, 345, 7134)]
        public void Add_GivenTwoInputs_ReturnsExpected(int a, int b, int expected)
        {
            var result = _calculator.Add(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Basic addition did not return {expected}");
        }

        [TestCase(1, 0, 1)]
        [TestCase(5, 2, 3)]
        [TestCase(1, 2, -1)]
        [TestCase(1, -2, 3)]
        [TestCase(-5, 10, -15)]
        [TestCase(-5, -10, 5)]
        [TestCase(305, -12345, 12650)]
        public void Subtract_GivenTwoInputs_ReturnsExpected(int a, int b, int expected)
        {
            var result = _calculator.Subtract(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Subtract method did not return {expected}");
        }

        [TestCase(1, 1, 1)]
        [TestCase(3, 4, 12)]
        [TestCase(-3, 4, -12)]
        [TestCase(-3, -4, 12)]
        [TestCase(98, 1423, 139454)]
        public void Multiply_GivenTwoInputs_ReturnsExpected(int a, int b, int expected)
        {
            var result = _calculator.Multiply(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Multiplication did not return {expected}");
        }
    }
}
