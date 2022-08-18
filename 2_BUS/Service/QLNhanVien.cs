using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class QLNhanVien : IQLNhanVien
    {
        List<NhanVien> GetNhanViens;
        List<ChucVu> GetChucVus;
        List<DSNV> DSNhanViens;
        IServiceNhanVien serviceNhanVien;
        public QLNhanVien()
        {
            GetNhanViens = new List<NhanVien>();
            GetChucVus = new List<ChucVu>();
            DSNhanViens = new List<DSNV>();
            serviceNhanVien = new ServiceNhanVien();
            GetTblNhanVien();
        }
        public string Add(NhanVien nhanVien)
        {
            if (serviceNhanVien.GetLstNhanVien().Count != 0 )
            {

                nhanVien.Id = GetTblNhanVien().Max(c => c.Id) + 1;
                nhanVien.MaNv = "NV" + nhanVien.Id;
                nhanVien.TrangThai = 0;
                serviceNhanVien.AddNhanVien(nhanVien);
            }
            else
            {
                nhanVien.Id = 1;
                nhanVien.MaNv = "NV" + nhanVien.Id;
                nhanVien.TrangThai = 0;
                serviceNhanVien.AddNhanVien(nhanVien);
            }
            GetTblNhanVien();
            return "Thêm thành công";
        }

        public string Delete(NhanVien nhanVien)
        {
            nhanVien.TrangThai = 1;
            serviceNhanVien.DeleteNhanVien(nhanVien);
            GetTblNhanVien();
            return "Xóa thành công";
        }

        public List<NhanVien> GetTblNhanVien()
        {
            return GetNhanViens = serviceNhanVien.GetLstNhanVien();
        }

        public List<DSNV> lstNhanVien()
        {
            GetTblNhanVien();
            DSNhanViens = new List<DSNV>();
            var kq = GetNhanViens.Join(GetChucVus, a => a.MaCv, b => b.MaCv, (a, b) => {
                return new
                {
                    ID = a.Id,
                    MaNV = a.MaNv,
                    TenNV = a.TenNv,
                    GioiTinh = a.GioiTinh,
                    CCCD = a.Cccd,
                    MaCV = b.MaCv,
                    NamSinh = a.NamSinh,
                    TaiKhoan = a.TaiKhoan,
                    MatKhau = a.MatKhau,
                    TrangThai = a.TrangThai,
                };
            });
            foreach (var x in GetTblNhanVien())
            {
                DSNV dSNV = new DSNV();
                dSNV.ID = Convert.ToInt32(x.Id);
                dSNV.MaNv = x.MaNv;
                dSNV.TenNv = x.TenNv;
                dSNV.GioiTinh = x.GioiTinh;
                dSNV.Cccd = x.Cccd;
                dSNV.MaCv = Convert.ToInt32(x.MaCv);
                dSNV.NamSinh = x.NamSinh;
                dSNV.TaiKhoan = x.TaiKhoan;
                dSNV.MatKhau = x.MatKhau;
                dSNV.TrangThai = x.TrangThai;
            }
            return DSNhanViens;
        }

        public int[] NamSinh()
        {
            int[] arrYears = new int[2021 - 1900];
            int temp = 1900;
            for (int i = 0; i < arrYears.Length; i++)
            {
                arrYears[i] = temp;
                temp++;
            }

            return arrYears;
        }

        public string Update(NhanVien nhanVien)
        {
            serviceNhanVien.EditNhanVien(nhanVien);
            GetTblNhanVien();
            return "Sửa thành công"; 
        }
    }
}
