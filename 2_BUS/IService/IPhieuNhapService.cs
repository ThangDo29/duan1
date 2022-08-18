using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
  public  interface IPhieuNhapService
    {
        public List<PhieuNhap> GetLstPhieuNhap();//Lấy dữ liệu bảng PhieuNhap
        public string EditPhieuNhap(PhieuNhap phieuNhap);//Sửa dữ liệu bảng PhieuNhap
        public string DeletePhieuNhap(PhieuNhap phieuNhap);//Xóa dữ liệu bảng PhieuNhap 
        public string AddPhieuNhap(PhieuNhap phieuNhap);//Thêm dữ liệu  bảng PhieuNhap
    }
}
