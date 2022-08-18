using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IServiceHD
    {
        public List<HoaDon> GetLstHoaDon();
        public HoaDon AddHoaDon(HoaDon hoaDon);
        public HoaDon EditHoaDonw(HoaDon hoaDon);
        public HoaDon DeleteHoaDon(HoaDon hoaDon);
    }
}
