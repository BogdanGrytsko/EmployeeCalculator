using EFCore.BulkExtensions;
using Employee.Data;
using EmployeeCalculator;
using System.Collections.Generic;
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

        int employeeCount = 500, yearCount = 20;
        var generator = new EmployeeDataGenerator();

        var context = ContextBuilder.GetContext();
        await context.BulkInsertAsync(EmployeeDataGenerator.GetRecords(employeeCount, yearCount).ToList());
    }

    [Fact]
    public async Task FindEmployeeByTaxId()
    {
        var context = ContextBuilder.GetContext();
        var taxId = 745995703;
        var employeeData = context.EmployeeData.Where(x => x.Employee.TaxId == taxId).ToList();
    }

    [Fact]
    public async Task MoveData()
    {
        var context = ContextBuilder.GetContext();
        var existingData = context.Employees.ToList();

        var employees = new List<EmployeeModel>();
        var employeeDatas = new List<EmployeeDataModel>();
        foreach (var employeeDataGroup in existingData.GroupBy(x => x.TaxId)) 
        {
            var first = employeeDataGroup.First();
            var employee = new EmployeeModel
            {
                TaxId = employeeDataGroup.Key,
                Name = first.Name,
                BirthDate = first.BirthDate,
                JoinDate = first.JoinDate,
                LastName = first.LastName,
            };
            employees.Add(employee);

            employeeDatas.AddRange(employeeDataGroup.Select(x => new EmployeeDataModel
            {
                Employee = employee,
                Year = x.Year,
                Jan = x.Jan,
                Feb = x.Feb,
                Mar = x.Mar,
                Apr = x.Apr,
                May = x.May,
                Jun = x.Jun,
                Aug = x.Aug,
                Sep = x.Sep,
                Oct = x.Oct,
                Nov = x.Nov,
                Dec = x.Dec,
            }));
        }

        var config = new BulkConfig { SetOutputIdentity = true };
        await context.BulkInsertAsync(employees, config);

        foreach (var data in employeeDatas)
        {
            data.EmployeeId = data.Employee.EmployeeId;
        }
        await context.BulkInsertAsync(employeeDatas);
    }
}
