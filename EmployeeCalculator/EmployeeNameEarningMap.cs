using CsvHelper.Configuration;

namespace EmployeeCalculator;

public class EmployeeNameEarningMap : ClassMap<Employee>
{
    public EmployeeNameEarningMap()
    {
        Map(m => m.TaxId);
        Map(m => m.Name);
        Map(m => m.LastName);
        Map(m => m.YearlySum);
    }
}
