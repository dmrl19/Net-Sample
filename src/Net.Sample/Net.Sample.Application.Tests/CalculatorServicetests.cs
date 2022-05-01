using System;
using Xunit;

namespace Net.Sample.Application.Tests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceTests()
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
        public void Sum_Test_Two()
        {
            var result = _calculatorService.Sum(2, 2);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Sum_Test_Three()
        {
            var result = _calculatorService.Sum(2, 6);
            Assert.NotEqual(4, result);
        }

        [Fact]
        public void Substract_Test()
        {
            var result = _calculatorService.Substract(5, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Substract_Test_Two()
        {
            var result = _calculatorService.Substract(1, 2);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Substract_Test_Three()
        {
            var result = _calculatorService.Substract(5, 2);
            Assert.NotEqual(13, result);
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
