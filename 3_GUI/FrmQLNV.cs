using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Service;
using _2_BUS.Untilities;
using Microsoft.IdentityModel.Tokens;
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
    public partial class FrmQLNV : Form
    {
        IQLNhanVien dsnv;
        NhanVien _nhanVien;
        private ChucNangHeThong utility;
        List<NhanVien> _lstnhanVien;
        public FrmQLNV()
        {
            InitializeComponent();
            dsnv = new QLNhanVien();
            _lstnhanVien = new List<NhanVien>();
            utility = new ChucNangHeThong();
            getlstNV();
            LoadData();
        }
        void getlstNV()
        {
            _lstnhanVien = dsnv.GetTblNhanVien();
        }
        void LoadData()
        {
            DataGridViewComboBoxColumn cmbGT = new DataGridViewComboBoxColumn();
            cmbGT.HeaderText = "Giới tính";
            cmbGT.Name = "cmbGT";
            cmbGT.Items.Add("Nam");
            cmbGT.Items.Add("Nữ");
            
            DataGridViewComboBoxColumn cmNS = new DataGridViewComboBoxColumn();
            cmNS.HeaderText = "Năm sinh";
            cmNS.Name = "cmbNS";
            //cmNS.DataSource = dsnv.NamSinh();
            foreach (var item in dsnv.NamSinh())
            {
                cmNS.Items.Add(item);
            }


            DataGridViewComboBoxColumn cmbMaCV = new DataGridViewComboBoxColumn();
            cmbMaCV.HeaderText = "Chức Vụ";
            cmbMaCV.Name = "CV";
            cmbMaCV.Items.Add("Quản Lý");
            cmbMaCV.Items.Add("Nhân Viên");
            
            DataGridViewComboBoxColumn CbxColumn = new DataGridViewComboBoxColumn();
            CbxColumn.HeaderText = "Chức năng";
            CbxColumn.Name = "cmbChucNang";
            CbxColumn.Items.Add("Thêm");
            CbxColumn.Items.Add("Sửa");
            CbxColumn.Items.Add("Xóa");
            DataGridViewButtonColumn btnXoaGrid = new DataGridViewButtonColumn();
            btnXoaGrid.Name = "Column_btnGrid";
            btnXoaGrid.HeaderText = "Nút";
            btnXoaGrid.UseColumnTextForButtonValue = true;
            btnXoaGrid.Text = "Xác nhận";

            dgrid_QLNV.ColumnCount = 5;
            dgrid_QLNV.Columns[0].Name = "Mã Nhân Viên";
            dgrid_QLNV.Columns[1].Name = "Tên Nhân Viên";
            dgrid_QLNV.Columns.Add(cmbGT);
            dgrid_QLNV.Columns[4].Name = "Căn cước CD";
            dgrid_QLNV.Columns.Add(cmbMaCV);
            dgrid_QLNV.Columns.Add(cmNS);
            dgrid_QLNV.Columns[2].Name = "Tài khoản";
            dgrid_QLNV.Columns[3].Name = "Mật khẩu";
            dgrid_QLNV.Columns.Add(CbxColumn);
            dgrid_QLNV.Columns.Add(btnXoaGrid);
            dgrid_QLNV.Columns[0].Visible = false;
            dgrid_QLNV.Rows.Clear();


            if (txt_TimKiem.Text.Length != 0)
            {
                foreach (var item in dsnv.GetTblNhanVien().Where(c=>c.TenNv.Contains(txt_TimKiem.Text)).ToList())
                {
                    if (item.TrangThai == 0 || item.TrangThai == 2)
                    {
                        dgrid_QLNV.Rows.Add(item.MaNv, item.TenNv, item.TaiKhoan, item.MatKhau, item.Cccd, item.GioiTinh == 1 ? "Nam" : "Nữ", item.MaCv == 0 ? "Quản Lý" : "Nhân Viên",
                                               item.NamSinh);
                    }
                } 
            }
            else
            {
                foreach (var item in dsnv.GetTblNhanVien())
                {
                    if (item.TrangThai == 0 || item.TrangThai == 2)
                    {
                        dgrid_QLNV.Rows.Add(item.MaNv, item.TenNv, item.TaiKhoan, item.MatKhau, item.Cccd, item.GioiTinh == 1 ? "Nam" : "Nữ", item.MaCv == 0 ? "Quản Lý" : "Nhân Viên",
                                               item.NamSinh);
                    }
                }
            }
        }
        private void dgrid_QLNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex == dsnv.GetTblNhanVien().Count + 1)return;
            if (rowindex == -1) return;
            if (e.ColumnIndex == -1) return;
            {

            }
            int index = 0;
            for (int i = 0; i < dsnv.NamSinh().Length; i++)
            {
                if (dsnv.NamSinh()[i] == Convert.ToInt32(dgrid_QLNV.Rows[rowindex].Cells[7].Value))
                {
                    index = i;
                }
            }
            dgrid_QLNV.Rows[rowindex].Cells[7].Value = (dgrid_QLNV.Rows[rowindex].Cells[7] as DataGridViewComboBoxCell).Items[index];
            if (dgrid_QLNV.Columns[e.ColumnIndex].Name == "Column_btnGrid")
            {
                if (MessageBox.Show("Bạn có chắc chọn chức năng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dgrid_QLNV.Columns[8].Name == "cmbChucNang")
                    {
                        if (dgrid_QLNV.Rows[rowindex].Cells[8].Value.ToString() == "Thêm")
                        {
                            _nhanVien = new NhanVien();
                            if (dgrid_QLNV.Rows[rowindex].Cells[1].Value == null)
                            {
                                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                                return;
                            }
                            bool tennv = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[1].Value.ToString(), @"^\s+$");
                            if (tennv)
                            {
                                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                                return;
                            }
                            bool checkTen = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[1].Value.ToString(), @"[0-9]+");
                            if (checkTen == true)
                            {
                                MessageBox.Show("Tên nhân viên chỉ được nhập chữ", "Thông báo");
                                return;
                            }
                            _nhanVien.TenNv = dgrid_QLNV.Rows[rowindex].Cells[1].Value.ToString();
                            if (dgrid_QLNV.Rows[rowindex].Cells[2].Value == null)
                            {
                                MessageBox.Show("Tài khoản không được để trống", "Thông báo");
                                return;
                            }
                            bool tk = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[2].Value.ToString(), @"\s");
                            if (tk)
                            {
                                MessageBox.Show("Tài khoản nhân viên không được có dấu cách", "Thông báo");
                                return;
                            }
                            _nhanVien.TaiKhoan = dgrid_QLNV.Rows[rowindex].Cells[2].Value.ToString() + "@gmail.com";
                            string taikhoan = dgrid_QLNV.Rows[rowindex].Cells[2].Value.ToString();
                            if (dgrid_QLNV.Rows[rowindex].Cells[3].Value == null)
                            {
                                MessageBox.Show("Mật khẩu không được để trống", "Thông báo");
                                return;
                            }
                            bool mk = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[3].Value.ToString(), @"\s");
                            if (mk)
                            {
                                MessageBox.Show("Mật khẩu không được có dấu cách", "Thông báo");
                                return;
                            }
                            var passwword = dgrid_QLNV.Rows[rowindex].Cells[3].Value.ToString();
                            _nhanVien.MatKhau = utility.MaHoaPass(passwword);
                            bool checkcccd = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString(), @"[0-9]+");
                            if (checkcccd == false)
                            {
                                MessageBox.Show("căn cước công dân không được nhập chữ");
                                return;
                            }
                            if (dgrid_QLNV.Rows[rowindex].Cells[4].Value == null)
                            {
                                MessageBox.Show("Căn cước công dân không được để trống", "Thông báo");
                                return;
                            }
                            bool cc = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString(), @"\s");
                            if (cc)
                            {
                                MessageBox.Show("Căn cước công dân không được có dấu cách", "Thông báo");
                                return;
                            }
                            if ((dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString().Length) < 12)
                            {
                                MessageBox.Show("Căn cước công dân không hợp lệ", "Thông báo");
                                return;
                            }
                            if ((dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString().Length) > 12)
                            {
                                MessageBox.Show("Căn cước công dân không hợp lệ", "Thông báo");
                                return;
                            }
                            _nhanVien.Cccd = dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString();
                            string cccd = dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString();

                            if (dgrid_QLNV.Rows[rowindex].Cells[5].Value == null)
                            {
                                MessageBox.Show("Giới tính không được để trống", "Thông báo");
                                return;
                            }
                            _nhanVien.GioiTinh = Convert.ToByte(dgrid_QLNV.Rows[rowindex].Cells[5].Value.ToString() == "Nam" ? 1 : 0);
                            if (dgrid_QLNV.Rows[rowindex].Cells[7].Value == null)
                            {
                                MessageBox.Show("Năm sinh không được để trống", "Thông báo");
                                return;
                            }
                            bool checkNS = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[7].Value.ToString(), @"\D+");
                            if (checkNS == true)
                            {
                                MessageBox.Show("Năm sinh không được nhập chữ");
                                return;
                            }
                            _nhanVien.NamSinh = Convert.ToInt32(dgrid_QLNV.Rows[rowindex].Cells[7].Value.ToString());
                            _nhanVien.MaCv = Convert.ToByte(dgrid_QLNV.Rows[rowindex].Cells[6].Value.ToString() == "Quản Lý" ? 0 : 1);
                            if (_lstnhanVien.Any(c => c.TaiKhoan == taikhoan))
                            {
                                MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                                return;
                            }
                            if (_lstnhanVien.Any(c => c.Cccd == cccd))
                            {
                                MessageBox.Show("Căn cước công dân đã tôn tại", "Thông báo");
                                return;
                            }
                            MessageBox.Show(dsnv.Add(_nhanVien), "thong bao");
                            LoadData();
                        }

                        else if (dgrid_QLNV.Rows[rowindex].Cells[8].Value.ToString() == "Sửa")
                        {
                            var id = dsnv.GetTblNhanVien().Where(c => c.MaNv == dgrid_QLNV.Rows[rowindex].Cells[0].Value.ToString()).FirstOrDefault();
                            if (dgrid_QLNV.Rows[rowindex].Cells[1].Value == null)
                            {
                                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                                return;
                            }
                            bool tennv1 = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[1].Value.ToString(), @"^\s+$");
                            if (tennv1)
                            {
                                MessageBox.Show("Tên nhân viên không được bỏ trống", "Thông báo");
                                return;
                            }
                            bool checkTen1 = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[1].Value.ToString(), @"[0-9]+");
                            if (checkTen1 == true)
                            {
                                MessageBox.Show("Tên nhân viên chỉ được nhập chữ", "Thông báo");
                                return;
                            }
                            id.TenNv = dgrid_QLNV.Rows[rowindex].Cells[1].Value.ToString();
                            if (dgrid_QLNV.Rows[rowindex].Cells[2].Value == null)
                            {
                                MessageBox.Show("Tài khoản không được để trống", "Thông báo");
                                return;
                            }
                            bool tk1 = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[2].Value.ToString(), @"\s");
                            if (tk1)
                            {
                                MessageBox.Show("Tài khoản nhân viên không được có dấu cách", "Thông báo");
                                return;
                            }
                            id.TaiKhoan = dgrid_QLNV.Rows[rowindex].Cells[2].Value.ToString() + "@gmail.com";
                            string taikhoan1 = dgrid_QLNV.Rows[rowindex].Cells[2].Value.ToString();
                            bool checkcccd1 = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString(), @"[0-9]+");
                            if (checkcccd1 == false)
                            {
                                MessageBox.Show("căn cước công dân không được nhập chữ");
                                return;
                            }
                            bool cc1 = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString(), @"\s");
                            if (cc1)
                            {
                                MessageBox.Show("Căn cước công dân không được có dấu cách", "Thông báo");
                                return;
                            }
                            if (dgrid_QLNV.Rows[rowindex].Cells[4].Value == null)
                            {
                                MessageBox.Show("Căn cước công dân không được để trống", "Thông báo");
                                return;
                            }
                            if ((dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString().Length) < 12)
                            {
                                MessageBox.Show("Căn cước công dân không hợp lệ", "Thông báo");
                                return;
                            }
                            if ((dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString().Length) > 12)
                            {
                                MessageBox.Show("Căn cước công dân không hợp lệ", "Thông báo");
                                return;
                            }
                            id.Cccd = dgrid_QLNV.Rows[rowindex].Cells[4].Value.ToString();
                            id.GioiTinh = Convert.ToByte(dgrid_QLNV.Rows[rowindex].Cells[5].Value.ToString() == "Nam" ? 1 : 0);
                            if (dgrid_QLNV.Rows[rowindex].Cells[5].Value == null)
                            {
                                MessageBox.Show("Giới tính không được để trống", "Thông báo");
                                return;
                            }
                            bool checkNS1 = Regex.IsMatch(dgrid_QLNV.Rows[rowindex].Cells[7].Value.ToString(), @"\D+");
                            if (checkNS1 == true)
                            {
                                MessageBox.Show("Năm sinh không được nhập chữ");
                                return;
                            }
                            id.NamSinh = Convert.ToInt32(dgrid_QLNV.Rows[rowindex].Cells[7].Value.ToString());
                            id.MaCv = Convert.ToByte(dgrid_QLNV.Rows[rowindex].Cells[6].Value.ToString() == "Quản Lý" ? 0 : 1);
                            MessageBox.Show(dsnv.Update(id), "Thong bao");
                            LoadData();
                        }

                        else if (dgrid_QLNV.Rows[rowindex].Cells[8].Value.ToString() == "Xóa")
                        {
                            var id2 = dsnv.GetTblNhanVien().Where(c => c.MaNv == dgrid_QLNV.Rows[rowindex].Cells[0].Value.ToString()).FirstOrDefault();
                            MessageBox.Show(dsnv.Delete(id2), "Thong bao");
                            LoadData();
                        }
                    }
                } 
            }
        }

        private void dgrid_QLNV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void txt_TimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            LoadData();
        }

    }
}
