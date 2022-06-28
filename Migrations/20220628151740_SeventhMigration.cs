using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductsInCart",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCart_UserId",
                table: "ProductsInCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInCart_UserId",
                table: "ProductsInCart");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductsInCart");
        }
    }
}
