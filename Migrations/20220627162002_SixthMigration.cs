using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_OwnerUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Users_UserId1",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Storefronts_Users_OwnerUserId",
                table: "Storefronts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedOrders_Users_SubmitterUserId",
                table: "SubmittedOrders");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedOrders_SubmitterUserId",
                table: "SubmittedOrders");

            migrationBuilder.DropIndex(
                name: "IX_Storefronts_OwnerUserId",
                table: "Storefronts");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_UserId1",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OwnerUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SubmitterUserId",
                table: "SubmittedOrders");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Storefronts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SubmittedOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Storefronts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShippingAddresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedOrders_UserId",
                table: "SubmittedOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Storefronts_UserId",
                table: "Storefronts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_UserId",
                table: "ShippingAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Users_UserId",
                table: "ShippingAddresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Storefronts_Users_UserId",
                table: "Storefronts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedOrders_Users_UserId",
                table: "SubmittedOrders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Users_UserId",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Storefronts_Users_UserId",
                table: "Storefronts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubmittedOrders_Users_UserId",
                table: "SubmittedOrders");

            migrationBuilder.DropIndex(
                name: "IX_SubmittedOrders_UserId",
                table: "SubmittedOrders");

            migrationBuilder.DropIndex(
                name: "IX_Storefronts_UserId",
                table: "Storefronts");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_UserId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubmittedOrders",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SubmitterUserId",
                table: "SubmittedOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Storefronts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Storefronts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShippingAddresses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ShippingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedOrders_SubmitterUserId",
                table: "SubmittedOrders",
                column: "SubmitterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Storefronts_OwnerUserId",
                table: "Storefronts",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_UserId1",
                table: "ShippingAddresses",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OwnerUserId",
                table: "Payments",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_OwnerUserId",
                table: "Payments",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Users_UserId1",
                table: "ShippingAddresses",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Storefronts_Users_OwnerUserId",
                table: "Storefronts",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmittedOrders_Users_SubmitterUserId",
                table: "SubmittedOrders",
                column: "SubmitterUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
