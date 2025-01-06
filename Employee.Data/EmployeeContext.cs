using Microsoft.EntityFrameworkCore;

namespace Employee.Data;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EmployeeModel> EmployeesNew { get; set; }
    public DbSet<EmployeeDataModel> EmployeeData { get; set; }
    public DbSet<EmployeeDataCsvModel> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeDataConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
