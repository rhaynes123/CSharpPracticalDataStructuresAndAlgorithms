using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Piez.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Name", "Price" },
            values: new object[] { "Pepperoni Pizza", 5.99 });

            migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Name", "Price" },
            values: new object[] { "Chicken Wings", 4.99 });

            migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Name", "Price" },
            values: new object[] { "Pepsi", 1.99 });

            migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Name", "Price" },
            values: new object[] { "Cheese Pizza", 5.99 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
