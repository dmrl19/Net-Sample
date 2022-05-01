using Xunit;

namespace Net.Sample.Application.Tests
{
    public class CalculatorServicetests
    {
        private readonly CalculatorService _calculatorService;
        public CalculatorServicetests()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void Sum_Test()
        {
            var result = _calculatorService.Sum(1, 2);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Substract_Test()
        {
            var result = _calculatorService.Substract(5, 2);
            Assert.Equal(3, result);
        }
        [Fact]
        public void Multiply_Test()
        {
            var result = _calculatorService.Multiply(3, 2);
            Assert.Equal(6, result);
        }
        [Fact]
        public void Divide_Test()
        {
            var result = _calculatorService.Divide(2, 2);
            Assert.Equal(1, result);
        }
    }
}