using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.Untilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class FrmDoiMK : Form
    {
        private IDangNhapService dnservice;
        private ChucNangHeThong cn;
        private NhanVien nv;
        
        public FrmDoiMK()
        {
            InitializeComponent();
            dnservice = new DangNhapService();
            cn = new ChucNangHeThong();

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMain frmMain = new FrmMain();           
            frmMain.Show();

        }
        public void taikhoan(string  tk)
        {
            txt_TK.Text = tk; 
        }
        private void btn_doimk_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (txt_TK.Text == "")
                {
                    MessageBox.Show("Vui lòng không để trống tài khoản", "Thông báo ");
                    return;
                }
                else
                {
                    bool tk1 = Regex.IsMatch(txt_MK.Text, @"\s");
                    if (tk1)
                    {
                        MessageBox.Show("Không để khoảng trắng");
                        return;
                    }
                    if (txt_MK.Text == "")
                    {
                        MessageBox.Show("Vui lòng không để trống mật khẩu", "Thông báo ");
                        return;
                    }
                    else
                    {
                        bool tk = Regex.IsMatch(txt_MKM.Text, @"\s");
                        if (tk )
                        {
                            MessageBox.Show("Không để khoảng trắng");
                            return; 
                        }
                        if (txt_MKM.Text == "")
                        {
                            MessageBox.Show("Vui lòng không để trống mật khẩu mới", "Thông báo ");
                            return;
                        }
                        else
                        {
                            bool tk2 = Regex.IsMatch(txt_MKMNL.Text, @"\s");
                            if (tk2)
                            {
                                MessageBox.Show("Không để khoảng trắng");
                                return;
                            }
                            if (txt_MKMNL.Text == "")
                            {
                                MessageBox.Show("Vui lòng không để trống nhập mật khẩu mới", "Thông báo ");
                                return;
                            }
                            else
                            {
                                if (dnservice.getlstNhanVien().Any(c => c.TaiKhoan == txt_TK.Text && c.MatKhau == cn.MaHoaPass(txt_MK.Text)))
                                {
                                    if (txt_MK.Text == txt_MKM.Text)
                                    {
                                        MessageBox.Show("Không đc trùng mật khẩu cũ", "Thông báo");
                                    }
                                    else
                                    {
                                        if (txt_MKM.Text == txt_MKMNL.Text)
                                        {
                                                                             
                                            nv = dnservice.getlstNhanVien().Where(c => c.TaiKhoan == txt_TK.Text && c.MatKhau == cn.MaHoaPass(txt_MK.Text)).FirstOrDefault();
                                            nv.MatKhau = cn.MaHoaPass(txt_MKM.Text);
                                            nv.TrangThai = 2;
                                            dnservice.DoiMatKhau(nv);
                                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                                            FrmMain frmMain = new FrmMain();
                                            frmMain.Main(nv.TaiKhoan); 
                                            this.Hide();
                                            frmMain.Show();
                                        }

                                        else
                                        {
                                            MessageBox.Show("Mật khẩu xác nhận nhập không khớp với mật khẩu mới", "Thông báo ");
                                            txt_MKMNL.Text = "";
                                            return;
                                        }
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Mật khẩu hoặc tài khoản bị sai vui lòng nhập lại", "Thông báo ");
                                    return;
                                }
                            }


                        }

                    }
                }
            }
        }
    }
}
