using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using _2_BUS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class FrmKhoHang : Form
    {
        private IQlKhoHang _servicesKhoHang;
        private DateTimePicker dtp;
        private KhoHang _kh;
        private string _mapx;
        private string _SoDu;
        private string _SoLuongCuaKho;
        private IServiceChiTietSP _serviceChiTietSP;
        private ChiTietKhoHang _ChiTietKhoHang;
        private IServiceQLHDXuat _serviceQLHDXuat;
        //private ISer

        public FrmKhoHang()
        {
            InitializeComponent();
            _servicesKhoHang = new QLKhoHang();
            _serviceChiTietSP = new ServiceChiTietSP();
            _serviceQLHDXuat = new ServiceQLHDXuat();
            load();
            loadHDXuat();
            loadKho();
        }
        void load()
        {

            try
            {
                DataGridViewButtonColumn btnXoaGrid = new DataGridViewButtonColumn();
                btnXoaGrid.Name = "Column_btnGrid";
                btnXoaGrid.HeaderText = "Nút";
                btnXoaGrid.UseColumnTextForButtonValue = true;
                btnXoaGrid.Text = "Xác nhận";

                DataGridViewComboBoxColumn CbxColumn = new DataGridViewComboBoxColumn();
                CbxColumn.HeaderText = "Chức năng";
                CbxColumn.Name = "cmbChucNang";
                CbxColumn.Items.Add("Thêm");
                CbxColumn.Items.Add("Sửa");
                CbxColumn.Items.Add("Xóa");

                DataGridViewComboBoxColumn cmSoLUong = new DataGridViewComboBoxColumn();
                cmSoLUong.HeaderText = "Số Lượng";
                cmSoLUong.Name = "cmbSoluong";
                cmSoLUong.DataSource = _servicesKhoHang.SoLuong();

                //DataGridViewComboBoxColumn cbxKho = new DataGridViewComboBoxColumn();
                //cbxKho.HeaderText = "Mã Kho";
                //cbxKho.Name = "cbxKho";
                //foreach (var x in _servicesKhoHang.GetLstKhoHang())
                //{
                //    cbxKho.Items.Add(x.MaKho);
                //}

                DataGridViewComboBoxColumn cmCTSP = new DataGridViewComboBoxColumn();
                cmCTSP.HeaderText = "Chi Tiết Sản Phẩm";
                cmCTSP.Name = "cmbCTSP";
                foreach (var x in _servicesKhoHang.GetChiTietSanPhams())
                {
                    cmCTSP.Items.Add(x.MaCtsp);
                }

                dgv_KhoHang.ColumnCount = 5;
                dgv_KhoHang.Columns[0].Name = "ID";
                dgv_KhoHang.Columns[1].Name = "Mã Chi Tiết Kho";
                dgv_KhoHang.Columns.Add(cmCTSP);
                dgv_KhoHang.Columns["cmbCTSP"].DisplayIndex = 2;
                dgv_KhoHang.Columns[2].Name = "Tên SP";
                dgv_KhoHang.Columns[3].Name = "Giá Bán";
                dgv_KhoHang.Columns[4].Name = "Mã Kho";
                dgv_KhoHang.Columns.Add(cmSoLUong);
                dgv_KhoHang.Columns.Add(CbxColumn);
                dgv_KhoHang.Columns.Add(btnXoaGrid);
                dgv_KhoHang.Columns[0].Visible = false;
                dgv_KhoHang.Columns[1].Visible = false;
                dgv_KhoHang.Columns[4].Visible = false;
                dgv_KhoHang.Rows.Clear();
                foreach (var x in _servicesKhoHang.LstDVKhoHangs())
                {
                    if (x.TrangThai == 0)
                    {
                        dgv_KhoHang.Rows.Add(x.Id, x.MaCtkho, x.TenSP, string.Format("{0:#,##0.00}", x.GiaBan) + " VNĐ", x.MaKho, x.MaCtsp, x.SoLuong);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void loadKho()
        {
            try
            {
                dgv_dsKhoHang.ColumnCount = 7;
                dgv_dsKhoHang.Columns[0].Name = "ID";
                dgv_dsKhoHang.Columns[1].Name = "Mã Chi Tiết Kho";
                dgv_dsKhoHang.Columns[2].Name = "Chi Tiết Sản Phẩm";
                dgv_dsKhoHang.Columns[3].Name = "Giá Bán";
                dgv_dsKhoHang.Columns[4].Name = "Tên SP";
                dgv_dsKhoHang.Columns[5].Name = "Mã Kho";
                dgv_dsKhoHang.Columns[6].Name = "Số lượng";
                dgv_dsKhoHang.Columns[0].Visible = false;
                dgv_dsKhoHang.Columns[1].Visible = false;
                dgv_dsKhoHang.Columns[5].Visible = false;
                dgv_dsKhoHang.Rows.Clear();
                foreach (var x in _servicesKhoHang.LstDVKhoHangs())
                {
                    if (x.TrangThai == 0)
                    {
                        dgv_dsKhoHang.Rows.Add(x.Id, x.MaCtkho, x.MaCtsp, string.Format("{0:#,##0.00}", x.GiaBan) + " VNĐ", x.TenSP, x.MaKho, x.SoLuong);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void loadTimKiemSP(string mactsp)
        {
            try
            {
                DataGridViewButtonColumn btnXoaGrid = new DataGridViewButtonColumn();
                btnXoaGrid.Name = "Column_btnGrid";
                btnXoaGrid.HeaderText = "Nút";
                btnXoaGrid.UseColumnTextForButtonValue = true;
                btnXoaGrid.Text = "Xác nhận";

                DataGridViewComboBoxColumn CbxColumn = new DataGridViewComboBoxColumn();
                CbxColumn.HeaderText = "Chức năng";
                CbxColumn.Name = "cmbChucNang";
                CbxColumn.Items.Add("Thêm");
                CbxColumn.Items.Add("Sửa");
                CbxColumn.Items.Add("Xóa");

                DataGridViewComboBoxColumn cmSoLUong = new DataGridViewComboBoxColumn();
                cmSoLUong.HeaderText = "Số Lượng";
                cmSoLUong.Name = "cmbSoluong";
                cmSoLUong.DataSource = _servicesKhoHang.SoLuong();

                //DataGridViewComboBoxColumn cbxKho = new DataGridViewComboBoxColumn();
                //cbxKho.HeaderText = "Mã Kho";
                //cbxKho.Name = "cbxKho";
                //foreach (var x in _servicesKhoHang.GetLstKhoHang())
                //{
                //    cbxKho.Items.Add(x.MaKho);
                //}

                DataGridViewComboBoxColumn cmCTSP = new DataGridViewComboBoxColumn();
                cmCTSP.HeaderText = "Chi Tiết Sản Phẩm";
                cmCTSP.Name = "cmbCTSP";
                foreach (var x in _servicesKhoHang.GetChiTietSanPhams())
                {
                    cmCTSP.Items.Add(x.MaCtsp);
                }

                dgv_KhoHang.ColumnCount = 5;
                dgv_KhoHang.Columns[0].Name = "ID";
                dgv_KhoHang.Columns[1].Name = "Mã Chi Tiết Kho";
                dgv_KhoHang.Columns.Add(cmCTSP);
                dgv_KhoHang.Columns["cmbCTSP"].DisplayIndex = 2;
                dgv_KhoHang.Columns[2].Name = "Tên SP";
                dgv_KhoHang.Columns[3].Name = "Giá Bán";
                dgv_KhoHang.Columns[4].Name = "Mã Kho";
                dgv_KhoHang.Columns.Add(cmSoLUong);
                dgv_KhoHang.Columns.Add(CbxColumn);
                dgv_KhoHang.Columns.Add(btnXoaGrid);
                dgv_KhoHang.Columns[0].Visible = false;
                dgv_KhoHang.Columns[1].Visible = false;
                dgv_KhoHang.Columns[4].Visible = false;
                dgv_KhoHang.Rows.Clear();
                foreach (var x in _servicesKhoHang.TimKiemSP(mactsp))
                {
                    if (x.TrangThai == 0)
                    {
                        dgv_KhoHang.Rows.Add(x.Id, x.MaCtkho, x.TenSP, string.Format("{0:#,##0.00}", x.GiaBan )+ " VNĐ", x.MaKho, x.MaCtsp, x.SoLuong);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void loadHDXuat()
        {
            try
            {
                dgv_HĐXuat.ColumnCount = 4;
                dgv_HĐXuat.Columns[0].Name = "mã phiếu xuất";
                dgv_HĐXuat.Columns[1].Name = "ngày tạo phiêu";
                dgv_HĐXuat.Columns[2].Name = "mã kho";
                dgv_HĐXuat.Columns[3].Name = "trạng thái";
                dgv_HĐXuat.Columns[2].Visible = false;
                dgv_HĐXuat.Columns[3].Visible = false;
                dgv_HĐXuat.Rows.Clear();
                foreach (var x in _serviceQLHDXuat.GetPhieuXuatKhos())
                {
                    if (x.TrangThai != 1)
                    {
                        dgv_HĐXuat.Rows.Add(x.MaPhieuXuat, x.NgayTaoPhieu, x.MaKho, x.TrangThai == 0 ? "chưa thanh toán" : "đã thanh toán");
                    }

                }
            }
            catch (Exception)
            {
                return;
            }

        }


        void loadcthdXuat(string mapx)
        {
            try
            {
                //DataGridViewCheckBoxColumn ckbx = new DataGridViewCheckBoxColumn();
                //ckbx.HeaderText = "Tích";
                //ckbx.Name = "ckbx";
                dgv_CTHD.ColumnCount = 6;
                dgv_CTHD.Columns[0].Name = "Mã Phiếu Xuất";
                dgv_CTHD.Columns[1].Name = "Chi Tiết Kho";
                dgv_CTHD.Columns[2].Name = "Yêu Cầu";
                dgv_CTHD.Columns[3].Name = "Thực Xuất";
                dgv_CTHD.Columns[4].Name = "Xuất thiếu";
                dgv_CTHD.Columns[5].Name = "Trạng Thái";
                //dgv_CTHD.Columns.Add(ckbx);
                dgv_CTHD.Rows.Clear();
                foreach (var x in _serviceQLHDXuat.GetLstCTPhieuXuats(mapx))
                {
                    if (x.TrangThai == 2 || x.TrangThai == 3)
                    {
                        dgv_CTHD.Rows.Add(x.MaPhieuXuat, x.MaCtkho, x.YeuCau, x.ThucXuat, x.YeuCau - x.ThucXuat, x.TrangThai == 2 ? "Xuất Thiếu" : "Xuất đủ");
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }
        void loadtreo()
        {
            dgv_CTHD.ColumnCount = 4;
            dgv_CTHD.Columns[0].Name = "Mã Phiếu Xuất";
            dgv_CTHD.Columns[1].Name = "Chi Tiết Kho";
            dgv_CTHD.Columns[2].Name = "Yêu Cầu";
            dgv_CTHD.Columns[3].Name = "Thực Xuất";
            dgv_CTHD.Rows.Clear();

        }
        private void dgv_KhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == _servicesKhoHang.LstDVKhoHangs().Count + 1) return;
                if (rowindex == -1) return;
                if (e.ColumnIndex == -1) return;
                int index = 0;
                dgv_KhoHang.Rows[rowindex].Cells[3].ReadOnly = true;
                dgv_KhoHang.Rows[rowindex].Cells[2].ReadOnly = true;
                //if (e.RowIndex != -1)
                //{

                //    if (e.ColumnIndex == 6)
                //    {
                //        // Initialize the dateTimePicker1.
                //        dtp = new DateTimePicker();
                //        // Adding the dateTimePicker1 into DataGridView.   
                //        dgv_KhoHang.Controls.Add(dtp);
                //        // Setting the format i.e. mm/dd/yyyy)
                //        dtp.Format = DateTimePickerFormat.Short;
                //        // Create retangular area that represents the display area for a cell.
                //        Rectangle oRectangle = dgv_KhoHang.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //        // Setting area for dateTimePicker1.
                //        dtp.Size = new Size(oRectangle.Width, oRectangle.Height);
                //        // Setting location for dateTimePicker1.
                //        dtp.Location = new Point(oRectangle.X, oRectangle.Y);
                //        // An event attached to dateTimePicker1 which is fired when any date is selected.
                //        dtp.TextChanged += new EventHandler(DateTimePickerChange);
                //        // An event attached to dateTimePicker1 which is fired when DateTimeControl is closed.
                //        dtp.CloseUp += new EventHandler(DateTimePickerClose);
                //    }
                //}
                if (e.ColumnIndex == 6)
                {
                    if (dgv_KhoHang.Rows[rowindex].Cells[6].Value == null)
                    {
                        return;
                    }
                }
                for (int i = 0; i < _servicesKhoHang.SoLuong().Length; i++)
                {
                    if (_servicesKhoHang.SoLuong()[i] == Convert.ToInt32(dgv_KhoHang.Rows[rowindex].Cells[6].Value))
                    {
                        index = i;
                    }
                }
                dgv_KhoHang.Rows[rowindex].Cells[6].Value = (dgv_KhoHang.Rows[rowindex].Cells[6] as DataGridViewComboBoxCell).Items[index];
                if (dgv_KhoHang.Columns[5].Name == "cmbCTSP")
                {
                    if (dgv_KhoHang.Rows[rowindex].Cells[5].Value == null)
                    {
                        return;
                    }
                    if (dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString() == _servicesKhoHang.GetChiTietSanPhams().Where(c => c.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString()).Select(c => c.MaCtsp).FirstOrDefault())
                    {
                        dgv_KhoHang.Rows[rowindex].Cells[2].Value = _servicesKhoHang.GetChiTietSanPhams().Where(c => c.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString()).Select(c => c.TenSp).FirstOrDefault();
                        dgv_KhoHang.Rows[rowindex].Cells[3].Value = string.Format("{0:#,##0.00}", _servicesKhoHang.GetChiTietSanPhams().Where(c => c.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString()).Select(c => c.GiaBan).FirstOrDefault() ) + " VNĐ";
                    }

                }
                if (dgv_KhoHang.Columns[e.ColumnIndex].Name == "Column_btnGrid")
                {
                    if (dgv_KhoHang.Columns[7].Name == "cmbChucNang")
                    {
                        if (dgv_KhoHang.Rows[rowindex].Cells[7].Value == null)
                        {
                            MessageBox.Show("Chưa chọn chức năng");
                            return;
                        }
                        if (dgv_KhoHang.Rows[rowindex].Cells[7].Value.ToString() == "Thêm")
                        {
                            if (dgv_KhoHang.Rows[rowindex].Cells[1].Value != null)
                            {
                                if (_servicesKhoHang.GetChiTietKhos().Any(c => c.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString() && c.TrangThai == 0))
                                {
                                    MessageBox.Show("Không thực hiện được nút thêm tại dòng này");
                                    txtTimKiem.Text = "";
                                    load();
                                    return;
                                }
                            }

                            if (_servicesKhoHang.GetChiTietKhos().Any(c => c.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString() && c.TrangThai == 0))
                            {
                                foreach (var x in _servicesKhoHang.GetChiTietKhos())
                                {
                                    if (dgv_KhoHang.Rows[rowindex].Cells[5].Value == null)
                                    {
                                        return;
                                    }
                                    else if (x.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString() && x.TrangThai == 0)
                                    {

                                        x.SoLuong = x.SoLuong + Convert.ToInt32(dgv_KhoHang.Rows[rowindex].Cells[6].Value.ToString());
                                        MessageBox.Show(_servicesKhoHang.EditCTKho(x), "Thông báo");
                                        load();
                                    }
                                }
                            }
                            else
                            {
                                _ChiTietKhoHang = new ChiTietKhoHang();
                                _ChiTietKhoHang.MaCtsp = dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString();
                                _ChiTietKhoHang.SoLuong = Convert.ToInt32(dgv_KhoHang.Rows[rowindex].Cells[6].Value.ToString());

                                MessageBox.Show(_servicesKhoHang.AddCTKho(_ChiTietKhoHang), "Thông báo");
                                load();

                            }
                        }

                        else if (dgv_KhoHang.Rows[rowindex].Cells[7].Value.ToString() == "Sửa")
                        {

                            _ChiTietKhoHang = _servicesKhoHang.GetChiTietKhos().Where(c => c.Id == Convert.ToInt32(dgv_KhoHang.Rows[rowindex].Cells[0].Value.ToString())).FirstOrDefault();
                            //if (_servicesKhoHang.GetChiTietKhos().Any(c => c.MaCtsp == dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString() && c.TrangThai == 0))
                            //{
                            //    MessageBox.Show("mã CTSP này đã tồn tại trong kho");
                            //    return;
                            //}
                            //else
                            //{
                            _ChiTietKhoHang.MaCtsp = dgv_KhoHang.Rows[rowindex].Cells[5].Value.ToString();
                            //}

                            _ChiTietKhoHang.SoLuong = Convert.ToInt32(dgv_KhoHang.Rows[rowindex].Cells[6].Value.ToString());
                            MessageBox.Show(_servicesKhoHang.EditCTKho(_ChiTietKhoHang), "Thông báo");
                            load();
                        }

                        else if (dgv_KhoHang.Rows[rowindex].Cells[7].Value.ToString() == "Xóa")
                        {
                            _ChiTietKhoHang = _servicesKhoHang.GetChiTietKhos().Where(c => c.Id == Convert.ToInt32(dgv_KhoHang.Rows[rowindex].Cells[0].Value.ToString())).FirstOrDefault();
                            MessageBox.Show(_servicesKhoHang.DeleteCTKh(_ChiTietKhoHang), "Thông báo");
                            load();
                        }

                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void DateTimePickerChange(object sender, EventArgs e)
        {
            dgv_KhoHang.CurrentCell.Value = dtp.Text.ToString();
            //MessageBox.Show(string.Format("Date changed to {0}", dtp.Text.ToString()));
        }

        private void DateTimePickerClose(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }


        private void dgv_HĐXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var rowindex = e.RowIndex;
                if (rowindex == -1) return;
                if (e.ColumnIndex == -1) return;
                if (dgv_HĐXuat.Rows[rowindex].Cells[0].Value != null)
                {
                    _mapx = dgv_HĐXuat.Rows[rowindex].Cells[0].Value.ToString();
                    loadcthdXuat(dgv_HĐXuat.Rows[rowindex].Cells[0].Value.ToString());
                }
            }
            catch (Exception)
            {
                return;
            }
        }



        //private void btn_ThanhToan_Click(object sender, EventArgs e)
        //{
        //    //HoaDon hoaDon = _serviceHD.GetLstHoaDon().Where(c => c.MaHd == _mahd).FirstOrDefault();
        //    if (dgv_CTHD.RowCount == 0)
        //    {
        //        MessageBox.Show("Chưa chọn phiếu");
        //        return;
        //    }
        //    foreach (DataGridViewRow i in dgv_CTHD.Rows)
        //    {
        //        bool check = Convert.ToBoolean(i.Cells["ckbx"].Value);

        //        if (check)
        //        {
        //            var kho = _servicesKhoHang.GetChiTietKhos().Where(c => c.MaCtkho == i.Cells[1].Value.ToString() && c.MaCtkho == i.Cells[1].Value.ToString()).FirstOrDefault();
        //            if (_serviceQLHDXuat.GetPhieuXuatKhos().Where(c => c.MaPhieuXuat == _mapx).Select(c => c.TrangThai).FirstOrDefault() == 2)
        //            {
        //                MessageBox.Show("Hóa đơn đã thanh toán rồi");
        //                return;
        //            }
        //            if (kho.SoLuong > Convert.ToInt32(i.Cells[3].Value))
        //            {
        //                kho.SoLuong = kho.SoLuong - Convert.ToInt32(i.Cells[3].Value);
        //                ChiTietSanPham chiTietSanPham = _serviceChiTietSP.GetLstChiTietSP().Where(c => c.MaCtsp == kho.MaCtsp.ToString()).FirstOrDefault();
        //                chiTietSanPham.SoLuong = chiTietSanPham.SoLuong + Convert.ToInt32(i.Cells[3].Value);
        //                var ctpx = _serviceQLHDXuat.GetLstCTPhieuXuat().Where(c => c.MaPhieuXuat == i.Cells[0].Value.ToString() && c.MaCtkho == i.Cells[1].Value.ToString()).FirstOrDefault();
        //                ctpx.TrangThai = 2;
        //                _servicesKhoHang.EditCTKho(kho);
        //                _serviceChiTietSP.EditChiTietSP(chiTietSanPham);

        //                _serviceQLHDXuat.EditCTPhieuXuat(ctpx);

        //                MessageBox.Show("thanh cong");
        //                loadKho();
        //                loadHDXuat();
        //            }

        //            if (kho.SoLuong < Convert.ToInt32(i.Cells[3].Value))
        //            {
        //                _SoLuongCuaKho = Convert.ToString(kho.SoLuong);
        //                _SoDu = Convert.ToString(Convert.ToInt32(i.Cells[3].Value) - kho.SoLuong);
        //                kho.SoLuong = 0;
        //                ChiTietSanPham chiTietSanPham = _serviceChiTietSP.GetLstChiTietSP().Where(c => c.MaCtsp == kho.MaCtsp.ToString()).FirstOrDefault();
        //                chiTietSanPham.SoLuong = chiTietSanPham.SoLuong + Convert.ToInt32(i.Cells[3].Value);
        //                var ctpx = _serviceQLHDXuat.GetLstCTPhieuXuat().Where(c => c.MaPhieuXuat == i.Cells[0].Value.ToString() && c.MaCtkho == i.Cells[1].Value.ToString()).FirstOrDefault();
        //                ctpx.TrangThai = 2;
        //                _servicesKhoHang.EditCTKho(kho);
        //                _serviceChiTietSP.EditChiTietSP(chiTietSanPham);
        //                _serviceQLHDXuat.EditCTPhieuXuat(ctpx);
        //                MessageBox.Show(string.Format("Đã xuất khỏi kho: {0}, số lượng thiếu: {1},yêu cầu nhập thêm: {1}", _SoLuongCuaKho, _SoDu));
        //                loadKho();
        //                loadHDXuat();
        //            }

        //        }

        //    }

        //    loadcthdXuat(_mapx);
        //    foreach (DataGridViewRow i in dgv_CTHD.Rows)
        //    {
        //        if (i.IsNewRow && i.Index == 0)
        //        {

        //            var pn = _serviceQLHDXuat.GetPhieuXuatKhos().Where(c => c.MaPhieuXuat == _mapx).FirstOrDefault();
        //            pn.TrangThai = 2;
        //            _serviceQLHDXuat.EditPhieuXuat(pn);
        //            loadHDXuat();
        //        }
        //    }
        //}

        //private void btn_HDXuat_Click(object sender, EventArgs e)
        //{
        //    HoaDon hoadon = new HoaDon();
        //    FrmHoa_Don_Xuat frmHoa_Don_Xuat = new FrmHoa_Don_Xuat();
        //    frmHoa_Don_Xuat.Show();
        //}

        private void dgv_KhoHang_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_CTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1) return;
                if (e.ColumnIndex == -1) return;
                //dgv_CTHD.Rows[rowindex].Cells[4].Value = false;
                //if ((bool)dgv_CTHD.Rows[rowindex].Cells[4].Value == false)
                //{
                //    dgv_CTHD.Rows[rowindex].Cells[4].Value = true;
                //}
                //else
                //{
                //    dgv_CTHD.Rows[rowindex].Cells[4].Value = false;
                //}
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            loadTimKiemSP(txtTimKiem.Text);
        }

        private void btn_LoadForm_Click(object sender, EventArgs e)
        {
            load();
        }


    }
}
