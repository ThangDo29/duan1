using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Models
{
   public class DSPhieuXuat
    {
        public string MaPhieuXuat { get; set; }
        public DateTime? NgayTaoPhieu { get; set; }
        
        public string MaCtkho { get; set; }
        public int YeuCau { get; set; }
        public int ThucXuat { get; set; }
        public string MaKho { get; set; }
        public int TrangThai { get; set; }
        public string TenSp { get; set; }
        public string MaCtsp { get; set; }

    }
}
