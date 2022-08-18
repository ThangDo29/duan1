using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace _1_DAL.Models
{
    [Table("KichThuoc")]
    public partial class KichThuoc
    {
        public KichThuoc()
        {
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
        }

        [Key]
        [Column("MaKT")]
        public int MaKt { get; set; }
        public int Size { get; set; }

        [InverseProperty(nameof(ChiTietSanPham.MaKtNavigation))]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
