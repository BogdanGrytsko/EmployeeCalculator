using EmployeeCalculator;

namespace EmployeeCalcucatorTest;

public class CalculatorTest
{
    [Fact]
    public void YearlySumTest()
    {
        var bytes = EmbeddedFileHelper.ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var employees = CsvFileHelper.Read(bytes);
        Assert.Equal(78, employees[0].CalculateYearlySum());
    }

    [Fact]
    public void IntegrationTest()
    {
        //arrange
        var bytes = EmbeddedFileHelper.ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var manager = new EmployeeManager();
        //act
        manager.ReadFromBytes(bytes);
        var yearlySum = manager.GetYearlySumFile();
        var top = manager.TopN(5);
        var bottom = manager.BottomN(5);
        //assert
        var employees = CsvFileHelper.Read(yearlySum);
        Assert.Equal(78, employees[0].YearlySum);
        //Assertion --> read csv file from Memory, check content of yearlySum, top, bottom
    }
}