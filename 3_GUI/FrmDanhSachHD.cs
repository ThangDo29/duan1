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
    public partial class FrmDanhSachHD : Form
    {
        IServiceHD serviceHD;
        string MaHd = "0";
        public FrmDanhSachHD()
        {
            InitializeComponent();
            serviceHD = new ServiceHD();
            LoadHD();
        }

        void LoadHD()
        {
            dgridHD.ColumnCount = 3;
            dgridHD.Columns[0].Name = "Mã hóa đơn";
            dgridHD.Columns[1].Name = "Loại hóa đơn";
            dgridHD.Columns[2].Name = "Ngày tạo hóa đơn";
            dgridHD.Rows.Clear();
            foreach (var x in serviceHD.GetLstHoaDon().Where(c => c.ThanhToan == true && c.TrangThai !=3 && c.NgayLapHD.Date == DateTime.Now.Date).ToList())
            {
                dgridHD.Rows.Add(x.MaHd, x.LoaiHd == 0 ? "Tại quầy" : "Giao hàng", x.NgayLapHD);
            }
        }

        private void dgridHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MaHd = dgridHD.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void toolXoa_Click(object sender, EventArgs e)
        {
            if (MaHd != "0")
            {
                HoaDon hoaDon1 = serviceHD.GetLstHoaDon().Where(c => c.MaHd == MaHd).FirstOrDefault();
                hoaDon1.TrangThai = 3;
                serviceHD.EditHoaDonw(hoaDon1);
                MaHd = "0";
                LoadHD();
            }
            else if (MaHd == "0")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn");
            }
        }
    }
}
