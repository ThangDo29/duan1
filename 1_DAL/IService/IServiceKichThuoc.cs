using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceKichThuoc
    {
        public List<KichThuoc> GetLstKichThuoc();//Lấy dữ liệu bảng KichThuoc
        public string EditKichThuoc(KichThuoc kichThuoc);//Sửa dữ liệu bảng KichThuoc
        public string DeleteKichThuoc(KichThuoc kichThuoc);//Xóa dữ liệu bảng KichThuoc
        public string AddKichThuoc(KichThuoc kichThuoc);//Thêm dữ liệu  bảng KichThuoc
    }
}
