using _1_DAL.Models;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
   public interface IServiceQLHDXuat
    {
        public List<ChiTietPhieuXuat> GetLstCTPhieuXuat();//Lấy dữ liệu bảng ChiTietHoaDonXuat
        public List<ChiTietSanPham> GetlstCTSP();
        public string EditCTPhieuXuat(ChiTietPhieuXuat CTPX);//Sửa dữ liệu bảng ChiTietHoaDonXuat
        public string DeleteCTPhieuXuat(ChiTietPhieuXuat CTPX);//Xóa dữ liệu bảng ChiTietHoaDonXuat
        public string AddCTPhieuXuat(ChiTietPhieuXuat CTPX);//Thêm dữ liệu  bảng ChiTietHoaDonXuat
        int[] SoLuong();
        public List<KhoHang> GetLstKho();
        public List<PhieuXuatKho> GetPhieuXuatKhos();
        public string EditPhieuXuat(PhieuXuatKho PhieuXuat);//Sửa dữ liệu bảng ChiTietHoaDonXuat
        public string DeletePhieuXuat(PhieuXuatKho PhieuXuat);//Xóa dữ liệu bảng ChiTietHoaDonXuat
        public string AddPhieuXuat(PhieuXuatKho PhieuXuat);
        public List<DSPhieuXuat> GetLSTDSPhieuXuats();
        public List<ChiTietKhoHang> GetChiTietKhoHangs();
        public List<ChiTietPhieuXuat> GetLstCTPhieuXuats(string mapx);
        public bool checkTrungMAKHo(string text, string mactsp);
        bool CheckSo(string text);


    }
}

