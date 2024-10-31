using CsvHelper.Configuration;
using Employee.Data;

namespace EmployeeCalculator;

public class EmployeeNameEarningMap : ClassMap<EmployeeModel>
{
    public EmployeeNameEarningMap()
    {
        Map(m => m.TaxId);
        Map(m => m.Name);
        Map(m => m.LastName);
        Map(m => m.YearlySum);
    }
}
