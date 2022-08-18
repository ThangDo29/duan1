using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("MaNCC")]
        public int MaNcc { get; set; }
        [Required]
        [Column("TenNCC")]
        [StringLength(50)]
        public string TenNcc { get; set; }

        [InverseProperty(nameof(SanPham.MaNccNavigation))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
