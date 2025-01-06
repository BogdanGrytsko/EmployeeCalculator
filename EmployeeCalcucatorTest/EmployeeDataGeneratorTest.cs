using Employee.Data;
using EmployeeCalculator;
using System.Diagnostics;
using Xunit.Abstractions;

namespace EmployeeCalcucatorTest;

public class EmployeeDataGeneratorTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public EmployeeDataGeneratorTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task GenerateAndInsertBigFile()
    {
        //Regular EF insertion
        //1000 records --> 1.3s
        //5000 records --> 3.2s
        //10000 records --> 4.5s
        //50000 records --> 17.5s

        //BulkInsertion
        //1000 records --> 0.6s
        //5000 records --> 0.6s
        //10000 records --> 0.7s
        //50000 records --> 1.6s
        //100000 records --> 2.7s

        int employeeCount = 50000, yearCount = 20;
        var generator = new EmployeeDataGenerator();
        var bytes = generator.Generate(employeeCount, yearCount);
        var fileName = $"EmployeeData_{employeeCount}_years_{yearCount}.csv";
        File.WriteAllBytes(fileName, bytes);

        var context = ContextBuilder.GetContext();
        var manager = new EmployeeManager();
        manager.ReadFromDisk(fileName);

        var sw = Stopwatch.StartNew();
        await manager.SaveBulkToDatabase(context);
        testOutputHelper.WriteLine($"Time to insert for {fileName} is {sw.Elapsed}");
    }

    [Fact]
    public async Task FindEmployeeByTaxId()
    {
        var context = ContextBuilder.GetContext();
        var taxId = 745995703;
        var employeeData = context.EmployeeData.Where(x => x.Employee.TaxId == taxId).ToList();
    }
}
