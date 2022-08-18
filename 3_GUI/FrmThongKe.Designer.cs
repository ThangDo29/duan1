
namespace _3_GUI
{
    partial class FrmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongKe));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.lbnGiaoHang = new System.Windows.Forms.Label();
            this.lbnThanhToan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbnDoanhThu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgridThgKe = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnTkiem = new System.Windows.Forms.Button();
            this.btnNam = new System.Windows.Forms.Button();
            this.bntThang = new System.Windows.Forms.Button();
            this.btnNgay = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridThgKe)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả bán hàng hôm nay";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.txtDoanhThu);
            this.groupBox3.Controls.Add(this.lbnGiaoHang);
            this.groupBox3.Controls.Add(this.lbnThanhToan);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(425, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 143);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Location = new System.Drawing.Point(494, 110);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(104, 27);
            this.txtDoanhThu.TabIndex = 5;
            this.txtDoanhThu.Visible = false;
            // 
            // lbnGiaoHang
            // 
            this.lbnGiaoHang.AutoSize = true;
            this.lbnGiaoHang.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbnGiaoHang.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbnGiaoHang.Location = new System.Drawing.Point(376, 87);
            this.lbnGiaoHang.Name = "lbnGiaoHang";
            this.lbnGiaoHang.Size = new System.Drawing.Size(99, 25);
            this.lbnGiaoHang.TabIndex = 4;
            this.lbnGiaoHang.Text = "Giao Hàng";
            // 
            // lbnThanhToan
            // 
            this.lbnThanhToan.AutoSize = true;
            this.lbnThanhToan.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbnThanhToan.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbnThanhToan.Location = new System.Drawing.Point(376, 26);
            this.lbnThanhToan.Name = "lbnThanhToan";
            this.lbnThanhToan.Size = new System.Drawing.Size(102, 25);
            this.lbnThanhToan.TabIndex = 3;
            this.lbnThanhToan.Text = "Doanh Thu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(150, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số Hóa Đơn Giao Hàng : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(150, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số Hóa Đơn Tại Quầy : ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(39, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbnDoanhThu);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 143);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lbnDoanhThu
            // 
            this.lbnDoanhThu.AutoSize = true;
            this.lbnDoanhThu.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbnDoanhThu.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lbnDoanhThu.Location = new System.Drawing.Point(175, 79);
            this.lbnDoanhThu.Name = "lbnDoanhThu";
            this.lbnDoanhThu.Size = new System.Drawing.Size(102, 25);
            this.lbnDoanhThu.TabIndex = 2;
            this.lbnDoanhThu.Text = "Doanh Thu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(112, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tổng Doanh Thu Hôm Nay";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgridThgKe
            // 
            this.dgridThgKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgridThgKe.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgridThgKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridThgKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgridThgKe.Location = new System.Drawing.Point(0, 226);
            this.dgridThgKe.Name = "dgridThgKe";
            this.dgridThgKe.RowHeadersWidth = 51;
            this.dgridThgKe.RowTemplate.Height = 29;
            this.dgridThgKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridThgKe.Size = new System.Drawing.Size(1032, 437);
            this.dgridThgKe.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.btnTkiem);
            this.groupBox4.Controls.Add(this.btnNam);
            this.groupBox4.Controls.Add(this.bntThang);
            this.groupBox4.Controls.Add(this.btnNgay);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1032, 57);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(683, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // btnTkiem
            // 
            this.btnTkiem.Location = new System.Drawing.Point(939, 25);
            this.btnTkiem.Name = "btnTkiem";
            this.btnTkiem.Size = new System.Drawing.Size(94, 29);
            this.btnTkiem.TabIndex = 3;
            this.btnTkiem.Text = "Tìm Kiếm";
            this.btnTkiem.UseVisualStyleBackColor = true;
            this.btnTkiem.Click += new System.EventHandler(this.btnTkiem_Click);
            // 
            // btnNam
            // 
            this.btnNam.Location = new System.Drawing.Point(180, 26);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(94, 29);
            this.btnNam.TabIndex = 2;
            this.btnNam.Text = "Năm";
            this.btnNam.UseVisualStyleBackColor = true;
            this.btnNam.Click += new System.EventHandler(this.btnNam_Click);
            // 
            // bntThang
            // 
            this.bntThang.Location = new System.Drawing.Point(92, 26);
            this.bntThang.Name = "bntThang";
            this.bntThang.Size = new System.Drawing.Size(94, 29);
            this.bntThang.TabIndex = 1;
            this.bntThang.Text = "Tháng";
            this.bntThang.UseVisualStyleBackColor = true;
            this.bntThang.Click += new System.EventHandler(this.bntThang_Click);
            // 
            // btnNgay
            // 
            this.btnNgay.Location = new System.Drawing.Point(2, 26);
            this.btnNgay.Name = "btnNgay";
            this.btnNgay.Size = new System.Drawing.Size(94, 29);
            this.btnNgay.TabIndex = 0;
            this.btnNgay.Text = "Hôm nay";
            this.btnNgay.UseVisualStyleBackColor = true;
            this.btnNgay.Click += new System.EventHandler(this.btnNgay_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "14.jpg");
            this.imageList1.Images.SetKeyName(1, "15.jpg");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(494, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 27);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1032, 663);
            this.Controls.Add(this.dgridThgKe);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmThongKe";
            this.Text = "FrmThongKe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgridThgKe)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbnGiaoHang;
        private System.Windows.Forms.Label lbnThanhToan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbnDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgridThgKe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnTkiem;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.Button bntThang;
        private System.Windows.Forms.Button btnNgay;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.TextBox textBox1;
    }
}