using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IService
{
    public interface IServiceMauSac
    {
        public List<MauSac> GetLstMauSac();//Lấy dữ liệu bảng MauSac
        public string EditMauSac(MauSac mauSac);//Sửa dữ liệu bảng MauSac
        public string DeleteMauSac(MauSac mauSac);//Xóa dữ liệu bảng MauSac
        public string AddMauSac(MauSac mauSac);//Thêm dữ liệu  bảng MauSac
    }
}
