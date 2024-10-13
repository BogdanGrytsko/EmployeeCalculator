using EmployeeCalculator;
using System.Reflection;

namespace EmployeeCalcucatorTest;

public class CalculatorTest
{
    [Fact]
    public void YearlySumTest()
    {
        var embeddedFile = ReadEmbeddedFile("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var lines = embeddedFile.Split(Environment.NewLine).ToList();
        var employees = Calculator.Parse(lines);
        Assert.Equal(78, employees[0].YearlySum());
    }

    public string ReadEmbeddedFile(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();

        using (Stream stream = assembly.GetManifestResourceStream(fileName))
        using (StreamReader reader = new StreamReader(stream))
        {
            string result = reader.ReadToEnd();
            return result;
        }
    }
}