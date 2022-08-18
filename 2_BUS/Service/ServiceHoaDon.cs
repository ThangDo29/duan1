using _1_DAL.Models;
using _1_DAL.IService;
using _2_BUS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Service;

namespace _2_BUS.Service
{
    public class ServiceHD : IServiceHD
    {
        IServiceHoaDon serviceHoaDon;
        List<HoaDon> lstHoaDon;
        public ServiceHD()
        {
            serviceHoaDon = new ServiceHoaDon();
            GetLstHoaDon();
        }
        public HoaDon AddHoaDon(HoaDon hoaDon)
        {
            if (GetLstHoaDon().Count == 0)
            {
                hoaDon.Id = 1;
            }
            else
            {
                hoaDon.Id = Convert.ToInt32(lstHoaDon.Max(c => c.Id) + 1);
            }
            hoaDon.MaHd = "HD" + hoaDon.Id.ToString();
            hoaDon.ThanhToan = false;
            hoaDon.NgayLapHD = DateTime.Now;
            hoaDon.TrangThai = 1;
            serviceHoaDon.AddHoaDon(hoaDon);
            return hoaDon;
        }

        public HoaDon DeleteHoaDon(HoaDon hoaDon)
        {
            hoaDon.TrangThai = 0;
            serviceHoaDon.DeleteHoaDon(hoaDon);
            return hoaDon;
        }

        public HoaDon EditHoaDonw(HoaDon hoaDon)
        {
            serviceHoaDon.EditHoaDon(hoaDon);
            return hoaDon;
        }

        public List<HoaDon> GetLstHoaDon()
        {
            lstHoaDon = serviceHoaDon.GetLstHoaDon();
            return lstHoaDon;
        }
    }
}
