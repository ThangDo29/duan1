using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("NhanVien")]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            PhieuNhaps = new HashSet<PhieuNhap>();
            PhieuXuatKhos = new HashSet<PhieuXuatKho>();
        }

        [Column("ID")]
        public int? Id { get; set; }
        [Key]
        [Column("MaNV")]
        [StringLength(10)]
        public string MaNv { get; set; }
        [Column("MaCV")]
        public int MaCv { get; set; }
        [Required]
        [Column("TenNV")]
        [StringLength(100)]
        public string TenNv { get; set; }
        [Required]
        [Column("CCCD")]
        [StringLength(20)]
        public string Cccd { get; set; }
        public byte GioiTinh { get; set; }
        [Required]
        [StringLength(50)]
        public string TaiKhoan { get; set; }
        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
        public int NamSinh { get; set; }

        [ForeignKey(nameof(MaCv))]
        [InverseProperty(nameof(ChucVu.NhanViens))]
        public virtual ChucVu MaCvNavigation { get; set; }
        [InverseProperty(nameof(HoaDon.MaNvNavigation))]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        [InverseProperty(nameof(PhieuXuatKho.MaNVNavigation))]
        public virtual ICollection<PhieuXuatKho> PhieuXuatKhos { get; set; }
        [InverseProperty(nameof(PhieuNhap.MaNVNavigation))]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
