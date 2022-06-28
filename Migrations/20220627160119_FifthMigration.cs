using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Storefronts_StorefrontId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StorefrontId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StorefrontId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Storefronts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Storefronts_OwnerUserId",
                table: "Storefronts",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storefronts_Users_OwnerUserId",
                table: "Storefronts",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storefronts_Users_OwnerUserId",
                table: "Storefronts");

            migrationBuilder.DropIndex(
                name: "IX_Storefronts_OwnerUserId",
                table: "Storefronts");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Storefronts");

            migrationBuilder.AddColumn<int>(
                name: "StorefrontId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StorefrontId",
                table: "Users",
                column: "StorefrontId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Storefronts_StorefrontId",
                table: "Users",
                column: "StorefrontId",
                principalTable: "Storefronts",
                principalColumn: "StorefrontId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
