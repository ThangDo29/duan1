using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Service
{
    public class ServiceHDBan : IServiceHDBan
    {
        DBContext _DbContext;
        public ServiceHDBan()
        {
            _DbContext = new DBContext();
        }
        public string AddHDBan(ChiTietHoaDonBan CTHDB)
        {
            _DbContext.ChiTietHoaDonBans.Add(CTHDB);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteHDBan(ChiTietHoaDonBan CTHDB)
        {
            _DbContext.ChiTietHoaDonBans.Update(CTHDB);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditHDBan(ChiTietHoaDonBan CTHDB)
        {
            _DbContext.ChiTietHoaDonBans.Update(CTHDB);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<ChiTietHoaDonBan> GetLstHDBan()
        {
            return _DbContext.ChiTietHoaDonBans.ToList();
        }
    }
}
