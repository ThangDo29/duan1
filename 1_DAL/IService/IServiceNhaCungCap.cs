using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceNhaCungCap
    {
        public List<NhaCungCap> GetLstNhaCungCap();//Lấy dữ liệu bảng NhaCungCap
        public string EditNhaCungCap(NhaCungCap nhaCungCap);//Sửa dữ liệu bảng NhaCungCap
        public string DeleteNhaCungCap(NhaCungCap nhaCungCap);//Xóa dữ liệu bảng NhaCungCap 
        public string AddNhaCungCap(NhaCungCap nhaCungCap);//Thêm dữ liệu  bảng NhaCungCap
    }
}
