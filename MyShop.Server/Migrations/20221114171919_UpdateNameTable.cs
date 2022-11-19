using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Server.Repository.Server.Migrations
{
    public partial class UpdateNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.RenameTable(
                name: "Authorizations",
                newName: "Accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Authorizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "Id");
        }
    }
}
