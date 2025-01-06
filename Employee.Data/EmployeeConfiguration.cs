using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeModel>
{
    public void Configure(EntityTypeBuilder<EmployeeModel> builder)
    {
        builder.HasIndex(x => x.TaxId);
        builder
            .HasMany(x => x.EmployeeDatas)
            .WithOne(x => x.Employee)
            .HasPrincipalKey(x => x.EmployeeId);
    }
}