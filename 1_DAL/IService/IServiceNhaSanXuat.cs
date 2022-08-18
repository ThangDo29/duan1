using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceNhaSanXuat
    {
        public List<NhaSanXuat> GetLstNhaSanXuat();//Lấy dữ liệu bảng NhaSanXuat
        public string EditNhaSanXuat(NhaSanXuat nhaSanXuat);//Sửa dữ liệu bảng NhaSanXuat
        public string DeleteNhaSanXuat(NhaSanXuat nhaSanXuat);//Xóa dữ liệu bảng NhaSanXuat
        public string AddNhaSanXuat(NhaSanXuat nhaSanXuat);//Thêm dữ liệu  bảng NhaSanXuat
    }
}
