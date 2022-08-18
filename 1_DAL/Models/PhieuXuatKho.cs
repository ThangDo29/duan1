using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("PhieuXuatKho")]
    public partial class PhieuXuatKho
    {
        public PhieuXuatKho()
        {
            ChiTietPhieuXuats = new HashSet<ChiTietPhieuXuat>();
        }
        [Key]
        [StringLength(10)]
        public string MaPhieuXuat { get; set; }
        [Column("ID")]
        public int? Id { get; set; }
        public DateTime? NgayTaoPhieu { get; set; }
        public int? TrangThai { get; set; }
        [StringLength(10)]
        public string MaKho { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(10)]
        public string MaNV { get; set; }

        [ForeignKey(nameof(MaKho))]
        [InverseProperty(nameof(KhoHang.PhieuXuatKhos))]
        public virtual KhoHang MaKhoNavigation { get; set; }
        [ForeignKey(nameof(MaNV))]
        [InverseProperty(nameof(NhanVien.PhieuXuatKhos))]
        public virtual NhanVien MaNVNavigation { get; set; }
        [InverseProperty(nameof(ChiTietPhieuXuat.MapxNavigation))]
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

    }
}
