using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_BUS.IService;
using _2_BUS.Service;
using _1_DAL.Models;

namespace _3_GUI
{
    public partial class FrmThongTinSP : Form
    {
        IServiceQlyHDBan serviceQlyHDBan;
        public FrmThongTinSP(ChiTietSanPham sanPham)
        {
            InitializeComponent();
            serviceQlyHDBan = new ServiceQlyHDBan();
            LoadTT(sanPham);
        }

        void LoadTT(ChiTietSanPham sanPham1)
        {
            System.Globalization.CultureInfo culture2 = new System.Globalization.CultureInfo("en-US");
            decimal value2 = decimal.Parse(sanPham1.GiaBan.ToString(), System.Globalization.NumberStyles.AllowThousands);
            textBox1.Text = String.Format(culture2, "{0:N0}", value2);
            txtTenSP.Text = sanPham1.TenSp;
            txtCL.Text = serviceQlyHDBan.GetlstCL().Where(c => c.MaCl == sanPham1.MaCl).Select(c => c.TenCl).FirstOrDefault().ToString();
            txtMS.Text = serviceQlyHDBan.GetlstMS().Where(c => c.MaMs == sanPham1.MaMs).Select(c => c.TenMs).FirstOrDefault().ToString();
            txtKT.Text = serviceQlyHDBan.GetlstKT().Where(c => c.MaKt == sanPham1.MaKt).Select(c => c.Size).FirstOrDefault().ToString();
            txtGia.Text = textBox1.Text + " VND";
            imgSP.Image = Image.FromFile("D:\\Desktop\\QuanLyBanHang_QuanLyShopGiay\\3_GUI" + sanPham1.Hinhanh);
            txtTHieu.Text = serviceQlyHDBan.GetlstSP().Where(c => c.MaSp == sanPham1.MaSp).Select(c => c.MaSp).FirstOrDefault().ToString();
        }
    }
}
