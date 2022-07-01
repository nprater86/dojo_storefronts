using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dojo_storefronts.Migrations
{
    public partial class MigrationFourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SubmittedOrders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubmittedOrders");
        }
    }
}
