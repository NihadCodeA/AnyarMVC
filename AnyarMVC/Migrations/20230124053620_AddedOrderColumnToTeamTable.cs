using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyarMVC.Migrations
{
    public partial class AddedOrderColumnToTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Teams");
        }
    }
}
