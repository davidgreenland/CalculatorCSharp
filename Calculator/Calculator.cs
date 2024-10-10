using Microsoft.Extensions.Logging;
using TestingNuget;

namespace CalculatorProject;

public class Calculator
{
    private readonly ILogger _logger;
    private readonly IInterestCalculator _interestCalculator;

    public Calculator(ILogger logger, IInterestCalculator interestCalculator)
    {
        _logger = logger;
        _interestCalculator = interestCalculator;
    }

    public int Add(int a, int b)
    {
        _logger.LogInformation($"Add method called with {a} + {b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public decimal Divide(decimal a, decimal b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }

        return a / b;
    }

    public int Power(int a, int b)
    {
        var result = a;

        if (b == 1)
        {
            return a;
        }

        return Multiply(result, Power(a, b - 1));
    }

    public decimal Interest(decimal rate, decimal principle, int periodYears)
    {
        return _interestCalculator.Calculate(rate, principle, periodYears);
    }
}
