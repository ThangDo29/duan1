using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Models;
using _2_BUS.Models;

namespace _2_BUS.IService
{
    public interface IChiTietSP
    {
        List<MauSac> GetLstMauSac();
        List<KichThuoc> GetLstKichThuoc();
        List<ChiTietSanPham> GetLstChiTietSP();
        List<TheLoaiSanPham> GetLstTheLoaiSP();
        List<NhaCungCap> GetLstNhaCungCap();
        List<NhaSanXuat> GetLstNhaSanXuat();
        List<ChatLieu> GetLstChatLieu();
        List<HienThiChiTietSP> getLstHienThiChiTietSP();
        List<SanPham> getLstSanPham();
        string Them(ChiTietSanPham chiTietSanPham);
        string Sua(ChiTietSanPham chiTietSanPham);
        string Xoa(ChiTietSanPham chiTietSanPham);
        
    }
}
