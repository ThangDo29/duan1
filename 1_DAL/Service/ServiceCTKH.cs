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
    public class ServiceCTKH : IServiceCTKH
    {
        DBContext _DbContext;
        public ServiceCTKH()
        {
            _DbContext = new DBContext();
        }

        public string AddHDBan(ChiTietKhoHang CTKH)
        {
            _DbContext.ChiTietKhoHangs.Add(CTKH);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string DeleteHDBan(ChiTietKhoHang CTKH)
        {
            _DbContext.ChiTietKhoHangs.Update(CTKH);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public string EditHDBan(ChiTietKhoHang CTKH)
        {
            _DbContext.ChiTietKhoHangs.Update(CTKH);
            _DbContext.SaveChanges();
            return "Thành công";
        }

        public List<ChiTietKhoHang> GetLstCTKH()
        {
            return _DbContext.ChiTietKhoHangs.ToList();
        }
    }
}
