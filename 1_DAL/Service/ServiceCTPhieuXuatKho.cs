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
    public class ServiceCTPhieuXuatKho : IServiceCTPhieuXuatKho
    {
        DBContext _DbContext;
        public ServiceCTPhieuXuatKho()
        {
            _DbContext = new DBContext();
        }

        public string AddHDBan(ChiTietPhieuXuat CTPX)
        {
            _DbContext.ChiTietPhieuXuats.Add(CTPX);
            _DbContext.SaveChanges();
            return "Thành công"; ;
        }

        public string DeleteHDBan(ChiTietPhieuXuat CTPX)
        {
            _DbContext.ChiTietPhieuXuats.Update(CTPX);
            _DbContext.SaveChanges();
            return "Thành công"; ;
        }

        public string EditHDBan(ChiTietPhieuXuat CTPX)
        {
            _DbContext.ChiTietPhieuXuats.Update(CTPX);
            _DbContext.SaveChanges();
            return "Thành công"; ;
        }

        public List<ChiTietPhieuXuat> GetLstCTPX()
        {
            return _DbContext.ChiTietPhieuXuats.ToList();
        }
    }
}
