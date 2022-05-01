using System;

namespace Net.Sample.Application
{
    public class CalculatorService
    {
        public int Sum(int a, int b) => a + b;
        public int Substract(int a, int b) => a - b;
        public int Divide(int a, int b) => a / b;
        public int Multiply(int a, int b) => a * b;
    }
}
