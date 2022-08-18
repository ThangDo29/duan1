using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceNhanVien
    {
        public List<NhanVien> GetLstNhanVien();//Lấy dữ liệu bảng NhanVien
        public string EditNhanVien(NhanVien nhanVien);//Sửa dữ liệu bảng NhanVien
        public string DeleteNhanVien(NhanVien nhanVien);//Xóa dữ liệu bảng NhanVien
        public string AddNhanVien(NhanVien nhanVien);//Thêm dữ liệu  bảng NhanVien
    }
}
