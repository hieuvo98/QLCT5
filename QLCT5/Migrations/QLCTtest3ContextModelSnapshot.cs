﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLCT5.Models;

namespace QLCT5.Migrations
{
    [DbContext(typeof(QLCTtest3Context))]
    partial class QLCTtest3ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("QLCT5.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QLCT5.Models.ChiTietMuon", b =>
                {
                    b.Property<int>("ChiTietMuonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdChungTu")
                        .HasColumnType("int");

                    b.Property<int>("MuonId")
                        .HasColumnType("int");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ChiTietMuonId");

                    b.HasIndex("IdChungTu");

                    b.HasIndex("MuonId");

                    b.ToTable("ChiTietMuons");
                });

            modelBuilder.Entity("QLCT5.Models.ChucDanh", b =>
                {
                    b.Property<int>("IdChucDanh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenChucDanh")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdChucDanh")
                        .HasName("pk_cd");

                    b.ToTable("ChucDanh");
                });

            modelBuilder.Entity("QLCT5.Models.ChungTu", b =>
                {
                    b.Property<int>("IdChungTu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdDonVi")
                        .HasColumnType("int");

                    b.Property<int?>("IdKepChungTu")
                        .HasColumnType("int");

                    b.Property<string>("MaChungTu")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("NgayChungTu")
                        .HasColumnType("date");

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenChungTu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdChungTu")
                        .HasName("pk_ct");

                    b.HasIndex("IdDonVi");

                    b.HasIndex("IdKepChungTu");

                    b.ToTable("ChungTu");
                });

            modelBuilder.Entity("QLCT5.Models.DonVi", b =>
                {
                    b.Property<int>("IdDonVi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenDonVi")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdDonVi")
                        .HasName("pk_dv");

                    b.ToTable("DonVi");
                });

            modelBuilder.Entity("QLCT5.Models.KepChungTu", b =>
                {
                    b.Property<int>("IdKepChungTu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdTuKe")
                        .HasColumnType("int");

                    b.Property<int?>("NamCt")
                        .HasColumnType("int")
                        .HasColumnName("NamCT");

                    b.Property<string>("SoHopDong")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TenKepChungTu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ThangCt")
                        .HasColumnType("int")
                        .HasColumnName("ThangCT");

                    b.HasKey("IdKepChungTu")
                        .HasName("pk_kct");

                    b.HasIndex("IdTuKe");

                    b.ToTable("KepChungTu");
                });

            modelBuilder.Entity("QLCT5.Models.Kho", b =>
                {
                    b.Property<int>("IdKho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdKho")
                        .HasName("pk_kho");

                    b.ToTable("Kho");
                });

