using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace EmployeeCalculator;

public class CsvFileHelper
{
    private static CsvConfiguration defaultCsvConfig = new(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

    public static byte[] WriteToByteArray<T>(List<T> employees, ClassMap<T> classMap = null)
    {
        using var ms = new MemoryStream();
        using var writer = new StreamWriter(ms);
        using var csv = new CsvWriter(writer, defaultCsvConfig);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        csv.WriteRecords(employees);
        writer.Flush();
        return ms.ToArray();
    }

    public static List<T> Read<T>(StreamReader reader, ClassMap<T> classMap = null, string delimiter = null)
    {
        var config = GetConfig(delimiter);
        using var csv = new CsvReader(reader, config);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        var records = csv.GetRecords<T>();
        return records.ToList();
    }

    private static CsvConfiguration GetConfig(string delimiter)
    {
        if (delimiter == null)
            return defaultCsvConfig;
        return new(CultureInfo.CurrentCulture) { Delimiter = delimiter, Encoding = Encoding.UTF8 };
    }

    public static List<T> Read<T>(MemoryStream memoryStream, ClassMap<T> classMap = null)
    {
        using var reader = new StreamReader(memoryStream);
        return Read(reader, classMap);
    }

    public static List<T> Read<T>(byte[] bytes, ClassMap<T> classMap = null, string delimiter = null)
    {
        using var reader = new StreamReader(new MemoryStream(bytes));
        return Read(reader, classMap, delimiter);
    }
}
