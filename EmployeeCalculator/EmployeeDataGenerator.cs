using Employee.Data;
using RandomNameGeneratorLibrary;

namespace EmployeeCalculator;

public class EmployeeDataGenerator
{
    public byte[] Generate(int employeeCount, int yearCount)
    {
        var records = GetRecords(employeeCount, yearCount).ToList();
        return CsvFileHelper.WriteToByteArray(records);
    }

    private static IEnumerable<EmployeeModel> GetRecords(int rowCount, int yearCount)
    {
        var nameGenerator = new PersonNameGenerator();
        var list = new List<EmployeeModel>();
        var rnd = new Random();
        for (int i = 0; i < rowCount; i++)
        {
            var employee = new EmployeeModel
            {
                TaxId = rnd.NextInt64(1000000000),
                Name = nameGenerator.GenerateRandomFirstName(),
                LastName = nameGenerator.GenerateRandomLastName(),
                BirthDate = new DateTime(1990 + rnd.Next(15), 1 + rnd.Next(11), 1 + rnd.Next(28)),
                JoinDate = new DateTime(2010 + rnd.Next(13), 1 + rnd.Next(11), 1 + rnd.Next(27)),
            };
            for (int j = 0; j < yearCount; j++)
            {
                var record = employee.Clone();
                record.Year = 2013 + j;
                record.Jan = rnd.NextInt64(100, 1000);
                record.Feb = rnd.NextInt64(100, 1000);
                record.Mar = rnd.NextInt64(100, 1400);
                record.Apr = rnd.NextInt64(100, 1000);
                record.May = rnd.NextInt64(100, 700);
                record.Jun = rnd.NextInt64(100, 500);
                record.Jul = rnd.NextInt64(100, 500);
                record.Aug = rnd.NextInt64(100, 200);
                record.Sep = rnd.NextInt64(100, 1000);
                record.Oct = rnd.NextInt64(100, 1000);
                record.Nov = rnd.NextInt64(100, 1100);
                record.Dec = rnd.NextInt64(100, 800);
                list.Add(record);
            }
        }

        return list;
    }
}
