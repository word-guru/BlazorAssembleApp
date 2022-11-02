using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationEntity.Migrations
{
    public partial class RenamingProToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pro",
                table: "Pro");

            migrationBuilder.RenameTable(
                name: "Pro",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Pro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pro",
                table: "Pro",
                column: "Id");
        }
    }
}
