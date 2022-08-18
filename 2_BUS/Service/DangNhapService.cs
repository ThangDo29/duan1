using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using _2_BUS.Untilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
   public class DangNhapService : IDangNhapService
    {
        List<DangNhap> _lstdangNhaps;
        List<NhanVien> _lstnhanViens;
        IServiceNhanVien _nhanVienService;
        ChucNangHeThong _cn;
        public DangNhapService()
        {
            _lstdangNhaps = new List<DangNhap>();
            _lstnhanViens = new List<NhanVien>();
            _nhanVienService = new ServiceNhanVien();
            _cn = new ChucNangHeThong();
            getlstNhanVien();
            getlstDangnhap();
        }
        public string DoiMatKhau(NhanVien nhanvien)
        {
            var result = _nhanVienService.EditNhanVien(nhanvien);
            return result;
        }

        public List<DangNhap> getlstDangnhap()
        {
            foreach (var x in _lstnhanViens)
            {
                DangNhap dangNhap = new DangNhap();
                dangNhap.taikhoan = x.TaiKhoan;
                dangNhap.matkhau = x.MatKhau;
                dangNhap.ttdangnhap = x.TrangThai;
                _lstdangNhaps.Add(dangNhap);
            }
            return _lstdangNhaps;
        }

        public List<NhanVien> getlstNhanVien()
        {
            return _lstnhanViens = _nhanVienService.GetLstNhanVien();
        }

        public NhanVien SenderNhanVien(string mail)
        {
            var xs = _nhanVienService.GetLstNhanVien().Where(c => c.TaiKhoan == mail).FirstOrDefault();
            return xs;
        }
    }
}
