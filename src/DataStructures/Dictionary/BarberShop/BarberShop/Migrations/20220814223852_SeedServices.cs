using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    public partial class SeedServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string RawSql = $@"
                            INSERT INTO Services(`Name`, Price)VALUES('Fade',20.00);
                            INSERT INTO Services(`Name`, Price)VALUES('Line',10.00);
                            INSERT INTO Services(`Name`, Price)VALUES('Shampoo',20.00);
                            INSERT INTO Services(`Name`, Price)VALUES('Trim',10.00);
                            INSERT INTO Services(`Name`, Price)VALUES('Shave',25.00);"
                            ;
            migrationBuilder.Sql(RawSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
