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
    public class ServiceSanPham : IServiceSanPham
    {
        DBContext _DbContext;
        public ServiceSanPham()
        {
            _DbContext = new DBContext();
        }

        public string AddSanPham(SanPham sanPham)
        {
            _DbContext.SanPhams.Add(sanPham);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteSanPham(SanPham sanPham)
        {
            _DbContext.SanPhams.Update(sanPham);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditSanPham(SanPham sanPham)
        {
            _DbContext.SanPhams.Update(sanPham);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<SanPham> GetLstSanPham()
        {
            return _DbContext.SanPhams.ToList();
        }
    }
}
