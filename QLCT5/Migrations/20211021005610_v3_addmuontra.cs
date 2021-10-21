using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLCT5.Migrations
{
    public partial class v3_addmuontra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk01_ctm",
                table: "ChiTietMuon");

            migrationBuilder.DropForeignKey(
                name: "fk02_ctm",
                table: "ChiTietMuon");

            migrationBuilder.DropForeignKey(
                name: "fk03_ctm_nhanvientra",
                table: "ChiTietMuon");

            migrationBuilder.DropForeignKey(
                name: "fk04_ctm_nhanviennhan",
                table: "ChiTietMuon");

            migrationBuilder.DropForeignKey(
                name: "fk01_muon",
                table: "Muon");

            migrationBuilder.DropForeignKey(
                name: "fk02_muon",
                table: "Muon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_muon",
                table: "Muon");

            migrationBuilder.DropIndex(
                name: "IX_Muon_IdNhanVienCho",
                table: "Muon");

            migrationBuilder.DropIndex(
                name: "IX_Muon_IdNhanVienMuon",
                table: "Muon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_ctm",
                table: "ChiTietMuon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietMuon_IdNhanVienNhan",
                table: "ChiTietMuon");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietMuon_IdNhanVienTra",
                table: "ChiTietMuon");

            migrationBuilder.DropColumn(
                name: "IdNhanVienCho",
                table: "Muon");

            migrationBuilder.DropColumn(
                name: "IdNhanVienMuon",
                table: "Muon");

            migrationBuilder.DropColumn(
                name: "IdNhanVienNhan",
                table: "ChiTietMuon");

            migrationBuilder.DropColumn(
                name: "NgayTra",
                table: "ChiTietMuon");

            migrationBuilder.RenameTable(
                name: "Muon",
                newName: "Muons");

            migrationBuilder.RenameTable(
                name: "ChiTietMuon",
                newName: "ChiTietMuons");

            migrationBuilder.RenameColumn(
                name: "IdMuon",
                table: "Muons",
                newName: "MaNvMuon");

            migrationBuilder.RenameColumn(
                name: "IdNhanVienTra",
                table: "ChiTietMuons",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "IdMuon",
                table: "ChiTietMuons",
                newName: "MuonId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietMuon_IdChungTu",
                table: "ChiTietMuons",
                newName: "IX_ChiTietMuons_IdChungTu");

            migrationBuilder.AlterColumn<string>(
                name: "TenKho",
                table: "Kho",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenChucDanh",
                table: "ChucDanh",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayMuon",
                table: "Muons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "Muons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaNvMuon",
                table: "Muons",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MuonId",
                table: "Muons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MaNvCho",
                table: "Muons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "Muons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChiTietMuonId",
                table: "ChiTietMuons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Muons",
                table: "Muons",
                column: "MuonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTietMuons",
                table: "ChiTietMuons",
                column: "ChiTietMuonId");

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
                name: "IX_Muons_MaNvCho",
                table: "Muons",
                column: "MaNvCho");

            migrationBuilder.CreateIndex(
                name: "IX_Muons_MaNvMuon",
                table: "Muons",
                column: "MaNvMuon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuons_MuonId",
                table: "ChiTietMuons",
                column: "MuonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tras_MaNvNhan",
                table: "Tras",
                column: "MaNvNhan");

            migrationBuilder.CreateIndex(
                name: "IX_Tras_MaNvTra",
                table: "Tras",
                column: "MaNvTra");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietMuons_ChungTu_IdChungTu",
                table: "ChiTietMuons",
                column: "IdChungTu",
                principalTable: "ChungTu",
                principalColumn: "IdChungTu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietMuons_Muons_MuonId",
                table: "ChiTietMuons",
                column: "MuonId",
                principalTable: "Muons",
                principalColumn: "MuonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Muons_NhanVien_MaNvCho",
                table: "Muons",
                column: "MaNvCho",
                principalTable: "NhanVien",
                principalColumn: "IdNhanVien");

            migrationBuilder.AddForeignKey(
                name: "FK_Muons_NhanVien_MaNvMuon",
                table: "Muons",
                column: "MaNvMuon",
                principalTable: "NhanVien",
                principalColumn: "IdNhanVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietMuons_ChungTu_IdChungTu",
                table: "ChiTietMuons");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietMuons_Muons_MuonId",
                table: "ChiTietMuons");

            migrationBuilder.DropForeignKey(
                name: "FK_Muons_NhanVien_MaNvCho",
                table: "Muons");

            migrationBuilder.DropForeignKey(
                name: "FK_Muons_NhanVien_MaNvMuon",
                table: "Muons");

            migrationBuilder.DropTable(
                name: "Tras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Muons",
                table: "Muons");

            migrationBuilder.DropIndex(
                name: "IX_Muons_MaNvCho",
                table: "Muons");

            migrationBuilder.DropIndex(
                name: "IX_Muons_MaNvMuon",
                table: "Muons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTietMuons",
                table: "ChiTietMuons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietMuons_MuonId",
                table: "ChiTietMuons");

            migrationBuilder.DropColumn(
                name: "MuonId",
                table: "Muons");

            migrationBuilder.DropColumn(
                name: "MaNvCho",
                table: "Muons");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Muons");

            migrationBuilder.DropColumn(
                name: "ChiTietMuonId",
                table: "ChiTietMuons");

            migrationBuilder.RenameTable(
                name: "Muons",
                newName: "Muon");

            migrationBuilder.RenameTable(
                name: "ChiTietMuons",
                newName: "ChiTietMuon");

            migrationBuilder.RenameColumn(
                name: "MaNvMuon",
                table: "Muon",
                newName: "IdMuon");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "ChiTietMuon",
                newName: "IdNhanVienTra");

            migrationBuilder.RenameColumn(
                name: "MuonId",
                table: "ChiTietMuon",
                newName: "IdMuon");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTietMuons_IdChungTu",
                table: "ChiTietMuon",
                newName: "IX_ChiTietMuon_IdChungTu");

            migrationBuilder.AlterColumn<string>(
                name: "TenKho",
                table: "Kho",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "TenChucDanh",
                table: "ChucDanh",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayMuon",
                table: "Muon",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "Muon",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdMuon",
                table: "Muon",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdNhanVienCho",
                table: "Muon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNhanVienMuon",
                table: "Muon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNhanVienNhan",
                table: "ChiTietMuon",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTra",
                table: "ChiTietMuon",
                type: "date",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_muon",
                table: "Muon",
                column: "IdMuon");

            migrationBuilder.AddPrimaryKey(
                name: "pk_ctm",
                table: "ChiTietMuon",
                columns: new[] { "IdMuon", "IdChungTu" });

            migrationBuilder.CreateIndex(
                name: "IX_Muon_IdNhanVienCho",
                table: "Muon",
                column: "IdNhanVienCho");

            migrationBuilder.CreateIndex(
                name: "IX_Muon_IdNhanVienMuon",
                table: "Muon",
                column: "IdNhanVienMuon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuon_IdNhanVienNhan",
                table: "ChiTietMuon",
                column: "IdNhanVienNhan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuon_IdNhanVienTra",
                table: "ChiTietMuon",
                column: "IdNhanVienTra");

            migrationBuilder.AddForeignKey(
                name: "fk01_ctm",
                table: "ChiTietMuon",
                column: "IdMuon",
                principalTable: "Muon",
                principalColumn: "IdMuon",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk02_ctm",
                table: "ChiTietMuon",
                column: "IdChungTu",
                principalTable: "ChungTu",
                principalColumn: "IdChungTu",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk03_ctm_nhanvientra",
                table: "ChiTietMuon",
                column: "IdNhanVienTra",
                principalTable: "NhanVien",
                principalColumn: "IdNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk04_ctm_nhanviennhan",
                table: "ChiTietMuon",
                column: "IdNhanVienNhan",
                principalTable: "NhanVien",
                principalColumn: "IdNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk01_muon",
                table: "Muon",
                column: "IdNhanVienMuon",
                principalTable: "NhanVien",
                principalColumn: "IdNhanVien",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk02_muon",
                table: "Muon",
                column: "IdNhanVienCho",
                principalTable: "NhanVien",
                principalColumn: "IdNhanVien",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
