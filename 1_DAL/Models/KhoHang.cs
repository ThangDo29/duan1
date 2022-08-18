using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("KhoHang")]
    public partial class KhoHang
    {
        public KhoHang()
        {
            ChiTietKhoHangs = new HashSet<ChiTietKhoHang>();
            PhieuNhaps = new HashSet<PhieuNhap>();
            PhieuXuatKhos = new HashSet<PhieuXuatKho>();
        }

        [Key]
        [StringLength(10)]
        public string MaKho { get; set; }
        [Column("ID")]
        public int Id { get; set; }
        public int TrangThai { get; set; }

        [InverseProperty(nameof(ChiTietKhoHang.MaKhoNavigation))]
        public virtual ICollection<ChiTietKhoHang> ChiTietKhoHangs { get; set; }
        [InverseProperty(nameof(PhieuNhap.MaKhoNavigation))]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        [InverseProperty(nameof(PhieuXuatKho.MaKhoNavigation))]
        public virtual ICollection<PhieuXuatKho> PhieuXuatKhos { get; set; }
    }
}
