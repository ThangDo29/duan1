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
    public class ServiceNhaSanXuat : IServiceNhaSanXuat
    {
        DBContext _DbContext;
        public ServiceNhaSanXuat()
        {
            _DbContext = new DBContext();
        }
        public string AddNhaSanXuat(NhaSanXuat nhaSanXuat)
        {
            _DbContext.NhaSanXuats.Add(nhaSanXuat);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteNhaSanXuat(NhaSanXuat nhaSanXuat)
        {
            _DbContext.NhaSanXuats.Update(nhaSanXuat);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditNhaSanXuat(NhaSanXuat nhaSanXuat)
        {
            _DbContext.NhaSanXuats.Update(nhaSanXuat);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<NhaSanXuat> GetLstNhaSanXuat()
        {
            return _DbContext.NhaSanXuats.ToList();
        }
    }
}
