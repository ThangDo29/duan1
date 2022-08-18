using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1_DAL.IService;
using _1_DAL.Models;
using _1_DAL.Service;
using _2_BUS.IService;
using _2_BUS.Models;
using _2_BUS.Service;
using BarcodeLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3_GUI
{
    public partial class FrmChiTietSP : Form
    {
        private string fileNameAnhSP;
        private string fileNameAnhBarcode;
        private string fileSavePath;
        private string fileAdress;
        private string maSP;
        private string maCTSP;

        private List<HienThiChiTietSP> _lstHienThiChiTietSp;
        // private List<HienThiSanPham> _lstHienThiSanPham;
        private List<SanPham> _lstSanPhams;
        private List<MauSac> _lstMauSacs;
        private List<ChatLieu> _lstChatLieus;
        private List<KichThuoc> _lstKichThuoc;
        private List<NhaCungCap> _lstNhaCungCap;
        private List<NhaSanXuat> _lstNhaSanXuat;
        private List<TheLoaiSanPham> _lstTheLoaiSanPham;
        private List<ChiTietSanPham> _lstChiTietSanPhams;
        private List<HienThiChiTietSP> _listTempAdd;
        private IChiTietSP _iChiTietSp;
        private IServiceTheLoaiSP _iServiceTheLoaiSp;
        private IServiceChatLieu _iServiceChatLieu;
        private IServiceNhaCungCap _iServiceNhaCungCap;
        private IServiceNhaSanXuat _iServiceNhaSanXuat;
        private IServiceKichThuoc _iServiceKichThuoc;
        private IQLSanPham _iQlSanPham;
        private IServiceMauSac _iServiceMauSac;
        NhanVien nv;
        private int a = 0;
        private int b = 0;//cell click vẫn đc thêm sản phẩm
        private int c = 0;
        ColorDialog colorPicker = new ColorDialog();
        string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 25));
        public FrmChiTietSP()
        {
            InitializeComponent();
            _iChiTietSp = new ServiceDetailSP();
            _iServiceKichThuoc = new ServiceKichThuoc();
            _iServiceMauSac = new ServiceMauSac();
            _iServiceChatLieu = new ServiceChatLieu();
            _iServiceNhaCungCap = new ServiceNhaCungCap();
            _iServiceNhaSanXuat = new ServiceNhaSanXuat();
            _iServiceTheLoaiSp = new ServiceTheLoaiSP();
            _iQlSanPham = new QLSanPham();
            nv = new NhanVien();

            _lstHienThiChiTietSp = new List<HienThiChiTietSP>();
            _listTempAdd = new List<HienThiChiTietSP>();
            _lstTheLoaiSanPham = new List<TheLoaiSanPham>();
            _lstSanPhams = new List<SanPham>();
            _lstMauSacs = new List<MauSac>();
            _lstChatLieus = new List<ChatLieu>();
            _lstKichThuoc = new List<KichThuoc>();
            _lstNhaCungCap = new List<NhaCungCap>();
            _lstNhaSanXuat = new List<NhaSanXuat>();
            _lstChiTietSanPhams = new List<ChiTietSanPham>();
            LoadDgrid();
            LoadCBX();

        }
        public bool CheckQuyen(NhanVien nhanvien)
        {
            nv = nhanvien;
            if (nhanvien.MaCv == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
        void LoadDgrid()
        {
            _lstHienThiChiTietSp = _iChiTietSp.getLstHienThiChiTietSP();
            dgrid_chitietsp.ColumnCount = 8;
            dgrid_chitietsp.Columns[0].Name = "ID";
            dgrid_chitietsp.Columns[1].Name = "Tên";
            dgrid_chitietsp.Columns[2].Name = "Tên Màu(Hoặc Mã Màu)";
            dgrid_chitietsp.Columns[3].Name = "Kích Thước";
            dgrid_chitietsp.Columns[4].Name = "Giá Bán";
            dgrid_chitietsp.Columns[5].Name = "Nhà Sản Xuất";
            dgrid_chitietsp.Columns[6].Name = "Nhà Cung Cấp";
            dgrid_chitietsp.Columns[7].Name = "Số lượng";
            dgrid_chitietsp.Rows.Clear();
            foreach (var y in _lstHienThiChiTietSp.Where(c => c.Status == 1))
            {
                dgrid_chitietsp.Rows.Add(y.ID, y.TenChiTietSP, y.TenMau, y.KichThuoc, string.Format("{0:#,##0.00}", y.GiaBan) + "VNĐ", y.TenNSX, y.TenNCC, y.SoLuong);

            }
        }

        void LoadCBX()
        {
            if (CheckQuyen(nv))
            {
                _lstMauSacs = _iServiceMauSac.GetLstMauSac();
                _lstSanPhams = _iQlSanPham.GetLstSanPhams();
                _lstKichThuoc = _iServiceKichThuoc.GetLstKichThuoc();
                _lstChatLieus = _iServiceChatLieu.GetLstChatLieu();
                _lstTheLoaiSanPham = _iServiceTheLoaiSp.GetLstTheLoaiSP();
                foreach (var x in _lstSanPhams)
                {
                    cmb_sp.Items.Add(x.MaSp);
                }
                foreach (var x in _lstMauSacs)
                {
                    cmb_mausac.Items.Add(x.TenMs);
                }

                foreach (var x in _lstKichThuoc)
                {
                    cmb_kichthuoc.Items.Add(x.Size);
                }

                foreach (var x in _lstChatLieus)
                {
                    cmb_chatlieu.Items.Add(x.TenCl);
                }

                foreach (var x in _lstTheLoaiSanPham)
                {
                    cmb_theloai.Items.Add(x.TenTl);
                    cmb_timkiem.Items.Add(x.TenTl);
                }
            }
        }

        private void btn_moanh_Click(object sender, EventArgs e)
        {
            if (CheckQuyen(nv))
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)*.*|";
                dlgOpen.FilterIndex = 2;
                dlgOpen.Title = "Chọn ảnh minh họa cho sản phẩm";

                if (dlgOpen.ShowDialog() == DialogResult.OK)
                {
                    fileAdress = dlgOpen.FileName;
                    ptr_addsanpham.Image = Image.FromFile(fileAdress);
                    fileNameAnhSP = Path.GetFileName(dlgOpen.FileName);
                    fileSavePath = saveDirectory + "Resources\\" + fileNameAnhSP;
                    txt_duongdananh.Text = "Resources\\" + fileNameAnhSP;

                }
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }
        }

        private void btn_add1_Click(object sender, EventArgs e)
        {
            if (CheckQuyen(nv))
            {
                try
                {
                    _lstChiTietSanPhams = _iChiTietSp.GetLstChiTietSP();
                    _lstSanPhams = _iQlSanPham.GetLstSanPhams();
                    _lstNhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
                    _lstNhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
                    _lstTheLoaiSanPham = _iServiceTheLoaiSp.GetLstTheLoaiSP();
                    _lstMauSacs = _iServiceMauSac.GetLstMauSac();
                    _lstKichThuoc = _iServiceKichThuoc.GetLstKichThuoc();
                    _lstChatLieus = _iServiceChatLieu.GetLstChatLieu();
                    _lstHienThiChiTietSp = _iChiTietSp.getLstHienThiChiTietSP();
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ChiTietSanPham ctsp = new ChiTietSanPham();

                        if (b == 0)//click vào cell đổ ra thông tin thì vẫn thêm sản phẩm được
                        {
                            if (string.IsNullOrEmpty(txt_tengiay.Text) || string.IsNullOrEmpty(txt_tenhang.Text) || string.IsNullOrEmpty(txt_ncc.Text) || string.IsNullOrEmpty(txt_nsx.Text) || string.IsNullOrEmpty(cmb_theloai.Text) || string.IsNullOrEmpty(cmb_chatlieu.Text) || string.IsNullOrEmpty(cmb_kichthuoc.Text) || string.IsNullOrEmpty(cmb_mausac.Text) || string.IsNullOrEmpty(txt_soluong.Text) || string.IsNullOrEmpty(txt_duongdananh.Text) || string.IsNullOrEmpty(txt_giaban.Text) || (chb_new.Checked == false && chb_old.Checked == false)||txt_tengiay.Text.Trim().Length==0||txt_giaban.Text.Trim().Length==0||txt_soluong.Text.Trim().Length==0||txt_ncc.Text.Trim().Length==0||txt_nsx.Text.Trim().Length==0||txt_tenhang.Text.Trim().Length==0)
                            {
                                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Cảnh Báo");
                                return;
                            }
                            if (!checkSo(txt_soluong.Text) || !checkSo(txt_giaban.Text))
                            {
                                MessageBox.Show("Thông tin số lượng và giá bán chỉ nhập số", "Cảnh báo");
                            }
                            ctsp.MaCtsp = "CTSP" + (_lstChiTietSanPhams.Count + 1);
                            ctsp.Id = _lstChiTietSanPhams.Count + 1;
                            ctsp.MaMs = _lstMauSacs.Where(c => c.TenMs == cmb_mausac.Text).Select(c => c.MaMs).FirstOrDefault();
                            ctsp.MaKt = _lstKichThuoc.Where(c => c.Size == Convert.ToInt32(cmb_kichthuoc.Text)).Select(c => c.MaKt).FirstOrDefault();
                            ctsp.MaCl = _lstChatLieus.Where(c => c.TenCl == cmb_chatlieu.Text).Select(c => c.MaCl).FirstOrDefault();
                            ctsp.TenSp = txt_tengiay.Text.Trim();
                            ctsp.SoLuong = Convert.ToInt32(txt_soluong.Text.Trim());
                            ctsp.GiaBan = Convert.ToDouble(txt_giaban.Text.Trim());
                            ctsp.Hinhanh = txt_duongdananh.Text;
                            ctsp.TrangThai = 1;
                            if (chb_old.Checked)
                            {
                                ctsp.MaSp = cmb_sp.Text;
                            }
                            if (chb_new.Checked)
                            {
                                var checknewsp = _lstHienThiChiTietSp.Where(c =>
                                    c.TenThuongHieu == txt_tenhang.Text && c.TenTheLoai == cmb_theloai.Text &&
                                    c.TenNCC == txt_ncc.Text && c.TenNSX == txt_nsx.Text);
                                if (checknewsp.Count() != 0)
                                {
                                    foreach (var x in checknewsp)
                                    {
                                        ctsp.MaSp = x.MaSP;
                                    }
                                }
                                else
                                {
                                    SanPham sp = new SanPham();
                                    sp.MaSp = "SP" + (_lstSanPhams.Count + 1);
                                    ctsp.MaSp = sp.MaSp;
                                    sp.Id = _lstSanPhams.Count + 1;
                                    sp.TenThuongHieu = txt_tenhang.Text.Trim();
                                    sp.TrangThai = 1;
                                    sp.BarCode = "...";
                                    sp.MaTl = _lstTheLoaiSanPham.Where(c => c.TenTl == cmb_theloai.Text).Select(c => c.MaTl).FirstOrDefault();
                                    if (_lstNhaSanXuat.Count == 0)
                                    {
                                        NhaSanXuat nhaSanXuat = new NhaSanXuat();
                                        nhaSanXuat.MaNsx = (byte)(_lstNhaSanXuat.Count + 1);
                                        nhaSanXuat.TenNsx = txt_nsx.Text.Trim();
                                        sp.MaNsx = nhaSanXuat.MaNsx;
                                        _iServiceNhaSanXuat.AddNhaSanXuat(nhaSanXuat);
                                        _lstNhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
                                    }

                                    var TempListNSX = _lstNhaSanXuat.Where(c => c.TenNsx == txt_nsx.Text);

                                    if (TempListNSX.Count() != 0)
                                    {

                                        var maNSX = _lstNhaSanXuat.Where(c => c.TenNsx == txt_nsx.Text).Select(c => c.MaNsx)
                                            .FirstOrDefault();
                                        sp.MaNsx = maNSX;

                                    }
                                    else
                                    {
                                        NhaSanXuat nhaSanXuat = new NhaSanXuat();
                                        nhaSanXuat.MaNsx = (byte)(_lstNhaSanXuat.Count + 1);
                                        nhaSanXuat.TenNsx = txt_nsx.Text.Trim();
                                        sp.MaNsx = nhaSanXuat.MaNsx;
                                        _iServiceNhaSanXuat.AddNhaSanXuat(nhaSanXuat);
                                    }
                                    if (_lstNhaCungCap.Count == 0)
                                    {
                                        NhaCungCap nhaCungCap = new NhaCungCap();
                                        nhaCungCap.MaNcc = (byte)(_lstNhaCungCap.Count + 1);
                                        nhaCungCap.TenNcc = txt_ncc.Text.Trim();
                                        sp.MaNcc = nhaCungCap.MaNcc;
                                        _iServiceNhaCungCap.AddNhaCungCap(nhaCungCap);
                                        _lstNhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
                                    }

                                    var TempListNhaCC = _lstNhaCungCap.Where(c => c.TenNcc == txt_ncc.Text);

                                    if (TempListNhaCC.Count() != 0)
                                    {

                                        var maNCC = _lstNhaCungCap.Where(c => c.TenNcc == txt_ncc.Text).Select(c => c.MaNcc)
                                            .FirstOrDefault();
                                        sp.MaNcc = maNCC;

                                    }
                                    else
                                    {
                                        NhaCungCap nhaCungCap = new NhaCungCap();
                                        nhaCungCap.MaNcc = (byte)(_lstNhaCungCap.Count + 1);
                                        nhaCungCap.TenNcc = txt_ncc.Text.Trim();
                                        sp.MaNcc = nhaCungCap.MaNcc;
                                        _iServiceNhaCungCap.AddNhaCungCap(nhaCungCap);
                                    }
                                    _iQlSanPham.Insert(sp);
                                }

                            }
                            var check = _lstHienThiChiTietSp.Where(c => c.HinhAnh == txt_duongdananh.Text);
                            if (check.Count() != 0)
                            {
                                MessageBox.Show("Ảnh minh họa này đã được sử dụng", "Cảnh báo");
                                txt_duongdananh.Text = null;
                                ptr_addsanpham.Image = null;
                                return;
                            }
                            else
                            {
                                File.Copy(fileAdress, fileSavePath, true);
                                Barcode barcode = new Barcode();
                                Image img = barcode.Encode(TYPE.CODE128, ctsp.MaCtsp, 500, 150);
                                var dialog = new SaveFileDialog();
                                dialog.Title = "Lưu ảnh Barcode của sản phẩm mới";
                                dialog.InitialDirectory = saveDirectory + "BarcodeImages";
                                dialog.Filter = "JPEG(*.jpg)|*.jpg";
                                if (dialog.ShowDialog() == DialogResult.OK)
                                {
                                    fileNameAnhBarcode = Path.GetFileName(dialog.FileName);
                                    img.Save(dialog.FileName);
                                    ctsp.BarCode = "BarcodeImages\\" + fileNameAnhBarcode;
                                }
                            }
                        }

                        if (b == 1)//thêm tay
                        {
                            var checknewsp = _lstHienThiChiTietSp.Where(c =>
                                c.TenThuongHieu == txt_tenhang.Text && c.TenTheLoai == cmb_theloai.Text &&
                                c.TenNCC == txt_ncc.Text && c.TenNSX == txt_nsx.Text);
                            if (string.IsNullOrEmpty(txt_tengiay.Text) || string.IsNullOrEmpty(txt_tenhang.Text) || string.IsNullOrEmpty(txt_ncc.Text) || string.IsNullOrEmpty(txt_nsx.Text) || string.IsNullOrEmpty(cmb_theloai.Text) || string.IsNullOrEmpty(cmb_chatlieu.Text) || string.IsNullOrEmpty(cmb_kichthuoc.Text) || string.IsNullOrEmpty(cmb_mausac.Text) || string.IsNullOrEmpty(txt_soluong.Text) || string.IsNullOrEmpty(txt_duongdananh.Text) || string.IsNullOrEmpty(txt_giaban.Text) || txt_tengiay.Text.Trim().Length == 0 || txt_giaban.Text.Trim().Length == 0 || txt_soluong.Text.Trim().Length == 0 || txt_ncc.Text.Trim().Length == 0 || txt_nsx.Text.Trim().Length == 0 || txt_tenhang.Text.Trim().Length == 0)
                            {
                                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Cảnh Báo");
                                return;
                            }
                            if (!checkSo(txt_soluong.Text) || !checkSo(txt_giaban.Text))
                            {
                                MessageBox.Show("Thông tin số lượng và giá bán chỉ nhập số", "Cảnh báo");
                            }
                            ctsp.MaCtsp = "CTSP" + (_lstChiTietSanPhams.Count + 1);
                            ctsp.Id = _lstChiTietSanPhams.Count + 1;
                            ctsp.MaMs = _lstMauSacs.Where(c => c.TenMs == cmb_mausac.Text).Select(c => c.MaMs).FirstOrDefault();
                            ctsp.MaKt = _lstKichThuoc.Where(c => c.Size == Convert.ToInt32(cmb_kichthuoc.Text)).Select(c => c.MaKt).FirstOrDefault();
                            ctsp.MaCl = _lstChatLieus.Where(c => c.TenCl == cmb_chatlieu.Text).Select(c => c.MaCl).FirstOrDefault();
                            ctsp.TenSp = txt_tengiay.Text.Trim();
                            ctsp.SoLuong = Convert.ToInt32(txt_soluong.Text.Trim());
                            ctsp.GiaBan = Convert.ToDouble(txt_giaban.Text.Trim());
                            ctsp.Hinhanh = txt_duongdananh.Text;
                            ctsp.TrangThai = 1;
                            if (chb_old.Checked)
                            {
                                ctsp.MaSp = cmb_sp.Text;
                            }
                            if (chb_new.Checked)
                            {

                                if (checknewsp.Count() != 0)
                                {
                                    foreach (var x in checknewsp)
                                    {
                                        ctsp.MaSp = x.MaSP;
                                    }
                                }
                                else
                                {
                                    SanPham sp = new SanPham();
                                    sp.MaSp = "SP" + (_lstSanPhams.Count + 1);
                                    ctsp.MaSp = sp.MaSp;
                                    sp.Id = _lstSanPhams.Count + 1;
                                    sp.TenThuongHieu = txt_tenhang.Text.Trim();
                                    sp.TrangThai = 1;
                                    sp.BarCode = "...";
                                    sp.MaTl = _lstTheLoaiSanPham.Where(c => c.TenTl == cmb_theloai.Text).Select(c => c.MaTl).FirstOrDefault();
                                    if (_lstNhaSanXuat.Count == 0)
                                    {
                                        NhaSanXuat nhaSanXuat = new NhaSanXuat();
                                        nhaSanXuat.MaNsx = (byte)(_lstNhaSanXuat.Count + 1);
                                        nhaSanXuat.TenNsx = txt_nsx.Text.Trim();
                                        sp.MaNsx = nhaSanXuat.MaNsx;
                                        _iServiceNhaSanXuat.AddNhaSanXuat(nhaSanXuat);
                                        _lstNhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
                                    }

                                    var TempListNSX = _lstNhaSanXuat.Where(c => c.TenNsx == txt_nsx.Text);

                                    if (TempListNSX.Count() != 0)
                                    {

                                        var maNSX = _lstNhaSanXuat.Where(c => c.TenNsx == txt_nsx.Text).Select(c => c.MaNsx)
                                            .FirstOrDefault();
                                        sp.MaNsx = maNSX;

                                    }
                                    else
                                    {
                                        NhaSanXuat nhaSanXuat = new NhaSanXuat();
                                        nhaSanXuat.MaNsx = (byte)(_lstNhaSanXuat.Count + 1);
                                        nhaSanXuat.TenNsx = txt_nsx.Text.Trim();
                                        sp.MaNsx = nhaSanXuat.MaNsx;
                                        _iServiceNhaSanXuat.AddNhaSanXuat(nhaSanXuat);
                                    }
                                    if (_lstNhaCungCap.Count == 0)
                                    {
                                        NhaCungCap nhaCungCap = new NhaCungCap();
                                        nhaCungCap.MaNcc = (byte)(_lstNhaCungCap.Count + 1);
                                        nhaCungCap.TenNcc = txt_ncc.Text.Trim();
                                        sp.MaNcc = nhaCungCap.MaNcc;
                                        _iServiceNhaCungCap.AddNhaCungCap(nhaCungCap);
                                        _lstNhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
                                    }

                                    var TempListNhaCC = _lstNhaCungCap.Where(c => c.TenNcc == txt_ncc.Text);

                                    if (TempListNhaCC.Count() != 0)
                                    {

                                        var maNCC = _lstNhaCungCap.Where(c => c.TenNcc == txt_ncc.Text).Select(c => c.MaNcc)
                                            .FirstOrDefault();
                                        sp.MaNcc = maNCC;

                                    }
                                    else
                                    {
                                        NhaCungCap nhaCungCap = new NhaCungCap();
                                        nhaCungCap.MaNcc = (byte)(_lstNhaCungCap.Count + 1);
                                        nhaCungCap.TenNcc = txt_ncc.Text.Trim();
                                        sp.MaNcc = nhaCungCap.MaNcc;
                                        _iServiceNhaCungCap.AddNhaCungCap(nhaCungCap);
                                    }
                                    _iQlSanPham.Insert(sp);
                                }

                            }

                            if (chb_new.Checked == false && chb_old.Checked == false)
                            {
                                if (checknewsp.Count() != 0)
                                {
                                    foreach (var x in checknewsp)
                                    {
                                        ctsp.MaSp = x.MaSP;
                                    }
                                }
                            }
                            var check = _lstHienThiChiTietSp.Where(c => c.HinhAnh == txt_duongdananh.Text);
                            if (check.Count() != 0)
                            {
                                MessageBox.Show("Ảnh minh họa này đã được sử dụng", "Cảnh báo");
                                txt_duongdananh.Text = null;
                                ptr_addsanpham.Image = null;
                                return;
                            }
                            else
                            {
                                File.Copy(fileAdress, fileSavePath, true);
                                Barcode barcode = new Barcode();
                                Image img = barcode.Encode(TYPE.CODE128, ctsp.MaCtsp, 500, 150);
                                var dialog = new SaveFileDialog();
                                dialog.Title = "Lưu ảnh Barcode của sản phẩm mới";
                                dialog.InitialDirectory = saveDirectory + "BarcodeImages";
                                dialog.Filter = "JPEG(*.jpg)|*.jpg";
                                if (dialog.ShowDialog() == DialogResult.OK)
                                {
                                    fileNameAnhBarcode = Path.GetFileName(dialog.FileName);
                                    img.Save(dialog.FileName);
                                    ctsp.BarCode = "BarcodeImages\\" + fileNameAnhBarcode;
                                }
                            }
                        }
                        _iChiTietSp.Them(ctsp);
                        MessageBox.Show("Thêm Thành Công", "Thông báo");
                        LoadDgrid();
                        cmb_sp.Items.Clear();
                        foreach (var x in _iQlSanPham.GetLstSanPhams())
                        {
                            cmb_sp.Items.Add(x.MaSp);
                        }
                        Reset();
                    }
                }
                catch (Exception error)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }
        }

        private void dgrid_chitietsp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                b = 1;
                _lstHienThiChiTietSp = _iChiTietSp.getLstHienThiChiTietSP();
                _lstChiTietSanPhams = _iChiTietSp.GetLstChiTietSP();
                _lstSanPhams = _iQlSanPham.GetLstSanPhams();
                if (e.RowIndex == _lstHienThiChiTietSp.Count || e.RowIndex == -1)
                {
                    return;
                }

                if (c == 1)
                {
                    btn_add1.Enabled = false;
                }
                var hienthi = _lstHienThiChiTietSp.Where(c => c.ID == (int)dgrid_chitietsp.Rows[e.RowIndex].Cells[0].Value).FirstOrDefault();
                maCTSP = hienthi.MaCTSP;
                maSP = hienthi.MaSP;
                var ctsp = _lstHienThiChiTietSp.Where(c => c.MaCTSP == maCTSP && c.MaSP == maSP).FirstOrDefault();
                cmb_sp.Visible = false;
                chb_new.Checked = false;
                chb_old.Checked = false;
                btn_editctsp.Enabled = true;
                btn_xoactsp.Enabled = true;
                txt_tenhang.ReadOnly = true;
                txt_ncc.ReadOnly = true;
                txt_nsx.ReadOnly = true;

                cmb_theloai.Enabled = false;
                cmb_sp.Text = maSP;
                label13.Visible = true;
                label13.Text = ctsp.TenChiTietSP;
                txt_tengiay.Text = ctsp.TenGiay;
                txt_tenhang.Text = ctsp.TenThuongHieu;
                cmb_theloai.Text = ctsp.TenTheLoai;
                txt_ncc.Text = ctsp.TenNCC;
                txt_nsx.Text = ctsp.TenNSX;
                cmb_mausac.Text = ctsp.TenMau;
                cmb_kichthuoc.Text = ctsp.KichThuoc.ToString();
                cmb_chatlieu.Text = ctsp.ChatLieu;
                txt_giaban.Text = ctsp.GiaBan.ToString();
                txt_duongdananh.Text = ctsp.HinhAnh;
                ptr_addsanpham.Image = Image.FromFile(saveDirectory + ctsp.HinhAnh);
                ptr_barcode.Image = Image.FromFile(saveDirectory + ctsp.Barcode);
                txt_soluong.Text = ctsp.SoLuong.ToString();
            }
            catch (Exception exception)
            {
                return;
            }
        }
        private void btn_editctsp_Click(object sender, EventArgs e)
        {
            if (CheckQuyen(nv))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(txt_tengiay.Text) || string.IsNullOrEmpty(txt_tenhang.Text) || string.IsNullOrEmpty(txt_ncc.Text) || string.IsNullOrEmpty(txt_nsx.Text) || string.IsNullOrEmpty(cmb_theloai.Text) || string.IsNullOrEmpty(cmb_chatlieu.Text) || string.IsNullOrEmpty(cmb_kichthuoc.Text) || string.IsNullOrEmpty(cmb_mausac.Text) || string.IsNullOrEmpty(txt_soluong.Text) || string.IsNullOrEmpty(txt_duongdananh.Text) || string.IsNullOrEmpty(txt_giaban.Text) || txt_tengiay.Text.Trim().Length == 0 || txt_giaban.Text.Trim().Length == 0 || txt_soluong.Text.Trim().Length == 0 || txt_ncc.Text.Trim().Length == 0 || txt_nsx.Text.Trim().Length == 0 || txt_tenhang.Text.Trim().Length == 0)
                        {
                            MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Cảnh Báo");
                            return;
                        }
                        if (!checkSo(txt_soluong.Text) || !checkSo(txt_giaban.Text))
                        {
                            MessageBox.Show("Thông tin số lượng và giá bán chỉ nhập số", "Cảnh báo");
                        }

                        _lstChiTietSanPhams = _iChiTietSp.GetLstChiTietSP();
                        _lstHienThiChiTietSp = _iChiTietSp.getLstHienThiChiTietSP();
                        _lstSanPhams = _iQlSanPham.GetLstSanPhams();
                        _lstChatLieus = _iServiceChatLieu.GetLstChatLieu();
                        _lstMauSacs = _iServiceMauSac.GetLstMauSac();
                        _lstKichThuoc = _iServiceKichThuoc.GetLstKichThuoc();
                        _lstTheLoaiSanPham = _iServiceTheLoaiSp.GetLstTheLoaiSP();
                        _lstNhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
                        _lstNhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
                        var ctsp = _lstChiTietSanPhams.Where(c => c.MaCtsp == maCTSP).FirstOrDefault();
                        ctsp.MaMs = _lstMauSacs.Where(c => c.TenMs == cmb_mausac.Text).Select(c => c.MaMs).FirstOrDefault();
                        ctsp.MaKt = _lstKichThuoc.Where(c => c.Size == Convert.ToInt32(cmb_kichthuoc.Text)).Select(c => c.MaKt).FirstOrDefault();
                        ctsp.MaCl = _lstChatLieus.Where(c => c.TenCl == cmb_chatlieu.Text).Select(c => c.MaCl).FirstOrDefault();
                        ctsp.SoLuong = Convert.ToInt32(txt_soluong.Text);
                        ctsp.TenSp = txt_tengiay.Text.Trim();
                        ctsp.GiaBan = Convert.ToDouble(txt_giaban.Text);
                        ctsp.Hinhanh = txt_duongdananh.Text;
                        if (chb_old.Checked)
                        {
                            ctsp.MaSp = cmb_sp.Text;
                        }
                        if (chb_new.Checked)
                        {
                            var checknewsp = _lstHienThiChiTietSp.Where(c =>
                                c.TenThuongHieu == txt_tenhang.Text && c.TenTheLoai == cmb_theloai.Text &&
                                c.TenNCC == txt_ncc.Text && c.TenNSX == txt_nsx.Text);
                            if (checknewsp.Count() != 0)
                            {
                                foreach (var x in checknewsp)
                                {
                                    ctsp.MaSp = x.MaSP;
                                }
                            }
                            else
                            {
                                SanPham sanPham = new SanPham();
                                sanPham.MaSp = "SP" + (_lstSanPhams.Count + 1);
                                ctsp.MaSp = sanPham.MaSp;
                                sanPham.Id = _lstSanPhams.Count + 1;
                                sanPham.TenThuongHieu = txt_tenhang.Text.Trim();
                                sanPham.TrangThai = 1;
                                sanPham.BarCode = "...";
                                sanPham.MaTl = _lstTheLoaiSanPham.Where(c => c.TenTl == cmb_theloai.Text).Select(c => c.MaTl)
                                    .FirstOrDefault();
                                var TempListNhaCC = _lstNhaCungCap.Where(c => c.TenNcc == txt_ncc.Text);
                                if (TempListNhaCC.Count() != 0)
                                {

                                    var maNCC = _lstNhaCungCap.Where(c => c.TenNcc == txt_ncc.Text).Select(c => c.MaNcc)
                                        .FirstOrDefault();
                                    sanPham.MaNcc = maNCC;

                                }
                                else
                                {
                                    NhaCungCap nhaCungCap = new NhaCungCap();
                                    nhaCungCap.MaNcc = (byte)(_lstNhaCungCap.Count + 1);
                                    nhaCungCap.TenNcc = txt_ncc.Text.Trim();
                                    sanPham.MaNcc = nhaCungCap.MaNcc;
                                    _iServiceNhaCungCap.AddNhaCungCap(nhaCungCap);

                                }
                                var TempListNSX = _lstNhaSanXuat.Where(c => c.TenNsx == txt_nsx.Text);

                                if (TempListNSX.Count() != 0)
                                {

                                    var maNSX = _lstNhaSanXuat.Where(c => c.TenNsx == txt_nsx.Text).Select(c => c.MaNsx)
                                        .FirstOrDefault();
                                    sanPham.MaNsx = maNSX;
                                }
                                else
                                {
                                    NhaSanXuat nhaSanXuat = new NhaSanXuat();
                                    nhaSanXuat.MaNsx = (byte)(_lstNhaSanXuat.Count + 1);
                                    nhaSanXuat.TenNsx = txt_nsx.Text.Trim();
                                    sanPham.MaNsx = nhaSanXuat.MaNsx;
                                    _iServiceNhaSanXuat.AddNhaSanXuat(nhaSanXuat);
                                }
                                _iQlSanPham.Insert(sanPham);
                            }

                        }

                        _iChiTietSp.Sua(ctsp);
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        LoadDgrid();
                        cmb_sp.Items.Clear();
                        foreach (var x in _iQlSanPham.GetLstSanPhams())
                        {
                            cmb_sp.Items.Add(x.MaSp);
                        }
                        Reset();
                    }
                }
                catch (Exception exception)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }

        }

        private void chb_old_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckQuyen(nv))
            {
                if (chb_old.Checked)
                {
                    chb_new.Checked = false;
                    cmb_sp.Visible = true;
                    cmb_sp.BringToFront();
                    txt_tenhang.ReadOnly = true;
                    txt_ncc.ReadOnly = true;
                    txt_nsx.ReadOnly = true;
                    cmb_theloai.Enabled = false;
                    if (b == 1 && c == 2)
                    {
                        btn_add1.Enabled = false;
                    }
                    else
                    {
                        btn_add1.Enabled = true;
                    }

                    ptr_barcode.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }

        }
        private void chb_new_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckQuyen(nv))
            {
                if (chb_new.Checked)
                {
                    chb_old.Checked = false;
                    txt_tenhang.ReadOnly = false;
                    txt_ncc.ReadOnly = false;
                    txt_nsx.ReadOnly = false;
                    cmb_theloai.Enabled = true;
                    txt_tenhang.Text = null;
                    txt_ncc.Text = null;
                    txt_nsx.Text = null;
                    cmb_theloai.Text = null;
                    if (b == 1 && c == 2)
                    {
                        btn_add1.Enabled = false;
                    }
                    else
                    {
                        btn_add1.Enabled = true;
                    }
                    ptr_barcode.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }
        }

        private void btn_xoactsp_Click(object sender, EventArgs e)
        {

            if (CheckQuyen(nv))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        _lstChiTietSanPhams = _iChiTietSp.GetLstChiTietSP();
                        var xoa = _lstChiTietSanPhams.Where(c => c.MaCtsp == maCTSP).FirstOrDefault();
                        _iChiTietSp.Xoa(xoa);
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        LoadDgrid();
                        Reset();
                    }
                }
                catch (Exception exception)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }
        }

        private void btn_resetctsp_Click(object sender, EventArgs e)
        {

            if (CheckQuyen(nv))
            {
                b = 0;
                txt_tengiay.Text = null;
                cmb_sp.Visible = false;
                txt_tenhang.Text = null;
                txt_ncc.Text = null;
                txt_nsx.Text = null;
                cmb_theloai.Text = null;
                cmb_theloai.Enabled = false;
                cmb_chatlieu.Text = null;
                cmb_kichthuoc.Text = null;
                cmb_mausac.Text = null;
                txt_giaban.Text = null;
                txt_soluong.Text = null;
                txt_duongdananh.Text = null;
                ptr_addsanpham.Image = null;
                ptr_barcode.Image = null;
                chb_new.Checked = false;
                chb_old.Checked = false;
                btn_add1.Enabled = true;
                label13.Visible = false;
                label2.Visible = false;
                btn_editctsp.Enabled = true;
                btn_xoactsp.Enabled = true;
                _listTempAdd.Clear();
                listview_addn.Items.Clear();
            }
            else
            {
                MessageBox.Show("Bạn không được phân quyền để thực hiện chức năng này", "Thông báo");
                return;
            }
        }

        private void listview_addn_Click(object sender, EventArgs e)
        {
            b = 1;
            c = 2;
            var tempsp = _listTempAdd.FirstOrDefault(c => c.ID == Convert.ToInt32(listview_addn.SelectedItems[0].SubItems[0].Text));
            cmb_sp.Visible = false;
            chb_new.Checked = false;
            chb_old.Checked = false;
            txt_ncc.ReadOnly = true;
            txt_tenhang.ReadOnly = true;
            txt_nsx.ReadOnly = true;
            cmb_theloai.Enabled = false;
            btn_editctsp.Enabled = false;
            btn_xoactsp.Enabled = false;
            txt_tengiay.Text = tempsp.TenGiay;
            txt_tenhang.Text = tempsp.TenThuongHieu;
            cmb_theloai.Text = tempsp.TenTheLoai;
            txt_ncc.Text = tempsp.TenNCC;
            txt_nsx.Text = tempsp.TenNSX;
            cmb_mausac.Text = tempsp.TenMau;
            cmb_kichthuoc.Text = tempsp.KichThuoc.ToString();
            cmb_chatlieu.Text = tempsp.ChatLieu;
            txt_giaban.Text = tempsp.GiaBan.ToString();
            txt_duongdananh.Text = tempsp.HinhAnh;
            ptr_addsanpham.Image = null;
            ptr_barcode.Image = Image.FromFile(saveDirectory + tempsp.Barcode);
            txt_soluong.Text = tempsp.SoLuong.ToString();
            label13.Text = tempsp.TenChiTietSP;
        }

        private void Reset()
        {
            txt_tengiay.Text = null;
            cmb_sp.Visible = false;
            txt_tenhang.Text = null;
            txt_ncc.Text = null;
            txt_nsx.Text = null;
            cmb_theloai.Text = null;
            cmb_theloai.Enabled = false;
            cmb_chatlieu.Text = null;
            cmb_kichthuoc.Text = null;
            cmb_mausac.Text = null;
            txt_giaban.Text = null;
            txt_soluong.Text = null;
            txt_duongdananh.Text = null;
            ptr_addsanpham.Image = null;
            ptr_barcode.Image = null;
            chb_new.Checked = false;
            chb_old.Checked = false;
            label13.Visible = false;
            label2.Visible = false;
            listview_addn.Items.Clear();
            b = 0;
            c = 0;
        }

        private void cmb_sp_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstSanPhams = _iQlSanPham.GetLstSanPhams();
            _lstNhaCungCap = _iServiceNhaCungCap.GetLstNhaCungCap();
            _lstNhaSanXuat = _iServiceNhaSanXuat.GetLstNhaSanXuat();
            _lstTheLoaiSanPham = _iServiceTheLoaiSp.GetLstTheLoaiSP();
            cmb_theloai.Enabled = false;
            txt_tenhang.ReadOnly = true;
            txt_ncc.ReadOnly = true;
            txt_nsx.ReadOnly = true;

            var sp = _lstSanPhams.Where(c => c.MaSp == cmb_sp.Text).FirstOrDefault();
            txt_tenhang.Text = sp.TenThuongHieu;
            txt_nsx.Text = _lstNhaSanXuat.Where(c => c.MaNsx == sp.MaNsx).Select(c => c.TenNsx).FirstOrDefault();
            txt_ncc.Text = _lstNhaCungCap.Where(c => c.MaNcc == sp.MaNcc).Select(c => c.TenNcc).FirstOrDefault();
            cmb_theloai.Text = _lstTheLoaiSanPham.Where(c => c.MaTl == sp.MaTl).Select(c => c.TenTl).FirstOrDefault();
            cmb_sp.Visible = false;
        }

        private void cmb_theloai_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Mục này chỉ được chọn", "Cảnh báo");
            cmb_theloai.Text = null;
            return;
        }

        private void cmb_sp_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Mục này chỉ được chọn", "Cảnh báo");
            cmb_sp.Text = null;
            return;
        }

        private void cmb_mausac_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Mục này chỉ được chọn", "Cảnh báo");
            cmb_mausac.Text = null;
            return;
        }

        private void cmb_kichthuoc_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Mục này chỉ được chọn", "Cảnh báo");
            cmb_kichthuoc.Text = null;
            return;
        }

        private void cmb_chatlieu_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("Mục này chỉ được chọn", "Cảnh báo");
            cmb_chatlieu.Text = null;
            return;
        }

        public bool checkSo(string text)
        {
            return Regex.IsMatch(text, @"^\d+$");
        }

        void LoadDgridtimkiem(string timkiem)
        {
            _lstHienThiChiTietSp = _iChiTietSp.getLstHienThiChiTietSP();
            dgrid_chitietsp.ColumnCount = 8;
            dgrid_chitietsp.Columns[0].Name = "ID";
            dgrid_chitietsp.Columns[1].Name = "Tên";
            dgrid_chitietsp.Columns[2].Name = "Tên Màu(Hoặc Mã Màu)";
            dgrid_chitietsp.Columns[3].Name = "Kích Thước";
            dgrid_chitietsp.Columns[4].Name = "Giá Bán";
            dgrid_chitietsp.Columns[5].Name = "Nhà Sản Xuất";
            dgrid_chitietsp.Columns[6].Name = "Nhà Cung Cấp";
            dgrid_chitietsp.Columns[7].Name = "Số lượng";
            dgrid_chitietsp.Rows.Clear();
            foreach (var y in _lstHienThiChiTietSp.Where(c => c.Status == 1 && c.TenTheLoai.StartsWith(timkiem)))
            {
                dgrid_chitietsp.Rows.Add(y.ID, y.TenChiTietSP, y.TenMau, y.KichThuoc, string.Format("{0:#,##0.00}", y.GiaBan) + "VNĐ", y.TenNSX, y.TenNCC, y.SoLuong);

            }
        }

        private void cmb_timkiem_TextChanged(object sender, EventArgs e)
        {
            LoadDgridtimkiem(cmb_timkiem.Text);
            if (cmb_timkiem.Text == null)
            {
                LoadDgrid();
            }
        }

    }
}
