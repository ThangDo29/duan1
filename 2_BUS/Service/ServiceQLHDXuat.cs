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
    public class ServiceQLHDXuat : IServiceQLHDXuat
    {
        private List<ChiTietPhieuXuat> _lstCTPhieuXuat;
        private List<ChiTietSanPham> _lstchiTietSanPhams;
        private IServiceChiTietSP _svCTSP;
        private IServiceCTPhieuXuatKho _serviceCTPhieuXuat;
        private IServicePhieuXuatKho _ServicePhieuXuatKho;
        private List<DSPhieuXuat> _lstdSPhieuXuats;
        private IServiceCTKH _serviceCTKH;
        private IServiceKhoHang _serviceKhoHang;
        private IServiceCTPhieuNhap _serviceCTPhieuNhap;
        public ServiceQLHDXuat()
        {
            _lstCTPhieuXuat = new List<ChiTietPhieuXuat>();
            _lstchiTietSanPhams = new List<ChiTietSanPham>();
            _svCTSP = new ServiceChiTietSP();
            _serviceCTPhieuXuat = new ServiceCTPhieuXuatKho();
            _ServicePhieuXuatKho = new ServicePhieuXuatKho();
            _serviceCTKH = new ServiceCTKH();
            _serviceKhoHang = new ServiceKhoHang();
            _serviceCTPhieuNhap = new ServiceCTPhieuNhap();
        }

        public string AddCTPhieuXuat(ChiTietPhieuXuat CTPX)
        {
            _serviceCTPhieuXuat.AddHDBan(CTPX);
            return "Thành Công";
        }

        public string AddPhieuXuat(PhieuXuatKho PhieuXuat)
        {
            _ServicePhieuXuatKho.AddHDBan(PhieuXuat);
            return "Thành Công";
        }

        public string DeleteCTPhieuXuat(ChiTietPhieuXuat CTPX)
        {
            CTPX.TrangThai = 1;
            _serviceCTPhieuXuat.DeleteHDBan(CTPX);
            return "Thành Công";
        }

        public string DeletePhieuXuat(PhieuXuatKho PhieuXuat)
        {
            PhieuXuat.TrangThai = 1;
            _ServicePhieuXuatKho.DeleteHDBan(PhieuXuat);
            return "Thành Công";
        }

        public string EditCTPhieuXuat(ChiTietPhieuXuat CTPX)
        {
            _serviceCTPhieuXuat.EditHDBan(CTPX);
            GetLstCTPhieuXuat();
            return "Thành Công";
        }

        public string EditPhieuXuat(PhieuXuatKho PhieuXuat)
        {
            _ServicePhieuXuatKho.EditHDBan(PhieuXuat);
            return "Thành Công";
        }

        public List<ChiTietKhoHang> GetChiTietKhoHangs()
        {
            return _serviceCTKH.GetLstCTKH();
        }

        public List<ChiTietPhieuXuat> GetLstCTPhieuXuat()
        {
            return _serviceCTPhieuXuat.GetLstCTPX();
        }
       

        //public string AddHDXuat(ChiTietHoaDonXuatKho CTHDX)
        //{
        //    _svHDXuat.AddHDXK(CTHDX);
        //    return "Them thanh cong";
        //}

        //public string DeleteHDXuat(ChiTietHoaDonXuatKho CTHDX)
        //{
        //    CTHDX.TrangThai = 1;
        //    _svHDXuat.DeleteHDXK(CTHDX);
        //    return "Xoa thanh cong ";
        //}

        //public string EditHDXuat(ChiTietHoaDonXuatKho CTHDX)
        //{
        //    _svHDXuat.EditHDXK(CTHDX);
        //    return "Sua thanh cong ";
        //}

        public List<ChiTietSanPham> GetlstCTSP()
        {
            return _svCTSP.GetLstChiTietSP();
        }

        public List<DSPhieuXuat> GetLSTDSPhieuXuats()
        {
            _lstdSPhieuXuats = new List<DSPhieuXuat>();
            var kp = (from px in GetPhieuXuatKhos() 
                      join  ctpx in GetLstCTPhieuXuat()on px.MaPhieuXuat equals ctpx.MaPhieuXuat
                      join ctk in GetChiTietKhoHangs() on ctpx.MaCtkho equals ctk.MaCtkho
                      join ctsp in GetlstCTSP() on ctk.MaCtsp equals ctsp.MaCtsp
                      select new
                      {
                          px.MaPhieuXuat,
                          ctk.MaCtkho,
                          ctk.MaKho,
                          ctsp.MaCtsp,
                          ctsp.TenSp,
                          ctpx.YeuCau,
                          ctpx.ThucXuat,
                          ctpx.TrangThai,
                          px.NgayTaoPhieu,
                      }
           );
            foreach (var x in kp)
            {
                DSPhieuXuat dSPhieuXuat = new DSPhieuXuat();
                dSPhieuXuat.MaKho = x.MaKho;
                dSPhieuXuat.MaCtkho = x.MaCtkho;
                dSPhieuXuat.MaPhieuXuat = x.MaPhieuXuat;
                dSPhieuXuat.NgayTaoPhieu = x.NgayTaoPhieu;
                dSPhieuXuat.TenSp = x.TenSp;
                dSPhieuXuat.ThucXuat = x.ThucXuat;
                dSPhieuXuat.YeuCau = x.YeuCau;
                dSPhieuXuat.TrangThai = x.TrangThai;
                dSPhieuXuat.MaCtsp = x.MaCtsp;
                _lstdSPhieuXuats.Add(dSPhieuXuat);
            }

            return _lstdSPhieuXuats;
        }

        public List<KhoHang> GetLstKho()
        {
            return _serviceKhoHang.GetLstKhoHang();
        }

        public List<PhieuXuatKho> GetPhieuXuatKhos()
        {
            return _ServicePhieuXuatKho.GetLstPhieuXuat();
        }

        public int[] SoLuong()
        {
            int[] arrSoLuong = new int[100 - 0];
            int temp = 0;
            for (int i = 0; i < arrSoLuong.Length; i++)
            {
                arrSoLuong[i] = temp;
                temp++;
            }

            return arrSoLuong;
        }
        public List<ChiTietPhieuXuat> GetLstCTPhieuXuats(string mapx)
        {
            return _serviceCTPhieuXuat.GetLstCTPX().Where(c => c.MaPhieuXuat == mapx).ToList();
        }
        public bool checkTrungMAKHo(string makho,string mactsp)
        {
            foreach (var x in GetChiTietKhoHangs())
            {
                if (x.MaKho == makho && x.MaCtsp == mactsp)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckSo(string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }





    }
}
