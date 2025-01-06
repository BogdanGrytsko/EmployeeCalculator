using CsvHelper.Configuration;
using Employee.Data;
namespace EmployeeCalculator;

public sealed class EmployeeMap : ClassMap<EmployeeDataModel>
{
    public EmployeeMap()
    {
        Map(m => m.Employee.TaxId);
        Map(m => m.Employee.Name);
        Map(m => m.Employee.LastName);
        Map(m => m.Employee.BirthDate);
        Map(m => m.Employee.JoinDate);
        Map(m => m.Year);
        Map(m => m.Jan);
        Map(m => m.Feb);
        Map(m => m.Mar);
        Map(m => m.Apr);
        Map(m => m.May);
        Map(m => m.Jun);
        Map(m => m.Jul);
        Map(m => m.Aug);
        Map(m => m.Sep);
        Map(m => m.Oct);
        Map(m => m.Nov);
        Map(m => m.Dec);

        Map(x => x.YearlySum).Optional();
    }
}
