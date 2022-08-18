
namespace _3_GUI
{
    partial class FrmPhieuNhap
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
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCane1 = new System.Windows.Forms.Button();
            this.btntimkiem1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgridView1 = new System.Windows.Forms.DataGridView();
            this.dgridPhieuNhap = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGuiYC = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lblManv = new System.Windows.Forms.Label();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgridSanPham = new System.Windows.Forms.DataGridView();
            this.txtTimKiemSP = new System.Windows.Forms.TextBox();
            this.btntimkiem2 = new System.Windows.Forms.Button();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dgridDaXuLi = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCanel2 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridPhieuNhap)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridDaXuLi)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Location = new System.Drawing.Point(399, 21);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(135, 42);
            this.btnTaoPhieu.TabIndex = 4;
            this.btnTaoPhieu.Text = "Tạo Phiếu";
            this.btnTaoPhieu.UseVisualStyleBackColor = true;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCane1);
            this.groupBox2.Controls.Add(this.btntimkiem1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.dgridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 509);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phiếu Đang Chờ Xử Lí";
            // 
            // btnCane1
            // 
            this.btnCane1.Location = new System.Drawing.Point(382, 28);
            this.btnCane1.Name = "btnCane1";
            this.btnCane1.Size = new System.Drawing.Size(94, 29);
            this.btnCane1.TabIndex = 7;
            this.btnCane1.Text = "Canel";
            this.btnCane1.UseVisualStyleBackColor = true;
            this.btnCane1.Click += new System.EventHandler(this.btnCane1_Click);
            // 
            // btntimkiem1
            // 
            this.btntimkiem1.Location = new System.Drawing.Point(268, 28);
            this.btntimkiem1.Name = "btntimkiem1";
            this.btntimkiem1.Size = new System.Drawing.Size(92, 29);
            this.btntimkiem1.TabIndex = 6;
            this.btntimkiem1.Text = "Tìm Kiếm";
            this.btntimkiem1.UseVisualStyleBackColor = true;
            this.btntimkiem1.Click += new System.EventHandler(this.btntimkiem1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // dgridView1
            // 
            this.dgridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridView1.Location = new System.Drawing.Point(3, 75);
            this.dgridView1.Name = "dgridView1";
            this.dgridView1.RowHeadersWidth = 51;
            this.dgridView1.RowTemplate.Height = 29;
            this.dgridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridView1.Size = new System.Drawing.Size(486, 431);
            this.dgridView1.TabIndex = 3;
            this.dgridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridView1_CellClick);
          //  this.dgridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgridView1_RowPrePaint);
            // 
            // dgridPhieuNhap
            // 
            this.dgridPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridPhieuNhap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridPhieuNhap.Location = new System.Drawing.Point(3, 122);
            this.dgridPhieuNhap.Name = "dgridPhieuNhap";
            this.dgridPhieuNhap.RowHeadersWidth = 51;
            this.dgridPhieuNhap.RowTemplate.Height = 29;
            this.dgridPhieuNhap.Size = new System.Drawing.Size(572, 384);
            this.dgridPhieuNhap.TabIndex = 2;
            this.dgridPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridPhieuNhap_CellClick);
            this.dgridPhieuNhap.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgridPhieuNhap_DataError);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGuiYC);
            this.groupBox3.Controls.Add(this.btnTaoPhieu);
            this.groupBox3.Controls.Add(this.dgridPhieuNhap);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lbltime);
            this.groupBox3.Controls.Add(this.lblManv);
            this.groupBox3.Controls.Add(this.lblMaPhieu);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(492, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 509);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi Tiết Phiếu Yêu Cầu";
            // 
            // btnGuiYC
            // 
            this.btnGuiYC.Location = new System.Drawing.Point(399, 78);
            this.btnGuiYC.Name = "btnGuiYC";
            this.btnGuiYC.Size = new System.Drawing.Size(135, 38);
            this.btnGuiYC.TabIndex = 3;
            this.btnGuiYC.Text = "Gửi Yêu Cầu";
            this.btnGuiYC.UseVisualStyleBackColor = true;
            this.btnGuiYC.Click += new System.EventHandler(this.btnGuiYC_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Thời Gian :";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(101, 81);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(18, 20);
            this.lbltime.TabIndex = 2;
            this.lbltime.Text = "...";
            // 
            // lblManv
            // 
            this.lblManv.AutoSize = true;
            this.lblManv.Location = new System.Drawing.Point(133, 23);
            this.lblManv.Name = "lblManv";
            this.lblManv.Size = new System.Drawing.Size(18, 20);
            this.lblManv.TabIndex = 2;
            this.lblManv.Text = "...";
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(101, 52);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(18, 20);
            this.lblMaPhieu.TabIndex = 2;
            this.lblMaPhieu.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã Nhân Viên :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mã Phiếu :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.dgridSanPham);
            this.groupBox4.Controls.Add(this.txtTimKiemSP);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(1070, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(511, 509);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sản Phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tìm Kiếm :";
            // 
            // dgridSanPham
            // 
            this.dgridSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridSanPham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridSanPham.Location = new System.Drawing.Point(3, 75);
            this.dgridSanPham.Name = "dgridSanPham";
            this.dgridSanPham.RowHeadersWidth = 51;
            this.dgridSanPham.RowTemplate.Height = 29;
            this.dgridSanPham.Size = new System.Drawing.Size(505, 431);
            this.dgridSanPham.TabIndex = 3;
            this.dgridSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridSanPham_CellClick);
            this.dgridSanPham.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgridSanPham_DataError);
            // 
            // txtTimKiemSP
            // 
            this.txtTimKiemSP.Location = new System.Drawing.Point(118, 27);
            this.txtTimKiemSP.Name = "txtTimKiemSP";
            this.txtTimKiemSP.Size = new System.Drawing.Size(171, 27);
            this.txtTimKiemSP.TabIndex = 0;
            this.txtTimKiemSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiemSP_KeyPress);
            // 
            // btntimkiem2
            // 
            this.btntimkiem2.Location = new System.Drawing.Point(1355, 26);
            this.btntimkiem2.Name = "btntimkiem2";
            this.btntimkiem2.Size = new System.Drawing.Size(94, 27);
            this.btntimkiem2.TabIndex = 6;
            this.btntimkiem2.Text = "Tìm Kiếm";
            this.btntimkiem2.UseVisualStyleBackColor = true;
            this.btntimkiem2.Click += new System.EventHandler(this.btntimkiem2_Click);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(1082, 27);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(254, 27);
            this.dateTimePicker3.TabIndex = 7;
            // 
            // dgridDaXuLi
            // 
            this.dgridDaXuLi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridDaXuLi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridDaXuLi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgridDaXuLi.Location = new System.Drawing.Point(3, 72);
            this.dgridDaXuLi.Name = "dgridDaXuLi";
            this.dgridDaXuLi.RowHeadersWidth = 51;
            this.dgridDaXuLi.RowTemplate.Height = 29;
            this.dgridDaXuLi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridDaXuLi.Size = new System.Drawing.Size(1575, 355);
            this.dgridDaXuLi.TabIndex = 2;
            this.dgridDaXuLi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgridDaXuLi_CellClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCanel2);
            this.groupBox6.Controls.Add(this.btntimkiem2);
            this.groupBox6.Controls.Add(this.dateTimePicker3);
            this.groupBox6.Controls.Add(this.dgridDaXuLi);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(0, 509);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1581, 430);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Phiếu Đã Xử Lí";
            // 
            // btnCanel2
            // 
            this.btnCanel2.Location = new System.Drawing.Point(1475, 27);
            this.btnCanel2.Name = "btnCanel2";
            this.btnCanel2.Size = new System.Drawing.Size(94, 29);
            this.btnCanel2.TabIndex = 8;
            this.btnCanel2.Text = "Canel";
            this.btnCanel2.UseVisualStyleBackColor = true;
            this.btnCanel2.Click += new System.EventHandler(this.btnCanel2_Click);
            // 
            // FrmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1581, 939);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Name = "FrmPhieuNhap";
            this.Text = "Phiếu Yêu Cầu Nhập Vào Cửa Hàng";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridPhieuNhap)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridDaXuLi)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgridPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgridSanPham;
        private System.Windows.Forms.DataGridView dgridDaXuLi;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTimKiemSP;
        private System.Windows.Forms.Button btnGuiYC;
        private System.Windows.Forms.DataGridView dgridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Button btntimkiem1;
        private System.Windows.Forms.Button btntimkiem2;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.Label lblManv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCane1;
        private System.Windows.Forms.Button btnCanel2;
    }
}