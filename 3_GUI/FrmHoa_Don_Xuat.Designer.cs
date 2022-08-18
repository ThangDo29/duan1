
namespace _3_GUI
{
    partial class FrmHoa_Don_Xuat
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_TaoPhieu = new System.Windows.Forms.Button();
            this.dgv_CTTPX = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_YeuCau = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.dtpTimKiem = new System.Windows.Forms.DateTimePicker();
            this.dgv_PhieuXuat = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTTPX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_YeuCau)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_TaoPhieu);
            this.groupBox2.Controls.Add(this.dgv_CTTPX);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(474, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1153, 696);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phiếu xuất";
            // 
            // btn_TaoPhieu
            // 
            this.btn_TaoPhieu.Location = new System.Drawing.Point(608, 628);
            this.btn_TaoPhieu.Name = "btn_TaoPhieu";
            this.btn_TaoPhieu.Size = new System.Drawing.Size(132, 50);
            this.btn_TaoPhieu.TabIndex = 4;
            this.btn_TaoPhieu.Text = "Xác Nhận";
            this.btn_TaoPhieu.UseVisualStyleBackColor = true;
            this.btn_TaoPhieu.Click += new System.EventHandler(this.btn_TaoPhieu_Click);
            // 
            // dgv_CTTPX
            // 
            this.dgv_CTTPX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_CTTPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CTTPX.Location = new System.Drawing.Point(6, 99);
            this.dgv_CTTPX.Name = "dgv_CTTPX";
            this.dgv_CTTPX.RowHeadersWidth = 51;
            this.dgv_CTTPX.RowTemplate.Height = 29;
            this.dgv_CTTPX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CTTPX.Size = new System.Drawing.Size(1141, 512);
            this.dgv_CTTPX.TabIndex = 3;
            this.dgv_CTTPX.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CTTPX_CellClick);
            this.dgv_CTTPX.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_CTTPX_DataError);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(422, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thông Tin Phiếu Xuất";
            // 
            // dgv_YeuCau
            // 
            this.dgv_YeuCau.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_YeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_YeuCau.Location = new System.Drawing.Point(6, 23);
            this.dgv_YeuCau.Name = "dgv_YeuCau";
            this.dgv_YeuCau.RowHeadersWidth = 51;
            this.dgv_YeuCau.RowTemplate.Height = 29;
            this.dgv_YeuCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_YeuCau.Size = new System.Drawing.Size(466, 588);
            this.dgv_YeuCau.TabIndex = 4;
            this.dgv_YeuCau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_YeuCau_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgv_YeuCau);
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 621);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Phiếu yêu cầu ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_timKiem);
            this.groupBox3.Controls.Add(this.dtpTimKiem);
            this.groupBox3.Controls.Add(this.dgv_PhieuXuat);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 696);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1627, 245);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách phiếu xuất";
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.Location = new System.Drawing.Point(279, 23);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(87, 30);
            this.btn_timKiem.TabIndex = 5;
            this.btn_timKiem.Text = "Tìm Kiếm";
            this.btn_timKiem.UseVisualStyleBackColor = true;
            this.btn_timKiem.Click += new System.EventHandler(this.btn_timKiem_Click);
            // 
            // dtpTimKiem
            // 
            this.dtpTimKiem.Location = new System.Drawing.Point(12, 26);
            this.dtpTimKiem.Name = "dtpTimKiem";
            this.dtpTimKiem.Size = new System.Drawing.Size(250, 27);
            this.dtpTimKiem.TabIndex = 1;
            // 
            // dgv_PhieuXuat
            // 
            this.dgv_PhieuXuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PhieuXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv_PhieuXuat.Location = new System.Drawing.Point(3, 59);
            this.dgv_PhieuXuat.Name = "dgv_PhieuXuat";
            this.dgv_PhieuXuat.RowHeadersWidth = 51;
            this.dgv_PhieuXuat.RowTemplate.Height = 29;
            this.dgv_PhieuXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PhieuXuat.Size = new System.Drawing.Size(1621, 183);
            this.dgv_PhieuXuat.TabIndex = 0;
            this.dgv_PhieuXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_PhieuXuat_CellClick);
            this.dgv_PhieuXuat.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_PhieuXuat_DataError);
            // 
            // FrmHoa_Don_Xuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1627, 941);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmHoa_Don_Xuat";
            this.Text = "FrmHoa_Don_Xuat";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTTPX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_YeuCau)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PhieuXuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_YeuCau;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_PhieuXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_TaoPhieu;
        private System.Windows.Forms.DataGridView dgv_CTTPX;
        private System.Windows.Forms.DateTimePicker dtpTimKiem;
        private System.Windows.Forms.Button btn_timKiem;
    }
}