using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceCTKH
    {
        public List<ChiTietKhoHang> GetLstCTKH();//Lấy dữ liệu bảng ChiTietKhoHang
        public string EditHDBan(ChiTietKhoHang CTKH);//Sửa dữ liệu bảng ChiTietKhoHang
        public string DeleteHDBan(ChiTietKhoHang CTKH);//Xóa dữ liệu bảng ChiTietKhoHang 
        public string AddHDBan(ChiTietKhoHang CTKH);//Thêm dữ liệu  bảng ChiTietKhoHang
    }
}
