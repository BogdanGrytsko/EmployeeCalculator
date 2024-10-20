using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace EmployeeCalculator;

public class Calculator
{
    private readonly string fileName;

    public Calculator(string fileName)
    {
        this.fileName = fileName;
    }

    public void ProcessFile()
    {
        var employees = ReadFromFile(fileName);
        CalcYearlySum(employees);
        WriteToFile(employees, fileName);
    }

    private static List<Employee> ReadFromFile(string fileName)
    {
        using var reader = new StreamReader(fileName);
        return GetRecords(reader);
    }

    private static void CalcYearlySum(List<Employee> employees)
    {
        foreach (Employee employee in employees)
        {
            employee.YearlySum = employee.CalculateYearlySum();
        }
    }

    private static void WriteToFile(List<Employee> employees, string fileName)
    {
        using var writer = new StreamWriter(fileName);
        var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
        using var csv = new CsvWriter(writer, config);
        csv.WriteRecords(employees);
    }

    private static List<Employee> GetRecords(StreamReader reader)
    {
        var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
        using var csv = new CsvReader(reader, config);
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
