using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetBakery.Migrations
{
    public partial class AddBreadType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Breads",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Breads");
        }
    }
}
