using _1_DAL.Models;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IQLNhanVien
    {
        List<DSNV> lstNhanVien();
        public List<NhanVien> GetTblNhanVien();
        string Add(NhanVien nhanVien);
        string Update(NhanVien nhanVien);
        string Delete(NhanVien nhanVien);
        int[] NamSinh();
    }
}
