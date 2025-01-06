using System.ComponentModel.DataAnnotations;

namespace Employee.Data;

public class EmployeeDataModel
{
    [Key]
    public long EmployeeDataId { get; set; }

    public long EmployeeId { get; set; }
    public int Year { get; set; }
    public decimal Jan { get; set; }
    public decimal Feb { get; set; }
    public decimal Mar { get; set; }
    public decimal Apr { get; set; }
    public decimal May { get; set; }
    public decimal Jun { get; set; }
    public decimal Jul { get; set; }
    public decimal Aug { get; set; }
    public decimal Sep { get; set; }
    public decimal Oct { get; set; }
    public decimal Nov { get; set; }
    public decimal Dec { get; set; }
    public decimal YearlySum { get; set; }

    public virtual EmployeeModel Employee { get; set; }

    public decimal CalculateYearlySum()
    {
        return Jan + Feb + Mar + Apr + May + Jun + Jul + Aug + Sep + Oct + Nov + Dec;
    }
}
