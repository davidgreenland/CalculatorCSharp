using CalculatorProject;
using Microsoft.Extensions.Logging;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = factory.CreateLogger("Calculator");
logger.LogInformation("Hello World! Logging is {Description}.", "fun");

var calculator = new Calculator(logger);

Console.WriteLine(calculator.Add(1,2));

Console.ReadKey();