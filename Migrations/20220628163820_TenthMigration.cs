using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class TenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Cart_CartId",
                table: "ProductsInCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInCart_CartId",
                table: "ProductsInCart");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ProductsInCart");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProductsInCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ProductsInCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ProductsInCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Cart_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInCart_CartId",
                table: "ProductsInCart",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Cart_CartId",
                table: "ProductsInCart",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInCart_Users_UserId",
                table: "ProductsInCart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
