using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using _2_BUS.Service;
using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace _3_GUI
{
    public partial class FrmHoa_Don_Xuat : Form
    {
        private IServiceQLHDXuat _serviceQLHDXuat;
        private DateTimePicker dtp;
        private string _mactsp;
        private IQlKhoHang _qlKhoHang;
        private PhieuXuatKho _PhieuXuatKho;
        private ChiTietPhieuXuat _ChiTietPhieuXuat;
        private IPhieuNhapService _phieuNhapService;
        private IQLCTPhieuNhap _qLCTPhieuNhap;
        private IQlKhoHang _servicesKhoHang;
        private IServiceChiTietSP _serviceChiTietSP;
        private string _mapn;
        private string _SoDu;
        private string _SoLuongCuaKho;
        private NhanVien _nv;
        public FrmHoa_Don_Xuat()
        {

            InitializeComponent();
            _serviceQLHDXuat = new ServiceQLHDXuat();
            _qlKhoHang = new QLKhoHang();
            _phieuNhapService = new PhieuNhapService();
            _qLCTPhieuNhap = new QLCTPhieuNhap();
            _serviceChiTietSP = new ServiceChiTietSP();
            _servicesKhoHang = new QLKhoHang();
            Load();
            LoadPhieuYeuCau();


        }
        public void NhanVien(NhanVien nv)
        {
            _nv = nv;
        }
        void LoadTreo()
        {
            dgv_CTTPX.Columns.Clear();
        }
        void Load()
        {
            try
            {
                //DataGridViewButtonColumn btnXoaGrid = new DataGridViewButtonColumn();
                //btnXoaGrid.Name = "Column_btnGrid";
                //btnXoaGrid.HeaderText = "Nút";
                //btnXoaGrid.UseColumnTextForButtonValue = true;
                //btnXoaGrid.Text = "Xác nhận";

                //DataGridViewComboBoxColumn cmbYeuCau = new DataGridViewComboBoxColumn();
                //cmbYeuCau.HeaderText = "Yêu Cầu";
                //cmbYeuCau.Name = "cmbYeuCau";
                //cmbYeuCau.DataSource = _serviceQLHDXuat.SoLuong();

                //DataGridViewComboBoxColumn cmbThucNhap = new DataGridViewComboBoxColumn();
                //cmbThucNhap.HeaderText = "Thực Xuất";
                //cmbThucNhap.Name = "cmbThucNhap";
                //cmbThucNhap.DataSource = _serviceQLHDXuat.SoLuong();





                //DataGridViewComboBoxColumn CbxColumn = new DataGridViewComboBoxColumn();
                //CbxColumn.HeaderText = "Chức năng";
                //CbxColumn.Name = "cmbChucNang";
                //CbxColumn.Items.Add("Thêm");
                //CbxColumn.Items.Add("Sửa");
                //CbxColumn.Items.Add("Xóa");

                //DataGridViewTextBoxColumn txtNgay = new DataGridViewTextBoxColumn();
                //txtNgay.HeaderText = "Ngày Tạo Phiếu";
                //txtNgay.Name = "txtNgay";
                //DateTimePicker dtp = new DateTimePicker();
                //dtp.Format = DateTimePickerFormat.Short;
                //dtp.Visible = true;

                dgv_PhieuXuat.ColumnCount = 3;
                dgv_PhieuXuat.Columns[0].Name = "Mã Phiếu Xuất";
                dgv_PhieuXuat.Columns[1].Name = "Ngày tạo Phiếu";
                dgv_PhieuXuat.Columns[2].Name = "Trạng Thái";
                dgv_PhieuXuat.Columns[2].Visible = false;
                dgv_PhieuXuat.Rows.Clear();
                foreach (var x in _serviceQLHDXuat.GetPhieuXuatKhos())
                {
                    if (x.TrangThai != 1)
                    {
                        dgv_PhieuXuat.Rows.Add(x.MaPhieuXuat, x.NgayTaoPhieu, x.TrangThai == 0 ? "Chưa Xác Nhận" : "Xác Nhận");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void LoadTìmKiem()
        {
            try
            {
                //DataGridViewButtonColumn btnXoaGrid = new DataGridViewButtonColumn();
                //btnXoaGrid.Name = "Column_btnGrid";
                //btnXoaGrid.HeaderText = "Nút";
                //btnXoaGrid.UseColumnTextForButtonValue = true;
                //btnXoaGrid.Text = "Xác nhận";

                //DataGridViewComboBoxColumn cmbYeuCau = new DataGridViewComboBoxColumn();
                //cmbYeuCau.HeaderText = "Yêu Cầu";
                //cmbYeuCau.Name = "cmbYeuCau";
                //cmbYeuCau.DataSource = _serviceQLHDXuat.SoLuong();

                //DataGridViewComboBoxColumn cmbThucNhap = new DataGridViewComboBoxColumn();
                //cmbThucNhap.HeaderText = "Thực Xuất";
                //cmbThucNhap.Name = "cmbThucNhap";
                //cmbThucNhap.DataSource = _serviceQLHDXuat.SoLuong();





                //DataGridViewComboBoxColumn CbxColumn = new DataGridViewComboBoxColumn();
                //CbxColumn.HeaderText = "Chức năng";
                //CbxColumn.Name = "cmbChucNang";
                //CbxColumn.Items.Add("Thêm");
                //CbxColumn.Items.Add("Sửa");
                //CbxColumn.Items.Add("Xóa");

                //DataGridViewTextBoxColumn txtNgay = new DataGridViewTextBoxColumn();
                //txtNgay.HeaderText = "Ngày Tạo Phiếu";
                //txtNgay.Name = "txtNgay";
                //DateTimePicker dtp = new DateTimePicker();
                //dtp.Format = DateTimePickerFormat.Short;
                //dtp.Visible = true;

                dgv_PhieuXuat.ColumnCount = 3;
                dgv_PhieuXuat.Columns[0].Name = "Mã Phiếu Xuất";
                dgv_PhieuXuat.Columns[1].Name = "Ngày tạo Phiếu";
                dgv_PhieuXuat.Columns[2].Name = "Trạng Thái";
                dgv_PhieuXuat.Columns[2].Visible = false;
                dgv_PhieuXuat.Rows.Clear();
                foreach (var x in _serviceQLHDXuat.GetPhieuXuatKhos().Where(c => c.NgayTaoPhieu == dtpTimKiem.Value.Date))
                {
                    if (x.TrangThai != 1)
                    {
                        dgv_PhieuXuat.Rows.Add(x.MaPhieuXuat, x.NgayTaoPhieu, x.TrangThai == 0 ? "Chưa Xác Nhận" : "Xác Nhận");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void LoadPhieuYeuCau()
        {
            try
            {
                //DataGridViewCheckBoxColumn ckbx = new DataGridViewCheckBoxColumn();
                //ckbx.HeaderText = "Tích";
                //ckbx.Name = "ckbx";
                dgv_YeuCau.ColumnCount = 3;
                dgv_YeuCau.Columns[0].Name = "Mã Phiếu Nhập";
                dgv_YeuCau.Columns[1].Name = "Ngày Tạo Phiếu";
                dgv_YeuCau.Columns[2].Name = "Trạng Thái";
                dgv_YeuCau.Rows.Clear();
                foreach (var x in _phieuNhapService.GetLstPhieuNhap())
                {
                    if (x.TrangThai == 0)
                    {
                        dgv_YeuCau.Rows.Add(x.MaPhieuNhap, x.NgayTaoPhieu, x.TrangThai == 0 ? "Chưa hoàn thành" : "Nhập Thiếu");
                    }


                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void LoadCTPN(string mapn)
        {
            try
            {
                DataGridViewCheckBoxColumn ckbx = new DataGridViewCheckBoxColumn();
                ckbx.HeaderText = "Tích";
                ckbx.Name = "ckbx";
                //DataGridViewComboBoxColumn cmbThucNhap = new DataGridViewComboBoxColumn();
                //cmbThucNhap.HeaderText = "Thực Xuất";
                //cmbThucNhap.Name = "cmbThucNhap";
                //cmbThucNhap.DataSource = _serviceQLHDXuat.SoLuong();
                //foreach (var x in _serviceQLHDXuat.GetChiTietKhoHangs())
                //{
                //    if (!(cmbKho.Items.Contains(x.MaKho)))
                //    {
                //        cmbKho.Items.Add(x.MaKho);
                //    }
                //}
                dgv_CTTPX.ColumnCount = 5;
                dgv_CTTPX.Columns[0].Name = "Mã Phiếu Nhập";
                dgv_CTTPX.Columns[1].Name = "Mã Chi Tiết Sản Phẩm";
                dgv_CTTPX.Columns[2].Name = "Tên Sản Phẩm";
                dgv_CTTPX.Columns[3].Name = "Yêu Cầu";
                //dgv_CTTPX.Columns.Add(cmbThucNhap);
                //dgv_CTTPX.Columns["cmbThucNhap"].DisplayIndex = 4;
                //dgv_CTTPX.Columns.Add(cmbKho1);
                //dgv_CTTPX.Columns["cmbKho1"].DisplayIndex = 5;
                dgv_CTTPX.Columns[4].Name = "Thực Xuất";

                dgv_CTTPX.Columns.Add(ckbx);
                dgv_CTTPX.Columns[0].Visible = false;
                dgv_CTTPX.Rows.Clear();
                foreach (var x in _qLCTPhieuNhap.GetChiTietPhieuNhaps(mapn))
                {
                    if (x.TrangThai == 0)
                    {
                        dgv_CTTPX.Rows.Add(x.MaPhieuNhap, x.MaCtsp, x.TenSp, x.SoLuong);
                    }

                }
            }
            catch (Exception)
            {
                return;
            }
        }
        void LoadCTPX(string mapx)
        {
            try
            {
                //DataGridViewCheckBoxColumn ckbx = new DataGridViewCheckBoxColumn();
                //ckbx.HeaderText = "Tích";
                //ckbx.Name = "ckbx";
                //DataGridViewComboBoxColumn cmbThucNhap = new DataGridViewComboBoxColumn();
                //cmbThucNhap.HeaderText = "Thực Xuất";
                //cmbThucNhap.Name = "cmbThucNhap";
                //cmbThucNhap.DataSource = _serviceQLHDXuat.SoLuong();
                //foreach (var x in _serviceQLHDXuat.GetChiTietKhoHangs())
                //{
                //    if (!(cmbKho.Items.Contains(x.MaKho)))
                //    {
                //        cmbKho.Items.Add(x.MaKho);
                //    }
                //}
                dgv_CTTPX.Columns.Clear();
                dgv_CTTPX.ColumnCount = 6;
                dgv_CTTPX.Columns[0].Name = "Mã Phiếu Xuất";
                dgv_CTTPX.Columns[1].Name = "Mã Chi Tiết Kho";
                dgv_CTTPX.Columns[2].Name = "Yêu Cầu";
                dgv_CTTPX.Columns[3].Name = "Thực xuất";
                dgv_CTTPX.Columns[4].Name = "Xuất thiếu";
                dgv_CTTPX.Columns[5].Name = "Trạng Thái";
                //dgv_CTTPX.Columns.Add(cmbThucNhap);
                //dgv_CTTPX.Columns["cmbThucNhap"].DisplayIndex = 4;
                //dgv_CTTPX.Columns.Add(cmbKho1);
                //dgv_CTTPX.Columns["cmbKho1"].DisplayIndex = 5;
                dgv_CTTPX.Columns[0].Visible = false;
                dgv_CTTPX.Rows.Clear();
                foreach (var x in _serviceQLHDXuat.GetLstCTPhieuXuats(mapx))
                {
                    if (x.TrangThai == 2 || x.TrangThai == 3)
                    {
                        dgv_CTTPX.Rows.Add(x.MaPhieuXuat, x.MaCtkho, x.YeuCau, x.ThucXuat, x.YeuCau - x.ThucXuat, x.TrangThai == 2 ? "Xuất Thiếu" : "Xuất đủ");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dgv_PhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == _serviceQLHDXuat.GetLSTDSPhieuXuats().Count) return;
                if (rowindex == -1) return;
                if (e.ColumnIndex == -1) return;
                if (dgv_PhieuXuat.Rows[rowindex].Cells[0].Value != null)
                {
                    LoadCTPX(dgv_PhieuXuat.Rows[rowindex].Cells[0].Value.ToString());
                    btn_TaoPhieu.Visible = false;
                }
                //int soYeuCau = 0;
                //int SoThucNhap = 0;
                //if (e.RowIndex != -1)
                //{

                //    if (e.ColumnIndex == 7)
                //    {
                //        // Initialize the dateTimePicker1.
                //        dtp = new DateTimePicker();
                //        // Adding the dateTimePicker1 into DataGridView.   
                //        dgv_PhieuXuat.Controls.Add(dtp);
                //        // Setting the format i.e. mm/dd/yyyy)
                //        dtp.Format = DateTimePickerFormat.Short;
                //        // Create retangular area that represents the display area for a cell.
                //        Rectangle oRectangle = dgv_PhieuXuat.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
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

                //if (e.ColumnIndex == 5)
                //{
                //    if (dgv_PhieuXuat.Rows[rowindex].Cells[5].Value == null)
                //    {
                //        return;
                //    }

                //}
                //for (int i = 0; i < _serviceQLHDXuat.SoLuong().Length; i++)
                //{
                //    if (_serviceQLHDXuat.SoLuong()[i] == Convert.ToInt32(dgv_PhieuXuat.Rows[rowindex].Cells[5].Value))
                //    {
                //        soYeuCau = i;
                //    }
                //}
                //if (e.ColumnIndex == 6)
                //{
                //    if (dgv_PhieuXuat.Rows[rowindex].Cells[6].Value == null)
                //    {
                //        return;
                //    }

                //}
                //for (int i = 0; i < _serviceQLHDXuat.SoLuong().Length; i++)
                //{
                //    if (_serviceQLHDXuat.SoLuong()[i] == Convert.ToInt32(dgv_PhieuXuat.Rows[rowindex].Cells[6].Value))
                //    {
                //        SoThucNhap = i;
                //    }
                //}
                //dgv_PhieuXuat.Rows[rowindex].Cells[5].Value = (dgv_PhieuXuat.Rows[rowindex].Cells[5] as DataGridViewComboBoxCell).Items[soYeuCau];
                //dgv_PhieuXuat.Rows[rowindex].Cells[6].Value = (dgv_PhieuXuat.Rows[rowindex].Cells[6] as DataGridViewComboBoxCell).Items[SoThucNhap];
                //if (dgv_PhieuXuat.Columns[3].Name == "cmbCTSP")
                //{
                //    if (dgv_PhieuXuat.Rows[rowindex].Cells[3].Value == null)
                //    {
                //        return;
                //    }
                //    if (dgv_PhieuXuat.Rows[rowindex].Cells[3].Value.ToString() == _serviceQLHDXuat.GetlstCTSP().Where(c => c.MaCtsp == dgv_PhieuXuat.Rows[rowindex].Cells[3].Value.ToString()).Select(c => c.MaCtsp).FirstOrDefault())
                //    {
                //        dgv_PhieuXuat.Rows[rowindex].Cells[1].Value = _serviceQLHDXuat.GetlstCTSP().Where(c => c.MaCtsp == dgv_PhieuXuat.Rows[rowindex].Cells[3].Value.ToString()).Select(c => c.TenSp).FirstOrDefault();
                //    }

                //}
                //if (dgv_PhieuXuat.Columns[4].Name == "cmbKho")
                //{
                //    //var id = _serviceQLHDXuat.GetChiTietKhoHangs().Where(c => c.MaCtsp == dgv_PhieuXuat.Rows[rowindex].Cells[3].Value.ToString()).Select(c => c.MaKho).ToList();
                //    //cmbKho.Items.Clear();
                //    //foreach (var x in id)
                //    //{
                //    //    cmbKho.Items.Add(x);

                //    //}
                //    if (dgv_PhieuXuat.Rows[rowindex].Cells[4].Value == null)
                //    {
                //        return;
                //    }
                //    if (dgv_PhieuXuat.Rows[rowindex].Cells[4].Value.ToString() == _serviceQLHDXuat.GetChiTietKhoHangs().Where(c => c.MaKho == dgv_PhieuXuat.Rows[rowindex].Cells[4].Value.ToString()).Select(c => c.MaKho).FirstOrDefault())
                //    {
                //        dgv_PhieuXuat.Rows[rowindex].Cells[2].Value = _serviceQLHDXuat.GetChiTietKhoHangs().Where(c => c.MaKho == dgv_PhieuXuat.Rows[rowindex].Cells[4].Value.ToString() && c.MaCtsp == dgv_PhieuXuat.Rows[rowindex].Cells[3].Value.ToString()).Select(c => c.MaCtkho).FirstOrDefault();
                //    }
                //}

                //if (dgv_PhieuXuat.Columns[e.ColumnIndex].Name == "Column_btnGrid")
                //{
                //    if (dgv_PhieuXuat.Columns[8].Name == "cmbChucNang")
                //    {
                //        if (dgv_PhieuXuat.Rows[rowindex].Cells[8].Value == null)
                //        {
                //            MessageBox.Show("Chưa chọn chức năng");
                //            return;
                //        }
                //        if (dgv_PhieuXuat.Rows[rowindex].Cells[8].Value.ToString() == "Thêm")
                //        {
                //            _PhieuXuatKho = new PhieuXuatKho();
                //            _PhieuXuatKho.Id = _serviceQLHDXuat.GetPhieuXuatKhos().Max(c => c.Id) + 1;
                //            _PhieuXuatKho.MaPhieuXuat = "PX" + _PhieuXuatKho.Id;
                //            if (dgv_PhieuXuat.Rows[rowindex].Cells[7].Value == null)
                //            {
                //                _PhieuXuatKho.NgayTaoPhieu = DateTime.Now;
                //            }
                //            else
                //            {
                //                _PhieuXuatKho.NgayTaoPhieu = Convert.ToDateTime(dgv_PhieuXuat.Rows[rowindex].Cells[7].Value.ToString());
                //            }
                //            _PhieuXuatKho.MaKho = dgv_PhieuXuat.Rows[rowindex].Cells[4].Value.ToString();
                //            _PhieuXuatKho.TrangThai = 0;

                //            _ChiTietPhieuXuat = new ChiTietPhieuXuat();
                //            _ChiTietPhieuXuat.MaCtkho = dgv_PhieuXuat.Rows[rowindex].Cells[2].Value.ToString();
                //            _ChiTietPhieuXuat.MaPhieuXuat = "PX" + _PhieuXuatKho.Id;
                //            _ChiTietPhieuXuat.YeuCau = Convert.ToInt32(dgv_PhieuXuat.Rows[rowindex].Cells[5].Value.ToString());
                //            _ChiTietPhieuXuat.ThucXuat = Convert.ToInt32(dgv_PhieuXuat.Rows[rowindex].Cells[6].Value.ToString());
                //            _ChiTietPhieuXuat.TrangThai = 0;
                //            _serviceQLHDXuat.AddPhieuXuat(_PhieuXuatKho);
                //            _serviceQLHDXuat.AddCTPhieuXuat(_ChiTietPhieuXuat);
                //            MessageBox.Show("Thành Công");
                //            Load();
                //        }

                //        else if (dgv_PhieuXuat.Rows[rowindex].Cells[8].Value.ToString() == "Sửa")
                //        {
                //            var id = _serviceQLHDXuat.GetPhieuXuatKhos().Where(c => c.MaPhieuXuat == dgv_PhieuXuat.Rows[rowindex].Cells[0].Value.ToString()).FirstOrDefault();
                //            var id1 = _serviceQLHDXuat.GetLstCTPhieuXuat().Where(c => c.MaPhieuXuat == dgv_PhieuXuat.Rows[rowindex].Cells[0].Value.ToString() && c.MaCtkho == dgv_PhieuXuat.Rows[rowindex].Cells[2].Value.ToString()).FirstOrDefault();
                //            id1.ThucXuat = Convert.ToInt32(dgv_PhieuXuat.Rows[rowindex].Cells[6].Value.ToString());
                //            id1.YeuCau = Convert.ToInt32(dgv_PhieuXuat.Rows[rowindex].Cells[5].Value.ToString());
                //            id.NgayTaoPhieu = Convert.ToDateTime(dgv_PhieuXuat.Rows[rowindex].Cells[7].Value.ToString());
                //            _serviceQLHDXuat.EditPhieuXuat(id);
                //            _serviceQLHDXuat.EditCTPhieuXuat(id1);
                //            MessageBox.Show("Thành Công");
                //            Load();
                //        }

                //        else if (dgv_PhieuXuat.Rows[rowindex].Cells[8].Value.ToString() == "Xóa")
                //        {
                //            var id2 = _serviceQLHDXuat.GetLstCTPhieuXuat().Where(c => c.MaPhieuXuat == dgv_PhieuXuat.Rows[rowindex].Cells[0].Value.ToString() && c.MaCtkho == dgv_PhieuXuat.Rows[rowindex].Cells[2].Value.ToString()).FirstOrDefault();
                //            MessageBox.Show(_serviceQLHDXuat.DeleteCTPhieuXuat(id2), "Thong bao");
                //            Load();
                //        }

                //    }
                //}
            }
            catch (Exception)
            {
                return;
            }
        }

        private void dgv_PhieuXuat_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_CTTPX_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_YeuCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1) return;
                if (e.ColumnIndex == -1) return;
                if (dgv_YeuCau.Rows[rowindex].Cells[0].Value != null)
                {
                    _mapn = dgv_YeuCau.Rows[rowindex].Cells[0].Value.ToString();
                    LoadCTPN(dgv_YeuCau.Rows[rowindex].Cells[0].Value.ToString());
                    btn_TaoPhieu.Visible = true;
                }
            }
            catch (Exception)
            {
                return;
            }

        }
        private void btn_TaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_CTTPX.RowCount == 0)
                {
                    MessageBox.Show("Chưa chọn phiếu yêu cầu");
                    return;

                }

                _PhieuXuatKho = new PhieuXuatKho();
                if (_serviceQLHDXuat.GetPhieuXuatKhos().Count == 0)
                {
                    _PhieuXuatKho.Id = 1;
                }
                else
                {
                    _PhieuXuatKho.Id = _serviceQLHDXuat.GetPhieuXuatKhos().Max(c => c.Id) + 1;
                }
                _PhieuXuatKho.MaPhieuXuat = "PX" + _PhieuXuatKho.Id;
                _PhieuXuatKho.NgayTaoPhieu = DateTime.Now;
                _PhieuXuatKho.MaKho = "K1";
                _PhieuXuatKho.TrangThai = 0;
                _PhieuXuatKho.MaNV = _nv.MaNv;
                foreach (DataGridViewRow i in dgv_CTTPX.Rows)
                {
                    //if (i.IsNewRow)
                    //{
                    //    //var pn = _phieuNhapService.GetLstPhieuNhap().Where(c => c.MaPhieuNhap == _mapn).FirstOrDefault();
                    //    //pn.TrangThai = 2;
                    //    //_phieuNhapService.EditPhieuNhap(pn);
                    //    //LoadPhieuYeuCau();
                    //    return;
                    //}
                    bool check = Convert.ToBoolean(i.Cells["ckbx"].Value);
                    if (check)
                    {
                        if (i.Cells[4].Value == null)
                        {
                            i.Cells[4].Style.BackColor = Color.Red;
                            i.Cells[4].Style.ForeColor = Color.White;
                            MessageBox.Show("Thực Xuất bị rỗng");
                            return;
                        }
                        if (i.Cells[3].Value == null)
                        {

                            return;
                        }
                        if (!(_serviceQLHDXuat.CheckSo(i.Cells[4].Value.ToString())))
                        {
                            MessageBox.Show("nhập sai dữ liệu");
                            i.Cells[4].Value = "";
                            i.Cells[4].Style.BackColor = Color.Red;
                            i.Cells[4].Style.ForeColor = Color.White;
                            return;
                        }
                        //string.Compare(i.Cells[3].Value.ToString(), i.Cells[4].Value.ToString()) < 0
                        if (Convert.ToInt32(i.Cells[3].Value.ToString()) < Convert.ToInt32(i.Cells[4].Value.ToString()))
                        {
                            MessageBox.Show("k đc nhập thức xuất lớn hơn yêu cầu");
                            i.Cells[4].Value = "";
                            i.Cells[4].Style.BackColor = Color.Red;
                            i.Cells[4].Style.ForeColor = Color.White;
                            return;
                        }
                        if (!(_servicesKhoHang.GetChiTietKhos().Any(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0)))
                        {
                            MessageBox.Show(string.Format("trong kho k có sp có mã là {0}",i.Cells[1].Value.ToString()));
                            LoadCTPN(_mapn);
                            return;
                        }
                        if (_serviceQLHDXuat.GetPhieuXuatKhos().Any(c => c.MaPhieuXuat == _PhieuXuatKho.MaPhieuXuat))
                        {
                            _ChiTietPhieuXuat = new ChiTietPhieuXuat();
                            if (_servicesKhoHang.GetChiTietKhos().Any(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0))
                            {
                                _ChiTietPhieuXuat.MaCtkho = _servicesKhoHang.GetChiTietKhos().Where(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0).Select(c => c.MaCtkho).FirstOrDefault();
                            }
                            //else
                            //{
                            //    MessageBox.Show("trong kho k có sp này");
                            //    return;
                            //}
                            _ChiTietPhieuXuat.MaPhieuXuat = "PX" + _PhieuXuatKho.Id;
                            _ChiTietPhieuXuat.YeuCau = Convert.ToInt32(i.Cells[3].Value.ToString());
                            _ChiTietPhieuXuat.ThucXuat = Convert.ToInt32(i.Cells[4].Value.ToString());


                            var ctpn = _qLCTPhieuNhap.GetLstCTPN().Where(c => c.MaPhieuNhap == i.Cells[0].Value.ToString() && c.MaCtsp == i.Cells[1].Value.ToString()).FirstOrDefault();
                            if (Convert.ToInt32(i.Cells[3].Value.ToString()) > Convert.ToInt32(i.Cells[4].Value.ToString()))
                            {
                                ctpn.TrangThai = 2;
                                ctpn.ThucNhap = Convert.ToInt32(i.Cells[4].Value.ToString());
                                _ChiTietPhieuXuat.TrangThai = 2;
                                _qLCTPhieuNhap.EditCTPN(ctpn);
                            }
                            else
                            {
                                ctpn.TrangThai = 3;
                                ctpn.ThucNhap = Convert.ToInt32(i.Cells[4].Value.ToString());
                                _ChiTietPhieuXuat.TrangThai = 3;
                                _qLCTPhieuNhap.EditCTPN(ctpn);
                            }
                            _serviceQLHDXuat.AddCTPhieuXuat(_ChiTietPhieuXuat);
                            var kho = _servicesKhoHang.GetChiTietKhos().Where(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0).FirstOrDefault();

                            if (kho.SoLuong >= Convert.ToInt32(i.Cells[4].Value.ToString()))
                            {
                                kho.SoLuong = kho.SoLuong - Convert.ToInt32(i.Cells[4].Value.ToString());
                                ChiTietSanPham chiTietSanPham = _serviceChiTietSP.GetLstChiTietSP().Where(c => c.MaCtsp == kho.MaCtsp.ToString()).FirstOrDefault();
                                chiTietSanPham.SoLuong = chiTietSanPham.SoLuong + Convert.ToInt32(i.Cells[4].Value.ToString());
                                _servicesKhoHang.EditCTKho(kho);
                                _serviceChiTietSP.EditChiTietSP(chiTietSanPham);
                                MessageBox.Show("Thành Công");
                            }

                            else if (kho.SoLuong < Convert.ToInt32(i.Cells[4].Value.ToString()))
                            {
                                _SoLuongCuaKho = Convert.ToString(kho.SoLuong);
                                _SoDu = Convert.ToString(Convert.ToInt32(i.Cells[4].Value.ToString()) - kho.SoLuong);
                                kho.SoLuong = 0;
                                ChiTietSanPham chiTietSanPham = _serviceChiTietSP.GetLstChiTietSP().Where(c => c.MaCtsp == kho.MaCtsp.ToString()).FirstOrDefault();
                                chiTietSanPham.SoLuong = chiTietSanPham.SoLuong + Convert.ToInt32(_SoLuongCuaKho);
                                _servicesKhoHang.EditCTKho(kho);
                                _serviceChiTietSP.EditChiTietSP(chiTietSanPham);
                                MessageBox.Show(string.Format("Đã xuất khỏi kho: {0}, số lượng xuất thiếu của kho: {1}", _SoLuongCuaKho, _SoDu));

                            }
                            //if (i.IsNewRow)
                            //{
                            //    //var pn = _phieuNhapService.GetLstPhieuNhap().Where(c => c.MaPhieuNhap == _mapn).FirstOrDefault();
                            //    //pn.TrangThai = 2;
                            //    //_phieuNhapService.EditPhieuNhap(pn);
                            //    //LoadPhieuYeuCau();
                            //    return;
                            //}

                            LoadPhieuYeuCau();
                        }
                        else
                        {
                            _serviceQLHDXuat.AddPhieuXuat(_PhieuXuatKho);
                            _ChiTietPhieuXuat = new ChiTietPhieuXuat();
                            if (_servicesKhoHang.GetChiTietKhos().Any(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0))
                            {
                                _ChiTietPhieuXuat.MaCtkho = _servicesKhoHang.GetChiTietKhos().Where(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0).Select(c => c.MaCtkho).FirstOrDefault();
                            }
                            //else
                            //{
                            //    MessageBox.Show("trong kho k có sp này");
                            //    return;
                            //}

                            _ChiTietPhieuXuat.MaPhieuXuat = "PX" + _PhieuXuatKho.Id;
                            _ChiTietPhieuXuat.YeuCau = Convert.ToInt32(i.Cells[3].Value.ToString());
                            _ChiTietPhieuXuat.ThucXuat = Convert.ToInt32(i.Cells[4].Value.ToString());


                            var ctpn = _qLCTPhieuNhap.GetLstCTPN().Where(c => c.MaPhieuNhap == i.Cells[0].Value.ToString() && c.MaCtsp == i.Cells[1].Value.ToString()).FirstOrDefault();
                            if (Convert.ToInt32(i.Cells[3].Value.ToString()) > Convert.ToInt32(i.Cells[4].Value.ToString()))
                            {
                                ctpn.TrangThai = 2;
                                ctpn.ThucNhap = Convert.ToInt32(i.Cells[4].Value.ToString());
                                _ChiTietPhieuXuat.TrangThai = 2;
                                _qLCTPhieuNhap.EditCTPN(ctpn);
                            }
                            else
                            {
                                ctpn.TrangThai = 3;
                                ctpn.ThucNhap = Convert.ToInt32(i.Cells[4].Value.ToString());
                                _ChiTietPhieuXuat.TrangThai = 3;
                                _qLCTPhieuNhap.EditCTPN(ctpn);
                            }

                            _serviceQLHDXuat.AddCTPhieuXuat(_ChiTietPhieuXuat);
                            var kho = _servicesKhoHang.GetChiTietKhos().Where(c => c.MaCtsp == i.Cells[1].Value.ToString() && c.TrangThai == 0).FirstOrDefault();

                            if (kho.SoLuong >= Convert.ToInt32(i.Cells[4].Value.ToString()))
                            {
                                kho.SoLuong = kho.SoLuong - Convert.ToInt32(i.Cells[4].Value);
                                ChiTietSanPham chiTietSanPham = _serviceChiTietSP.GetLstChiTietSP().Where(c => c.MaCtsp == kho.MaCtsp.ToString()).FirstOrDefault();
                                chiTietSanPham.SoLuong = chiTietSanPham.SoLuong + Convert.ToInt32(i.Cells[4].Value.ToString());
                                _servicesKhoHang.EditCTKho(kho);
                                _serviceChiTietSP.EditChiTietSP(chiTietSanPham);
                                MessageBox.Show("Thành Công");
                            }

                            else if (kho.SoLuong < Convert.ToInt32(i.Cells[4].Value.ToString()))
                            {
                                _SoLuongCuaKho = Convert.ToString(kho.SoLuong);
                                _SoDu = Convert.ToString(Convert.ToInt32(i.Cells[4].Value.ToString()) - kho.SoLuong);
                                kho.SoLuong = 0;
                                ChiTietSanPham chiTietSanPham = _serviceChiTietSP.GetLstChiTietSP().Where(c => c.MaCtsp == kho.MaCtsp.ToString()).FirstOrDefault();
                                chiTietSanPham.SoLuong = chiTietSanPham.SoLuong + Convert.ToInt32(_SoLuongCuaKho);
                                _servicesKhoHang.EditCTKho(kho);
                                _serviceChiTietSP.EditChiTietSP(chiTietSanPham);
                                MessageBox.Show(string.Format("Đã xuất khỏi kho: {0}, số lượng xuất thiếu của kho: {1}", _SoLuongCuaKho, _SoDu));
                            }

                            LoadPhieuYeuCau();
                        }
                    }
                }
                LoadCTPN(_mapn);
                foreach (DataGridViewRow i in dgv_CTTPX.Rows)
                {
                    if (i.IsNewRow && i.Index == 0)
                    {
                        var pn = _phieuNhapService.GetLstPhieuNhap().Where(c => c.MaPhieuNhap == _mapn).FirstOrDefault();
                        pn.TrangThai = 3;
                        _phieuNhapService.EditPhieuNhap(pn);
                        LoadPhieuYeuCau();
                        LoadTreo();

                    }
                    else
                    {
                        var pn = _phieuNhapService.GetLstPhieuNhap().Where(c => c.MaPhieuNhap == _mapn).FirstOrDefault();
                        pn.TrangThai = 2;
                        _phieuNhapService.EditPhieuNhap(pn);
                        LoadPhieuYeuCau();
                        LoadTreo();
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
            dgv_PhieuXuat.CurrentCell.Value = dtp.Text.ToString();
            //MessageBox.Show(string.Format("Date changed to {0}", dtp.Text.ToString()));
        }

        private void DateTimePickerClose(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgv_CTTPX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex == -1) return;
                if (e.ColumnIndex == -1) return;
                dgv_CTTPX.Rows[rowindex].Cells[3].ReadOnly = true;
                dgv_CTTPX.Rows[rowindex].Cells[2].ReadOnly = true;
                dgv_CTTPX.Rows[rowindex].Cells[0].ReadOnly = true;
                dgv_CTTPX.Rows[rowindex].Cells[1].ReadOnly = true;

                //int SoThucNhap = 0;
                //if (e.ColumnIndex == 5)
                //{
                //    if (dgv_CTTPX.Rows[rowindex].Cells[5].Value == null)
                //    {
                //        return;
                //    }

                //}
                //for (int i = 0; i < _serviceQLHDXuat.SoLuong().Length; i++)
                //{
                //    if (_serviceQLHDXuat.SoLuong()[i] == Convert.ToInt32(dgv_CTTPX.Rows[rowindex].Cells[5].Value))
                //    {
                //        SoThucNhap = i;
                //    }
                //}
                //if (dgv_CTTPX.Columns[6].Name == "cmbKho1")
                //{
                //    if (dgv_CTTPX.Rows[rowindex].Cells[1].Value == null)
                //    {
                //        return;
                //    }
                //    //var id = _serviceQLHDXuat.GetChiTietKhoHangs().Where(c => c.MaCtsp == dgv_CTTPX.Rows[rowindex].Cells[1].Value.ToString()).Select(c => c.MaKho).ToList();
                //    //cmbKho1.Items.Clear();
                //    //foreach (var x in id)
                //    //{
                //    //    cmbKho1.Items.Add(x);

                //    //}
                //    if (dgv_CTTPX.Rows[rowindex].Cells[6].Value == null)
                //    {
                //        return;
                //    }
                //    if (dgv_CTTPX.Rows[rowindex].Cells[6].Value.ToString() == _serviceQLHDXuat.GetChiTietKhoHangs().Where(c => c.MaKho == dgv_CTTPX.Rows[rowindex].Cells[6].Value.ToString()).Select(c => c.MaKho).FirstOrDefault())
                //    {
                //        dgv_CTTPX.Rows[rowindex].Cells[4].Value = _serviceQLHDXuat.GetChiTietKhoHangs().Where(c => c.MaKho == dgv_CTTPX.Rows[rowindex].Cells[6].Value.ToString() && c.MaCtsp == dgv_CTTPX.Rows[rowindex].Cells[1].Value.ToString()).Select(c => c.MaCtkho).FirstOrDefault();
                //    }
                //}

                //dgv_CTTPX.Rows[rowindex].Cells[5].Value = (dgv_CTTPX.Rows[rowindex].Cells[5] as DataGridViewComboBoxCell).Items[SoThucNhap];
                //if (dgv_CTTPX.Columns[5].Visible = true)
                //{
                //    dgv_CTTPX.Rows[rowindex].Cells[5].Value = false;
                //    if ((bool)dgv_CTTPX.Rows[rowindex].Cells[5].Value == false)
                //    {
                //        dgv_CTTPX.Rows[rowindex].Cells[5].Value = true;
                //    }
                //    else
                //    {
                //        dgv_CTTPX.Rows[rowindex].Cells[5].Value = false;
                //    }
                //}
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            LoadTìmKiem();
        }



    }
}
