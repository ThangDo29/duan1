using _1_DAL.Context;
using _1_DAL.IService;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Service
{
    public class ServicePhieuNhap : IServicePhieuNhap
    {
        DBContext _DbContext;
        public ServicePhieuNhap()
        {
            _DbContext = new DBContext();
        }
        public string AddHDBan(PhieuNhap phieuNhap)
        {
            _DbContext.PhieuNhaps.Add(phieuNhap);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteHDBan(PhieuNhap phieuNhap)
        {
            _DbContext.PhieuNhaps.Update(phieuNhap);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditHDBan(PhieuNhap phieuNhap)
        {
            _DbContext.PhieuNhaps.Update(phieuNhap);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<PhieuNhap> GetLstPhieuNhap()
        {
            return _DbContext.PhieuNhaps.ToList();
        }
    }
}
