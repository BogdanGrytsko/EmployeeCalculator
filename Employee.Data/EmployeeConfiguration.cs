using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Employee.Data;

public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeModel>
{
    public void Configure(EntityTypeBuilder<EmployeeModel> builder)
    {
        builder.Property(x => x.TaxId).ValueGeneratedNever();
    }
}
