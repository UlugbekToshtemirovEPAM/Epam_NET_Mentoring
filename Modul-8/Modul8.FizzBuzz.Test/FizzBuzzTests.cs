using Xunit;

namespace Modul8.FizzBuzz.Test
{
    public class FizzBuzzTests
    {
        private FizzBuzz fizzBuzz;

        public FizzBuzzTests()
        {
            fizzBuzz = new FizzBuzz();
        }

        [Fact]
        public void Calculate_ReturnsFizz_WhenNumberDivisibleBy3()
        {
            Assert.Equal("Fizz", fizzBuzz.Calculate(3));
        }

        [Fact]
        public void Calculate_ReturnsBuzz_WhenNumberDivisibleBy5()
        {
            Assert.Equal("Buzz", fizzBuzz.Calculate(10));
        }

        [Fact]
        public void Calculate_ReturnsFizzBuzz_WhenNumberDivisibleBy3And5()
        {
            Assert.Equal("FizzBuzz", fizzBuzz.Calculate(15));
        }

        [Fact]
        public void Calculate_ReturnsNumber_WhenNumberNotDivisibleBy3Or5()
        {
            Assert.Equal("1", fizzBuzz.Calculate(1));
        }
    }
}
