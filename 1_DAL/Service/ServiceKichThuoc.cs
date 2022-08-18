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
    public class ServiceKichThuoc : IServiceKichThuoc
    {
        DBContext _DbContext;
        public ServiceKichThuoc()
        {
            _DbContext = new DBContext();
        }
        public string AddKichThuoc(KichThuoc kichThuoc)
        {
            _DbContext.KichThuocs.Add(kichThuoc);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteKichThuoc(KichThuoc kichThuoc)
        {
            _DbContext.KichThuocs.Update(kichThuoc);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditKichThuoc(KichThuoc kichThuoc)
        {
            _DbContext.KichThuocs.Update(kichThuoc);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<KichThuoc> GetLstKichThuoc()
        {
            return _DbContext.KichThuocs.ToList();
        }
    }
}
