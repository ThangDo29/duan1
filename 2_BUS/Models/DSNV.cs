using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Models
{
    public class DSNV
    {
        public int ID { get; set; }
        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public byte GioiTinh { get; set; }
        public string Cccd { get; set; }
        public int MaCv { get; set; }
        public string TenCV { get; set; }
        public int NamSinh { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public int TrangThai { get; set; }
    }
}
