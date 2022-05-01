using Net.Sample.Application;
using System;

namespace Net.Sample.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("Hello World!");
            System.Console.WriteLine("Hello, World!");
            var calculatorService = new CalculatorService();
            var result = calculatorService.Sum(5, 5);
            System.Console.WriteLine("5 + 5 = {0}", result);
        }
    }
}
