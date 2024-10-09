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
        if (b == 1)
        {
            return a;
        }

        if (b == 2)
        {
            return Multiply(a, a);

        }

        return Multiply(Multiply(a, a), a);
    }
}
