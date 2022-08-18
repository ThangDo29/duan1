using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.IService;
using System.Threading;

namespace _2_BUS.Service
{
    public class ServiceQlyHDBan : IServiceQlyHDBan
    {
        IServiceHDBan serviceHDBan;
        IServiceChiTietSP serviceCTSP;
        IServiceMauSac serviceMS;
        IServiceChatLieu serviceCL;
        IServiceKichThuoc serviceKT;
        IServiceSanPham serviceSP;
        public ServiceQlyHDBan()
        {
            serviceHDBan = new ServiceHDBan();
            serviceCTSP = new ServiceChiTietSP();
            serviceMS = new ServiceMauSac();
            serviceCL = new ServiceChatLieu();
            serviceKT = new ServiceKichThuoc();
            serviceSP = new ServiceSanPham();
        }
        public ChiTietHoaDonBan AddCTHDBan(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            chiTietHoaDonBan.TrangThai = 1;
            chiTietHoaDonBan.TongTien = chiTietHoaDonBan.SoLuong * chiTietHoaDonBan.GiaBan;
            serviceHDBan.AddHDBan(chiTietHoaDonBan);
            //Thread.Sleep(2000);
            return chiTietHoaDonBan;
        }

        public ChiTietHoaDonBan DeleteCTHDBan(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            chiTietHoaDonBan.TrangThai = 0;
            serviceHDBan.DeleteHDBan(chiTietHoaDonBan);
            return chiTietHoaDonBan;
        }

        public ChiTietHoaDonBan EditCTHDBan(ChiTietHoaDonBan chiTietHoaDonBan)
        {
            serviceHDBan.EditHDBan(chiTietHoaDonBan);
            return chiTietHoaDonBan;
        }

        public List<ChiTietHoaDonBan> GetlstCTHDBan()
        {
            return serviceHDBan.GetLstHDBan();
        }

        public List<ChiTietSanPham> GetlstCTSP()
        {
            return serviceCTSP.GetLstChiTietSP();
        }
        public List<ChatLieu> GetlstCL()
        {
            return serviceCL.GetLstChatLieu();
        }

        public List<KichThuoc> GetlstKT()
        {
            return serviceKT.GetLstKichThuoc();
        }

        public List<MauSac> GetlstMS()
        {
            return serviceMS.GetLstMauSac();
        }

        public List<SanPham> GetlstSP()
        {
            return serviceSP.GetLstSanPham();
        }

        public ChiTietSanPham EditCTSP(ChiTietSanPham chiTietSanPham)
        {
            serviceCTSP.EditChiTietSP(chiTietSanPham);
            return chiTietSanPham;
        }
    }
}
