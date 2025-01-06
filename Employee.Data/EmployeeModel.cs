using Employee.Data;
using System.ComponentModel.DataAnnotations;

public class EmployeeModel
{
    [Key]
    public long EmployeeId { get; set; }

    public long TaxId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime JoinDate { get; set; }

    public List<EmployeeDataModel> EmployeeDatas { get; set; }
}