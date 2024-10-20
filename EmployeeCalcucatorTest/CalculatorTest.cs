using EmployeeCalculator;
using System.Reflection;

namespace EmployeeCalcucatorTest;

public class CalculatorTest
{
    [Fact]
    public void YearlySumTest()
    {
        var bytes = ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var employees = EmployeeManager.Parse(new MemoryStream(bytes));
        Assert.Equal(78, employees[0].CalculateYearlySum());
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

    public static byte[] ReadAsBytes(string filename)
    {
        var a = Assembly.GetExecutingAssembly();
        using Stream resFilestream = a.GetManifestResourceStream(filename);
        var ms = new MemoryStream();
        resFilestream!.CopyTo(ms);
        return ms.ToArray();
    }
}