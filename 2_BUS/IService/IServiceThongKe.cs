using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IServiceThongKe
    {
        public List<ChiTietHoaDonBan> GetlstCTHDBan();
        public List<HoaDon> GetLstHoaDon();
        public List<ChiTietSanPham> GetlstCTSP();
    }
}
