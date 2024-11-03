using Microsoft.EntityFrameworkCore;

namespace Employee.Data;

public class EmployeeContext : DbContext
{
    public DbSet<EmployeeModel> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=EmployeeDB;trusted_connection=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
