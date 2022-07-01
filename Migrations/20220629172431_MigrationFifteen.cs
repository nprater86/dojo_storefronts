using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class MigrationFifteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "SubmittedOrders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TrackingNumber",
                table: "SubmittedOrders",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "SubmittedOrders");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "SubmittedOrders");
        }
    }
}