            modelBuilder.Entity("QLCT5.Models.Muon", b =>
                {
                    b.Property<int>("MuonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaNvCho")
                        .HasColumnType("int");

                    b.Property<int>("MaNvMuon")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayMuon")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MuonId");

                    b.HasIndex("MaNvCho");

                    b.HasIndex("MaNvMuon");

                    b.ToTable("Muons");
                });

            modelBuilder.Entity("QLCT5.Models.NhanVien", b =>
                {
                    b.Property<int>("IdNhanVien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("IdChucDanh")
                        .HasColumnType("int");

                    b.Property<int?>("IdDonVi")
                        .HasColumnType("int");

                    b.Property<int?>("IdPhongBan")
                        .HasColumnType("int");

                    b.Property<string>("SoDt")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("SoDT");

                    b.HasKey("IdNhanVien")
                        .HasName("pk_nv");

                    b.HasIndex("IdChucDanh");

                    b.HasIndex("IdDonVi");

                    b.HasIndex("IdPhongBan");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("QLCT5.Models.PhongBan", b =>
                {
                    b.Property<int>("IdPhongBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenPhongBan")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdPhongBan")
                        .HasName("pk_pb");

                    b.ToTable("PhongBan");
                });

            modelBuilder.Entity("QLCT5.Models.Tra", b =>
                {
                    b.Property<int>("TraId")
                        .HasColumnType("int");

                    b.Property<int>("MaNvNhan")
                        .HasColumnType("int");

                    b.Property<int>("MaNvTra")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayTra")
                        .HasColumnType("datetime2");

                    b.HasKey("TraId");

                    b.HasIndex("MaNvNhan");

                    b.HasIndex("MaNvTra");

                    b.ToTable("Tras");
                });

            modelBuilder.Entity("QLCT5.Models.TuKe", b =>
                {
                    b.Property<int>("IdTuKe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdKho")
                        .HasColumnType("int");

                    b.Property<string>("TenTuKe")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTuKe")
                        .HasName("pk_tk");

                    b.HasIndex("IdKho");

                    b.ToTable("TuKe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QLCT5.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QLCT5.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCT5.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QLCT5.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLCT5.Models.ChiTietMuon", b =>
                {
                    b.HasOne("QLCT5.Models.ChungTu", "ChungTu")
                        .WithMany()
                        .HasForeignKey("IdChungTu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLCT5.Models.Muon", "Muon")
                        .WithMany("ChiTietMuons")
                        .HasForeignKey("MuonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChungTu");

                    b.Navigation("Muon");
                });

            modelBuilder.Entity("QLCT5.Models.ChungTu", b =>
                {
                    b.HasOne("QLCT5.Models.DonVi", "IdDonViNavigation")
                        .WithMany("ChungTus")
                        .HasForeignKey("IdDonVi")
                        .HasConstraintName("fk01_ct");

                    b.HasOne("QLCT5.Models.KepChungTu", "IdKepChungTuNavigation")
                        .WithMany("ChungTus")
                        .HasForeignKey("IdKepChungTu")
                        .HasConstraintName("fk02_ct");

                    b.Navigation("IdDonViNavigation");

                    b.Navigation("IdKepChungTuNavigation");
                });

            modelBuilder.Entity("QLCT5.Models.KepChungTu", b =>
                {
                    b.HasOne("QLCT5.Models.TuKe", "IdTuKeNavigation")
                        .WithMany("KepChungTus")
                        .HasForeignKey("IdTuKe")
                        .HasConstraintName("fk01_kct");

                    b.Navigation("IdTuKeNavigation");
                });

            modelBuilder.Entity("QLCT5.Models.Muon", b =>
                {
                    b.HasOne("QLCT5.Models.NhanVien", "NhanVienCho")
                        .WithMany()
                        .HasForeignKey("MaNvCho")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QLCT5.Models.NhanVien", "NhanVienMuon")
                        .WithMany()
                        .HasForeignKey("MaNvMuon")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("NhanVienCho");

                    b.Navigation("NhanVienMuon");
                });

            modelBuilder.Entity("QLCT5.Models.NhanVien", b =>
                {
                    b.HasOne("QLCT5.Models.ChucDanh", "IdChucDanhNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdChucDanh")
                        .HasConstraintName("fk02_nv");

                    b.HasOne("QLCT5.Models.DonVi", "IdDonViNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdDonVi")
                        .HasConstraintName("fk03_nv");

                    b.HasOne("QLCT5.Models.PhongBan", "IdPhongBanNavigation")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdPhongBan")
                        .HasConstraintName("fk01_nv");

                    b.Navigation("IdChucDanhNavigation");

                    b.Navigation("IdDonViNavigation");

                    b.Navigation("IdPhongBanNavigation");
                });

            modelBuilder.Entity("QLCT5.Models.Tra", b =>
                {
                    b.HasOne("QLCT5.Models.NhanVien", "NhanVienNhan")
                        .WithMany()
                        .HasForeignKey("MaNvNhan")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QLCT5.Models.NhanVien", "NhanVienTra")
                        .WithMany()
                        .HasForeignKey("MaNvTra")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QLCT5.Models.Muon", "Muon")
                        .WithOne("Tra")
                        .HasForeignKey("QLCT5.Models.Tra", "TraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Muon");

                    b.Navigation("NhanVienNhan");

                    b.Navigation("NhanVienTra");
                });

            modelBuilder.Entity("QLCT5.Models.TuKe", b =>
                {
                    b.HasOne("QLCT5.Models.Kho", "IdKhoNavigation")
                        .WithMany("TuKes")
                        .HasForeignKey("IdKho")
                        .HasConstraintName("fk01_tk");

                    b.Navigation("IdKhoNavigation");
                });

            modelBuilder.Entity("QLCT5.Models.ChucDanh", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("QLCT5.Models.DonVi", b =>
                {
                    b.Navigation("ChungTus");

                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("QLCT5.Models.KepChungTu", b =>
                {
                    b.Navigation("ChungTus");
                });

            modelBuilder.Entity("QLCT5.Models.Kho", b =>
                {
                    b.Navigation("TuKes");
                });

            modelBuilder.Entity("QLCT5.Models.Muon", b =>
                {
                    b.Navigation("ChiTietMuons");

                    b.Navigation("Tra");
                });

            modelBuilder.Entity("QLCT5.Models.PhongBan", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("QLCT5.Models.TuKe", b =>
                {
                    b.Navigation("KepChungTus");
                });
#pragma warning restore 612, 618
        }
    }
}
