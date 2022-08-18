using _1_DAL.Models;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
  public interface IDangNhapService
    {        
        List<NhanVien> getlstNhanVien();

        List<DangNhap> getlstDangnhap();
        string DoiMatKhau(NhanVien nhanvien);
        NhanVien SenderNhanVien(string mail);
    }
}
