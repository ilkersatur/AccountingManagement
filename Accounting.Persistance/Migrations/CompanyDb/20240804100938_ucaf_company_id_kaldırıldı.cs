using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class ucaf_company_id_kaldırıldı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "UniformChartOfAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "UniformChartOfAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
