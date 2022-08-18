using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("ChatLieu")]
    public partial class ChatLieu
    {
        public ChatLieu()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        [Key]
        [Column("MaCL")]
        public int MaCl { get; set; }
        [Required]
        [Column("TenCL")]
        [StringLength(50)]
        public string TenCl { get; set; }

        [InverseProperty(nameof(ChiTietSanPham.MaClNavigation))]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
