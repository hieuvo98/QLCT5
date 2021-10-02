using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLCT5.Models
{
    public partial class QLCTtest3Context : IdentityDbContext<AppUser>
    {
        public QLCTtest3Context()
        {
        }

        public QLCTtest3Context(DbContextOptions<QLCTtest3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietMuon> ChiTietMuons { get; set; }
        public virtual DbSet<ChucDanh> ChucDanhs { get; set; }
        public virtual DbSet<ChungTu> ChungTus { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<KepChungTu> KepChungTus { get; set; }
        public virtual DbSet<Kho> Khos { get; set; }
        public virtual DbSet<Muon> Muons { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<TuKe> TuKes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PQL87F9;Initial Catalog=QLCTtest3;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietMuon>(entity =>
            {
                entity.HasKey(e => new { e.IdMuon, e.IdChungTu })
                    .HasName("pk_ctm");

                entity.ToTable("ChiTietMuon");

                entity.Property(e => e.NgayTra).HasColumnType("date");

                entity.HasOne(d => d.IdChungTuNavigation)
                    .WithMany(p => p.ChiTietMuons)
                    .HasForeignKey(d => d.IdChungTu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk02_ctm");

                entity.HasOne(d => d.IdMuonNavigation)
                    .WithMany(p => p.ChiTietMuons)
                    .HasForeignKey(d => d.IdMuon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk01_ctm");

                entity.HasOne(d => d.IdNhanVienNhanNavigation)
                    .WithMany(p => p.ChiTietMuonIdNhanVienNhanNavigations)
                    .HasForeignKey(d => d.IdNhanVienNhan)
                    .HasConstraintName("fk04_ctm_nhanviennhan");

                entity.HasOne(d => d.IdNhanVienTraNavigation)
                    .WithMany(p => p.ChiTietMuonIdNhanVienTraNavigations)
                    .HasForeignKey(d => d.IdNhanVienTra)
                    .HasConstraintName("fk03_ctm_nhanvientra");
            });

            modelBuilder.Entity<ChucDanh>(entity =>
            {
                entity.HasKey(e => e.IdChucDanh)
                    .HasName("pk_cd");

                entity.ToTable("ChucDanh");

                entity.Property(e => e.TenChucDanh).HasMaxLength(30);
            });

            modelBuilder.Entity<ChungTu>(entity =>
            {
                entity.HasKey(e => e.IdChungTu)
                    .HasName("pk_ct");

                entity.ToTable("ChungTu");

                entity.Property(e => e.MaChungTu).HasMaxLength(30);

                entity.Property(e => e.NgayChungTu).HasColumnType("date");

                entity.Property(e => e.TenChungTu).HasMaxLength(100);

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.ChungTus)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("fk01_ct");

                entity.HasOne(d => d.IdKepChungTuNavigation)
                    .WithMany(p => p.ChungTus)
                    .HasForeignKey(d => d.IdKepChungTu)
                    .HasConstraintName("fk02_ct");
            });

            modelBuilder.Entity<DonVi>(entity =>
            {
                entity.HasKey(e => e.IdDonVi)
                    .HasName("pk_dv");

                entity.ToTable("DonVi");

                entity.Property(e => e.TenDonVi).HasMaxLength(30);
            });

            modelBuilder.Entity<KepChungTu>(entity =>
            {
                entity.HasKey(e => e.IdKepChungTu)
                    .HasName("pk_kct");

                entity.ToTable("KepChungTu");

                entity.Property(e => e.NamCt).HasColumnName("NamCT");

                entity.Property(e => e.SoHopDong).HasMaxLength(30);

                entity.Property(e => e.TenKepChungTu).HasMaxLength(50);

                entity.Property(e => e.ThangCt).HasColumnName("ThangCT");

                entity.HasOne(d => d.IdTuKeNavigation)
                    .WithMany(p => p.KepChungTus)
                    .HasForeignKey(d => d.IdTuKe)
                    .HasConstraintName("fk01_kct");
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.IdKho)
                    .HasName("pk_kho");

                entity.ToTable("Kho");

                entity.Property(e => e.DiaChi).HasMaxLength(30);

                entity.Property(e => e.TenKho).HasMaxLength(30);
            });

            modelBuilder.Entity<Muon>(entity =>
            {
                entity.HasKey(e => e.IdMuon)
                    .HasName("pk_muon");

                entity.ToTable("Muon");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.NgayMuon).HasColumnType("date");

                entity.HasOne(d => d.IdNhanVienChoNavigation)
                    .WithMany(p => p.MuonIdNhanVienChoNavigations)
                    .HasForeignKey(d => d.IdNhanVienCho)
                    .HasConstraintName("fk02_muon");

                entity.HasOne(d => d.IdNhanVienMuonNavigation)
                    .WithMany(p => p.MuonIdNhanVienMuonNavigations)
                    .HasForeignKey(d => d.IdNhanVienMuon)
                    .HasConstraintName("fk01_muon");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.IdNhanVien)
                    .HasName("pk_nv");

                entity.ToTable("NhanVien");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HoTen).HasMaxLength(30);

                entity.Property(e => e.SoDt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SoDT");

                entity.HasOne(d => d.IdChucDanhNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdChucDanh)
                    .HasConstraintName("fk02_nv");

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("fk03_nv");

                entity.HasOne(d => d.IdPhongBanNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.IdPhongBan)
                    .HasConstraintName("fk01_nv");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.IdPhongBan)
                    .HasName("pk_pb");

                entity.ToTable("PhongBan");

                entity.Property(e => e.TenPhongBan).HasMaxLength(30);
            });

            modelBuilder.Entity<TuKe>(entity =>
            {
                entity.HasKey(e => e.IdTuKe)
                    .HasName("pk_tk");

                entity.ToTable("TuKe");

                entity.Property(e => e.TenTuKe).HasMaxLength(20);

                entity.HasOne(d => d.IdKhoNavigation)
                    .WithMany(p => p.TuKes)
                    .HasForeignKey(d => d.IdKho)
                    .HasConstraintName("fk01_tk");
            });



        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
