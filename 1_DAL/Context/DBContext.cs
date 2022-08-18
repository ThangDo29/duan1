using _1_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {

        }

        public virtual DbSet<ChatLieu> ChatLieus { get; set; }
        public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        public virtual DbSet<ChiTietKhoHang> ChiTietKhoHangs { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<KichThuoc> KichThuocs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TheLoaiSanPham> TheLoaiSanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-RHDF27IF\\SQLEXPRESS;Initial Catalog=Du_an_1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatLieu>(entity =>
            {
                entity.Property(e => e.MaCl).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Mactsp });

                entity.HasOne(d => d.MactspNavigation)
                    .WithMany(p => p.ChiTietHoaDonBans)
                    .HasForeignKey(d => d.Mactsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonBan_ChiTietSanPham");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.ChiTietHoaDonBans)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDonBan_HoaDon");
            });

            modelBuilder.Entity<ChiTietKhoHang>(entity =>
            {
                entity.HasKey(e => e.MaCtkho)
                    .HasName("PK_ChiTietKhoHang_1");

                entity.HasOne(d => d.MaCtspNavigation)
                    .WithMany(p => p.ChiTietKhoHangs)
                    .HasForeignKey(d => d.MaCtsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietKhoHang_ChiTietSanPham");

                entity.HasOne(d => d.MaKhoNavigation)
                    .WithMany(p => p.ChiTietKhoHangs)
                    .HasForeignKey(d => d.MaKho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietKhoHang_KhoHang");
            });

            modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuNhap, e.MaCtsp });

                entity.HasOne(d => d.MaCtspNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaCtsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuNhap_ChiTietSanPham");

                entity.HasOne(d => d.MapnNavigation)
                    .WithMany(p => p.ChiTietPhieuNhaps)
                    .HasForeignKey(d => d.MaPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuNhap_PhieuNhap");
            });

            modelBuilder.Entity<ChiTietPhieuXuat>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuXuat, e.MaCtkho });
                entity.HasOne(d => d.MaCtkhoNavigation)
                    .WithMany(p => p.ChiTietPhieuXuats)
                    .HasForeignKey(d => d.MaCtkho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuXuat_ChiTietKhoHang");

                entity.HasOne(d => d.MapxNavigation)
                    .WithMany(p => p.ChiTietPhieuXuats)
                    .HasForeignKey(d => d.MaPhieuXuat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieuXuat_PhieuXuat");
            });

            modelBuilder.Entity<ChiTietSanPham>(entity =>
            {
                entity.HasOne(d => d.MaClNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaCl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSanPham_ChatLieu");

                entity.HasOne(d => d.MaKtNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaKt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSanPham_KichThuoc");

                entity.HasOne(d => d.MaMsNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaMs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSanPham_MauSac");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietSanPhams)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietSanPham_SanPham");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.Property(e => e.MaCv).ValueGeneratedNever();
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.DiaChi).IsFixedLength(true);

                entity.Property(e => e.Sdt).IsFixedLength(true);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_NhanVien");
            });

            modelBuilder.Entity<KichThuoc>(entity =>
            {
                entity.Property(e => e.MaKt).ValueGeneratedNever();
            });

            modelBuilder.Entity<MauSac>(entity =>
            {
                entity.Property(e => e.MaMs).ValueGeneratedNever();
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.Property(e => e.MaNcc).ValueGeneratedNever();
            });

            modelBuilder.Entity<NhaSanXuat>(entity =>
            {
                entity.Property(e => e.MaNsx).ValueGeneratedNever();
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhanVien_ChucVu");
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasOne(d => d.MaKhoNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaKho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuNhap_PhieuNhap");

                entity.HasOne(d => d.MaNVNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaNV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuNhap_NhanVien");
            });

            modelBuilder.Entity<PhieuXuatKho>(entity =>
            {
                entity.HasOne(d => d.MaKhoNavigation)
                    .WithMany(p => p.PhieuXuatKhos)
                    .HasForeignKey(d => d.MaKho)
                    .HasConstraintName("FK_PhieuXuatKho_KhoHang");


                entity.HasOne(d => d.MaNVNavigation)
                .WithMany(p => p.PhieuXuatKhos)
                .HasForeignKey(d => d.MaNV)
                .HasConstraintName("FK_PhieuXuatKho_NhanVien");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.BarCode).IsUnicode(false);

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_NhaCungCap");

                entity.HasOne(d => d.MaNsxNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_NhaSanXuat");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaTl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_TheLoaiSanPham");
            });

            modelBuilder.Entity<TheLoaiSanPham>(entity =>
            {
                entity.Property(e => e.MaTl).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
