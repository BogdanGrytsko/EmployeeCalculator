
using Microsoft.EntityFrameworkCore;

namespace Employee.Data;

public class ContextBuilder
{
    public static EmployeeContext GetContext()
    {
        var options = new DbContextOptionsBuilder<EmployeeContext>()
                        .UseSqlServer("Server=.;Database=EmployeeDB;trusted_connection=true;TrustServerCertificate=True")
                        .Options;
        return new EmployeeContext(options);
    }
}
