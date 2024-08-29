using System;
using Xunit;

namespace Calculators.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void TestAddition()
        {
            var result = _calculator.Add(5, 3);
            Assert.Equal(8, result);
        }

        [Fact]
        public void TestAddition2()
        {
            var result = _calculator.Add(6, 3);
            Assert.Equal(9, result);
        }

        [Fact]
        public void TestSubtraction()
        {
            var result = _calculator.Subtract(5, 3);
            Assert.Equal(2, result);
        }

        [Fact]
        public void TestMultiplication()
        {
            var result = _calculator.Multiply(5, 3);
            Assert.Equal(15, result);
        }

        [Fact]
        public void TestDivision()
        {
            var result = _calculator.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void DivisionByZero()
        {
            var ex = Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
            Assert.Equal("Division by zero is not allowed.", ex.Message);
        }
    }
}