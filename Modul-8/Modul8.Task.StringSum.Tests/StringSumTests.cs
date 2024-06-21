using Xunit;

namespace Modul8.Task.StringSum.Tests
{
    public class StringSumTests
    {
        private readonly StringSum _stringSum;

        public StringSumTests()
        {
            _stringSum = new StringSum();
        }

        [Fact]
        public void Sum_ReturnsZero_WhenBothInputsAreEmpty()
        {
            string num1 = "";
            string num2 = "";

            string result = _stringSum.Sum(num1, num2);

            Assert.Equal("0", result);
        }

        [Fact]
        public void Sum_ReturnsSum_WhenBothInputsAreNaturalNumbers()
        {
            string num1 = "3";
            string num2 = "5";

            string result = _stringSum.Sum(num1, num2);

            Assert.Equal("8", result);
        }

        [Fact]
        public void Sum_ReturnsNaturalNumber_WhenOneInputIsNotNaturalNumber()
        {
            string num1 = "5";
            string num2 = "abc";

            string result = _stringSum.Sum(num1, num2);

            Assert.Equal("5", result);
        }

        [Fact]
        public void Sum_ReturnsZero_WhenBothInputsAreNotNaturalNumbers()
        {
            string num1 = "abc";
            string num2 = "def";

            string result = _stringSum.Sum(num1, num2);

            Assert.Equal("0", result);
        }
    }
}
