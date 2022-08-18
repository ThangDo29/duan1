using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("SanPham")]
    public partial class SanPham
    {
        public SanPham()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Key]
        [Column("MaSP")]
        [StringLength(10)]
        public string MaSp { get; set; }
        [Column("MaTL")]
        public int MaTl { get; set; }
        [Column("MaNCC")]
        public int MaNcc { get; set; }
        [Column("MaNSX")]
        public int MaNsx { get; set; }
        [Required]
        [StringLength(20)]
        public string BarCode { get; set; }
        [Required]
        [StringLength(50)]
        public string TenThuongHieu { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey(nameof(MaNcc))]
        [InverseProperty(nameof(NhaCungCap.SanPhams))]
        public virtual NhaCungCap MaNccNavigation { get; set; }
        [ForeignKey(nameof(MaNsx))]
        [InverseProperty(nameof(NhaSanXuat.SanPhams))]
        public virtual NhaSanXuat MaNsxNavigation { get; set; }
        [ForeignKey(nameof(MaTl))]
        [InverseProperty(nameof(TheLoaiSanPham.SanPhams))]
        public virtual TheLoaiSanPham MaTlNavigation { get; set; }
        [InverseProperty(nameof(ChiTietSanPham.MaSpNavigation))]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
