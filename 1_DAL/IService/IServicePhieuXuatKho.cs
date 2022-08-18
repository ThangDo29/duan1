using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServicePhieuXuatKho
    {
        public List<PhieuXuatKho> GetLstPhieuXuat();//Lấy dữ liệu bảng PhieuXuatKho
        public string EditHDBan(PhieuXuatKho phieuXuat);//Sửa dữ liệu bảng PhieuXuatKho
        public string DeleteHDBan(PhieuXuatKho phieuXuat);//Xóa dữ liệu bảng PhieuXuatKho 
        public string AddHDBan(PhieuXuatKho phieuXuat);//Thêm dữ liệu  bảng PhieuXuatKho
    }
}
