using _2_BUS.IService;
using _2_BUS.Models;
using _2_BUS.Service;
using _2_BUS.Untilities;
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
    public partial class FrmDangnhap : Form
    {

        IDangNhapService _Idangnhapservice;
        List<DangNhap> _dangnhap;
        ChucNangHeThong _cn;

        public FrmDangnhap()
        {
            InitializeComponent();
            _Idangnhapservice = new DangNhapService();
            _dangnhap = _Idangnhapservice.getlstDangnhap();
            _cn = new ChucNangHeThong();

        }
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                FrmQuenMK frm_QuenMKEmali = new FrmQuenMK();
                frm_QuenMKEmali.MdiParent = this.MdiParent;
                frm_QuenMKEmali.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("thực hiện bị hủy", "thong bao");
                return;
            }
        }

        private void btn_dangnhap_Click_1(object sender, EventArgs e)
        {
            if (txt_TK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản ", "Thông báo");
                return;
            }
            else
            {
                if (txt_MK.Text == "")
                {

                    MessageBox.Show("Vui lòng nhập mật khẩu ", "Thông báo");
                    return;
                }
                else
                {
                    if (_dangnhap.Any(c => c.taikhoan == txt_TK.Text && c.matkhau ==_cn.MaHoaPass( txt_MK.Text)  && c.ttdangnhap == 0))
                    {
                        MessageBox.Show("Bạn phải đổi mật khẩu để sử dụng lần dầu ", "Thông báo ");
                        this.Hide();
                        FrmDoiMK frmDoiMK = new FrmDoiMK();
                        frmDoiMK.taikhoan(txt_TK.Text); 
                        frmDoiMK.Show();
                    }
                    else if (_dangnhap.Any(c => c.taikhoan == txt_TK.Text && c.matkhau ==_cn.MaHoaPass( txt_MK.Text) && c.ttdangnhap == 2))
                    {
                        MessageBox.Show("Đăng nhập thành công  ", "Thông báo ");
                        this.Hide();
                        FrmMain frmMain = new FrmMain();
                        frmMain.Main(txt_TK.Text);                       
                        frmMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản mật khẩu ", "Thông báo");
                        txt_TK.Text = "";
                        txt_MK.Text = ""; 
                    }
                }
            }

        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show("Bạn muốn thoát chương trình không", "Thông báo", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
                Application.Exit();
        }
    }
}
