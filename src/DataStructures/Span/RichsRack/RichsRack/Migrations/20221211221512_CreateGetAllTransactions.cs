using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RichsRack.Migrations
{
    /// <inheritdoc />
    public partial class CreateGetAllTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string createGetAllTransactionsFile = Path.Combine("Persistence/ManualScripts/CreateGetAllTransactions.sql");
            if (!File.Exists(createGetAllTransactionsFile))
            {
                throw new FileNotFoundException("CreateGetAllTransactions.sql Could Not be found during migration");
            }
            migrationBuilder.Sql(File.ReadAllText(createGetAllTransactionsFile));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
