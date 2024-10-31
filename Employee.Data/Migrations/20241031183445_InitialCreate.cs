using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    TaxId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Jan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Feb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Apr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    May = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Jun = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Jul = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aug = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sep = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Oct = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nov = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dec = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearlySum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.TaxId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
