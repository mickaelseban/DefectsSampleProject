using Xunit;

namespace FizzBuzzProject.Tests
{
    public class FizzBuzzTests
    {
        private readonly FizzBuzz _fizzBuzz;

        public FizzBuzzTests()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnFizz_WhenNumberIsDivisibleBy3()
        {
            // Arrange
            var number = 3;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnBuzz_WhenNumberIsDivisibleBy5()
        {
            // Arrange
            var number = 5;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnFizzBuzz_WhenNumberIsDivisibleBy3And5()
        {
            // Arrange
            var number = 15;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnNumber_WhenNumberIsNotDivisibleBy3Or5()
        {
            // Arrange
            var number = 7;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("7", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnFizz_WhenNumberIsNegativeAndDivisibleBy3()
        {
            // Arrange
            var number = -3;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnBuzz_WhenNumberIsNegativeAndDivisibleBy5()
        {
            // Arrange
            var number = -5;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnFizzBuzz_WhenNumberIsNegativeAndDivisibleBy3And5()
        {
            // Arrange
            var number = -15;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnZero_WhenNumberIsZero()
        {
            // Arrange
            var number = 0;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("0", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnFizz_WhenNumberIsLargeAndDivisibleBy3()
        {
            // Arrange
            var number = 3003;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnBuzz_WhenNumberIsLargeAndDivisibleBy5()
        {
            // Arrange
            var number = 5000;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void GetFizzBuzz_ShouldReturnFizzBuzz_WhenNumberIsLargeAndDivisibleBy3And5()
        {
            // Arrange
            var number = 15000;

            // Act
            var result = _fizzBuzz.GetFizzBuzz(number);

            // Assert
            Assert.Equal("FizzBuzz", result);
        }
    }
}