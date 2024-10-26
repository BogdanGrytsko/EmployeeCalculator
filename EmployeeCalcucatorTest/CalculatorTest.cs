using EmployeeCalculator;

namespace EmployeeCalcucatorTest;

public class CalculatorTest
{
    [Fact]
    public void YearlySumTest()
    {
        var bytes = EmbeddedFileHelper.ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var employees = EmployeeManager.Parse(new MemoryStream(bytes));
        Assert.Equal(78, employees[0].CalculateYearlySum());
    }

    [Fact]
    public void IntegrationTest()
    {
        var bytes = EmbeddedFileHelper.ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var manager = new EmployeeManager();
        manager.ReadFromBytes(bytes);
        var yearlySum = manager.GetYearlySumFile();
        //var top = manager.TopN(5);
        //var bottom = manager.BottomN(5);

        //Assertion --> read csv file from Memory, check content of yearlySum, top, bottom
    }
}