using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;

namespace _2_BUS.Service
{
    public class ServiceDetailSP : IChiTietSP
    {
        private IServiceMauSac _iServiceMauSac;
        private IServiceKichThuoc _iServiceKichThuoc;
        private IServiceChiTietSP _iServiceChiTietSp;
        private IServiceTheLoaiSP _iServiceTheLoaiSp;
        private IServiceNhaCungCap _iServiceNhaCungCap;
        private IServiceNhaSanXuat _iServiceNhaSanXuat;
        private IServiceSanPham _isServiceSanPham;
        private IServiceChatLieu _iServiceChatLieu;
        private List<MauSac> _lstMauSac;
        private List<KichThuoc> _lstKichThuoc;
        private List<ChiTietSanPham> _lstChiTietSanPham;
        private List<HienThiChiTietSP> _lstHienThiChiTietSP;
        private List<SanPham> _lstSanPham;
        private List<TheLoaiSanPham> _lstTheLoaiSanPham;
        private List<NhaCungCap> _lstNhaCungCap;
        private List<NhaSanXuat> _lstNhaSanXuat;
        private List<ChatLieu> _lstChatLieu;
        public ServiceDetailSP()
        {
            _iServiceMauSac = new ServiceMauSac();
            _iServiceKichThuoc = new ServiceKichThuoc();
            _iServiceChiTietSp = new ServiceChiTietSP();
            _iServiceNhaCungCap = new ServiceNhaCungCap();
            _iServiceNhaSanXuat = new ServiceNhaSanXuat();
            _iServiceTheLoaiSp = new ServiceTheLoaiSP();
            _iServiceChatLieu = new ServiceChatLieu();
            _isServiceSanPham = new ServiceSanPham();

            _lstNhaCungCap = new List<NhaCungCap>();
            _lstNhaSanXuat = new List<NhaSanXuat>();
            _lstTheLoaiSanPham = new List<TheLoaiSanPham>();
            _lstChiTietSanPham = new List<ChiTietSanPham>();
            _lstKichThuoc = new List<KichThuoc>();
            _lstMauSac = new List<MauSac>();
            _lstSanPham = new List<SanPham>();
            _lstChatLieu = new List<ChatLieu>();





        }
        public List<MauSac> GetLstMauSac()
        {
            return _lstMauSac = _iServiceMauSac.GetLstMauSac();
        }

        public List<KichThuoc> GetLstKichThuoc()
        {
            return _lstKichThuoc = _iServiceKichThuoc.GetLstKichThuoc();
        }

        public List<ChiTietSanPham> GetLstChiTietSP()
        {
            return _lstChiTietSanPham = _iServiceChiTietSp.GetLstChiTietSP();
        }

        public List<TheLoaiSanPham> GetLstTheLoaiSP()
        {
            return _lstTheLoaiSanPham = _iServiceTheLoaiSp.GetLstTheLoaiSP();
        }

        public List<NhaCungCap> GetLstNhaCungCap()
        {
            return _lstNhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
        }

        public List<NhaSanXuat> GetLstNhaSanXuat()
        {
            return _lstNhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
        }

        public List<ChatLieu> GetLstChatLieu()
        {
            return _lstChatLieu = _iServiceChatLieu.GetLstChatLieu();
        }

        public List<HienThiChiTietSP> getLstHienThiChiTietSP()
        {
            getLstSanPham();
            GetLstKichThuoc();
            GetLstTheLoaiSP();
            GetLstChatLieu();
            GetLstChiTietSP();
            GetLstMauSac();
            GetLstNhaCungCap();
            GetLstNhaSanXuat();
            _lstHienThiChiTietSP = new List<HienThiChiTietSP>();
            var hienThi = from ct in _lstChiTietSanPham
                          join sp in _lstSanPham on ct.MaSp equals sp.MaSp
                          join tl in _lstTheLoaiSanPham on sp.MaTl equals tl.MaTl
                          join ms in _lstMauSac on ct.MaMs equals ms.MaMs
                          join kt in _lstKichThuoc on ct.MaKt equals kt.MaKt
                          join cl in _lstChatLieu on ct.MaCl equals cl.MaCl
                          join ncc in _lstNhaCungCap on sp.MaNcc equals ncc.MaNcc
                          join nsx in _lstNhaSanXuat on sp.MaNsx equals nsx.MaNsx 
                          select new
                          {
                              ct.MaCtsp,
                              tl.TenTl,
                              sp.MaSp,
                              sp.TenThuongHieu,
                              ct.TenSp,
                              ms.TenMs,
                              kt.Size,
                              cl.TenCl,
                              ct.SoLuong,
                              ct.GiaBan,
                              ncc.TenNcc,
                              nsx.TenNsx,
                              ct.BarCode,
                              ct.Hinhanh,
                              ct.TrangThai
                          };
            foreach (var x in hienThi)
            {
                HienThiChiTietSP dsChiTiet = new HienThiChiTietSP();
                dsChiTiet.TenThuongHieu = x.TenThuongHieu;
                dsChiTiet.TenGiay = x.TenSp;
                dsChiTiet.TenTheLoai = x.TenTl;
                dsChiTiet.TenChiTietSP = x.TenTl +" "+ x.TenThuongHieu +" "+ x.TenSp;
                dsChiTiet.MaCTSP = x.MaCtsp;
                dsChiTiet.TenNCC = x.TenNcc;
                dsChiTiet.TenNSX = x.TenNsx;
                dsChiTiet.MaSP = x.MaSp;
                dsChiTiet.Status = x.TrangThai;
                dsChiTiet.TenMau = x.TenMs;
                dsChiTiet.KichThuoc = x.Size;
                dsChiTiet.ChatLieu = x.TenCl;
                dsChiTiet.GiaBan = x.GiaBan;
                dsChiTiet.Barcode = x.BarCode;
                dsChiTiet.HinhAnh = x.Hinhanh;
                dsChiTiet.SoLuong = x.SoLuong;
                dsChiTiet.ID = _lstHienThiChiTietSP.Count + 1;
                _lstHienThiChiTietSP.Add(dsChiTiet);

            }
            return _lstHienThiChiTietSP;
        }

        public List<SanPham> getLstSanPham()
        {
            return _lstSanPham = _isServiceSanPham.GetLstSanPham();
        }

        public string Them(ChiTietSanPham chiTietSanPham)
        {
            _iServiceChiTietSp.AddChiTietSP(chiTietSanPham);
            return "Thêm Thành Công";
        }

        public string Sua(ChiTietSanPham chiTietSanPham)
        {
            _iServiceChiTietSp.EditChiTietSP(chiTietSanPham);
            return "Sửa Thành Công";
        }

        public string Xoa(ChiTietSanPham chiTietSanPham)
        {
            chiTietSanPham.TrangThai = 0;
            _iServiceChiTietSp.DeleteChiTietSP(chiTietSanPham);
            return "Xóa Thành Công";
        }

    }
}
