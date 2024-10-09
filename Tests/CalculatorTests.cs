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

        [TestCase(1, 1, 1)]
        [TestCase(0, 1, 0)]
        [TestCase(10, 2, 5)]
        [TestCase(1, 2, 0.5)]
        [TestCase(1, 2, 0.5)]
        [TestCase(198, 5, 39.6)]
        [TestCase(10, -5, -2)]
        public void Divide_GivenTwoInputs_ReturnsExpected(decimal a, decimal b, decimal expected)
        {
            var result = _calculator.Divide(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Division did not return {expected}");
        }

        [Test]
        public void Divide_TenAndThree_ReturnsThreePointThreeRecurring()
        {
            var result = _calculator.Divide(10, 3);

            Assert.That(result, Is.EqualTo(3.3333333333333333333333333333), $"Division did not return three point three recurring");
        }

        [Test]
        public void Divide_WhenByZero_ReturnsAnError()
        {
            var result = Assert.Throws<ArgumentException>(() => _calculator.Divide(2, 0));
            Assert.That(result!.Message, Is.EqualTo("Cannot divide by zero"));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(34)]
        [TestCase(10989)]
        public void Power_WhenRaisedToPowerOne_ReturnsFirstNumber(int a)
        {
            var result = _calculator.Power(a, 1);

            Assert.That(result, Is.EqualTo(a));
        }

        [TestCase(3, 9)]
        [TestCase(7, 49)]
        [TestCase(45, 2025)]
        [TestCase(3198, 10_227_204)]
        public void Power_WhenSquaring_ReturnsExpected(int a, int expected)
        {
            var result = _calculator.Power(a, 2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
