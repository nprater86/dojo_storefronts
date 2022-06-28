using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class MigrationThirteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Products_ProductId",
                table: "ProductsInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInCart",
                table: "ProductsInCart");

            migrationBuilder.RenameTable(
                name: "ProductsInCart",
                newName: "ProductsInCarts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInCart_UserId",
                table: "ProductsInCarts",
                newName: "IX_ProductsInCarts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInCart_ProductId",
                table: "ProductsInCarts",
                newName: "IX_ProductsInCarts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInCarts",
                table: "ProductsInCarts",
                column: "ProductsInCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCarts_Products_ProductId",
                table: "ProductsInCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCarts_Users_UserId",
                table: "ProductsInCarts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCarts_Products_ProductId",
                table: "ProductsInCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCarts_Users_UserId",
                table: "ProductsInCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInCarts",
                table: "ProductsInCarts");

            migrationBuilder.RenameTable(
                name: "ProductsInCarts",
                newName: "ProductsInCart");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInCarts_UserId",
                table: "ProductsInCart",
                newName: "IX_ProductsInCart_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsInCarts_ProductId",
                table: "ProductsInCart",
                newName: "IX_ProductsInCart_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInCart",
                table: "ProductsInCart",
                column: "ProductsInCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Products_ProductId",
                table: "ProductsInCart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
