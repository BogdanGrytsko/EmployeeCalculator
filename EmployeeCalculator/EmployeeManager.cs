using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace EmployeeCalculator;

public class EmployeeManager
{
    private List<Employee> employees;

    public EmployeeManager()
    {
    }

    public void ReadFromDisk(string fileName)
    {
        using var reader = new StreamReader(fileName);
        employees = GetRecords(reader);
    }

    public void ReadFromBytes(byte[] bytes)
    {
        using var reader = new StreamReader(new MemoryStream(bytes));
        employees = GetRecords(reader);
    }

    public byte[] GetYearlySumFile()
    {
        CalcYearlySum();
        return WriteToByteArray(employees);
    }

    public void ProcessFile(int n)
    {
        var yearlySumBytes = GetYearlySumFile();
        File.WriteAllBytes("Output.csv", yearlySumBytes);
        //WriteToFile(employees, "Output.csv");

        var topEarners = GetTopEarners(n);
        WriteToFile(topEarners, new EmployeeNameEarningMap(), "TopEarners.csv");
        var bottomEarners = GetBottomEarners(n);
        WriteToFile(bottomEarners, new EmployeeNameEarningMap(), "BottomEarners.csv");
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

    private static byte[] WriteToByteArray(List<Employee> employees, ClassMap<Employee> classMap = null)
    {
        using var ms = new MemoryStream();
        using var writer = new StreamWriter(ms);
        using var csv = new CsvWriter(writer, csvConfig);
        if (classMap != null)
        {
            csv.Context.RegisterClassMap(classMap);
        }
        csv.WriteRecords(employees);
        return ms.ToArray();
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
