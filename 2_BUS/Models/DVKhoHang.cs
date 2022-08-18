using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Models
{
    public class DVKhoHang
    {
        public int? Id { get; set; }
        public string MaKho { get; set; }
        public string MaCtsp { get; set; }
        public double GiaBan { get; set; }
        public int SoLuong { get; set; }
        public int TrangThai { get; set; }
        public string TenSP { get; set; }
        public string MaCtkho { get; set; }
    }
}
