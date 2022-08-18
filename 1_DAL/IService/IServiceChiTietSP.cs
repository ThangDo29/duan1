using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceChiTietSP
    {
        public List<ChiTietSanPham> GetLstChiTietSP();//Lấy dữ liệu bảng ChiTietSanPham
        public string EditChiTietSP(ChiTietSanPham CTSP);//Sửa dữ liệu bảng ChiTietSanPham
        public string DeleteChiTietSP(ChiTietSanPham CTSP);//Xóa dữ liệu bảng ChiTietSanPham
        public string AddChiTietSP(ChiTietSanPham CTSP);//Thêm dữ liệu  bảng ChiTietSanPham
    }
}
