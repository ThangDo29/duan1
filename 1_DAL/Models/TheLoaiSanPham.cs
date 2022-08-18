using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("TheLoaiSanPham")]
    public partial class TheLoaiSanPham
    {
        public TheLoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("MaTL")]
        public int MaTl { get; set; }
        [Required]
        [Column("TenTL")]
        [StringLength(50)]
        public string TenTl { get; set; }

        [InverseProperty(nameof(SanPham.MaTlNavigation))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
