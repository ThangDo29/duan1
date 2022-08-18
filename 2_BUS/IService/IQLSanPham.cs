using _1_DAL.Models;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IQLSanPham
    {
        public List<SanPham> GetLstSanPhams();
        public List<NhaCungCap> GetLstNhaCungCap();
        public List<NhaSanXuat> GetLstNhaSanXuat();
        public List<TheLoaiSanPham> GetLstTheLoaiSanPham();
        SanPham Insert(SanPham sanPham);
        SanPham Update(SanPham sanPham);
        SanPham Delete(SanPham sanPham);
    }
}
