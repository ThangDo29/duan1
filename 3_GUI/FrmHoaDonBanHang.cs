using AForge.Video;
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
using _2_BUS.IService;
using _2_BUS.Service;
using _1_DAL.Models;
using AForge.Video.DirectShow;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace _3_GUI
{
    public partial class FrmHoaDonBanHang : Form
    {
        IServiceQlyHDBan serviceQlyHDBan;
        IServiceHD serviceHD;
        FilterInfoCollection Filter;
        VideoCaptureDevice camera;
        HoaDon hoaDon1;
        //List<ChiTietHoaDonBan> lstCTHDBan;
        ChiTietHoaDonBan _chitiet;
        string _Mahoadon; // Hứng mã hóa đơn khi cellclick
        string _MaCTSP; // Hứng mã CTSP khi cellclick
        string selected; // Hững mã CTSP của listview
        public FrmHoaDonBanHang(HoaDon hoaDon)
        {
            InitializeComponent();
            serviceQlyHDBan = new ServiceQlyHDBan();
            serviceHD = new ServiceHD();
            hoaDon1 = hoaDon;
            //lstCTHDBan = new List<ChiTietHoaDonBan>();
            LoadDGridHD(hoaDon1);
            LoadDgridHDTreo();
            //LoadSPDaBan();
            LoadDgridSP();
        }

        private void FrmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            try
            {
                Filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                CmbCamera.Items.Add("USB2.0 HD UVC WebCam");
                CmbCamera.SelectedIndex = 0;
                LoadBarCode();
            }
            catch (Exception)
            {

                return;
            }
        }

        void LoadBarCode()
        {
            try
            {
                camera = new VideoCaptureDevice(Filter[1].MonikerString);
                camera.NewFrame += VideoCaptureDevice_NewFrame;
                camera.Start();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                BarcodeReader barcode = new BarcodeReader();
                var result = barcode.Decode(bitmap);
                if (result != null)
                {
                    txtBarcode.Invoke(new MethodInvoker(delegate ()
                    {
                        ChiTietSanPham chiTietSanPham = serviceQlyHDBan.GetlstCTSP().Where(c => c.BarCode == result.ToString()).FirstOrDefault();
                        if (chiTietSanPham == null)
                        {
                            MessageBox.Show("Quét mã không thành công", "Thông báo");
                        }
                        else
                        {
                            ChiTietHoaDonBan chiTietBan = new ChiTietHoaDonBan();
                            chiTietBan.Mahd = hoaDon1.MaHd;
                            chiTietBan.NgayTaoHd = hoaDon1.NgayLapHD;
                            chiTietBan.Mactsp = chiTietSanPham.MaCtsp;
                            chiTietBan.GiaBan = chiTietSanPham.GiaBan;
                            chiTietBan.TenSp = chiTietSanPham.TenSp;
                            chiTietBan.TrangThai = 1;
                            if (serviceQlyHDBan.GetlstCTHDBan().Any(c => c.Mahd == chiTietBan.Mahd && c.Mactsp == chiTietBan.Mactsp) == false)
                            {
                                if (chiTietSanPham.SoLuong >= 1)
                                {
                                    chiTietBan.SoLuong = 1;
                                    serviceQlyHDBan.AddCTHDBan(chiTietBan);
                                    MessageBox.Show("Thêm thành công");
                                    LoadDGridHD(hoaDon1);
                                    camera.Stop();
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng trong cửa hàng không đủ");
                                }

                            }
                            else
                            {
                                ChiTietHoaDonBan chiTietBan1 = serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == chiTietBan.Mahd && c.Mactsp == chiTietBan.Mactsp).FirstOrDefault();
                                if (chiTietBan1.SoLuong < chiTietSanPham.SoLuong)
                                {
                                    chiTietBan1.SoLuong += 1;
                                    chiTietBan1.TongTien = chiTietBan1.SoLuong * chiTietBan1.GiaBan;
                                    MessageBox.Show("Thêm thành công");
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng trong cửa hàng không đủ");
                                }
                                if (chiTietBan1.TrangThai == 0)
                                {
                                    chiTietBan1.TrangThai = 1;
                                    chiTietBan1.SoLuong = 1;
                                }
                                serviceQlyHDBan.EditCTHDBan(chiTietBan1);
                                LoadDGridHD(hoaDon1);
                            }
                        }
                        txtBarcode.Text = serviceQlyHDBan.GetlstCTSP().Where(c => c.BarCode == result.ToString()).FirstOrDefault().TenSp;
                    }));
                    //Thread.Sleep(2000);
                    //System.Media.SystemSounds.Hand.Play();
                    //MessageBox.Show("TC");
                }
                BarCode.Image = bitmap;
            }
            catch (Exception)
            {

                return;
            }
        }

        void LoadDGridHD(HoaDon hoaDonBans)
        {
            try
            {
                //DataGridViewButtonCell btnXacNhan = new DataGridViewButtonCell();
                //btnXacNhan.Value = "Xác nhận";
                txtMaHD.Text = hoaDon1.MaHd;
                dtpTime.Value = hoaDon1.NgayLapHD;
                txtMaNV.Text = hoaDon1.MaNv;
                DgirgHDonBan.ColumnCount = 6;
                DgirgHDonBan.Columns[0].Name = "MAHD";
                DgirgHDonBan.Columns[1].Name = "MACTSP";
                DgirgHDonBan.Columns[2].Name = "TenSp";
                DgirgHDonBan.Columns[3].Name = "SoLuong";
                DgirgHDonBan.Columns[4].Name = "Dongia";
                DgirgHDonBan.Columns[5].Name = "Tổng";
                //DgirgHDonBan.Columns[6].Name = "Sửa";
                //DgirgHDonBan.Columns[7].Name = "Xóa";
                DgirgHDonBan.Columns[0].Visible = false;
                DgirgHDonBan.Columns[1].Visible = false;
                Double total = 0;
                DgirgHDonBan.Rows.Clear();
                foreach (var x in serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDonBans.MaHd))
                {
                    if (x.TrangThai == 1)
                    {
                        System.Globalization.CultureInfo culture2 = new System.Globalization.CultureInfo("en-US");
                        decimal value2 = decimal.Parse(x.GiaBan.ToString(), System.Globalization.NumberStyles.AllowThousands);
                        textBox1.Text = String.Format(culture2, "{0:N0}", value2);
                        System.Globalization.CultureInfo culture1 = new System.Globalization.CultureInfo("en-US");
                        decimal value1 = decimal.Parse((x.SoLuong * x.GiaBan).ToString(), System.Globalization.NumberStyles.AllowThousands);
                        textBox2.Text = String.Format(culture1, "{0:N0}", value1);
                        DgirgHDonBan.Rows.Add(x.Mahd, x.Mactsp, x.TenSp, x.SoLuong, textBox1.Text+ " VND", textBox2.Text + " VND");
                        total += (x.SoLuong * x.GiaBan);
                        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                        decimal value = decimal.Parse(total.ToString(), System.Globalization.NumberStyles.AllowThousands);
                        txtTong.Text = String.Format(culture, "{0:N0}", value);
                    }
                    else if (x.TrangThai == 0)
                    {
                        System.Globalization.CultureInfo culture2 = new System.Globalization.CultureInfo("en-US");
                        decimal value2 = decimal.Parse(x.GiaBan.ToString(), System.Globalization.NumberStyles.AllowThousands);
                        textBox1.Text = String.Format(culture2, "{0:N0}", value2);
                        System.Globalization.CultureInfo culture1 = new System.Globalization.CultureInfo("en-US");
                        decimal value1 = decimal.Parse((x.SoLuong * x.GiaBan).ToString(), System.Globalization.NumberStyles.AllowThousands);
                        textBox2.Text = String.Format(culture1, "{0:N0}", value1);
                        DgirgHDonBan.Rows.Add(x.Mahd, x.Mactsp, x.TenSp, x.SoLuong, textBox1.Text + " VND", textBox2.Text + " VND");
                        total += (x.SoLuong * x.GiaBan);
                        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                        decimal value = decimal.Parse(total.ToString(), System.Globalization.NumberStyles.AllowThousands);
                        txtTong.Text = String.Format(culture, "{0:N0}", value);
                    }
                }
                if (serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDonBans.MaHd && c.TrangThai == 1).ToList().Count != 0)
                {
                    DgirgHDonBan.Rows[serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd && c.TrangThai == 1).ToList().Count].Cells[5].Value = txtTong.Text + " VND";
                    DgirgHDonBan.Rows[serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd && c.TrangThai == 1).ToList().Count].Cells[4].Value = "Tổng";
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void FrmHoaDonBanHang_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FrmHoaDonBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        void LoadDgridHDTreo()
        {
            listHDTreo.Clear();
            listHDTreo.View = View.Details;
            listHDTreo.Columns.Add("", 100);
            listHDTreo.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            ImageList img = new ImageList();
            img.ImageSize = new Size(69, 69);
            foreach (var x in serviceHD.GetLstHoaDon().Where(c => c.ThanhToan == false && c.LoaiHd == 0 && c.TrangThai != 3))
            {
                img.Images.Add(Image.FromFile("E:\\bill.png"));
            }
            listHDTreo.SmallImageList = img;
            List<HoaDon> lstHD = serviceHD.GetLstHoaDon().Where(c => c.ThanhToan == false && c.LoaiHd == 0).ToList();
            for (int i = 0; i < lstHD.Count; i++)
            {
                listHDTreo.Items.Add(lstHD[i].MaHd.ToString(), i);
            }
        }
        void LoadDgridSP()
        {
            listViewSP.Clear();
            listViewSP.View = View.LargeIcon;
            ImageList img = new ImageList();
            img.ImageSize = new Size(100, 100);
            foreach (var x in serviceQlyHDBan.GetlstCTSP().Where(c => c.TrangThai == 1))
            {
                img.Images.Add(Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\" + x.Hinhanh));
            }
            listViewSP.LargeImageList = img;
            List<ChiTietSanPham> lstCTSP = serviceQlyHDBan.GetlstCTSP().Where(c => c.TrangThai == 1).ToList();
            for (int i = 0; i < lstCTSP.Count; i++)
            {
                listViewSP.Items.Add(lstCTSP[i].TenSp.ToString(), i);
            }
        }
        private void DgirgHDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                _Mahoadon = DgirgHDonBan.Rows[rowindex].Cells[0].Value.ToString();
                _MaCTSP = DgirgHDonBan.Rows[rowindex].Cells[1].Value.ToString();
                _chitiet = serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == _Mahoadon && c.Mactsp == _MaCTSP).FirstOrDefault();
                ChiTietSanPham _chitietSP = serviceQlyHDBan.GetlstCTSP().Where(c => c.MaCtsp == _MaCTSP).FirstOrDefault();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnNewHD_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaNv = hoaDon1.MaNv;
                serviceHD.AddHoaDon(hoaDon);
                hoaDon1 = hoaDon;
                LoadDGridHD(hoaDon1);
                LoadDgridHDTreo();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnupSl_Click(object sender, EventArgs e)
        {
            try
            {
                if (hoaDon1.ThanhToan == true && hoaDon1.LoaiHd == 0)
                {
                    MessageBox.Show("Hóa đơn đã thanh toán không thể thêm");
                }
                else if (_chitiet.SoLuong < serviceQlyHDBan.GetlstCTSP().Where(c => c.MaCtsp == _chitiet.Mactsp).FirstOrDefault().SoLuong)
                {
                    if (hoaDon1.LoaiHd == 1 && hoaDon1.TrangThai != 1)
                    {
                        MessageBox.Show("Hóa đơn đã thanh toán không thể thêm");
                        return;
                    }
                    _chitiet.SoLuong += 1;
                    _chitiet.TongTien = _chitiet.SoLuong * _chitiet.GiaBan;
                    serviceQlyHDBan.EditCTHDBan(_chitiet);
                    if (hoaDon1.LoaiHd == 1 && hoaDon1.TrangThai == 1)
                    {
                        btnXN.Text = "Giao Hàng";
                        hoaDon1.TrangThai = 5;
                        serviceHD.EditHoaDonw(hoaDon1);
                        LoadHDGiaoHang();

                    }

                }
                else
                {
                    MessageBox.Show("Số lượng trong cửa hàng không đủ");
                }
                LoadDGridHD(hoaDon1);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btndownSl_Click(object sender, EventArgs e)
        {
            try
            {
                if (_chitiet.SoLuong > 1)
                {
                    _chitiet.SoLuong -= 1;
                    _chitiet.TongTien = _chitiet.SoLuong * _chitiet.GiaBan;
                    serviceQlyHDBan.EditCTHDBan(_chitiet);
                    if (hoaDon1.LoaiHd == 1 && hoaDon1.TrangThai != 0)
                    {
                        hoaDon1.TrangThai = 5;
                        btnXN.Text = "Giao Hàng";
                        serviceHD.EditHoaDonw(hoaDon1);
                        LoadHDGiaoHang();
                    }
                    else if (hoaDon1.LoaiHd == 1 && hoaDon1.TrangThai == 0)
                    {
                        hoaDon1.TrangThai = 2;
                        btnXN.Text = "Hoàn Thành";
                        serviceHD.EditHoaDonw(hoaDon1);
                        LoadHDGiaoHang();
                    }
                }
                else if (_chitiet.SoLuong == 1)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                }

                LoadDGridHD(hoaDon1);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btndeteleCT_Click(object sender, EventArgs e)
        {
            try
            {
                if (hoaDon1.LoaiHd == 0)
                {
                    _chitiet.TrangThai = 2;
                    serviceQlyHDBan.EditCTHDBan(_chitiet);
                    LoadDGridHD(hoaDon1);
                }
                else if (hoaDon1.LoaiHd == 1 && hoaDon1.TrangThai !=1)
                {
                    foreach (var x in serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd))
                    {
                        foreach (var y in serviceQlyHDBan.GetlstCTSP().Where(c => c.MaCtsp == x.Mactsp))
                        {
                            y.SoLuong -= x.SoLuong;
                            serviceQlyHDBan.EditCTSP(y);
                        }
                    }
                    _chitiet.TrangThai = 2;
                    hoaDon1.TrangThai = 2;
                    serviceQlyHDBan.EditCTHDBan(_chitiet);
                    serviceHD.EditHoaDonw(hoaDon1);
                    LoadDGridHD(hoaDon1);
                }
            }
            catch (Exception)
            {

                return;
            }
        }
        private void btnXN_Click(object sender, EventArgs e)
        {
            try
            {
                if (hoaDon1.ThanhToan == true && hoaDon1.LoaiHd == 0)
                {
                    MessageBox.Show("Hoá đơn đã thanh toán", "TB");
                }
                //else if (hoaDon1.LoaiHd == 1 && hoaDon1.TrangThai != 1)
                //{
                //    MessageBox.Show("Hoá đơn đã thanh toán", "TB");
                //}
                else if (btnXN.Text == "Giao Hàng")
                {
                    HoaDon hoaDon2 = serviceHD.GetLstHoaDon().Where(c => c.MaHd == hoaDon1.MaHd).FirstOrDefault();
                    hoaDon2.ThanhToan = true;
                    hoaDon2.TrangThai = 0;
                    serviceHD.EditHoaDonw(hoaDon2);
                    DgirgHDonBan.Rows.Clear();
                    LoadHDGiaoHang();
                    btnXN.Text = "Xác Nhận";
                    foreach (var x in serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd))
                    {
                        foreach (var y in serviceQlyHDBan.GetlstCTSP().Where(c => c.MaCtsp == x.Mactsp))
                        {
                            y.SoLuong -= x.SoLuong;
                            serviceQlyHDBan.EditCTSP(y);
                        }
                    }
                }
                else if (btnXN.Text == "Hoàn Thành")
                {
                    HoaDon hoaDon2 = serviceHD.GetLstHoaDon().Where(c => c.MaHd == hoaDon1.MaHd).FirstOrDefault();
                    hoaDon2.ThanhToan = true;
                    hoaDon2.TrangThai = 4;
                    serviceHD.EditHoaDonw(hoaDon2);
                    DgirgHDonBan.Rows.Clear();
                    LoadHDGiaoHang();
                    btnXN.Text = "Xác Nhận";
                }
                else
                {
                    foreach (var x in serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd))
                    {
                        foreach (var y in serviceQlyHDBan.GetlstCTSP().Where(c => c.MaCtsp == x.Mactsp))
                        {
                            y.SoLuong -= x.SoLuong;
                            serviceQlyHDBan.EditCTSP(y);
                        }
                        if (hoaDon1.LoaiHd == 0)
                        {
                            x.TrangThai = 0;
                            serviceQlyHDBan.EditCTHDBan(x);
                        }
                    }
                    HoaDon hoaDon2 = serviceHD.GetLstHoaDon().Where(c => c.MaHd == hoaDon1.MaHd).FirstOrDefault();
                    hoaDon2.NgayLapHD = DateTime.Now;
                    if (hoaDon2.LoaiHd == 0)
                    {
                        hoaDon2.ThanhToan = true;
                        serviceHD.EditHoaDonw(hoaDon2);
                        LoadDgridHDTreo();
                        DgirgHDonBan.Rows.Clear();
                    }
                    //else if (hoaDon2.LoaiHd == 1)
                    //{
                    //    hoaDon2.ThanhToan = true;
                    //    hoaDon2.TrangThai = 4;
                    //    serviceHD.EditHoaDonw(hoaDon2);
                    //    //int id = serviceHD.GetLstHoaDon().Where(c => c.LoaiHd == 1 && c.ThanhToan == false).Max(c => c.Id);
                    //    //hoaDon1 = serviceHD.GetLstHoaDon().Where(c => c.Id == id).FirstOrDefault();
                    //    LoadHDGiaoHang();
                    //    DgirgHDonBan.Rows.Clear();
                    //}
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void listHDTreo_MouseClick(object sender, MouseEventArgs e)
        {
            string selected = listHDTreo.SelectedItems[0].SubItems[0].Text;
            hoaDon1 = serviceHD.GetLstHoaDon().Where(c => c.MaHd == selected).FirstOrDefault();
            if (hoaDon1.LoaiHd == 0)
            {
                LoadDGridHD(hoaDon1);
            }
            else
            {
                if (hoaDon1.TrangThai != 1 && hoaDon1.TrangThai != 5)
                {
                    btnXN.Text = "Hoàn Thành";
                }
                else if (hoaDon1.TrangThai == 1 || hoaDon1.TrangThai == 5)
                {
                    btnXN.Text = "Giao Hàng";
                }
                double total = 0;
                txtTenKH.Text = hoaDon1.TenKh;
                txtSDT.Text = hoaDon1.Sdt;
                txtDC.Text = hoaDon1.DiaChi;
                foreach (var item in serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd))
                {
                    total += item.TongTien;
                }
                txtTong.Text = total.ToString();
                ckbCTT.Checked = hoaDon1.ThanhToan == false ? true : false;
                ckbDTT.Checked = hoaDon1.ThanhToan == true ? true : false;
                LoadDGridHD(hoaDon1);
            }
        }

        private void listViewSP_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selected = listViewSP.SelectedItems[0].SubItems[0].Text;
                menuNguCanh.Show(listViewSP, new Point(e.X, e.Y));
            }
            if (e.Button == MouseButtons.Left)
            {
                string selected = listViewSP.SelectedItems[0].SubItems[0].Text;
                ChiTietSanPham ctsp = serviceQlyHDBan.GetlstCTSP().Where(c => c.TenSp == selected).FirstOrDefault();
                ChiTietHoaDonBan chiTietBan = new ChiTietHoaDonBan();
                chiTietBan.Mahd = hoaDon1.MaHd;
                chiTietBan.NgayTaoHd = hoaDon1.NgayLapHD;
                chiTietBan.Mactsp = ctsp.MaCtsp;
                chiTietBan.GiaBan = ctsp.GiaBan;
                chiTietBan.TenSp = ctsp.TenSp;
                chiTietBan.TrangThai = 1;
                if (serviceQlyHDBan.GetlstCTHDBan().Any(c => c.Mahd == chiTietBan.Mahd && c.Mactsp == chiTietBan.Mactsp) == false)
                {
                    if (hoaDon1.LoaiHd == 0 && hoaDon1.ThanhToan == false)
                    {
                        if (ctsp.SoLuong >= 1)
                        {
                            chiTietBan.SoLuong = 1;
                            serviceQlyHDBan.AddCTHDBan(chiTietBan);
                            MessageBox.Show("Thêm thành công");
                            LoadDGridHD(hoaDon1);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng trong cửa hàng không đủ");
                        }
                    }
                    else if (hoaDon1.LoaiHd == 1 && hoaDon1.ThanhToan == false)
                    {

                        if (ctsp.SoLuong >= 1)
                        {
                            chiTietBan.SoLuong = 1;
                            serviceQlyHDBan.AddCTHDBan(chiTietBan);
                            MessageBox.Show("Thêm thành công");
                            LoadDGridHD(hoaDon1);
                        }
                        else
                        {
                            MessageBox.Show("Số lượng trong cửa hàng không đủ");
                        }
                    }
                    else if (hoaDon1.ThanhToan == true)
                    {
                        MessageBox.Show("Hoá đơn đã thanh toán không thể thêm", "TB");
                    }
                }
                else
                {
                    ChiTietHoaDonBan chiTietBan1 = serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == chiTietBan.Mahd && c.Mactsp == chiTietBan.Mactsp).FirstOrDefault();
                    if (hoaDon1.ThanhToan == true)
                    {
                        MessageBox.Show("Hoá đơn đã thanh toán không thể thêm", "TB");
                    }
                    else if (ctsp.SoLuong >= 1)
                    {
                        if (chiTietBan1.TrangThai == 2)
                        {
                            chiTietBan1.TrangThai = 1;
                            chiTietBan1.SoLuong = 1;
                            MessageBox.Show("Thêm thành công");
                        }
                        else
                        {
                            if (chiTietBan1.SoLuong == ctsp.SoLuong)
                            {
                                MessageBox.Show("Số lượng trong cửa hàng không đủ");
                            }
                            else
                            {
                                chiTietBan1.SoLuong += 1;
                                MessageBox.Show("Thêm thành công");
                                chiTietBan1.TongTien = chiTietBan.SoLuong * chiTietBan1.GiaBan;
                            }
                        }
                    }
                    serviceQlyHDBan.EditCTHDBan(chiTietBan1);
                    LoadDGridHD(hoaDon1);
                }
            }
        }

        void LoadHDGiaoHang()
        {
            listHDTreo.Clear();
            listHDTreo.View = View.Details;
            listHDTreo.Columns.Add("", 100);
            listHDTreo.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            ImageList img = new ImageList();
            img.ImageSize = new Size(69, 69);
            foreach (var x in serviceHD.GetLstHoaDon().Where(c => c.LoaiHd == 1 && c.TrangThai != 3 && c.TrangThai != 4))
            {
                if (x.TrangThai == 1)
                {
                    img.Images.Add(Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\Resources\\tuyen-giao-hang.jpg"));
                }
                else if (x.TrangThai == 2)
                {
                    img.Images.Add(Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\Resources\\nhan-vien-giao-hang.png"));
                }
                else if (x.TrangThai == 5)
                {
                    img.Images.Add(Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\Resources\\7_800x450.jpg"));
                }
                else if (x.TrangThai == 0)
                {
                    img.Images.Add(Image.FromFile("E:\\Thư mục mới (3)\\duan1\\QuanLyBanHang_QuanLyShopGiay\\3_GUI\\Resources\\1562142858-tnp.png"));
                }
            }
            listHDTreo.SmallImageList = img;
            List<HoaDon> lstHD = serviceHD.GetLstHoaDon().Where(c => c.LoaiHd == 1 && c.TrangThai != 3 && c.TrangThai != 4).ToList();
            for (int i = 0; i < lstHD.Count; i++)
            {
                if (hoaDon1.TrangThai == 1 || hoaDon1.TrangThai == 5)
                {
                    listHDTreo.Items.Add(lstHD[i].MaHd.ToString()/*+ "-Chưa giao hàng"*/, i);
                }
                else if (hoaDon1.TrangThai == 0)
                {
                    listHDTreo.Items.Add(lstHD[i].MaHd.ToString() /*+"-Đang giao"*/ , i);
                }
            }
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon3 = serviceHD.GetLstHoaDon().Where(c => c.MaHd == hoaDon1.MaHd).FirstOrDefault();
            hoaDon3.TenKh = txtTenKH.Text;
            hoaDon3.Sdt = txtSDT.Text;
            hoaDon3.DiaChi = txtDC.Text;
            hoaDon3.LoaiHd = 1;
            hoaDon3.TrangThai = 1;
            #region Validal

            if (Regex.IsMatch(txtTenKH.Text, @"[a-zA-Z]+") == false)
            {
                MessageBox.Show("Tên khách hàng không được để trống");
                return;
            }
            if (Regex.IsMatch(txtDC.Text, @"[a-zA-Z0-9]+") == false)
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            if (Regex.IsMatch(txtSDT.Text, @"[0-9]") == false)
            {
                MessageBox.Show("Số điện thoại không để trống");
                return;
            }
            if (ckbCTT.Checked == false && ckbDTT.Checked == false)
            {
                MessageBox.Show("Chưa chọn trạng thái hóa đơn");
                return;
            }
            #endregion
            txtDC.Text = "";
            txtSDT.Text = "";
            txtTenKH.Text = "";
            txtTong.Text = "";
            ckbCTT.Checked = false;
            ckbDTT.Checked = false;
            serviceHD.EditHoaDonw(hoaDon3);
            LoadHDGiaoHang();
            btnChuyenDoi.Text = "HD Thanh Toan";
        }

        private void ckbDTT_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
            txtTong.Visible = false;
            ckbCTT.Checked = false;
            hoaDon1.ThanhToan = true;
        }

        private void ckbCTT_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCTT.Checked == true)
            {
                label8.Visible = true;
                txtTong.Visible = true;
                ckbDTT.Checked = false;
                hoaDon1.ThanhToan = false;
                double tong = 0;
                foreach (var x in serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == hoaDon1.MaHd && c.TrangThai !=2))
                {
                    tong += x.TongTien;
                }
                txtTong.Text = tong.ToString();
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                decimal value = decimal.Parse(txtTong.Text, System.Globalization.NumberStyles.AllowThousands);
                txtTong.Text = String.Format(culture, "{0:N0}", value);
                txtTong.Select(txtTong.Text.Length, 0);
                txtTong.Text = txtTong.Text + " VND";


            }
            else
            {
                label8.Visible = false;
                txtTong.Visible = false;
            }
        }

        private void btnChuyenDoi_Click(object sender, EventArgs e)
        {
            if (btnChuyenDoi.Text == "HD Giao Hang")
            {
                LoadHDGiaoHang();
                btnChuyenDoi.Text = "HD Treo";
            }
            else if (btnChuyenDoi.Text == "HD Treo")
            {
                txtDC.Text = "";
                txtSDT.Text = "";
                txtTenKH.Text = "";
                txtTong.Text = "";
                ckbCTT.Checked = false;
                ckbDTT.Checked = false;
                LoadDgridHDTreo();
                btnChuyenDoi.Text = "HD Giao Hang";
                btnXN.Text = "Xác Nhận";
            }
        }

        private void toolStripXemSP_Click(object sender, EventArgs e)
        {
            ChiTietSanPham ctsp = serviceQlyHDBan.GetlstCTSP().Where(c => c.TenSp == selected).FirstOrDefault();
            FrmThongTinSP frmThongTinSP = new FrmThongTinSP(ctsp);
            frmThongTinSP.Show();
        }

        private void toolStripThemSP_Click(object sender, EventArgs e)
        {
            ChiTietSanPham ctsp = serviceQlyHDBan.GetlstCTSP().Where(c => c.TenSp == selected).FirstOrDefault();
            ChiTietHoaDonBan chiTietBan = new ChiTietHoaDonBan();
            chiTietBan.Mahd = hoaDon1.MaHd;
            chiTietBan.NgayTaoHd = hoaDon1.NgayLapHD;
            chiTietBan.Mactsp = ctsp.MaCtsp;
            chiTietBan.GiaBan = ctsp.GiaBan;
            chiTietBan.TenSp = ctsp.TenSp;
            chiTietBan.TrangThai = 1;
            if (serviceQlyHDBan.GetlstCTHDBan().Any(c => c.Mahd == chiTietBan.Mahd && c.Mactsp == chiTietBan.Mactsp) == false)
            {
                if (hoaDon1.LoaiHd == 0 && hoaDon1.ThanhToan == false)
                {
                    if (ctsp.SoLuong >= 1)
                    {
                        chiTietBan.SoLuong = 1;
                        serviceQlyHDBan.AddCTHDBan(chiTietBan);
                        LoadDGridHD(hoaDon1);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng trong cửa hàng không đủ");
                    }
                }
                else if (hoaDon1.LoaiHd == 1 && hoaDon1.ThanhToan == false)
                {

                    if (ctsp.SoLuong >= 1)
                    {
                        chiTietBan.SoLuong = 1;
                        serviceQlyHDBan.AddCTHDBan(chiTietBan);
                        LoadDGridHD(hoaDon1);
                    }
                    else
                    {
                        MessageBox.Show("Số lượng trong cửa hàng không đủ");
                    }
                }
                else if (hoaDon1.ThanhToan == true)
                {
                    MessageBox.Show("Hoá đơn đã thanh toán không thể thêm", "TB");
                }
            }
            else
            {
                ChiTietHoaDonBan chiTietBan1 = serviceQlyHDBan.GetlstCTHDBan().Where(c => c.Mahd == chiTietBan.Mahd && c.Mactsp == chiTietBan.Mactsp).FirstOrDefault();
                if (hoaDon1.ThanhToan == true)
                {
                    MessageBox.Show("Hoá đơn đã thanh toán không thể thêm", "TB");
                }
                else if (ctsp.SoLuong >= 1)
                {
                    if (chiTietBan1.TrangThai == 0)
                    {
                        chiTietBan1.TrangThai = 1;
                        chiTietBan1.SoLuong = 1;
                    }
                    else
                    {
                        if (chiTietBan1.SoLuong == ctsp.SoLuong)
                        {
                            MessageBox.Show("Số lượng trong cửa hàng không đủ");
                        }
                        else
                        {
                            chiTietBan1.SoLuong += 1;
                            chiTietBan1.TongTien = chiTietBan.SoLuong * chiTietBan1.GiaBan;
                        }
                    }
                }
                serviceQlyHDBan.EditCTHDBan(chiTietBan1);
                LoadDGridHD(hoaDon1);
            }
        }

        private void btnHDTT_Click(object sender, EventArgs e)
        {
            FrmDanhSachHD frmDanhSachHD = new FrmDanhSachHD();
            frmDanhSachHD.Show();
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên khách hàng không được nhập số");
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại không được nhập chữ");
            }
        }

        private void listViewSP_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            Size size = listViewSP.LargeImageList.ImageSize;
            int w = size.Width + 4;
            int h = size.Height + 3;
            int x = (e.Bounds.Width - size.Width) / 2 + e.Bounds.X - 2;
            int y = e.Bounds.Top + 1;
            //e.Graphics.DrawRectangle(Pens.Red, e.Bounds);
            using (Pen pen = new Pen(Color.Black, 2f))
            {
                pen.Alignment = PenAlignment.Center;
                e.Graphics.DrawRectangle(pen, x, y, w, h);
            }
        }
    }
}
