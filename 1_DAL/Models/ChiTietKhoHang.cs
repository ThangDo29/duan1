using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("ChiTietKhoHang")]
    public partial class ChiTietKhoHang
    {
        public ChiTietKhoHang()
        {
            ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
        }

        [Required]
        [StringLength(10)]
        public string MaKho { get; set; }
        [Required]
        [Column("MaCTSP")]
        [StringLength(10)]
        public string MaCtsp { get; set; }
        public int SoLuong { get; set; }
        public int TrangThai { get; set; }
        [Key]
        [Column("MaCTKho")]
        [StringLength(10)]
        public string MaCtkho { get; set; }
        [Column("ID")]
        public int? Id { get; set; }

        [ForeignKey(nameof(MaCtsp))]
        [InverseProperty(nameof(ChiTietSanPham.ChiTietKhoHangs))]
        public virtual ChiTietSanPham MaCtspNavigation { get; set; }
        [ForeignKey(nameof(MaKho))]
        [InverseProperty(nameof(KhoHang.ChiTietKhoHangs))]
        public virtual KhoHang MaKhoNavigation { get; set; }
        [InverseProperty(nameof(ChiTietPhieuXuat.MaCtkhoNavigation))]
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
    }
}
