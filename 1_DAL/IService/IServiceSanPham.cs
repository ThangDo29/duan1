using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceSanPham
    {
        public List<SanPham> GetLstSanPham();//Lấy dữ liệu bảng SanPham
        public string EditSanPham(SanPham sanPham);//Sửa dữ liệu bảng SanPham
        public string DeleteSanPham(SanPham sanPham);//Xóa dữ liệu bảng SanPham
        public string AddSanPham(SanPham sanPham);//Thêm dữ liệu  bảng SanPham
    }
}
