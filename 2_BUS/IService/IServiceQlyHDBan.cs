using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IServiceQlyHDBan
    {
        public List<ChiTietHoaDonBan> GetlstCTHDBan();
        public List<ChiTietSanPham> GetlstCTSP();
        public List<MauSac> GetlstMS();
        public List<ChatLieu> GetlstCL();
        public List<KichThuoc> GetlstKT();
        public List<SanPham> GetlstSP();
        public ChiTietHoaDonBan AddCTHDBan(ChiTietHoaDonBan chiTietHoaDonBan);
        public ChiTietHoaDonBan EditCTHDBan(ChiTietHoaDonBan chiTietHoaDonBan);
        public ChiTietSanPham EditCTSP(ChiTietSanPham chiTietSanPham);
        public ChiTietHoaDonBan DeleteCTHDBan(ChiTietHoaDonBan chiTietHoaDonBan);
    }
}
