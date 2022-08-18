using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceChucVu
    {
        public List<ChucVu> GetLstChucVu();//Lấy dữ liệu bảng chức vụ
        public string EditChucVu(ChucVu chucVu);//Sửa dữ liệu bảng chức vụ
        public string DeleteChucVu(ChucVu chucVu);//Xóa dữ liệu bảng chức vụ 
        public string AddChucVu(ChucVu chucVu);//Thêm dữ liệu  bảng chức vụ
    }
}
