using EmployeeCalculator;

var lines = File.ReadLines("SomeData.csv").ToList();
var employees = Calculator.Parse(lines);

var outputLines = new List<string> { "TaxId;YearlySum" };
foreach (var employee in employees)
{
    var line = $"{employee.TaxId};{employee.YearlySum()}";
    outputLines.Add(line);
}

File.WriteAllLines("Result.csv", outputLines);