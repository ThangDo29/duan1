using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class ServiceThongKe : IServiceThongKe
    {
        IServiceHoaDon serviceHoaDon; 
        IServiceChiTietSP serviceChiTietSP; 
        IServiceHDBan serviceHDBan; 
        public ServiceThongKe()
        {
            serviceHDBan = new ServiceHDBan();
            serviceChiTietSP = new ServiceChiTietSP();
            serviceHoaDon = new ServiceHoaDon();
        }

        public List<ChiTietHoaDonBan> GetlstCTHDBan()
        {
            return serviceHDBan.GetLstHDBan();
        }

        public List<ChiTietSanPham> GetlstCTSP()
        {
            return serviceChiTietSP.GetLstChiTietSP();
        }

        public List<HoaDon> GetLstHoaDon()
        {
            return serviceHoaDon.GetLstHoaDon();
        }
    }
}
