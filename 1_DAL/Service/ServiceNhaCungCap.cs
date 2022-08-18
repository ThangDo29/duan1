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
    public class ServiceNhaCungCap : IServiceNhaCungCap
    {
        DBContext _DbContext;
        public ServiceNhaCungCap()
        {
            _DbContext = new DBContext();
        }
        public string AddNhaCungCap(NhaCungCap nhaCungCap)
        {
            _DbContext.NhaCungCaps.Add(nhaCungCap);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteNhaCungCap(NhaCungCap nhaCungCap)
        {
            _DbContext.NhaCungCaps.Update(nhaCungCap);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditNhaCungCap(NhaCungCap nhaCungCap)
        {
            _DbContext.NhaCungCaps.Update(nhaCungCap);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<NhaCungCap> GetLstNhaCungCap()
        {
            return  _DbContext.NhaCungCaps.ToList();
        }
    }
}
