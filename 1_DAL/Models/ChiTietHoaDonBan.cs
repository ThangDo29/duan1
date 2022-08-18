using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("ChiTietHoaDonBan")]
    public partial class ChiTietHoaDonBan
    {
        [Key]
        [Column("MAHD")]
        [StringLength(10)]
        public string Mahd { get; set; }
        [Key]
        [Column("MACTSP")]
        [StringLength(10)]
        public string Mactsp { get; set; }
        [Required]
        [Column("TenSP")]
        [StringLength(50)]
        public string TenSp { get; set; }
        public int SoLuong { get; set; }
        [Column("NgayTaoHD")]
        public DateTime NgayTaoHd { get; set; }
        public double GiaBan { get; set; }
        public double TongTien { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey(nameof(Mactsp))]
        [InverseProperty(nameof(ChiTietSanPham.ChiTietHoaDonBans))]
        public virtual ChiTietSanPham MactspNavigation { get; set; }
        [ForeignKey(nameof(Mahd))]
        [InverseProperty(nameof(HoaDon.ChiTietHoaDonBans))]
        public virtual HoaDon MahdNavigation { get; set; }
    }
}
