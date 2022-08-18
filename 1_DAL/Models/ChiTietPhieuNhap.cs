using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("ChiTietPhieuNhap")]
    public partial class ChiTietPhieuNhap
    {
        [Key]
        [StringLength(10)]
        public string MaPhieuNhap { get; set; }
        [Key]
        [Column("MaCTSP")]
        [StringLength(10)]
        public string MaCtsp { get; set; }
        [Required]
        [Column("TenSP")]
        [StringLength(100)]
        public string TenSp { get; set; }
        public int SoLuong { get; set; }
        public int ThucNhap { get; set; }
        public int ID { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey(nameof(MaCtsp))]
        [InverseProperty(nameof(ChiTietSanPham.ChiTietPhieuNhaps))]
        public virtual ChiTietSanPham MaCtspNavigation { get; set; }
        [ForeignKey(nameof(MaPhieuNhap))]
        [InverseProperty(nameof(PhieuNhap.ChiTietPhieuNhaps))]
        public virtual PhieuNhap MapnNavigation { get; set; }
    }
}
