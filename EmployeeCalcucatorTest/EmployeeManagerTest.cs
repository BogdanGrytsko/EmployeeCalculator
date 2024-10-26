using EmployeeCalculator;
using FluentAssertions;

namespace EmployeeCalcucatorTest;

public class EmployeeManagerTest
{
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
        employees[0].YearlySum.Should().Be(78);

        var topEmployees = CsvFileHelper.Read(top, new EmployeeNameEarningMap());
        topEmployees[0].YearlySum.Should().Be(12576);
        topEmployees[0].YearlySum.Should().BeGreaterThanOrEqualTo(topEmployees[1].YearlySum);

        var bottomEmployees = CsvFileHelper.Read(bottom, new EmployeeNameEarningMap());
        bottomEmployees[0].YearlySum.Should().Be(78);
        bottomEmployees[0].YearlySum.Should().BeLessThanOrEqualTo(bottomEmployees[1].YearlySum);
    }
}