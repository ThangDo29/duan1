using _1_DAL.IService;
using _1_DAL.Context;
using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Service
{
    public class ServiceChiTietSP : IServiceChiTietSP
    {
        DBContext _DbContext;
        public ServiceChiTietSP()
        {
            _DbContext = new DBContext();
        }
        public string AddChiTietSP(ChiTietSanPham CTSP)
        {
            _DbContext.ChiTietSanPhams.Add(CTSP);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteChiTietSP(ChiTietSanPham CTSP)
        {
            _DbContext.ChiTietSanPhams.Update(CTSP);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditChiTietSP(ChiTietSanPham CTSP)
        {
            _DbContext.ChiTietSanPhams.Update(CTSP);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<ChiTietSanPham> GetLstChiTietSP()
        {
            return _DbContext.ChiTietSanPhams.ToList();
        }
    }
}
