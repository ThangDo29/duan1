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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class FrmQuenMK : Form
    {
        private ChucNangHeThong CNHT;
        private IDangNhapService _DangNhapServices;
        private string _passRandom;
        private string _code;
        private string _Mail;
        int count = 1;

        public FrmQuenMK()
        {
            InitializeComponent();
            CNHT = new ChucNangHeThong();
            _DangNhapServices = new DangNhapService();
        }

        private void btn_xacnhan_Click_1(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (count == 1)
                {
                    if (btn_xacnhan.Text == "Nhận code")
                    {
                        _Mail = txt_NhapEmail.Text;
                        if (txt_NhapEmail.Text == "")
                        {
                           MessageBox.Show( "Vui lòng nhập mail","Thông báo ");
                            return; 
                        }
                        else
                        {
                            if (_DangNhapServices.SenderNhanVien(_Mail) == null)
                            {
                                MessageBox.Show("Email không tồn tại trong hệ thống ");
                                txt_NhapEmail.Text = "";
                                txt_NhapEmail.BackColor = Color.Red;
                                txt_NhapEmail.ForeColor = Color.White;
                                this.txt_NhapEmail.Focus();
                                return;
                            }
                            _code = CNHT.PassRandom(5);
                            _passRandom = CNHT.PassRandom(8);
                            MessageBox.Show(CNHT.SenderMail(txt_NhapEmail.Text, _passRandom, _code));
                            txt_NhapEmail.Text = default;
                            btn_xacnhan.Text = "Xác nhận code";
                            count++;
                            lb_email.Text = "nhập code :";
                        }


                    }
                }
                else if (count == 2)
                {
                    if (btn_xacnhan.Text == "Xác nhận code")
                    {
                        if (txt_NhapEmail.Text == _code)
                        {
                            var Nhanvien = _DangNhapServices.SenderNhanVien(_Mail);
                            Nhanvien.MatKhau = CNHT.MaHoaPass(_passRandom);
                            Nhanvien.TrangThai = 0; 
                            _DangNhapServices.DoiMatKhau(Nhanvien);
                            MessageBox.Show("Xac nhan thanh cong ");
                            MessageBox.Show(_passRandom, "Mật khẩu mới quả bạn");
                            this.Close();
                            FrmDangnhap dn = new FrmDangnhap();
                            dn.Show();
                        }
                        else
                        {
                            MessageBox.Show("Mã code không khớp");
                            txt_NhapEmail.Text = "";
                            txt_NhapEmail.BackColor = Color.Red;
                            txt_NhapEmail.ForeColor = Color.White;
                            this.txt_NhapEmail.Focus();
                            return;
                        }
                    }
                }


            }
            else
            {
                MessageBox.Show("thực hiện bị hủy", "thong bao");
                return;
            }
        }
    }
}
