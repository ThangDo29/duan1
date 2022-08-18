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
    public class ServiceNhanVien : IServiceNhanVien
    {
        DBContext _DbContext;
        public ServiceNhanVien()
        {
            _DbContext = new DBContext();
        }
        public string AddNhanVien(NhanVien nhanVien)
        {
            _DbContext.NhanViens.Add(nhanVien);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteNhanVien(NhanVien nhanVien)
        {
            _DbContext.NhanViens.Update(nhanVien);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditNhanVien(NhanVien nhanVien)
        {
            _DbContext.NhanViens.Update(nhanVien);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<NhanVien> GetLstNhanVien()
        {
            return _DbContext.NhanViens.ToList();
        }
    }
}
