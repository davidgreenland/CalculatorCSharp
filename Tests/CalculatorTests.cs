using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using TestingNuget;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        private Mock<ILogger> _loggerMock;
        private Mock<IInterestCalculator> _interestCalculatorMock;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _interestCalculatorMock = new Mock<IInterestCalculator>();

            _interestCalculatorMock.Setup(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<int>())).Returns(1m);
            _calculator = new Calculator(_loggerMock.Object, _interestCalculatorMock.Object);
        }

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
        [TestCase(10, 3, 3.3333333333333333333333333333)]
        public void Divide_GivenTwoInputs_ReturnsExpected(decimal a, decimal b, decimal expected)
        {
            var result = _calculator.Divide(a, b);

            Assert.That(result, Is.EqualTo(expected), $"Division did not return {expected}");
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
            const int POWER_ONE = 1;

            var result = _calculator.Power(a, POWER_ONE);

            Assert.That(result, Is.EqualTo(a));
        }

        [TestCase(3, 9)]
        [TestCase(7, 49)]
        [TestCase(45, 2025)]
        [TestCase(3198, 10_227_204)]
        public void Power_WhenSquaring_ReturnsExpected(int a, int expected)
        {
            const int POWER_TWO = 2;

            var result = _calculator.Power(a, POWER_TWO);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(3, 27)]
        [TestCase(7, 343)]
        [TestCase(9, 729)]
        [TestCase(14, 2744)]
        public void Power_WhenCubing_ReturnsExpected(int a, int expected)
        {
            const int POWER_THREE = 3;


            var result = _calculator.Power(a, POWER_THREE);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10, 4, 10000)]
        [TestCase(7, 5, 16807)]
        [TestCase(2, 10, 1024)]
        [TestCase(2, 12, 4096)]
        [TestCase(3, 14, 4_782_969)]
        public void Power_WhenRaising_ReturnsExpected(int a, int b, int expected)
        {
            var result = _calculator.Power(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_ShouldLogInformation()
        {
            var result = _calculator.Add(2, 56);

            Assert.That(result, Is.EqualTo(58));

            _loggerMock.Verify(logger => logger.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
                Times.Once);
        }

        [Test]
        public void Interest_ShouldUseInterestLibrary()
        {
            var rate = 4.2m;
            var principle = 100_000m;
            var periodYears = 25;

            var result = _calculator.Interest(rate, principle, periodYears);

            _interestCalculatorMock.Verify(x => x.Calculate(rate, principle, periodYears), Times.Once);
        }
    }
}
