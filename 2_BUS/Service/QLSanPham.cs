using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class QLSanPham : IQLSanPham
    {
        IServiceSanPham _iServiceSanPham;
        IServiceNhaCungCap _iServiceNhaCungCap;
        IServiceNhaSanXuat _iServiceNhaSanXuat;
        IServiceTheLoaiSP _iServiceTheLoaiSp;
        List<SanPham> _lstSanPham;
        List<NhaCungCap> _lstnhaCungCap;
        List<NhaSanXuat> _lstnhaSanXuat;
        List<TheLoaiSanPham> _lstTheLoaiSanPham;
        //List<HienThiSanPham> _lstHienThiSanPham;
        public QLSanPham()
        {
            _iServiceSanPham = new ServiceSanPham();
            _iServiceNhaCungCap = new ServiceNhaCungCap();
            _iServiceNhaSanXuat = new ServiceNhaSanXuat();
            _iServiceTheLoaiSp = new ServiceTheLoaiSP();
            _lstSanPham = new List<SanPham>();
            _lstnhaCungCap = new List<NhaCungCap>();
            _lstnhaSanXuat = new List<NhaSanXuat>();
            _lstTheLoaiSanPham = new List<TheLoaiSanPham>();
            //_lstHienThiSanPham = new List<HienThiSanPham>();
        }
        public SanPham Delete(SanPham sanPham)
        {
            sanPham.TrangThai = 0;
            _iServiceSanPham.DeleteSanPham(sanPham);
            return sanPham;
        }

        public List<NhaCungCap> GetLstNhaCungCap()
        {
            return _lstnhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
        }

        public List<NhaSanXuat> GetLstNhaSanXuat()
        {
            return _lstnhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
        }

        public List<TheLoaiSanPham> GetLstTheLoaiSanPham()
        {
            return _lstTheLoaiSanPham = _iServiceTheLoaiSp.GetLstTheLoaiSP();
        }

        public List<SanPham> GetLstSanPhams()
        {
            return _lstSanPham = _iServiceSanPham.GetLstSanPham();
        }


        public SanPham Insert(SanPham sanPham)
        {
            _iServiceSanPham.AddSanPham(sanPham);
            return sanPham;
        }


        public SanPham Update(SanPham sanPham)
        {
            _iServiceSanPham.EditSanPham(sanPham);
            return sanPham;
        }
    }
}
