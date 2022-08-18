using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceKhoHang
    {
        public List<KhoHang> GetLstKhoHang();//Lấy dữ liệu bảng KhoHang
        public string EditKhoHang(KhoHang khoHang);//Sửa dữ liệu bảng KhoHang
        public string DeleteKhoHang(KhoHang khoHang);//Xóa dữ liệu bảng KhoHang
        public string AddKhoHang(KhoHang khoHang);//Thêm dữ liệu  bảng KhoHang
        void GetlstDB();
    }
}
