using Employee.Data;
using EmployeeCalculator;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCalcucatorTest;

public class EmployeeManagerTest
{
    [Fact]
    public void ReadFromFileTest()
    {
        //arrange
        var bytes = EmbeddedFileHelper.ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var manager = new EmployeeManager();

        //act
        manager.ReadFromBytes(bytes);

        AssertEmployeeResults(manager);
    }

    private static void AssertEmployeeResults(EmployeeManager manager)
    {
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

    [Fact]
    public void ReadFromDbTest()
    {
        // Arrange
        var context = GetImMemoryContext();
        AddEmployees(context);

        // Act
        var manager = new EmployeeManager();
        manager.ReadFromDatabase(context);

        // Assert
        AssertEmployeeResults(manager);
    }

    private static void AddEmployees(EmployeeContext context)
    {
        var bytes = EmbeddedFileHelper.ReadAsBytes("EmployeeCalcucatorTest.EmployeeTestData.csv");
        var employees = CsvFileHelper.Read(bytes, new EmployeeMap());
        context.EmployeeData.AddRange(employees);
        context.SaveChanges();
    }

    private static EmployeeContext GetImMemoryContext()
    {
        var myDatabaseName = "Employee_Test_" + DateTime.UtcNow.ToFileTimeUtc();
        var options = new DbContextOptionsBuilder<EmployeeContext>()
                        .UseInMemoryDatabase(databaseName: myDatabaseName)
                        .Options;
        return new EmployeeContext(options);
    }
}