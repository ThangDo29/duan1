using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class FrmThongKe : Form
    {
        IServiceThongKe serviceThongKe;
        public FrmThongKe()
        {
            InitializeComponent();
            serviceThongKe = new ServiceThongKe();
            pictureBox1.Image = Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\Resources\\15.jpg");
            pictureBox2.Image = Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\Resources\\16.png");
            LoadThongKe(serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date == DateTime.Now.Date && c.ThanhToan == true).ToList());
            LoadTKTheoNgay();
        }
        void LoadThongKe(List<HoaDon> hoaDons)
        {
            double doanhThu = 0;
            int soHDTT = 0;
            int soHDGH = 0;
            foreach (var x in hoaDons)
            {
                if (x.LoaiHd == 1)
                {
                    soHDGH += 1;
                }
                else if(x.LoaiHd == 0)
                {
                    soHDTT += 1;
                }
                foreach (var y in serviceThongKe.GetlstCTHDBan().Where(c => c.Mahd == x.MaHd && c.TrangThai == 0 || c.Mahd == x.MaHd && c.TrangThai == 1))
                {
                    doanhThu += y.TongTien;

                }
            }
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            decimal value = decimal.Parse(doanhThu.ToString(), System.Globalization.NumberStyles.AllowThousands);
            txtDoanhThu.Text = String.Format(culture, "{0:N0}", value);
            txtDoanhThu.Select(doanhThu.ToString().Length, 0);
            lbnDoanhThu.Text = txtDoanhThu.Text+" VND";
            lbnGiaoHang.Text = soHDGH.ToString();
            lbnThanhToan.Text = soHDTT.ToString();
        }
        void LoadTKTheoNgay()
        {
            dgridThgKe.ColumnCount = 5;
            dgridThgKe.Columns[0].Name = "Mã HD";
            dgridThgKe.Columns[1].Name = "Số SP";
            dgridThgKe.Columns[2].Name = "Doanh Thu";
            dgridThgKe.Columns[3].Name = "Loại HD";
            dgridThgKe.Columns[4].Name = "Thời gian TT";
            dgridThgKe.Rows.Clear();
            foreach (var x in serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date == DateTime.Now.Date && c.ThanhToan == true))
            {
                int Sl = 0;
                double TT = 0;
                foreach (var y in serviceThongKe.GetlstCTHDBan().Where(c => c.Mahd == x.MaHd && c.TrangThai == 0 || c.Mahd == x.MaHd && c.TrangThai == 1))
                {
                    Sl += y.SoLuong;
                    TT += y.TongTien;
                }
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(TT.ToString(), System.Globalization.NumberStyles.AllowThousands);
                textBox1.Text = String.Format(culture, "{0:N0}", value);
                dgridThgKe.Rows.Add(x.MaHd, Sl, textBox1.Text + " VND", x.LoaiHd == 0 ? "Thanh Toán" : "Giao Hàng", x.NgayLapHD);
            }
            LoadThongKe(serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date == DateTime.Now.Date && c.ThanhToan == true).ToList());
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            label1.Text = "Tổng Doanh Thu Hôm Nay";
            LoadTKTheoNgay();
        }

        void LoadTKTheoThang()
        {
            dgridThgKe.ColumnCount = 5;
            dgridThgKe.Columns[0].Name = "Mã HD";
            dgridThgKe.Columns[1].Name = "Số SP";
            dgridThgKe.Columns[2].Name = "Doanh Thu";
            dgridThgKe.Columns[3].Name = "Loại HD";
            dgridThgKe.Columns[4].Name = "Thời gian TT";
            dgridThgKe.Rows.Clear();
            foreach (var x in serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date.Month == DateTime.Now.Date.Month && c.ThanhToan == true))
            {
                int Sl = 0;
                double TT = 0;
                foreach (var y in serviceThongKe.GetlstCTHDBan().Where(c => c.Mahd == x.MaHd && c.TrangThai == 0 || c.Mahd == x.MaHd && c.TrangThai == 1))
                {
                    Sl += y.SoLuong;
                    TT += y.TongTien;
                }
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(TT.ToString(), System.Globalization.NumberStyles.AllowThousands);
                textBox1.Text = String.Format(culture, "{0:N0}", value);
                dgridThgKe.Rows.Add(x.MaHd, Sl, textBox1.Text, x.LoaiHd == 0 ? "Thanh Toán" : "Giao Hàng", x.NgayLapHD);
            }
            LoadThongKe(serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date.Month == DateTime.Now.Date.Month && c.ThanhToan == true).ToList());
        }

        private void bntThang_Click(object sender, EventArgs e)
        {
            label1.Text = "Tổng Doanh Thu Của Tháng";
            LoadTKTheoThang();
        }

        void LoadTKTheoNam()
        {
            dgridThgKe.ColumnCount = 5;
            dgridThgKe.Columns[0].Name = "Mã HD";
            dgridThgKe.Columns[1].Name = "Số SP";
            dgridThgKe.Columns[2].Name = "Doanh Thu";
            dgridThgKe.Columns[3].Name = "Loại HD";
            dgridThgKe.Columns[4].Name = "Thời gian TT";
            dgridThgKe.Rows.Clear();
            foreach (var x in serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date.Year == DateTime.Now.Date.Year && c.ThanhToan == true))
            {
                int Sl = 0;
                double TT = 0;
                foreach (var y in serviceThongKe.GetlstCTHDBan().Where(c => c.Mahd == x.MaHd && c.TrangThai == 0 || c.Mahd == x.MaHd && c.TrangThai == 1))
                {
                    Sl += y.SoLuong;
                    TT += y.TongTien;
                }
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(TT.ToString(), System.Globalization.NumberStyles.AllowThousands);
                textBox1.Text = String.Format(culture, "{0:N0}", value);
                dgridThgKe.Rows.Add(x.MaHd, Sl, textBox1.Text, x.LoaiHd == 0 ? "Thanh Toán" : "Giao Hàng", x.NgayLapHD);
            }
            LoadThongKe(serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date.Year == DateTime.Now.Date.Year && c.ThanhToan == true).ToList());
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            label1.Text = "Tổng Doanh Thu Của Năm";
            LoadTKTheoNam();
        }

        void LoadTimKiem()
        {
            dgridThgKe.ColumnCount = 5;
            dgridThgKe.Columns[0].Name = "Mã HD";
            dgridThgKe.Columns[1].Name = "Số SP";
            dgridThgKe.Columns[2].Name = "Doanh Thu";
            dgridThgKe.Columns[3].Name = "Loại HD";
            dgridThgKe.Columns[4].Name = "Thời gian TT";
            dgridThgKe.Rows.Clear();
            foreach (var x in serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date == dateTimePicker1.Value.Date && c.ThanhToan == true))
            {
                int Sl = 0;
                double TT = 0;
                foreach (var y in serviceThongKe.GetlstCTHDBan().Where(c => c.Mahd == x.MaHd && c.TrangThai == 0 || c.Mahd == x.MaHd && c.TrangThai == 1))
                {
                    Sl += y.SoLuong;
                    TT += y.TongTien;
                }
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(TT.ToString(), System.Globalization.NumberStyles.AllowThousands);
                textBox1.Text = String.Format(culture, "{0:N0}", value);
                dgridThgKe.Rows.Add(x.MaHd, Sl, textBox1.Text, x.LoaiHd == 0 ? "Thanh Toán" : "Giao Hàng", x.NgayLapHD);
            }
            LoadThongKe(serviceThongKe.GetLstHoaDon().Where(c => c.NgayLapHD.Date == dateTimePicker1.Value.Date && c.ThanhToan == true).ToList());
        }

        private void btnTkiem_Click(object sender, EventArgs e)
        {
            label1.Text = "Tổng Doanh Thu Theo Ngày";
            LoadTimKiem();
        }
    }
}
