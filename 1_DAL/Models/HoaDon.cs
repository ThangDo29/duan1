using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("HoaDon")]
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDonBans = new HashSet<ChiTietHoaDonBan>();
        }

        [Key]
        [Column("MaHD")]
        [StringLength(10)]
        public string MaHd { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(10)]
        public string MaNv { get; set; }
        public bool ThanhToan { get; set; }
        public int TrangThai { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        [Column("LoaiHD")]
        public int LoaiHd { get; set; }
        [Column("TenKH")]
        [StringLength(50)]
        public string TenKh { get; set; }
        [Column("SDT")]
        [StringLength(10)]
        public string Sdt { get; set; }
        [StringLength(10)]
        public string DiaChi { get; set; }
        public DateTime NgayLapHD { get; set; }

        [ForeignKey(nameof(MaNv))]
        [InverseProperty(nameof(NhanVien.HoaDons))]
        public virtual NhanVien MaNvNavigation { get; set; }
        [InverseProperty(nameof(ChiTietHoaDonBan.MahdNavigation))]
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }
    }
}
