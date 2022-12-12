using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RichsRack.Migrations
{
    /// <inheritdoc />
    public partial class SeedSnacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table:"Snacks",
                columns: new[] { "Name","Price",},
                values: new object[] { "Pepsi", 1.00});
            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "Name", "Price", },
                values: new object[] { "Lays Plain", 2.00 });
            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "Name", "Price", },
                values: new object[] { "Oreos", 2.00 });
            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "Name", "Price", },
                values: new object[] { "Coke", 1.00 });
            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "Name", "Price", },
                values: new object[] { "Cheetos", 2.00 });
            migrationBuilder.InsertData(
                table: "Snacks",
                columns: new[] { "Name", "Price", },
                values: new object[] { "7-UP", 1.00 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
