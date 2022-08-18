using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceCTPhieuXuatKho
    {
        public List<ChiTietPhieuXuat> GetLstCTPX();//Lấy dữ liệu bảng ChiTietPhieuXuat
        public string EditHDBan(ChiTietPhieuXuat CTPX);//Sửa dữ liệu bảng ChiTietPhieuXuat
        public string DeleteHDBan(ChiTietPhieuXuat CTPX);//Xóa dữ liệu bảng ChiTietPhieuXuat 
        public string AddHDBan(ChiTietPhieuXuat CTPX);//Thêm dữ liệu  bảng ChiTietPhieuXuat
    }
}
