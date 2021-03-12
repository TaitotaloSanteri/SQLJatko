using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLJatko.Migrations
{
    public partial class Games2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "testi",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testi",
                table: "Games");
        }
    }
}
