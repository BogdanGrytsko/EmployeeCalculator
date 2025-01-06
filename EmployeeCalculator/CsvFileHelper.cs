using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;
using Employee.Data;

namespace EmployeeCalculator;

public class CsvFileHelper
{
    private static CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

    public static byte[] WriteToByteArray<T>(List<T> employees, ClassMap<T> classMap = null)
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

    public static List<EmployeeDataModel> Read(StreamReader reader, ClassMap<EmployeeDataModel> classMap = null)
    {
        using var csv = new CsvReader(reader, csvConfig);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        var records = csv.GetRecords<EmployeeDataModel>();
        return records.ToList();
    }

    public static List<EmployeeDataModel> Read(MemoryStream memoryStream, ClassMap<EmployeeDataModel> classMap = null)
    {
        using var reader = new StreamReader(memoryStream);
        return Read(reader, classMap);
    }

    public static List<EmployeeDataModel> Read(byte[] bytes, ClassMap<EmployeeDataModel> classMap = null)
    {
        using var reader = new StreamReader(new MemoryStream(bytes));
        return Read(reader, classMap);
    }
}
