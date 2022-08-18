using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceHoaDon
    {
        public List<HoaDon> GetLstHoaDon();//Lấy dữ liệu bảng HoaDon
        public string EditHoaDon(HoaDon hoaDon);//Sửa dữ liệu bảng HoaDon
        public string DeleteHoaDon(HoaDon hoaDon);//Xóa dữ liệu bảng HoaDon
        public string AddHoaDon(HoaDon hoaDon);//Thêm dữ liệu  bảng HoaDon
        
    }
}
