using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class PhieuNhapService : IPhieuNhapService
    {
        IServicePhieuNhap _isvPhieuNhap;
        List<PhieuNhap> _lstPhieuNhap;
        public PhieuNhapService()
        {
            _isvPhieuNhap = new ServicePhieuNhap();
            _lstPhieuNhap = new List<PhieuNhap>();
            GetLstPhieuNhap();
        }
        public string AddPhieuNhap(PhieuNhap phieuNhap)
        {
            if (GetLstPhieuNhap().Count ==0)
            {
                phieuNhap.Id = 0;
            }
            else
            {
                phieuNhap.Id = GetLstPhieuNhap().Max(c => c.Id) + 1;
            }
            phieuNhap.MaPhieuNhap = "PN" + phieuNhap.Id;
            phieuNhap.NgayTaoPhieu = DateTime.Now;
            phieuNhap.TrangThai = 4;
            phieuNhap.MaKho = "K1";
            _isvPhieuNhap.AddHDBan(phieuNhap);
            return "Thêm thành công";
        }

        public string DeletePhieuNhap(PhieuNhap phieuNhap)
        {
            phieuNhap.TrangThai = 0;
            _isvPhieuNhap.DeleteHDBan(phieuNhap);
            return "Xóa thành công";

        }

        public string EditPhieuNhap(PhieuNhap phieuNhap)
        {
            _isvPhieuNhap.DeleteHDBan(phieuNhap);
            return "Sửa thành công";
        }

        public List<PhieuNhap> GetLstPhieuNhap()
        {
            _lstPhieuNhap = _isvPhieuNhap.GetLstPhieuNhap();
            return _lstPhieuNhap;
        }
    }
}
