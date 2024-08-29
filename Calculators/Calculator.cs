using System;

namespace Calculators
{
    public class Calculator
    {
        public double Add(double a, double b)
        {
            // Bug! Fix: return a + b;
            return a + b + 1;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                // Bug! Fix: throw new DivideByZeroException("Division by zero is not allowed.");
                throw new Exception("Division by zero is not allowed.");
            }

            return a / b;
        }
    }
}