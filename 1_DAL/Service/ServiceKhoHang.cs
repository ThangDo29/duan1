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
    public class ServiceKhoHang : IServiceKhoHang
    {
        DBContext _DbContext;
        private List<KhoHang> _lstkhoHangs;
        public ServiceKhoHang()
        {
            _DbContext = new DBContext();
            _lstkhoHangs = new List<KhoHang>();
            GetlstDB();

        }
        public string AddKhoHang(KhoHang khoHang)
        {
            _DbContext.KhoHangs.Add(khoHang);
            _DbContext.SaveChanges();
            GetlstDB();
            return "Thành công";
        }

        public string DeleteKhoHang(KhoHang khoHang)
        {
            _DbContext.KhoHangs.Update(khoHang);
            _DbContext.SaveChanges();
            GetlstDB();
            return "Thành công";
        }

        public string EditKhoHang(KhoHang khoHang)
        {
            _DbContext.KhoHangs.Update(khoHang);
            _DbContext.SaveChanges();
            GetlstDB();
            return "Thành công";
        }

        public void GetlstDB()
        {
           _lstkhoHangs = _DbContext.KhoHangs.ToList();
        }

        public List<KhoHang> GetLstKhoHang()
        {
            return _lstkhoHangs;
        }
    }
}
