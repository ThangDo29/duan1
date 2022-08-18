using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceTheLoaiSP
    {
        public List<TheLoaiSanPham> GetLstTheLoaiSP();//Lấy dữ liệu bảng TheLoaiSanPham
        public string EditTheLoaiSP(TheLoaiSanPham theLoai);//Sửa dữ liệu bảng TheLoaiSanPham
        public string DeleteTheLoaiSP(TheLoaiSanPham theLoai);//Xóa dữ liệu bảng TheLoaiSanPham
        public string AddTheLoaiSP(TheLoaiSanPham theLoai);//Thêm dữ liệu  bảng TheLoaiSanPham
    }
}
