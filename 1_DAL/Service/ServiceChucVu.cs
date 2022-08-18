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
    public class ServiceChucVu : IServiceChucVu
    {
        DBContext _DbContext;
        public ServiceChucVu()
        {
            _DbContext = new DBContext();
        }
        public string AddChucVu(ChucVu chucVu)
        {
            _DbContext.ChucVus.Add(chucVu);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteChucVu(ChucVu chucVu)
        {
            _DbContext.ChucVus.Update(chucVu);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditChucVu(ChucVu chucVu)
        {
            _DbContext.ChucVus.Update(chucVu);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<ChucVu> GetLstChucVu()
        {
            return _DbContext.ChucVus.ToList();
        }
    }
}
