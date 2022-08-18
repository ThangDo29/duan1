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
    public class ServiceTheLoaiSP : IServiceTheLoaiSP
    {
        DBContext _DbContext;
        public ServiceTheLoaiSP()
        {
            _DbContext = new DBContext();
        }
        public string AddTheLoaiSP(TheLoaiSanPham theLoai)
        {
            _DbContext.TheLoaiSanPhams.Add(theLoai);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteTheLoaiSP(TheLoaiSanPham theLoai)
        {
            _DbContext.TheLoaiSanPhams.Update(theLoai);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditTheLoaiSP(TheLoaiSanPham theLoai)
        {
            _DbContext.TheLoaiSanPhams.Update(theLoai);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<TheLoaiSanPham> GetLstTheLoaiSP()
        {
            return _DbContext.TheLoaiSanPhams.ToList();
        }
    }
}
