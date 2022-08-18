using _1_DAL.IService;
using _1_DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_DAL.Models;

namespace _1_DAL.Service
{
    public class ServiceMauSac : IServiceMauSac
    {
        DBContext _DbContext;
        public ServiceMauSac()
        {
            _DbContext = new DBContext();
        }
        public string AddMauSac(MauSac mauSac)
        {
            _DbContext.MauSacs.Add(mauSac);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteMauSac(MauSac mauSac)
        {
            _DbContext.MauSacs.Update(mauSac);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditMauSac(MauSac mauSac)
        {
            _DbContext.MauSacs.Update(mauSac);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<MauSac> GetLstMauSac()
        {
            return _DbContext.MauSacs.ToList();
        }
    }
}
