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
    public class ServiceCTPhieuNhap : IServiceCTPhieuNhap
    {
        DBContext _DbContext;
        public ServiceCTPhieuNhap()
        {
            _DbContext = new DBContext();
        }

        public string AddCTPN(ChiTietPhieuNhap CTPN)
        {
            _DbContext.ChiTietPhieuNhaps.Add(CTPN);
            _DbContext.SaveChanges();
            return "Thành công"; ;
        }

        public string DeleteCTPN(ChiTietPhieuNhap CTPN)
        {
            _DbContext.ChiTietPhieuNhaps.Update(CTPN);
            _DbContext.SaveChanges();
            return "Thành công"; ;
        }

        public string EditCTPN(ChiTietPhieuNhap CTPN)
        {
            _DbContext.ChiTietPhieuNhaps.Update(CTPN);
            _DbContext.SaveChanges();
            return "Thành công"; ;
        }

        public List<ChiTietPhieuNhap> GetLstCTPN()
        {
            return _DbContext.ChiTietPhieuNhaps.ToList();
        }
    }
}
