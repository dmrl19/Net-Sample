// See https://aka.ms/new-console-template for more information
using Net.Sample.Application;

Console.WriteLine("Hello, World!");
var calculatorService = new CalculatorService();
var result = calculatorService.Sum(5, 5);
Console.WriteLine("5 + 5 = {0}", result);
