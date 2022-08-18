using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Column("MaNSX")]
        public int MaNsx { get; set; }
        [Required]
        [Column("TenNSX")]
        [StringLength(50)]
        public string TenNsx { get; set; }

        [InverseProperty(nameof(SanPham.MaNsxNavigation))]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
