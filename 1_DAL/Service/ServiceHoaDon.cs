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
    public class ServiceHoaDon : IServiceHoaDon
    {
        DBContext _DbContext;
        public ServiceHoaDon()
        {
            _DbContext = new DBContext();
        }
        public string AddHoaDon(HoaDon hoaDon)
        {
            _DbContext.HoaDons.Add(hoaDon);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteHoaDon(HoaDon hoaDon)
        {
            _DbContext.HoaDons.Update(hoaDon);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditHoaDon(HoaDon hoaDon)
        {
            _DbContext.HoaDons.Update(hoaDon);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<HoaDon> GetLstHoaDon()
        {
            return _DbContext.HoaDons.ToList();
        }
    }
}
