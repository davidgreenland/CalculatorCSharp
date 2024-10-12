using Microsoft.Extensions.Logging;
using TestingNuget;

namespace SimpleCalculator.Services;

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

    public decimal Multiply(decimal a, decimal b)
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

    public decimal Power(decimal a, int power)
    {
        if (power == 0)
        {
            return 1;
        }

        if (power > 0)
        {
            return Multiply(a, Power(a, power - 1));
        }

        return Divide(1, Power(a, -power));
    }

    public decimal Interest(decimal rate, decimal principle, int periodYears)
    {
        return _interestCalculator.Calculate(rate, principle, periodYears);
    }

    public async Task<int> MultiplyAsync(int a, int b)
    {
        await Task.Delay(1000);

        return a * b;
    }
}
