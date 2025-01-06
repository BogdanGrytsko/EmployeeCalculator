using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Employee.Data;

public class EmployeeDataConfiguration : IEntityTypeConfiguration<EmployeeDataModel>
{
    public void Configure(EntityTypeBuilder<EmployeeDataModel> builder)
    {
        builder.HasIndex(x => x.EmployeeId);
    }
}
