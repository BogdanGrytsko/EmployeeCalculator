using EmployeeCalculator;

var employees = Calculator.Parse("SomeData.csv");

var outputLines = new List<string> { "TaxId;YearlySum" };
foreach (var employee in employees)
{
    var line = $"{employee.TaxId};{employee.YearlySum()}";
    outputLines.Add(line);
}

File.WriteAllLines("Result.csv", outputLines);