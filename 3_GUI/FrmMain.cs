using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace _3_GUI
{
    public partial class FrmMain : Form
    {
        IServiceHD serviceHD;
        FrmQLNV frmQLNV;
        IQLNhanVien qLNhanVien;
        IServiceNhanVien serviceNhanVien;
        string taikhoan;
        FrmKhoHang frmKhoHang;
        FrmHoaDonBanHang frmHoaDonBanHang;
        FrmHoa_Don_Xuat _FrmHoa_Don_Xuat;
        NhanVien nv;
        FrmPhieuNhap FrmPhieuNhap;
        FrmThongKe FrmThongKe;
        public FrmMain()
        {
            InitializeComponent();
            serviceHD = new ServiceHD();
            qLNhanVien = new QLNhanVien();
            nv = new NhanVien();
            serviceNhanVien = new ServiceNhanVien();
            this.tabControl1.Padding = new Point(12, 4);
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += tabControl1_DrawItem;
            this.tabControl1.MouseDown += tabControl1_MouseDown;
            this.tabControl1.HandleCreated += tabControl1_HandleCreated;
            

        }
        private bool check(string name)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        public void Main(string tk)
        {
            taikhoan = tk;
            string tv = qLNhanVien.GetTblNhanVien().Where(c => c.TaiKhoan == taikhoan).Select(c => c.MaNv).FirstOrDefault();
            nv = serviceNhanVien.GetLstNhanVien().Where(c => c.MaNv == tv).FirstOrDefault();
            if (nv.MaCv == 1)
            { 
                btn_Nhan_Vien.Visible = false;
                btn_DoanhThu.Visible = false;
                btn_PhieuXuat.Visible = false;
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Thanh Toán    ");
            if (!(check("Thanh Toán    ")))
            {
                HoaDon hoadon = new HoaDon();
                hoadon.LoaiHd = 0;
                hoadon.MaNv = nv.MaNv;
                frmHoaDonBanHang = new FrmHoaDonBanHang(serviceHD.AddHoaDon(hoadon));
                frmHoaDonBanHang.TopLevel = false;
                frmHoaDonBanHang.Dock = DockStyle.Fill;
                frmHoaDonBanHang.FormBorderStyle = FormBorderStyle.None;
                frmHoaDonBanHang.Show();
                tp.Controls.Add(frmHoaDonBanHang);
                tabControl1.TabPages.Add(tp);
            }
            else if ((check("Thanh Toán    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }

        }

        private void btn_Nhan_Vien_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Nhân Viên    ");
            if (!(check("Nhân Viên    ")))
            {

                frmQLNV = new FrmQLNV();
                frmQLNV.TopLevel = false;
                frmQLNV.Dock = DockStyle.Fill;
                frmQLNV.FormBorderStyle = FormBorderStyle.None;
                frmQLNV.Show();
                tp.Controls.Add(frmQLNV);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            else if ((check("Nhân Viên    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x2000 + 100;
        private void tabControl1_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(this.tabControl1.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            if ((this.tabControl1.GetTabRect(lastIndex).Contains(e.Location)) || (!(this.tabControl1.GetTabRect(lastIndex).Contains(e.Location))))
            {
                for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
                {
                    var tabRect = this.tabControl1.GetTabRect(i);
                    tabRect.Inflate(-2, -2);
                    var closeImage = Properties.Resources.icon_xoa;
                    Bitmap objBitmap = new Bitmap(closeImage, new Size(30, 30));
                    var imageRect = new Rectangle(
                        (tabRect.Right - objBitmap.Width),
                        tabRect.Top + (tabRect.Height - objBitmap.Height) / 2,
                        objBitmap.Width,
                        objBitmap.Height);
                    if (imageRect.Contains(e.Location))
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void btn_HoaDonNhap_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Phiếu Yêu Cầu Nhập    ");
            if (!(check("Phiếu Yêu Cầu Nhập    ")))
            {

                FrmPhieuNhap = new FrmPhieuNhap();
                FrmPhieuNhap.TopLevel = false;
                FrmPhieuNhap.FormBorderStyle = FormBorderStyle.None;
                FrmPhieuNhap.layNhanVien(nv);
                FrmPhieuNhap.Show();
                tp.Controls.Add(FrmPhieuNhap);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            else if ((check("Phiếu Yêu Cầu Nhập    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }
        }

        private void btn_Kho_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Kho Hàng    ");
            if (!(check("Kho Hàng    ")))
            {

                frmKhoHang = new FrmKhoHang();
                frmKhoHang.TopLevel = false;
                frmKhoHang.Dock = DockStyle.Fill;
                frmKhoHang.FormBorderStyle = FormBorderStyle.None;
                frmKhoHang.Show();
                tp.Controls.Add(frmKhoHang);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            else if ((check("Kho Hàng    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }
        }

        private void btn_PhieuXuat_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Phiếu Xuất Kho    ");
            if (!(check("Phiếu Xuất Kho    ")))
            {

                _FrmHoa_Don_Xuat = new FrmHoa_Don_Xuat();
                _FrmHoa_Don_Xuat.TopLevel = false;
                _FrmHoa_Don_Xuat.Dock = DockStyle.Fill;
                _FrmHoa_Don_Xuat.FormBorderStyle = FormBorderStyle.None;
                _FrmHoa_Don_Xuat.NhanVien(nv);
                _FrmHoa_Don_Xuat.Show();
                tp.Controls.Add(_FrmHoa_Don_Xuat);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            else if ((check("Phiếu Xuất Kho    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDoiMK frmDoiMK = new FrmDoiMK();
            frmDoiMK.taikhoan(taikhoan); 
            frmDoiMK.Show(); 
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Sản Phẩm    ");
            if (!(check("Sản Phẩm    ")))
            {

                FrmChiTietSP frmChiTietSP = new FrmChiTietSP();
                frmChiTietSP.TopLevel = false;
                frmChiTietSP.Dock = DockStyle.Fill;
                frmChiTietSP.FormBorderStyle = FormBorderStyle.None;
                frmChiTietSP.CheckQuyen(nv);
                frmChiTietSP.Show();
                tp.Controls.Add(frmChiTietSP);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            else if ((check("Sản Phẩm    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDangnhap frmDangnhap = new FrmDangnhap();
            frmDangnhap.Show();
            this.Hide();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = this.tabControl1.TabPages[e.Index];
            var tabRect = this.tabControl1.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            if (!(e.Index == this.tabControl1.TabCount))
            {
                var closeImage = Properties.Resources.icon_xoa;
                Bitmap objBitmap = new Bitmap(closeImage, new Size(30, 30));
                e.Graphics.DrawImage(objBitmap,
                    (tabRect.Right - objBitmap.Width),
                    tabRect.Top + (tabRect.Height - objBitmap.Height) / 5);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                    tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Doanh Thu    ");
            if (!(check("Doanh Thu    ")))
            {

                FrmThongKe = new FrmThongKe();
                FrmThongKe.TopLevel = false;
                FrmThongKe.Dock = DockStyle.Fill;
                FrmThongKe.FormBorderStyle = FormBorderStyle.None;
                FrmThongKe.Show();
                tp.Controls.Add(FrmThongKe);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
            }
            else if ((check("Doanh Thu    ")))
            {
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    if (tabPage.Text == tp.Text)
                    {
                        tabControl1.SelectedTab = tabPage;
                    }
                }
            }
        }
    }
}
