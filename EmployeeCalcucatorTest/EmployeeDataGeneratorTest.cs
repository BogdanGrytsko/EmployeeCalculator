using EmployeeCalculator;

namespace EmployeeCalcucatorTest;

public class EmployeeDataGeneratorTest
{
    [Fact]
    public void GenerateBigFile()
    {
        int employeeCount = 1000, yearCount = 10;
        var generator = new EmployeeDataGenerator();
        var bytes = generator.Generate(employeeCount, yearCount);
        File.WriteAllBytes($"EmployeeData_{employeeCount}_years_{yearCount}.csv", bytes);
    }
}
