using CsvHelper.Configuration;
namespace EmployeeCalculator;

public sealed class EmployeeMap : ClassMap<Employee>
{
    public EmployeeMap()
    {
        Map(m => m.TaxId);
        Map(m => m.Name);
        Map(m => m.LastName);
        Map(m => m.BirthDate);
        Map(m => m.JoinDate);
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
