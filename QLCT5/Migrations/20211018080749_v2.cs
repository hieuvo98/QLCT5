using Microsoft.EntityFrameworkCore.Migrations;

namespace QLCT5.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk01_ctm",
                table: "ChiTietMuon");

            migrationBuilder.AddForeignKey(
                name: "fk01_ctm",
                table: "ChiTietMuon",
                column: "IdMuon",
                principalTable: "Muon",
                principalColumn: "IdMuon",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk01_ctm",
                table: "ChiTietMuon");

            migrationBuilder.AddForeignKey(
                name: "fk01_ctm",
                table: "ChiTietMuon",
                column: "IdMuon",
                principalTable: "Muon",
                principalColumn: "IdMuon",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
