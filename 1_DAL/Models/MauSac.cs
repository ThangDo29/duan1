using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("MauSac")]
    public partial class MauSac
    {
        public MauSac()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        [Key]
        [Column("MaMS")]
        public int MaMs { get; set; }
        [Required]
        [Column("TenMS")]
        [StringLength(20)]
        public string TenMs { get; set; }

        [InverseProperty(nameof(ChiTietSanPham.MaMsNavigation))]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
