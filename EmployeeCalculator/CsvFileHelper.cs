using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace EmployeeCalculator;

public class CsvFileHelper
{
    private static CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

    public static byte[] WriteToByteArray(List<Employee> employees, ClassMap<Employee> classMap = null)
    {
        using var ms = new MemoryStream();
        using var writer = new StreamWriter(ms);
        using var csv = new CsvWriter(writer, csvConfig);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        csv.WriteRecords(employees);
        writer.Flush();
        return ms.ToArray();
    }

    public static List<Employee> Read(StreamReader reader, ClassMap<Employee> classMap = null)
    {
        using var csv = new CsvReader(reader, csvConfig);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        var records = csv.GetRecords<Employee>();
        return records.ToList();
    }

    public static List<Employee> Read(MemoryStream memoryStream, ClassMap<Employee> classMap = null)
    {
        using var reader = new StreamReader(memoryStream);
        return Read(reader, classMap);
    }

    public static List<Employee> Read(byte[] bytes, ClassMap<Employee> classMap = null)
    {
        using var reader = new StreamReader(new MemoryStream(bytes));
        return Read(reader, classMap);
    }
}
