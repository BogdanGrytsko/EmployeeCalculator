using Microsoft.EntityFrameworkCore.Design;

namespace Employee.Data;

public class EmployeeContextDesignTimeFactory : IDesignTimeDbContextFactory<EmployeeContext>
{
    public EmployeeContext CreateDbContext(string[] args)
    {
        return ContextBuilder.GetContext();
    }
}
