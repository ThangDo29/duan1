using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        public ChiTietSanPham()
        {
            ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
            ChiTietKhoHangs = new HashSet<ChiTietKhoHang>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [Column("MaCTSP")]
        [StringLength(10)]
        public string MaCtsp { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("TenSP")]
        [StringLength(50)]
        public string TenSp { get; set; }
        [Required]
        [Column("MaSP")]
        [StringLength(10)]
        public string MaSp { get; set; }
        [Column("MaMS")]
        public int MaMs { get; set; }
        [Column("MaKT")]
        public int MaKt { get; set; }
        [Column("MaCL")]
        public int MaCl { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
        [Required]
        [StringLength(20)]
        public string BarCode { get; set; }
        [Required]
        public string Hinhanh { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey(nameof(MaCl))]
        [InverseProperty(nameof(ChatLieu.ChiTietSanPhams))]
        public virtual ChatLieu MaClNavigation { get; set; }
        [ForeignKey(nameof(MaKt))]
        [InverseProperty(nameof(KichThuoc.ChiTietSanPhams))]
        public virtual KichThuoc MaKtNavigation { get; set; }
        [ForeignKey(nameof(MaMs))]
        [InverseProperty(nameof(MauSac.ChiTietSanPhams))]
        public virtual MauSac MaMsNavigation { get; set; }
        [ForeignKey(nameof(MaSp))]
        [InverseProperty(nameof(SanPham.ChiTietSanPhams))]
        public virtual SanPham MaSpNavigation { get; set; }
        [InverseProperty(nameof(ChiTietHoaDonBan.MactspNavigation))]
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
        [InverseProperty(nameof(ChiTietKhoHang.MaCtspNavigation))]
        public virtual ICollection<ChiTietKhoHang> ChiTietKhoHangs { get; set; }
        [InverseProperty(nameof(ChiTietPhieuNhap.MaCtspNavigation))]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
