using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{
    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {
        public PhieuNhap()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }
        [Key]
        [StringLength(10)]
        public string MaPhieuNhap { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        public int TrangThai { get; set; }
        [Required]
        [StringLength(10)]
        public string MaKho { get; set; }
        [Required]
        [Column("MaNV")]
        [StringLength(10)]
        public string MaNV { get; set; }
        public DateTime NgayTaoPhieu { get; set; }

        [ForeignKey(nameof(MaKho))]
        [InverseProperty(nameof(KhoHang.PhieuNhaps))]
        public virtual KhoHang MaKhoNavigation { get; set; }
        [ForeignKey(nameof(MaNV))]
        [InverseProperty(nameof(NhanVien.PhieuNhaps))]
        public virtual NhanVien MaNVNavigation { get; set; }
        [InverseProperty(nameof(ChiTietPhieuNhap.MapnNavigation))]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
