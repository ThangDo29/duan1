using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class QLKhoHang : IQlKhoHang
    {
        private IServiceKhoHang _serviceKhoHang;
        private IServiceChiTietSP _serviceChiTietSP;
        private List<DVKhoHang> _lstdVKhoHangs;
        private IServiceCTKH _serviceCTKH;
        private IServiceCTPhieuXuatKho _serviceCTPhieuXuat;
        public QLKhoHang()
        {
            _serviceKhoHang = new ServiceKhoHang();
            _serviceChiTietSP = new ServiceChiTietSP();
            _serviceCTKH = new ServiceCTKH();
            _serviceCTPhieuXuat = new ServiceCTPhieuXuatKho();
            GetLstKhoHang();
            GetChiTietSanPhams();
        }
        public string AddKhoHang(KhoHang khoHang)
        {
            if (GetLstKhoHang().Count == 0)
            {
                khoHang.Id = 1;
                khoHang.MaKho = "K" + khoHang.Id;
                khoHang.TrangThai = 0;
                _serviceKhoHang.AddKhoHang(khoHang);
                GetLstKhoHang();
            }
            else
            {
                return "chỉ có 1 kho";

            }

            return "Thành Công";
        }

        public string DeleteKhoHang(KhoHang khoHang)
        {
            khoHang.TrangThai = 1;
            _serviceKhoHang.DeleteKhoHang(khoHang);
            return "Thành Công";
        }

        public string EditKhoHang(KhoHang khoHang)
        {
            _serviceKhoHang.EditKhoHang(khoHang);
            return "Thành Công";
        }

        public List<DVKhoHang> LstDVKhoHangs()
        {
            _lstdVKhoHangs = new List<DVKhoHang>();
            var kp = (from k in GetLstKhoHang()
                      join ctk in GetChiTietKhos() on k.MaKho equals ctk.MaKho
                      join c in GetChiTietSanPhams() on ctk.MaCtsp equals c.MaCtsp
                      select new
                      {
                          ctk.Id,
                          ctk.MaCtkho,
                          k.MaKho,
                          c.MaCtsp,
                          c.TenSp,
                          c.GiaBan,
                          ctk.SoLuong,
                          ctk.TrangThai,
                      }
            );
            foreach (var x in kp)
            {
                DVKhoHang khoHang = new DVKhoHang();
                khoHang.Id = x.Id;
                khoHang.MaKho = x.MaKho;
                khoHang.MaCtsp = x.MaCtsp;
                khoHang.TenSP = x.TenSp;
                khoHang.GiaBan = x.GiaBan;
                khoHang.SoLuong = x.SoLuong;
                khoHang.TrangThai = x.TrangThai;
                khoHang.MaCtkho = x.MaCtkho;
                _lstdVKhoHangs.Add(khoHang);
            }
            return _lstdVKhoHangs;

        }

        public List<KhoHang> GetLstKhoHang()
        {
            return _serviceKhoHang.GetLstKhoHang();
        }

        public int[] SoLuong()
        {
            int[] arrSoLuong = new int[2000 - 0];
            int temp = 0;
            for (int i = 0; i < arrSoLuong.Length; i++)
            {
                arrSoLuong[i] = temp;
                temp++;
            }

            return arrSoLuong;
        }

        public List<ChiTietSanPham> GetChiTietSanPhams()
        {
            return _serviceChiTietSP.GetLstChiTietSP();
        }

        //public List<ChiTietPhieuXuat> GetchiTietHoaDonXuatKhos(string mahd)
        //{
        //    return _serviceHDXuatKho.GetLstHDXK().Where(c => c.MaHd == mahd).ToList();
        //}


        public List<ChiTietKhoHang> GetChiTietKhos()
        {
            return _serviceCTKH.GetLstCTKH();
        }

        public string EditCTKho(ChiTietKhoHang chiTietKhoHang)
        {
            _serviceCTKH.EditHDBan(chiTietKhoHang);
            return "Thành Công";
        }

        public string DeleteCTKh(ChiTietKhoHang chiTietKhoHang)
        {
            chiTietKhoHang.TrangThai = 1;
            _serviceCTKH.DeleteHDBan(chiTietKhoHang);
            return "Thành Công";
        }

        public string AddCTKho(ChiTietKhoHang chiTietKhoHang)
        {
            if (GetChiTietKhos().Count == 0)
            {
                chiTietKhoHang.Id = 1;
            }
            else
            {
                chiTietKhoHang.Id = GetChiTietKhos().Max(c => c.Id) + 1;
            }
            chiTietKhoHang.MaCtkho = "CTK" + chiTietKhoHang.Id;
            if (_serviceKhoHang.GetLstKhoHang().Count == 0)
            {
                KhoHang khoHang = new KhoHang();
                khoHang.Id = 1;
                khoHang.MaKho = "K" + khoHang.Id;
                khoHang.TrangThai = 0;
                _serviceKhoHang.AddKhoHang(khoHang);
                LstDVKhoHangs();
            }
            chiTietKhoHang.MaKho = "K1";
            chiTietKhoHang.TrangThai = 0;
            _serviceCTKH.AddHDBan(chiTietKhoHang);
            LstDVKhoHangs();
            return "Thành Công";
        }
        public bool CheckSo(string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }

        public bool CheckChu(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z]+$");
        }
        public List<DVKhoHang> TimKiemSP(string tensp)
        {
            return _lstdVKhoHangs.Where(c => c.TenSP.StartsWith(tensp)).ToList();
        }

    }
}
