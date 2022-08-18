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
    public class QLCTPhieuNhap : IQLCTPhieuNhap
    {
        IServiceCTPhieuNhap _isvCTPN;
        List<ChiTietPhieuNhap> _lstCTPN;
        IServiceChiTietSP _isvCTSP;
        List<ChiTietSanPham> _lstChiTietSanPhams;
        public QLCTPhieuNhap()
        {
            _isvCTPN = new ServiceCTPhieuNhap();
            _lstCTPN = new List<ChiTietPhieuNhap>();
            _isvCTSP = new ServiceChiTietSP();
            _lstChiTietSanPhams = new List<ChiTietSanPham>();
            GetLstCTPN();
            GetLstCTSP();
            //
        }

        public string AddCTPN(ChiTietPhieuNhap CTPN)
        {
            if (GetLstCTPN().Count == 0)
            {
                CTPN.ID = 0;
            }
            else
            {
                CTPN.ID = GetLstCTPN().Max(c => c.ID) + 1;
            }
            _isvCTPN.AddCTPN(CTPN);
            return "Thêm thành công";
        }

        public string DeleteCTPN(ChiTietPhieuNhap CTPN)
        {
            CTPN.TrangThai = 1;
            _isvCTPN.DeleteCTPN(CTPN);
            return "Xóa thành công";
        }

        public string EditCTPN(ChiTietPhieuNhap CTPN)
        {
            _isvCTPN.EditCTPN(CTPN);
            return "Xóa thành công";
        }

        public List<ChiTietPhieuNhap> GetChiTietPhieuNhaps(string mapn)
        {
            return _isvCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == mapn).ToList();
        }

        public List<ChiTietPhieuNhap> GetLstCTPN()
        {
            _lstCTPN = _isvCTPN.GetLstCTPN();
            return _lstCTPN;
        }

        public List<ChiTietSanPham> GetLstCTSP()
        {
            _lstChiTietSanPhams = _isvCTSP.GetLstChiTietSP();
            return _lstChiTietSanPhams;
        }

        public int[] Soluong()
        {
            int[] arrSoLuong = new int[1001 - 0];
            int temp=0;
            for (int i = 0; i < arrSoLuong.Length; i++)
            {
                arrSoLuong[i] = temp;
                temp++;
            }
            return arrSoLuong;
        }
    }
}
