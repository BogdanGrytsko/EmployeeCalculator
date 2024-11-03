using Employee.Data;

namespace EmployeeCalculator;

public class EmployeeManager
{
    private List<EmployeeModel> employees;

    public void ReadFromDisk(string fileName)
    {
        using var reader = new StreamReader(fileName);
        employees = CsvFileHelper.Read(reader, new EmployeeMap());
        CalcYearlySum();
    }

    public void ReadFromBytes(byte[] bytes)
    {
        employees = CsvFileHelper.Read(bytes, new EmployeeMap());
        CalcYearlySum();
    }

    public void ReadFromDatabase(EmployeeContext context)
    {
        employees = context.Employees.ToList();
        CalcYearlySum();
    }

    public async Task SaveToDatabase(EmployeeContext context)
    {
        await context.AddRangeAsync(employees);
        await context.SaveChangesAsync();
    }

    public byte[] GetYearlySumFile()
    {
        return CsvFileHelper.WriteToByteArray(employees);
    }

    public byte[] TopN(int n)
    {
        var topEarners = GetTopEarners(n);
        return CsvFileHelper.WriteToByteArray(topEarners, new EmployeeNameEarningMap());
    }

    public byte[] BottomN(int n)
    {
        var bottomEarners = GetBottomEarners(n);
        return CsvFileHelper.WriteToByteArray(bottomEarners, new EmployeeNameEarningMap());
    }

    private List<EmployeeModel> GetTopEarners(int n)
    {
        return employees.OrderByDescending(x => x.YearlySum).Take(n).ToList();
    }

    private List<EmployeeModel> GetBottomEarners(int n)
    {
        return employees.OrderBy(x => x.YearlySum).Take(n).ToList();
    }

    private void CalcYearlySum()
    {
        foreach (EmployeeModel employee in employees)
        {
            employee.YearlySum = employee.CalculateYearlySum();
        }
    }
}
