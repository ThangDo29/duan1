using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServicePhieuNhap
    {
        public List<PhieuNhap> GetLstPhieuNhap();//Lấy dữ liệu bảng PhieuNhap
        public string EditHDBan(PhieuNhap phieuNhap);//Sửa dữ liệu bảng PhieuNhap
        public string DeleteHDBan(PhieuNhap phieuNhap);//Xóa dữ liệu bảng PhieuNhap 
        public string AddHDBan(PhieuNhap phieuNhap);//Thêm dữ liệu  bảng PhieuNhap
    }
}
