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
    public class ServicePhieuXuatKho : IServicePhieuXuatKho
    {
        DBContext _DbContext;
        public ServicePhieuXuatKho()
        {
            _DbContext = new DBContext();
        }

        public string AddHDBan(PhieuXuatKho phieuXuat)
        {
            _DbContext.PhieuXuatKhos.Add(phieuXuat);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteHDBan(PhieuXuatKho phieuXuat)
        {
            _DbContext.PhieuXuatKhos.Update(phieuXuat);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditHDBan(PhieuXuatKho phieuXuat)
        {
            _DbContext.PhieuXuatKhos.Update(phieuXuat);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<PhieuXuatKho> GetLstPhieuXuat()
        {
            return _DbContext.PhieuXuatKhos.ToList();
        }
    }
}
