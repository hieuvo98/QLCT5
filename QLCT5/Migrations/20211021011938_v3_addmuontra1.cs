using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLCT5.Migrations
{
    public partial class v3_addmuontra1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietMuons");

            migrationBuilder.DropTable(
                name: "Tras");

            migrationBuilder.DropTable(
                name: "Muons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muons",
                columns: table => new
                {
                    MuonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNvCho = table.Column<int>(type: "int", nullable: false),
                    MaNvMuon = table.Column<int>(type: "int", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muons", x => x.MuonId);
                    table.ForeignKey(
                        name: "FK_Muons_NhanVien_MaNvCho",
                        column: x => x.MaNvCho,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien");
                    table.ForeignKey(
                        name: "FK_Muons_NhanVien_MaNvMuon",
                        column: x => x.MaNvMuon,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietMuons",
                columns: table => new
                {
                    ChiTietMuonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChungTu = table.Column<int>(type: "int", nullable: false),
                    MuonId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietMuons", x => x.ChiTietMuonId);
                    table.ForeignKey(
                        name: "FK_ChiTietMuons_ChungTu_IdChungTu",
                        column: x => x.IdChungTu,
                        principalTable: "ChungTu",
                        principalColumn: "IdChungTu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietMuons_Muons_MuonId",
                        column: x => x.MuonId,
                        principalTable: "Muons",
                        principalColumn: "MuonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tras",
                columns: table => new
                {
                    TraId = table.Column<int>(type: "int", nullable: false),
                    MaNvNhan = table.Column<int>(type: "int", nullable: false),
                    MaNvTra = table.Column<int>(type: "int", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tras", x => x.TraId);
                    table.ForeignKey(
                        name: "FK_Tras_Muons_TraId",
                        column: x => x.TraId,
                        principalTable: "Muons",
                        principalColumn: "MuonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tras_NhanVien_MaNvNhan",
                        column: x => x.MaNvNhan,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien");
                    table.ForeignKey(
                        name: "FK_Tras_NhanVien_MaNvTra",
                        column: x => x.MaNvTra,
                        principalTable: "NhanVien",
                        principalColumn: "IdNhanVien");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuons_IdChungTu",
                table: "ChiTietMuons",
                column: "IdChungTu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuons_MuonId",
                table: "ChiTietMuons",
                column: "MuonId");

            migrationBuilder.CreateIndex(
                name: "IX_Muons_MaNvCho",
                table: "Muons",
                column: "MaNvCho");

            migrationBuilder.CreateIndex(
                name: "IX_Muons_MaNvMuon",
                table: "Muons",
                column: "MaNvMuon");

            migrationBuilder.CreateIndex(
                name: "IX_Tras_MaNvNhan",
                table: "Tras",
                column: "MaNvNhan");

            migrationBuilder.CreateIndex(
                name: "IX_Tras_MaNvTra",
                table: "Tras",
                column: "MaNvTra");
        }
    }
}
