
namespace _3_GUI
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_PhieuXuat = new System.Windows.Forms.Button();
            this.btn_SanPham = new System.Windows.Forms.Button();
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_Kho = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btn_HoaDonNhap = new System.Windows.Forms.Button();
            this.btn_Nhan_Vien = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MintCream;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1420, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.MintCream;
            this.groupBox1.Controls.Add(this.btn_PhieuXuat);
            this.groupBox1.Controls.Add(this.btn_SanPham);
            this.groupBox1.Controls.Add(this.btn_DoanhThu);
            this.groupBox1.Controls.Add(this.btn_Kho);
            this.groupBox1.Controls.Add(this.btnThanhToan);
            this.groupBox1.Controls.Add(this.btn_HoaDonNhap);
            this.groupBox1.Controls.Add(this.btn_Nhan_Vien);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 676);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btn_PhieuXuat
            // 
            this.btn_PhieuXuat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_PhieuXuat.BackgroundImage")));
            this.btn_PhieuXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_PhieuXuat.ForeColor = System.Drawing.Color.Black;
            this.btn_PhieuXuat.Location = new System.Drawing.Point(6, 333);
            this.btn_PhieuXuat.Name = "btn_PhieuXuat";
            this.btn_PhieuXuat.Size = new System.Drawing.Size(258, 71);
            this.btn_PhieuXuat.TabIndex = 1;
            this.btn_PhieuXuat.Text = "          Phiếu Xuất Kho";
            this.btn_PhieuXuat.UseVisualStyleBackColor = true;
            this.btn_PhieuXuat.Click += new System.EventHandler(this.btn_PhieuXuat_Click);
            // 
            // btn_SanPham
            // 
            this.btn_SanPham.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SanPham.BackgroundImage")));
            this.btn_SanPham.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_SanPham.Location = new System.Drawing.Point(6, 103);
            this.btn_SanPham.Name = "btn_SanPham";
            this.btn_SanPham.Size = new System.Drawing.Size(258, 68);
            this.btn_SanPham.TabIndex = 0;
            this.btn_SanPham.Text = "                      Sản Phẩm";
            this.btn_SanPham.UseVisualStyleBackColor = true;
            this.btn_SanPham.Click += new System.EventHandler(this.btn_SanPham_Click);
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DoanhThu.BackgroundImage")));
            this.btn_DoanhThu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_DoanhThu.Location = new System.Drawing.Point(6, 410);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Size = new System.Drawing.Size(258, 68);
            this.btn_DoanhThu.TabIndex = 0;
            this.btn_DoanhThu.Text = "          Doanh Thu";
            this.btn_DoanhThu.UseVisualStyleBackColor = true;
            this.btn_DoanhThu.Click += new System.EventHandler(this.btn_DoanhThu_Click);
            // 
            // btn_Kho
            // 
            this.btn_Kho.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Kho.BackgroundImage")));
            this.btn_Kho.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Kho.Location = new System.Drawing.Point(6, 177);
            this.btn_Kho.Name = "btn_Kho";
            this.btn_Kho.Size = new System.Drawing.Size(258, 73);
            this.btn_Kho.TabIndex = 0;
            this.btn_Kho.Text = "          Kho";
            this.btn_Kho.UseVisualStyleBackColor = true;
            this.btn_Kho.Click += new System.EventHandler(this.btn_Kho_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.BackgroundImage")));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThanhToan.Location = new System.Drawing.Point(6, 26);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(258, 71);
            this.btnThanhToan.TabIndex = 0;
            this.btnThanhToan.Text = "     Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btn_HoaDonNhap
            // 
            this.btn_HoaDonNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_HoaDonNhap.BackgroundImage")));
            this.btn_HoaDonNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_HoaDonNhap.ForeColor = System.Drawing.Color.Black;
            this.btn_HoaDonNhap.Location = new System.Drawing.Point(6, 256);
            this.btn_HoaDonNhap.Name = "btn_HoaDonNhap";
            this.btn_HoaDonNhap.Size = new System.Drawing.Size(258, 71);
            this.btn_HoaDonNhap.TabIndex = 0;
            this.btn_HoaDonNhap.Text = "        Yêu Cầu Nhập";
            this.btn_HoaDonNhap.UseVisualStyleBackColor = true;
            this.btn_HoaDonNhap.Click += new System.EventHandler(this.btn_HoaDonNhap_Click);
            // 
            // btn_Nhan_Vien
            // 
            this.btn_Nhan_Vien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Nhan_Vien.BackgroundImage")));
            this.btn_Nhan_Vien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Nhan_Vien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Nhan_Vien.ForeColor = System.Drawing.Color.Black;
            this.btn_Nhan_Vien.Location = new System.Drawing.Point(6, 484);
            this.btn_Nhan_Vien.Name = "btn_Nhan_Vien";
            this.btn_Nhan_Vien.Size = new System.Drawing.Size(258, 68);
            this.btn_Nhan_Vien.TabIndex = 0;
            this.btn_Nhan_Vien.Text = "             Nhân Viên";
            this.btn_Nhan_Vien.UseVisualStyleBackColor = false;
            this.btn_Nhan_Vien.Click += new System.EventHandler(this.btn_Nhan_Vien_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(282, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1138, 676);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1420, 704);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SanPham;
        private System.Windows.Forms.Button btn_DoanhThu;
        private System.Windows.Forms.Button btn_Kho;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btn_HoaDonNhap;
        private System.Windows.Forms.Button btn_Nhan_Vien;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_PhieuXuat;
    }
}