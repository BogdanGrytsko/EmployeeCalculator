using EmployeeCalculator;

var lines = File.ReadLines("SomeData.csv").ToList();

var employees = new List<Employee>();
foreach (var line in lines.Skip(1))
{
    var splitLine = line.Split(';');
    var employee = new Employee
    {
        TaxId = long.Parse(splitLine[0]),
        Name = splitLine[1],
        LastName = splitLine[2],
        BirthDate = DateTime.Parse(splitLine[3]),
        JoinDate = DateTime.Parse(splitLine[4]),
        Year = int.Parse(splitLine[5]),
        Jan = decimal.Parse(splitLine[6]),
        Feb = decimal.Parse(splitLine[7]),
        Mar = decimal.Parse(splitLine[8]),
        Apr = decimal.Parse(splitLine[9]),
        May = decimal.Parse(splitLine[10]),
        Jun = decimal.Parse(splitLine[11]),
        Jul = decimal.Parse(splitLine[12]),
        Aug = decimal.Parse(splitLine[13]),
        Sep = decimal.Parse(splitLine[14]),
        Oct = decimal.Parse(splitLine[15]),
        Nov = decimal.Parse(splitLine[16]),
        Dec = decimal.Parse(splitLine[17]),
    };
    employees.Add(employee);
}

var outputLines = new List<string> { "TaxId;YearlySum" };
foreach (var employee in employees)
{
    var line = $"{employee.TaxId};{employee.YearlySum()}";
    outputLines.Add(line);
}

File.WriteAllLines("Result.csv", outputLines);