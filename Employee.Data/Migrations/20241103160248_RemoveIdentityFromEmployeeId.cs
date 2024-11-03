using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIdentityFromEmployeeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_Employees", "Employees");

            // Drop the existing Id column if it has an IDENTITY
            migrationBuilder.Sql("ALTER TABLE Employees DROP COLUMN TaxId;");

            // Recreate the Id column without the IDENTITY attribute
            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            // Re-add primary key constraint
            migrationBuilder.Sql("ALTER TABLE Employees ADD CONSTRAINT PK_Employees PRIMARY KEY(TaxId);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TaxId",
                table: "Employees",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
