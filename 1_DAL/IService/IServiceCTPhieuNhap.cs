using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceCTPhieuNhap
    {
        public List<ChiTietPhieuNhap> GetLstCTPN();//Lấy dữ liệu bảng ChiTietPhieuNhap
        public string EditCTPN(ChiTietPhieuNhap CTPN);//Sửa dữ liệu bảng ChiTietPhieuNhap
        public string DeleteCTPN(ChiTietPhieuNhap CTPN);//Xóa dữ liệu bảng ChiTietPhieuNhap 
        public string AddCTPN(ChiTietPhieuNhap CTPN);//Thêm dữ liệu  bảng ChiTietPhieuNhap
    }
}
