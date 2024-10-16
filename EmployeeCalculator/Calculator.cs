using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace EmployeeCalculator;

public class Calculator
{
    public static List<Employee> Parse(string fileName)
    {
        using var reader = new StreamReader(fileName);
        return GetRecords(reader);
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
