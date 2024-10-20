using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace EmployeeCalculator;

public class EmployeeManager
{
    private readonly string fileName;
    private List<Employee> employees;

    public EmployeeManager(string fileName)
    {
        this.fileName = fileName;
    }

    public void ProcessFile(int n)
    {
        employees = ReadFromFile(fileName);
        CalcYearlySum();
        WriteToFile(employees, fileName);

        var topEarners = GetTopEarners(n);
        WriteToFile(topEarners, new EmployeeNameEarningMap(), "TopEarners.csv");
        var bottomEarners = GetBottomEarners(n);
        WriteToFile(bottomEarners, new EmployeeNameEarningMap(), "BottomEraners.csv");
    }

    private List<Employee> GetTopEarners(int n)
    {
        return employees.OrderByDescending(x => x.YearlySum).Take(n).ToList();
    }

    private List<Employee> GetBottomEarners(int n)
    {
        return employees.OrderBy(x => x.YearlySum).Take(n).ToList();
    }

    private static List<Employee> ReadFromFile(string fileName)
    {
        using var reader = new StreamReader(fileName);
        return GetRecords(reader);
    }

    private void CalcYearlySum()
    {
        foreach (Employee employee in employees)
        {
            employee.YearlySum = employee.CalculateYearlySum();
        }
    }

    private static void WriteToFile(List<Employee> employees, string fileName)
    {
        WriteToFile(employees, null, fileName);
    }

    private static CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

    private static void WriteToFile(List<Employee> employees, ClassMap<Employee> classMap, string fileName)
    {
        using var writer = new StreamWriter(fileName);
        using var csv = new CsvWriter(writer, csvConfig);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        csv.WriteRecords(employees);
    }

    private static List<Employee> GetRecords(StreamReader reader)
    {
        using var csv = new CsvReader(reader, csvConfig);
        csv.Context.RegisterClassMap<EmployeeMap>();
        var records = csv.GetRecords<Employee>();
        return records.ToList();
    }

    public static List<Employee> Parse(MemoryStream memoryStream)
    {
        using var reader = new StreamReader(memoryStream);
        return GetRecords(reader);
    }
}
