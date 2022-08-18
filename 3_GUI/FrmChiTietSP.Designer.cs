
namespace _3_GUI
{
    partial class FrmChiTietSP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChiTietSP));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DetailTable = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgrid_chitietsp = new System.Windows.Forms.DataGridView();
            this.listview_addn = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_timkiem = new System.Windows.Forms.ComboBox();
            this.CRUD = new System.Windows.Forms.GroupBox();
            this.chb_new = new System.Windows.Forms.CheckBox();
            this.chb_old = new System.Windows.Forms.CheckBox();
            this.cmb_chatlieu = new System.Windows.Forms.ComboBox();
            this.cmb_kichthuoc = new System.Windows.Forms.ComboBox();
            this.txt_nsx = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_ncc = new System.Windows.Forms.TextBox();
            this.cmb_theloai = new System.Windows.Forms.ComboBox();
            this.cmb_mausac = new System.Windows.Forms.ComboBox();
            this.btn_resetctsp = new System.Windows.Forms.Button();
            this.btn_xoactsp = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_duongdananh = new System.Windows.Forms.TextBox();
            this.btn_add1 = new System.Windows.Forms.Button();
            this.btn_editctsp = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ptr_barcode = new System.Windows.Forms.PictureBox();
            this.ptr_addsanpham = new System.Windows.Forms.PictureBox();
            this.txt_tenhang = new System.Windows.Forms.TextBox();
            this.btn_moanh = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_soluong = new System.Windows.Forms.TextBox();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.txt_tengiay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_sp = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.DetailTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_chitietsp)).BeginInit();
            this.CRUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptr_barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptr_addsanpham)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1687, 684);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.Controls.Add(this.DetailTable);
            this.tabPage1.Controls.Add(this.CRUD);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1679, 651);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông Tin Sản Phẩm";
            // 
            // DetailTable
            // 
            this.DetailTable.Controls.Add(this.label2);
            this.DetailTable.Controls.Add(this.dgrid_chitietsp);
            this.DetailTable.Controls.Add(this.listview_addn);
            this.DetailTable.Controls.Add(this.label6);
            this.DetailTable.Controls.Add(this.cmb_timkiem);
            this.DetailTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.DetailTable.Location = new System.Drawing.Point(803, 3);
            this.DetailTable.Name = "DetailTable";
            this.DetailTable.Size = new System.Drawing.Size(873, 645);
            this.DetailTable.TabIndex = 67;
            this.DetailTable.TabStop = false;
            this.DetailTable.Text = "Bảng Chi Tiết Sản Phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 69;
            this.label2.Text = "Số lượng thêm:";
            this.label2.Visible = false;
            // 
            // dgrid_chitietsp
            // 
            this.dgrid_chitietsp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_chitietsp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrid_chitietsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_chitietsp.Location = new System.Drawing.Point(149, 62);
            this.dgrid_chitietsp.Name = "dgrid_chitietsp";
            this.dgrid_chitietsp.RowHeadersWidth = 51;
            this.dgrid_chitietsp.RowTemplate.Height = 29;
            this.dgrid_chitietsp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_chitietsp.Size = new System.Drawing.Size(711, 527);
            this.dgrid_chitietsp.TabIndex = 36;
            this.dgrid_chitietsp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_chitietsp_CellClick);
            // 
            // listview_addn
            // 
            this.listview_addn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listview_addn.HideSelection = false;
            this.listview_addn.LargeImageList = this.imageList1;
            this.listview_addn.Location = new System.Drawing.Point(19, 60);
            this.listview_addn.Name = "listview_addn";
            this.listview_addn.Size = new System.Drawing.Size(124, 529);
            this.listview_addn.TabIndex = 68;
            this.listview_addn.UseCompatibleStateImageBehavior = false;
            this.listview_addn.Visible = false;
            this.listview_addn.Click += new System.EventHandler(this.listview_addn_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Phiên bản sản phẩm";
            this.columnHeader1.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "326884.png");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(554, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "Tìm Kiếm";
            // 
            // cmb_timkiem
            // 
            this.cmb_timkiem.FormattingEnabled = true;
            this.cmb_timkiem.Location = new System.Drawing.Point(641, 27);
            this.cmb_timkiem.Name = "cmb_timkiem";
            this.cmb_timkiem.Size = new System.Drawing.Size(162, 28);
            this.cmb_timkiem.TabIndex = 64;
            this.cmb_timkiem.TextChanged += new System.EventHandler(this.cmb_timkiem_TextChanged);
            // 
            // CRUD
            // 
            this.CRUD.Controls.Add(this.chb_new);
            this.CRUD.Controls.Add(this.chb_old);
            this.CRUD.Controls.Add(this.cmb_chatlieu);
            this.CRUD.Controls.Add(this.cmb_kichthuoc);
            this.CRUD.Controls.Add(this.txt_nsx);
            this.CRUD.Controls.Add(this.label15);
            this.CRUD.Controls.Add(this.label16);
            this.CRUD.Controls.Add(this.txt_ncc);
            this.CRUD.Controls.Add(this.cmb_theloai);
            this.CRUD.Controls.Add(this.cmb_mausac);
            this.CRUD.Controls.Add(this.btn_resetctsp);
            this.CRUD.Controls.Add(this.btn_xoactsp);
            this.CRUD.Controls.Add(this.label11);
            this.CRUD.Controls.Add(this.txt_duongdananh);
            this.CRUD.Controls.Add(this.btn_add1);
            this.CRUD.Controls.Add(this.btn_editctsp);
            this.CRUD.Controls.Add(this.label13);
            this.CRUD.Controls.Add(this.ptr_barcode);
            this.CRUD.Controls.Add(this.ptr_addsanpham);
            this.CRUD.Controls.Add(this.txt_tenhang);
            this.CRUD.Controls.Add(this.btn_moanh);
            this.CRUD.Controls.Add(this.label25);
            this.CRUD.Controls.Add(this.label26);
            this.CRUD.Controls.Add(this.txt_soluong);
            this.CRUD.Controls.Add(this.txt_giaban);
            this.CRUD.Controls.Add(this.txt_tengiay);
            this.CRUD.Controls.Add(this.label8);
            this.CRUD.Controls.Add(this.label7);
            this.CRUD.Controls.Add(this.label5);
            this.CRUD.Controls.Add(this.label4);
            this.CRUD.Controls.Add(this.label3);
            this.CRUD.Controls.Add(this.label1);
            this.CRUD.Controls.Add(this.label12);
            this.CRUD.Controls.Add(this.cmb_sp);
            this.CRUD.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CRUD.Location = new System.Drawing.Point(8, 38);
            this.CRUD.Name = "CRUD";
            this.CRUD.Size = new System.Drawing.Size(778, 598);
            this.CRUD.TabIndex = 66;
            this.CRUD.TabStop = false;
            this.CRUD.Text = "Nghiệp vụ";
            // 
            // chb_new
            // 
            this.chb_new.AutoSize = true;
            this.chb_new.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chb_new.Location = new System.Drawing.Point(241, 77);
            this.chb_new.Name = "chb_new";
            this.chb_new.Size = new System.Drawing.Size(88, 24);
            this.chb_new.TabIndex = 65;
            this.chb_new.Text = "Tạo mới";
            this.chb_new.UseVisualStyleBackColor = true;
            this.chb_new.CheckedChanged += new System.EventHandler(this.chb_new_CheckedChanged);
            // 
            // chb_old
            // 
            this.chb_old.AutoSize = true;
            this.chb_old.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chb_old.Location = new System.Drawing.Point(168, 77);
            this.chb_old.Name = "chb_old";
            this.chb_old.Size = new System.Drawing.Size(70, 24);
            this.chb_old.TabIndex = 65;
            this.chb_old.Text = "Đã có";
            this.chb_old.UseVisualStyleBackColor = true;
            this.chb_old.CheckedChanged += new System.EventHandler(this.chb_old_CheckedChanged);
            // 
            // cmb_chatlieu
            // 
            this.cmb_chatlieu.FormattingEnabled = true;
            this.cmb_chatlieu.Location = new System.Drawing.Point(169, 381);
            this.cmb_chatlieu.Name = "cmb_chatlieu";
            this.cmb_chatlieu.Size = new System.Drawing.Size(162, 31);
            this.cmb_chatlieu.TabIndex = 64;
            this.cmb_chatlieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_chatlieu_KeyDown);
            // 
            // cmb_kichthuoc
            // 
            this.cmb_kichthuoc.FormattingEnabled = true;
            this.cmb_kichthuoc.Location = new System.Drawing.Point(168, 336);
            this.cmb_kichthuoc.Name = "cmb_kichthuoc";
            this.cmb_kichthuoc.Size = new System.Drawing.Size(162, 31);
            this.cmb_kichthuoc.TabIndex = 64;
            this.cmb_kichthuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_kichthuoc_KeyDown);
            // 
            // txt_nsx
            // 
            this.txt_nsx.Location = new System.Drawing.Point(168, 202);
            this.txt_nsx.Name = "txt_nsx";
            this.txt_nsx.ReadOnly = true;
            this.txt_nsx.Size = new System.Drawing.Size(162, 30);
            this.txt_nsx.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(7, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 23);
            this.label15.TabIndex = 44;
            this.label15.Text = "Tên Nhà Cung Cấp";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(7, 208);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 23);
            this.label16.TabIndex = 45;
            this.label16.Text = "Tên Nhà Sản Xuất";
            // 
            // txt_ncc
            // 
            this.txt_ncc.Location = new System.Drawing.Point(169, 158);
            this.txt_ncc.Name = "txt_ncc";
            this.txt_ncc.ReadOnly = true;
            this.txt_ncc.Size = new System.Drawing.Size(162, 30);
            this.txt_ncc.TabIndex = 50;
            // 
            // cmb_theloai
            // 
            this.cmb_theloai.Enabled = false;
            this.cmb_theloai.FormattingEnabled = true;
            this.cmb_theloai.Location = new System.Drawing.Point(168, 246);
            this.cmb_theloai.Name = "cmb_theloai";
            this.cmb_theloai.Size = new System.Drawing.Size(162, 31);
            this.cmb_theloai.TabIndex = 64;
            this.cmb_theloai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_theloai_KeyDown);
            // 
            // cmb_mausac
            // 
            this.cmb_mausac.FormattingEnabled = true;
            this.cmb_mausac.Location = new System.Drawing.Point(169, 291);
            this.cmb_mausac.Name = "cmb_mausac";
            this.cmb_mausac.Size = new System.Drawing.Size(162, 31);
            this.cmb_mausac.TabIndex = 64;
            this.cmb_mausac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_mausac_KeyDown);
            // 
            // btn_resetctsp
            // 
            this.btn_resetctsp.Location = new System.Drawing.Point(642, 440);
            this.btn_resetctsp.Name = "btn_resetctsp";
            this.btn_resetctsp.Size = new System.Drawing.Size(94, 29);
            this.btn_resetctsp.TabIndex = 63;
            this.btn_resetctsp.Text = "Reset";
            this.btn_resetctsp.UseVisualStyleBackColor = true;
            this.btn_resetctsp.Click += new System.EventHandler(this.btn_resetctsp_Click);
            // 
            // btn_xoactsp
            // 
            this.btn_xoactsp.Location = new System.Drawing.Point(642, 405);
            this.btn_xoactsp.Name = "btn_xoactsp";
            this.btn_xoactsp.Size = new System.Drawing.Size(94, 29);
            this.btn_xoactsp.TabIndex = 63;
            this.btn_xoactsp.Text = "Remove";
            this.btn_xoactsp.UseVisualStyleBackColor = true;
            this.btn_xoactsp.Click += new System.EventHandler(this.btn_xoactsp_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(337, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 23);
            this.label11.TabIndex = 40;
            this.label11.Text = "Ảnh Minh Họa";
            // 
            // txt_duongdananh
            // 
            this.txt_duongdananh.Location = new System.Drawing.Point(464, 23);
            this.txt_duongdananh.Name = "txt_duongdananh";
            this.txt_duongdananh.ReadOnly = true;
            this.txt_duongdananh.Size = new System.Drawing.Size(129, 30);
            this.txt_duongdananh.TabIndex = 52;
            // 
            // btn_add1
            // 
            this.btn_add1.Location = new System.Drawing.Point(642, 335);
            this.btn_add1.Name = "btn_add1";
            this.btn_add1.Size = new System.Drawing.Size(94, 29);
            this.btn_add1.TabIndex = 63;
            this.btn_add1.Text = "Add";
            this.btn_add1.UseVisualStyleBackColor = true;
            this.btn_add1.Click += new System.EventHandler(this.btn_add1_Click);
            // 
            // btn_editctsp
            // 
            this.btn_editctsp.Location = new System.Drawing.Point(642, 370);
            this.btn_editctsp.Name = "btn_editctsp";
            this.btn_editctsp.Size = new System.Drawing.Size(94, 29);
            this.btn_editctsp.TabIndex = 63;
            this.btn_editctsp.Text = "Edit";
            this.btn_editctsp.UseVisualStyleBackColor = true;
            this.btn_editctsp.Click += new System.EventHandler(this.btn_editctsp_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(336, 341);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 23);
            this.label13.TabIndex = 46;
            this.label13.Text = "Ảnh Barcode";
            this.label13.Visible = false;
            // 
            // ptr_barcode
            // 
            this.ptr_barcode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ptr_barcode.Location = new System.Drawing.Point(337, 372);
            this.ptr_barcode.Name = "ptr_barcode";
            this.ptr_barcode.Size = new System.Drawing.Size(299, 174);
            this.ptr_barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptr_barcode.TabIndex = 61;
            this.ptr_barcode.TabStop = false;
            // 
            // ptr_addsanpham
            // 
            this.ptr_addsanpham.Location = new System.Drawing.Point(337, 76);
            this.ptr_addsanpham.Name = "ptr_addsanpham";
            this.ptr_addsanpham.Size = new System.Drawing.Size(354, 192);
            this.ptr_addsanpham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptr_addsanpham.TabIndex = 59;
            this.ptr_addsanpham.TabStop = false;
            // 
            // txt_tenhang
            // 
            this.txt_tenhang.Location = new System.Drawing.Point(168, 114);
            this.txt_tenhang.Name = "txt_tenhang";
            this.txt_tenhang.ReadOnly = true;
            this.txt_tenhang.Size = new System.Drawing.Size(162, 30);
            this.txt_tenhang.TabIndex = 50;
            // 
            // btn_moanh
            // 
            this.btn_moanh.Location = new System.Drawing.Point(599, 25);
            this.btn_moanh.Name = "btn_moanh";
            this.btn_moanh.Size = new System.Drawing.Size(70, 29);
            this.btn_moanh.TabIndex = 62;
            this.btn_moanh.Text = "Open";
            this.btn_moanh.UseVisualStyleBackColor = true;
            this.btn_moanh.Click += new System.EventHandler(this.btn_moanh_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(6, 252);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 23);
            this.label25.TabIndex = 36;
            this.label25.Text = "Thể Loại";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label26.Location = new System.Drawing.Point(6, 120);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(82, 23);
            this.label26.TabIndex = 36;
            this.label26.Text = "Tên Hãng";
            // 
            // txt_soluong
            // 
            this.txt_soluong.Location = new System.Drawing.Point(168, 471);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(162, 30);
            this.txt_soluong.TabIndex = 55;
            // 
            // txt_giaban
            // 
            this.txt_giaban.Location = new System.Drawing.Point(168, 427);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(162, 30);
            this.txt_giaban.TabIndex = 54;
            // 
            // txt_tengiay
            // 
            this.txt_tengiay.Location = new System.Drawing.Point(168, 28);
            this.txt_tengiay.Name = "txt_tengiay";
            this.txt_tengiay.Size = new System.Drawing.Size(162, 30);
            this.txt_tengiay.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 473);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 23);
            this.label8.TabIndex = 43;
            this.label8.Text = "Số Lượng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(6, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "Giá Bán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(7, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 23);
            this.label5.TabIndex = 39;
            this.label5.Text = "Chất Liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(7, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "Kích Thước";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(7, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Màu Sắc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 36;
            this.label1.Text = "Dòng Sản Phẩm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(6, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 23);
            this.label12.TabIndex = 36;
            this.label12.Text = "Tên Giày";
            // 
            // cmb_sp
            // 
            this.cmb_sp.FormattingEnabled = true;
            this.cmb_sp.Location = new System.Drawing.Point(168, 73);
            this.cmb_sp.Name = "cmb_sp";
            this.cmb_sp.Size = new System.Drawing.Size(163, 31);
            this.cmb_sp.TabIndex = 66;
            this.cmb_sp.Visible = false;
            this.cmb_sp.SelectedIndexChanged += new System.EventHandler(this.cmb_sp_SelectedIndexChanged);
            this.cmb_sp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_sp_KeyDown);
            // 
            // FrmChiTietSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 684);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmChiTietSP";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.DetailTable.ResumeLayout(false);
            this.DetailTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_chitietsp)).EndInit();
            this.CRUD.ResumeLayout(false);
            this.CRUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptr_barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptr_addsanpham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox DetailTable;
        private System.Windows.Forms.ListView listview_addn;
        private System.Windows.Forms.DataGridView dgrid_chitietsp;
        private System.Windows.Forms.GroupBox CRUD;
        private System.Windows.Forms.ComboBox cmb_chatlieu;
        private System.Windows.Forms.ComboBox cmb_mausac;
        private System.Windows.Forms.Button btn_resetctsp;
        private System.Windows.Forms.Button btn_xoactsp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_duongdananh;
        private System.Windows.Forms.Button btn_add1;
        private System.Windows.Forms.Button btn_editctsp;
        private System.Windows.Forms.TextBox txt_nsx;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_ncc;
        private System.Windows.Forms.PictureBox ptr_barcode;
        private System.Windows.Forms.PictureBox ptr_addsanpham;
        private System.Windows.Forms.TextBox txt_tenhang;
        private System.Windows.Forms.Button btn_moanh;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_soluong;
        private System.Windows.Forms.TextBox txt_giaban;
        private System.Windows.Forms.TextBox txt_tengiay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_kichthuoc;
        private System.Windows.Forms.ComboBox cmb_theloai;
        private System.Windows.Forms.ComboBox cmb_sp;
        private System.Windows.Forms.CheckBox chb_new;
        private System.Windows.Forms.CheckBox chb_old;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_timkiem;
    }
}