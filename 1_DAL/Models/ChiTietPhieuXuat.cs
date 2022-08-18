using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("ChiTietPhieuXuat")]
    public partial class ChiTietPhieuXuat
    {
        [Key]
        [StringLength(10)]
        public string MaPhieuXuat { get; set; }
        [Key]
        [Required]
        [Column("MaCTKho")]
        [StringLength(10)]
        public string MaCtkho { get; set; }
        public int YeuCau { get; set; }
        public int ThucXuat { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey(nameof(MaCtkho))]
        [InverseProperty(nameof(ChiTietKhoHang.ChiTietPhieuXuats))]
        public virtual ChiTietKhoHang MaCtkhoNavigation { get; set; }
        [ForeignKey(nameof(MaPhieuXuat))]
        [InverseProperty(nameof(PhieuXuatKho.ChiTietPhieuXuats))]
        public virtual PhieuXuatKho MapxNavigation { get; set; }
    }
}
