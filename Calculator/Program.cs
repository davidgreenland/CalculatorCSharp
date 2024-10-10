using CalculatorProject;
using Microsoft.Extensions.Logging;
using TestingNuget;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = factory.CreateLogger("Calculator");
logger.LogInformation("Hello World! Logging is {Description}.", "fun");

var interestCalculator = new InterestCalculator();

var calculator = new Calculator(logger, interestCalculator);

Console.WriteLine(calculator.Add(1,2));

Console.ReadKey();