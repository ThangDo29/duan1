using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceHDBan
    {
        public List<ChiTietHoaDonBan> GetLstHDBan();//Lấy dữ liệu bảng ChiTietHoaDonBan
        public string EditHDBan(ChiTietHoaDonBan CTHDB);//Sửa dữ liệu bảng ChiTietHoaDonBan
        public string DeleteHDBan(ChiTietHoaDonBan CTHDB);//Xóa dữ liệu bảng ChiTietHoaDonBan 
        public string AddHDBan(ChiTietHoaDonBan CTHDB);//Thêm dữ liệu  bảng ChiTietHoaDonBan
    }
}
