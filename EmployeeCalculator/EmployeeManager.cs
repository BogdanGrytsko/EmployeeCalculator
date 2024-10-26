namespace EmployeeCalculator;

public class EmployeeManager
{
    private List<Employee> employees;

    public void ReadFromDisk(string fileName)
    {
        using var reader = new StreamReader(fileName);
        employees = CsvFileHelper.GetRecords(reader);
        CalcYearlySum();
    }

    public void ReadFromBytes(byte[] bytes)
    {
        using var reader = new StreamReader(new MemoryStream(bytes));
        employees = CsvFileHelper.GetRecords(reader);
        CalcYearlySum();
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

    public void ProcessFile(int n)
    {
        var yearlySumBytes = GetYearlySumFile();
        File.WriteAllBytes("Output.csv", yearlySumBytes);

        var topEarners = TopN(n);
        File.WriteAllBytes("TopEarners.csv", topEarners);
        var bottomEarners = BottomN(n);
        File.WriteAllBytes("BottomEarners.csv", bottomEarners);
    }

    private List<Employee> GetTopEarners(int n)
    {
        return employees.OrderByDescending(x => x.YearlySum).Take(n).ToList();
    }

    private List<Employee> GetBottomEarners(int n)
    {
        return employees.OrderBy(x => x.YearlySum).Take(n).ToList();
    }

    private void CalcYearlySum()
    {
        foreach (Employee employee in employees)
        {
            employee.YearlySum = employee.CalculateYearlySum();
        }
    }
}
