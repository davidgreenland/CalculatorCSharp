namespace CalculatorProject;

public class Calculator
{
    public int Add(int a, int b)
    {
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
        if (power == 1)
        {
            return a;
        }

        if (power > 0)
        {
            return Multiply(a, Power(a, power - 1));
        }
        return Divide(1, Power(a, -power));
    }
}
