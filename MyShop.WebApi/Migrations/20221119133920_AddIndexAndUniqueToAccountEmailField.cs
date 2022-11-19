using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.WebApi.Repository.Server.Migrations
{
    public partial class AddIndexAndUniqueToAccountEmailField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Email",
                table: "Accounts",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Email",
                table: "Accounts");
        }
    }
}
