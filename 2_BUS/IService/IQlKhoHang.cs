using _1_DAL.Models;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IQlKhoHang
    {
        public List<KhoHang> GetLstKhoHang();
        public List<ChiTietKhoHang> GetChiTietKhos();
        public string EditKhoHang(KhoHang khoHang);
        public string DeleteKhoHang(KhoHang khoHang);
        public string AddKhoHang(KhoHang khoHang);
        public string EditCTKho(ChiTietKhoHang chiTietKhoHang);
        public string DeleteCTKh(ChiTietKhoHang chiTietKhoHang);
        public string AddCTKho(ChiTietKhoHang chiTietKhoHang);
        List<DVKhoHang> LstDVKhoHangs(); 
        int[] SoLuong();
        public List<ChiTietSanPham> GetChiTietSanPhams();
        //public List<ChiTietPhieuXuat> GetchiTietHoaDonXuatKhos(string mahd);
        //public List<ChiTietPhieuNhap> GetChiTietHoaDonNhaps(string mahd);
        bool CheckSo(string text);
        bool CheckChu(string text);
        public List<DVKhoHang> TimKiemSP(string tensp);
    }
}
