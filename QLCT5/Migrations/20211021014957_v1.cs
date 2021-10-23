using Microsoft.EntityFrameworkCore.Migrations;

namespace QLCT5.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idd",
                table: "Muons");

            migrationBuilder.DropColumn(
                name: "idddddd",
                table: "ChiTietMuons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idd",
                table: "Muons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idddddd",
                table: "ChiTietMuons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
