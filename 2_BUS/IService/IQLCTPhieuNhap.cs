using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
   public interface IQLCTPhieuNhap
    {
        public List<ChiTietPhieuNhap> GetChiTietPhieuNhaps(string mapn);

        public List<ChiTietPhieuNhap> GetLstCTPN();//Lấy dữ liệu bảng ChiTietPhieuNhap
        public string EditCTPN(ChiTietPhieuNhap CTPN);//Sửa dữ liệu bảng ChiTietPhieuNhap
        public string DeleteCTPN(ChiTietPhieuNhap CTPN);//Xóa dữ liệu bảng ChiTietPhieuNhap 
        public string AddCTPN(ChiTietPhieuNhap CTPN);//Thêm dữ liệu  bảng ChiTietPhieuNhap
        public List<ChiTietSanPham> GetLstCTSP();
       public  int[] Soluong() ;
    }
}
