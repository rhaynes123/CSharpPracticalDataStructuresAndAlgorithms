using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DebtForgivenessRegistration.Migrations
{
    public partial class AddingDebtAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeOfDebt",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DebtAmount",
                table: "Customers",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeOfDebt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DebtAmount",
                table: "Customers");
        }
    }
}
