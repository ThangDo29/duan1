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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_GUI
{
    public partial class FrmPhieuNhap : Form
    {
        IQLNhanVien _iQLNhanVien;
        IQLCTPhieuNhap _iQLCTPN;
        IPhieuNhapService _iPNsv;
        List<PhieuNhap> _lstPhieuNhap;
        List<ChiTietPhieuNhap> _lstCTPN;
        List<ChiTietPhieuNhap> _lstCT2;
        PhieuNhap _phieuNhap;
        int _flag = 0;
        string _maPNLoad;
        int _flagg = 0;
        string _maPN;
        public FrmPhieuNhap()
        {
            _iQLNhanVien = new QLNhanVien();
            _iQLCTPN = new QLCTPhieuNhap();
            _iPNsv = new PhieuNhapService();
            _lstCTPN = new List<ChiTietPhieuNhap>();
            _lstPhieuNhap = new List<PhieuNhap>();
            _lstCT2 = new List<ChiTietPhieuNhap>();
            InitializeComponent();


            loadGridSP();
            loadGridPhieuDCXL();
            loadGridCTPhieuNhap();
            loadGridPhieuDXL();

        }


        #region LOAD DATAGRID

        void tim3()
        {
            try
            {
                dgridDaXuLi.ColumnCount = 4;
                dgridDaXuLi.Columns[0].Name = "Mã Phiếu Nhập";
                dgridDaXuLi.Columns[1].Name = "Nhân Viên Tạo";
                dgridDaXuLi.Columns[2].Name = "Ngày tạo Phiếu";
                dgridDaXuLi.Columns[3].Name = "Số Lượng Nhập";
                int tong = 0;
                dgridDaXuLi.Rows.Clear();
                foreach (var x in _iPNsv.GetLstPhieuNhap().Where(c => c.NgayTaoPhieu.Date == dateTimePicker3.Value.Date))
                {
                    if (x.TrangThai == 3 || x.TrangThai == 2)
                    {
                        foreach (var y in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == x.MaPhieuNhap))
                        {
                            tong = tong + y.SoLuong;
                        }
                        dgridDaXuLi.Rows.Add(x.MaPhieuNhap, x.MaNV, x.NgayTaoPhieu, tong);
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        void tim1()
        {
            try
            {
                dgridView1.ColumnCount = 4;
                dgridView1.Columns[0].Name = "Mã Phiếu Nhập";
                dgridView1.Columns[1].Name = "Nhân Viên Tạo";
                dgridView1.Columns[2].Name = "Ngày tạo Phiếu";
                dgridView1.Columns[3].Name = "Số Lượng Yêu Cầu";
                int tong = 0;

                dgridView1.Rows.Clear();
                foreach (var x in _iPNsv.GetLstPhieuNhap().Where(c => c.NgayTaoPhieu.Date == dateTimePicker1.Value.Date))
                {
                    if (x.TrangThai == 0)
                    {
                        foreach (var y in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == x.MaPhieuNhap))
                        {
                            tong = tong + y.SoLuong;
                        }
                        if (tong != 0)
                        {
                            dgridView1.Rows.Add(x.MaPhieuNhap, x.MaNV, x.NgayTaoPhieu, tong);
                        }
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        void loadPNtoCTPN(string maPN)
        {
            try
            {
                dgridPhieuNhap.Columns.Clear();
                dgridPhieuNhap.ColumnCount = 6;
                dgridPhieuNhap.Columns[0].Name = "Mã Chi Tiết Sản Phẩm";
                dgridPhieuNhap.Columns[1].Name = "Tên Sản Phẩm";
                dgridPhieuNhap.Columns[2].Name = "ID";
                dgridPhieuNhap.Columns[3].Name = "Số Lượng Yêu Cầu";
                dgridPhieuNhap.Columns[4].Name = "Số Lượng Thực Nhập";
                dgridPhieuNhap.Columns[5].Name = "Trạng Thái";
                dgridPhieuNhap.Columns[2].Visible = false;
                dgridPhieuNhap.Rows.Clear();
                var temp = _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == maPN).FirstOrDefault();
                if (temp == null) return;
                lblMaPhieu.Text = temp.MaPhieuNhap;
                lbltime.Text = _iPNsv.GetLstPhieuNhap().Where(c => c.MaPhieuNhap == maPN).FirstOrDefault().NgayTaoPhieu.ToString();
                foreach (var x in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == maPN))
                {
                    if (x.TrangThai != 1)
                    {
                        dgridPhieuNhap.Rows.Add(x.MaCtsp, x.TenSp, x.ID, x.SoLuong, x.ThucNhap, x.TrangThai == 0 ? "Chưa Nhập" : x.TrangThai == 2 ? "Nhập Thiếu" : "Nhập Đủ");
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        void loadTimSp(string tensp)
        {
            try
            {
                dgridSanPham.ColumnCount = 2;
                dgridSanPham.Columns[0].Name = "Mã Chi Tiết Sản Phẩm";
                dgridSanPham.Columns[1].Name = "Tên Sản Phẩm";
                btnAddSP();
                // dgridSanPham.Columns[0].IsReadOnly = false;
                // dgridSanPham.Columns[1].ReadOnly = false;

                // dataGridView1.Rows[e.RowIndex].ReadOnly = false
                dgridSanPham.Rows.Clear();
                foreach (var x in _iQLCTPN.GetLstCTSP().Where(c => c.TenSp.Contains(txtTimKiemSP.Text)).ToList())
                {
                    dgridSanPham.Rows.Add(x.MaCtsp, x.TenSp);
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        void loadGridSP()
        {
            try
            {
                dgridSanPham.ColumnCount = 2;
                dgridSanPham.Columns[0].Name = "Mã Chi Tiết Sản Phẩm";
                dgridSanPham.Columns[1].Name = "Tên Sản Phẩm";
                btnAddSP();
                dgridSanPham.Rows.Clear();
                foreach (var x in _iQLCTPN.GetLstCTSP())
                {
                    if (x.TrangThai == 1)
                    {
                        dgridSanPham.Rows.Add(x.MaCtsp, x.TenSp);
                    }
                   
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        void loadGridCTPhieuNhap()
        {
            try
            {
                DataGridViewButtonColumn btnSuaSPCTPN = new DataGridViewButtonColumn();
                btnSuaSPCTPN.HeaderText = "Sửa";
                btnSuaSPCTPN.Text = "Sửa";
                btnSuaSPCTPN.Name = "btnSuaSPCTPN";
                DataGridViewComboBoxColumn cmbSoLuongGridCTPN = new DataGridViewComboBoxColumn();
                cmbSoLuongGridCTPN.HeaderText = "Số Lượng";
                cmbSoLuongGridCTPN.Name = "cmbSoLuongGridCTPN";
                foreach (var i in _iQLCTPN.Soluong())
                {
                    cmbSoLuongGridCTPN.Items.Add(i);
                }
                DataGridViewButtonColumn btnXoaSPCTPN = new DataGridViewButtonColumn();
                btnXoaSPCTPN.HeaderText = "Xóa";
                btnXoaSPCTPN.Text = "Xóa";
                btnXoaSPCTPN.Name = "btnXoaSPCTPN";

                dgridPhieuNhap.ColumnCount = 3;
                dgridPhieuNhap.Columns[0].Name = "Mã Chi Tiết Sản Phẩm";
                dgridPhieuNhap.Columns[1].Name = "Tên Sản Phẩm";
                dgridPhieuNhap.Columns[2].Name = "ID";
                dgridPhieuNhap.Columns[2].Visible = false;

                dgridPhieuNhap.Columns.Add(cmbSoLuongGridCTPN);
                dgridPhieuNhap.Columns.Add(btnSuaSPCTPN);
                dgridPhieuNhap.Columns.Add(btnXoaSPCTPN);
                btnSuaSPCTPN.UseColumnTextForButtonValue = true;
                btnXoaSPCTPN.UseColumnTextForButtonValue = true;
                dgridPhieuNhap.Rows.Clear();
                if (_phieuNhap == null) return;

                var temp = _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == _phieuNhap.MaPhieuNhap && c.TrangThai != 1).FirstOrDefault();
                if (temp == null) return;

                foreach (var x in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == _phieuNhap.MaPhieuNhap))
                {
                    if (x.TrangThai != 1)
                    {
                        dgridPhieuNhap.Rows.Add(x.MaCtsp, x.TenSp, x.ID, x.SoLuong);
                    }

                }
            }
            catch (Exception)
            {

                return;
            }
        }

        void loadGridPhieuDXL()
        {
            try
            {

                dgridDaXuLi.ColumnCount = 6;
                dgridDaXuLi.Columns[0].Name = "Mã Phiếu Nhập";
                dgridDaXuLi.Columns[1].Name = "Nhân Viên Tạo";
                dgridDaXuLi.Columns[2].Name = "Ngày tạo Phiếu";
                dgridDaXuLi.Columns[3].Name = "Số Lượng Yêu Cầu";
                dgridDaXuLi.Columns[4].Name = "Số Lượng Nhập";
                dgridDaXuLi.Columns[5].Name = "Trạng Thái";
                int tong1 = 0;
                int tong2 = 0;
                dgridDaXuLi.Rows.Clear();
                foreach (var x in _iPNsv.GetLstPhieuNhap().OrderByDescending(c => c.Id))
                {

                    if (x.TrangThai == 3 || x.TrangThai == 2)
                    {
                        foreach (var y in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == x.MaPhieuNhap))
                        {
                            tong1 = tong1 + y.SoLuong;
                            tong2 = tong2 + y.ThucNhap;
                        }
                        dgridDaXuLi.Rows.Add(x.MaPhieuNhap, x.MaNV, x.NgayTaoPhieu, tong1, tong2, x.TrangThai == 2 ? "Nhập Thiếu" : "Nhập đủ");
                        tong1 = 0;
                        tong2 = 0;
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        void loadGridPhieuDCXL()
        {
            try
            {
                dgridView1.ColumnCount = 5;
                dgridView1.Columns[0].Name = "Mã Phiếu Nhập";
                dgridView1.Columns[1].Name = "Nhân Viên Tạo";
                dgridView1.Columns[2].Name = "Ngày tạo Phiếu";
                dgridView1.Columns[3].Name = "Số Lượng Yêu Cầu";
                dgridView1.Columns[4].Name = "Trạng Thái";

                int tong = 0;

                dgridView1.Rows.Clear();
                foreach (var x in _iPNsv.GetLstPhieuNhap().OrderByDescending(c => c.Id))
                {
                    if (x.TrangThai == 0)
                    {
                        foreach (var y in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == x.MaPhieuNhap))
                        {
                            tong = tong + y.SoLuong;
                        }
                        if (tong != 0)
                        {
                            dgridView1.Rows.Add(x.MaPhieuNhap, x.MaNV, x.NgayTaoPhieu, tong, "Chưa Xử Lí");
                            tong = 0;
                        }

                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        #endregion  /// LOAD DATAGRID

        #region   Button DataGrid  

        void btnAddSP()
        {
            DataGridViewButtonColumn btnAddSP = new DataGridViewButtonColumn();
            btnAddSP.HeaderText = "Thêm Vào Phiếu";
            btnAddSP.Text = "Thêm";
            btnAddSP.Name = "btnAddSP";
            DataGridViewComboBoxColumn cmbSoLuongGrid = new DataGridViewComboBoxColumn();
            cmbSoLuongGrid.HeaderText = "Số Lượng";
            cmbSoLuongGrid.Name = "cmbSoLuong";
            foreach (var i in _iQLCTPN.Soluong())
            {
                cmbSoLuongGrid.Items.Add(i);
            }
            dgridSanPham.Columns.Add(cmbSoLuongGrid);
            dgridSanPham.Columns.Add(btnAddSP);
            btnAddSP.UseColumnTextForButtonValue = true;
        }


        #endregion

        #region CellClick
        private void dgridSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                int index = 0;

                if (rowindex == _iQLCTPN.GetLstCTSP().Count + 1 || rowindex == -1) return;
                if (e.ColumnIndex == 2)
                {
                    if (dgridSanPham.Rows[rowindex].Cells[2].Value == null) return;
                }
                for (int i = 1; i < _iQLCTPN.Soluong().Length; i++)
                {

                    if (_iQLCTPN.Soluong()[i] == Convert.ToInt32(dgridSanPham.Rows[rowindex].Cells[2].Value))
                    {
                        index = i;
                    }

                }
                dgridSanPham.Rows[rowindex].Cells[2].Value = (dgridSanPham.Rows[rowindex].Cells[2] as DataGridViewComboBoxCell).Items[index];
                // dataGridView1.Rows[e.RowIndex].ReadOnly = false
                dgridSanPham.Rows[rowindex].Cells[0].ReadOnly = true;
                dgridSanPham.Rows[rowindex].Cells[1].ReadOnly = true;

                if (e.ColumnIndex == dgridSanPham.Columns["btnAddSP"].Index)
                {
                    if (_flag == 0)
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        MessageBox.Show("Bạn phải tạo phiếu trước!!", "Thông Báo");
                        return;
                    }
                    _flagg = 2;
                    ChiTietPhieuNhap chiTietPhieuNhap = new ChiTietPhieuNhap();
                    chiTietPhieuNhap.MaPhieuNhap = _phieuNhap.MaPhieuNhap;
                    chiTietPhieuNhap.MaCtsp = dgridSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                    chiTietPhieuNhap.TenSp = dgridSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                    chiTietPhieuNhap.SoLuong = Convert.ToInt32(dgridSanPham.Rows[e.RowIndex].Cells[2].Value.ToString());
                    if (chiTietPhieuNhap.SoLuong <= 0)
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        MessageBox.Show("Số lượng phải lớn hơn 0!!", "Thông Báo");
                        return;
                    }
                    chiTietPhieuNhap.ThucNhap = 0;
                    chiTietPhieuNhap.TrangThai = 0;
                    foreach (var x in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == _phieuNhap.MaPhieuNhap))
                    {
                        if (x.MaCtsp == chiTietPhieuNhap.MaCtsp && x.TrangThai != 1)
                        {
                            x.SoLuong = x.SoLuong + chiTietPhieuNhap.SoLuong;
                            _iQLCTPN.EditCTPN(x);
                            MessageBox.Show("Thêm thành công");
                            loadGridCTPhieuNhap();
                            return;
                        }
                        else if (x.MaCtsp == chiTietPhieuNhap.MaCtsp && x.TrangThai == 1)
                        {
                            x.TrangThai = 0;
                            x.SoLuong = Convert.ToInt32(dgridSanPham.Rows[e.RowIndex].Cells[2].Value.ToString());
                            _iQLCTPN.EditCTPN(x);
                            MessageBox.Show("Thêm thành công");
                            loadGridCTPhieuNhap();
                            return;
                        }
                    }
                    _iQLCTPN.AddCTPN(chiTietPhieuNhap);
                    _lstCTPN.Add(chiTietPhieuNhap);
                    var temp = _lstCT2.Where(c => c.ID == chiTietPhieuNhap.ID).FirstOrDefault();
                    if (temp == null)
                    {
                        _lstCT2.Add(chiTietPhieuNhap);
                    }
                    
                    MessageBox.Show("Thêm thành công");
                    loadGridCTPhieuNhap();
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        private void dgridPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                int index = 0;
                List<ChiTietPhieuNhap> lstPhieuNhap = new List<ChiTietPhieuNhap>();
                foreach (var x in _iQLCTPN.GetLstCTPN().Where(c => c.MaPhieuNhap == _phieuNhap.MaPhieuNhap))
                {
                    if (x.TrangThai != 1)
                    {
                        lstPhieuNhap.Add(x);
                    }

                }

                if (rowindex == lstPhieuNhap.Count || rowindex == -1) return;
                ChiTietPhieuNhap CTphieuNhap = _iQLCTPN.GetLstCTPN().Where(c => c.ID == Convert.ToInt32(dgridPhieuNhap.Rows[rowindex].Cells[2].Value.ToString())).FirstOrDefault();

                if (e.ColumnIndex == 3)
                {
                    if (dgridPhieuNhap.Rows[rowindex].Cells[3].Value == null) return;
                }
                for (int i = 1; i < _iQLCTPN.Soluong().Length; i++)
                {

                    if (_iQLCTPN.Soluong()[i] == Convert.ToInt32(dgridPhieuNhap.Rows[rowindex].Cells[3].Value))
                    {
                        index = i;
                    }

                }
                dgridPhieuNhap.Rows[rowindex].Cells[3].Value = index;

                if (e.ColumnIndex == dgridPhieuNhap.Columns["btnSuaSPCTPN"].Index)
                {
                    var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        CTphieuNhap.SoLuong = index;
                        if (CTphieuNhap.SoLuong <= 0)
                        {
                            System.Media.SystemSounds.Asterisk.Play();
                            MessageBox.Show("Số lượng phải lớn hơn 0!!", "Thông Báo");
                            return;
                        }
                        _iQLCTPN.EditCTPN(CTphieuNhap);
                        MessageBox.Show("Đã Sửa", "Thông Báo");
                        loadGridCTPhieuNhap();
                    }
                }
                else if (e.ColumnIndex == dgridPhieuNhap.Columns["btnXoaSPCTPN"].Index)
                {
                    var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        _iQLCTPN.DeleteCTPN(CTphieuNhap);
                        _lstCT2.Remove(CTphieuNhap);
                        _lstCT2.Remove(CTphieuNhap);
                        MessageBox.Show("Đã Xóa", "Thông Báo");
                        loadGridCTPhieuNhap();
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        private void dgridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;

                if (_flagg != 0)
                {
                    MessageBox.Show("Bạn chưa gửi yêu cầu!!", "Thông báo!!");
                    return;
                }
                List<PhieuNhap> lstPhieuNhap = new List<PhieuNhap>();
                foreach (var x in _iPNsv.GetLstPhieuNhap())
                {
                    if (x.TrangThai == 0)
                    {
                        lstPhieuNhap.Add(x);
                    }
                }
                if (rowindex == lstPhieuNhap.Count || rowindex == -1) return;
                _maPNLoad = dgridView1.Rows[rowindex].Cells[0].Value.ToString();
                // dgridDaXuLi.Rows.Clear();
                loadPNtoCTPN(_maPNLoad);
                loadGridSP();
                loadGridPhieuDXL();
            }
            catch (Exception)
            {

                return;
            }
        }



        private void dgridDaXuLi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                int index = 0;
                if (_flagg != 0)
                {
                    MessageBox.Show("Bạn chưa gửi yêu cầu!!", "Thông báo!!");
                    return;
                }
                List<PhieuNhap> lstPhieuNhap = new List<PhieuNhap>();
                foreach (var x in _iPNsv.GetLstPhieuNhap())
                {
                    if (x.TrangThai == 3 || x.TrangThai == 2)
                    {
                        lstPhieuNhap.Add(x);
                    }
                }
                if (rowindex == lstPhieuNhap.Count || rowindex == -1) return;
                _maPNLoad = dgridDaXuLi.Rows[rowindex].Cells[0].Value.ToString();
                loadPNtoCTPN(_maPNLoad);
                loadGridSP();
                loadGridPhieuDCXL();
            }
            catch (Exception)
            {

                return;
            }
        }


        #endregion


        #region Tìm Kiếm
        private void dgridSanPham_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }





        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            tim1();
        }

        private void btntimkiem2_Click(object sender, EventArgs e)
        {
            tim3();
        }



        #endregion






        private void dgridPhieuNhap_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnGuiYC_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {

                    if (_flag == 0)
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        MessageBox.Show("Bạn phải tạo phiếu trước!!", "Thông Báo");
                        return;
                    }
                    if (_flagg == 1)
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        MessageBox.Show("Bạn chưa thêm sản phẩm vào phiếu!!", "Thông Báo");
                        return;
                    }
                    if (_lstCT2.Count == 0)
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        MessageBox.Show("Phiếu không được để trống !!", "Thông Báo");
                        _lstCT2 = new List<ChiTietPhieuNhap>();
                        return;
                    }
                    _flagg = 0;
                    _phieuNhap.TrangThai = 0;
                    _iPNsv.EditPhieuNhap(_phieuNhap);
                    MessageBox.Show("Gửi yêu cầu thành công!!", "Thông Báo");
                    _phieuNhap = new PhieuNhap();
                    _lstCT2 = new List<ChiTietPhieuNhap>();

                    txtTimKiemSP.Text = null;
                    lbltime.Text = "...";
                    lblMaPhieu.Text = "...";
                    loadGridSP();
                    loadGridPhieuDCXL();
                    loadGridCTPhieuNhap();
                    loadGridPhieuDXL();

                }
                catch (Exception)
                {

                    return;
                }
            }

        }


        private void txtTimKiemSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            loadTimSp(txtTimKiemSP.Text);
        }

        public void layNhanVien(NhanVien nhanVien)
        {
            lblManv.Text = nhanVien.MaNv;
        }
        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(" Có chắc chắn thực hiện hành động này hay không???", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {

                    if (_flagg == 2)
                    {
                        MessageBox.Show("Bạn chưa gửi yêu cầu!!", "Thông báo!!");
                        return;
                    }
                    _flag = 1;
                    _flagg = 1;
                    PhieuNhap phieunhap = new PhieuNhap();
                    if (lblManv.Text != "...")
                    {
                        phieunhap.MaNV = lblManv.Text;
                    }
                    else
                    {
                        phieunhap.MaNV = "NV1";
                    }
                    _iPNsv.AddPhieuNhap(phieunhap);
                    _lstPhieuNhap.Add(phieunhap);
                    MessageBox.Show("Tạo phiếu thành công!!", "Thông báo!!");
                    int id = phieunhap.Id;
                    _phieuNhap = phieunhap;
                    _maPN = _phieuNhap.MaPhieuNhap;
                    lblMaPhieu.Text = _phieuNhap.MaPhieuNhap;
                    lbltime.Text = _phieuNhap.NgayTaoPhieu.Date.ToString();
                    loadGridPhieuDCXL();
                    loadGridCTPhieuNhap();
                    loadGridPhieuDXL();
                }
                catch (Exception)
                {

                    return;
                }
            }
        }

        private void btnCane1_Click(object sender, EventArgs e)
        {
            loadGridPhieuDCXL();
            loadGridPhieuDXL();
        }

        private void btnCanel2_Click(object sender, EventArgs e)
        {
            loadGridPhieuDXL();
            loadGridPhieuDCXL();
        }

      
    }
}
