using Xunit;

namespace MaxFloatProject.Tests
{
    public class MaxFloatProjectTests
    {
        [Fact]
        public void Max_ShouldReturnFirstNumber_WhenSecondNumberIsNaN()
        {
            // Arrange
            var a = 5.0f;
            var b = float.NaN;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }

        [Fact]
        public void Max_ShouldReturnFirstNumber_WhenSecondNumberIsNaN_AndFirstIsNegative()
        {
            // Arrange
            var a = -3.2f;
            var b = float.NaN;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }

        [Fact]
        public void Max_ShouldReturnFirstNumber_WhenSecondNumberIsNaN_AndFirstIsZero()
        {
            // Arrange
            var a = 0.0f;
            var b = float.NaN;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }

        [Fact]
        public void Max_ShouldReturnGreater_WhenBothNumbersArePositive()
        {
            // Arrange
            var a = 3.5f;
            var b = 2.5f;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }

        [Fact]
        public void Max_ShouldReturnGreater_WhenBothNumbersAreNegative()
        {
            // Arrange
            var a = -3.5f;
            var b = -2.5f;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(b, result);
        }

        [Fact]
        public void Max_ShouldReturnNonNaN_WhenOneNumberIsNaN()
        {
            // Arrange
            var a = float.NaN;
            var b = 2.5f;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(b, result);
        }

        [Fact]
        public void Max_ShouldReturnNaN_WhenBothNumbersAreNaN()
        {
            // Arrange
            var a = float.NaN;
            var b = float.NaN;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.True(float.IsNaN(result));
        }

        [Fact]
        public void Max_ShouldReturnPositiveNumber_WhenOneNumberIsPositiveAndOneIsNegative()
        {
            // Arrange
            var a = -3.5f;
            var b = 2.5f;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(b, result);
        }

        [Fact]
        public void Max_ShouldReturnMaxFloat_WhenOneNumberIsMaxFloat()
        {
            // Arrange
            var a = float.MaxValue;
            var b = 2.5f;

            // Act
            var result = MaxFloatProject.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }
    }
}