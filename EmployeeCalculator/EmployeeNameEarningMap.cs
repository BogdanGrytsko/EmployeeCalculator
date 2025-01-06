using CsvHelper.Configuration;
using Employee.Data;

namespace EmployeeCalculator;

public class EmployeeNameEarningMap : ClassMap<EmployeeDataModel>
{
    public EmployeeNameEarningMap()
    {
        Map(m => m.Employee.TaxId);
        Map(m => m.Employee.Name);
        Map(m => m.Employee.LastName);
        Map(m => m.YearlySum);
    }
}
