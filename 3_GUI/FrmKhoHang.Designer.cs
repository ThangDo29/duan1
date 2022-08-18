
namespace _3_GUI
{
    partial class FrmKhoHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.QLNhapXuat = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_LoadForm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgv_KhoHang = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgv_dsKhoHang = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_HĐXuat = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_CTHD = new System.Windows.Forms.DataGridView();
            this.QLNhapXuat.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhoHang)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhoHang)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HĐXuat)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTHD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(616, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thông Tin Kho Hàng";
            // 
            // QLNhapXuat
            // 
            this.QLNhapXuat.Controls.Add(this.tabPage1);
            this.QLNhapXuat.Controls.Add(this.tabPage2);
            this.QLNhapXuat.Location = new System.Drawing.Point(7, 4);
            this.QLNhapXuat.Name = "QLNhapXuat";
            this.QLNhapXuat.SelectedIndex = 0;
            this.QLNhapXuat.Size = new System.Drawing.Size(1621, 979);
            this.QLNhapXuat.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.MintCream;
            this.tabPage1.Controls.Add(this.btn_LoadForm);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btn_TimKiem);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtTimKiem);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1613, 946);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kho Hàng";
            // 
            // btn_LoadForm
            // 
            this.btn_LoadForm.Location = new System.Drawing.Point(1507, 869);
            this.btn_LoadForm.Name = "btn_LoadForm";
            this.btn_LoadForm.Size = new System.Drawing.Size(100, 34);
            this.btn_LoadForm.TabIndex = 22;
            this.btn_LoadForm.Text = "Load Form";
            this.btn_LoadForm.UseVisualStyleBackColor = true;
            this.btn_LoadForm.Click += new System.EventHandler(this.btn_LoadForm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(622, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 50);
            this.label3.TabIndex = 21;
            this.label3.Text = "Thông Tin Kho Hàng";
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Location = new System.Drawing.Point(298, 78);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(100, 34);
            this.btn_TimKiem.TabIndex = 20;
            this.btn_TimKiem.Text = "Tìm Kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Tìm kiếm :";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(86, 82);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(194, 27);
            this.txtTimKiem.TabIndex = 19;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgv_KhoHang);
            this.groupBox6.Location = new System.Drawing.Point(3, 108);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1607, 757);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh sách kho hàng";
            // 
            // dgv_KhoHang
            // 
            this.dgv_KhoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_KhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_KhoHang.Location = new System.Drawing.Point(6, 26);
            this.dgv_KhoHang.Name = "dgv_KhoHang";
            this.dgv_KhoHang.RowHeadersWidth = 51;
            this.dgv_KhoHang.RowTemplate.Height = 29;
            this.dgv_KhoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_KhoHang.Size = new System.Drawing.Size(1598, 729);
            this.dgv_KhoHang.TabIndex = 2;
            this.dgv_KhoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KhoHang_CellClick);
            this.dgv_KhoHang.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_KhoHang_DataError_1);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MintCream;
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1613, 946);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Phiếu Xuất";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dgv_dsKhoHang);
            this.groupBox7.Location = new System.Drawing.Point(10, 609);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1592, 337);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Danh sách kho hàng";
            // 
            // dgv_dsKhoHang
            // 
            this.dgv_dsKhoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_dsKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsKhoHang.Location = new System.Drawing.Point(6, 26);
            this.dgv_dsKhoHang.Name = "dgv_dsKhoHang";
            this.dgv_dsKhoHang.RowHeadersWidth = 51;
            this.dgv_dsKhoHang.RowTemplate.Height = 29;
            this.dgv_dsKhoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dsKhoHang.Size = new System.Drawing.Size(1580, 305);
            this.dgv_dsKhoHang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(635, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 50);
            this.label2.TabIndex = 17;
            this.label2.Text = "Thông Tin Xuất";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_HĐXuat);
            this.groupBox3.Location = new System.Drawing.Point(1133, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 544);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phiếu Xuất";
            // 
            // dgv_HĐXuat
            // 
            this.dgv_HĐXuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_HĐXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HĐXuat.Location = new System.Drawing.Point(6, 26);
            this.dgv_HĐXuat.Name = "dgv_HĐXuat";
            this.dgv_HĐXuat.RowHeadersWidth = 51;
            this.dgv_HĐXuat.RowTemplate.Height = 29;
            this.dgv_HĐXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_HĐXuat.Size = new System.Drawing.Size(457, 411);
            this.dgv_HĐXuat.TabIndex = 0;
            this.dgv_HĐXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HĐXuat_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_CTHD);
            this.groupBox1.Location = new System.Drawing.Point(16, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1117, 544);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết phiếu xuất";
            // 
            // dgv_CTHD
            // 
            this.dgv_CTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_CTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CTHD.Location = new System.Drawing.Point(0, 26);
            this.dgv_CTHD.Name = "dgv_CTHD";
            this.dgv_CTHD.RowHeadersWidth = 51;
            this.dgv_CTHD.RowTemplate.Height = 29;
            this.dgv_CTHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CTHD.Size = new System.Drawing.Size(1111, 411);
            this.dgv_CTHD.TabIndex = 3;
            this.dgv_CTHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CTHD_CellClick);
            // 
            // FrmKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1757, 1055);
            this.Controls.Add(this.QLNhapXuat);
            this.Controls.Add(this.label1);
            this.Name = "FrmKhoHang";
            this.Text = "FrmKhoHang";
            this.QLNhapXuat.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhoHang)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhoHang)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HĐXuat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CTHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl QLNhapXuat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_HĐXuat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_CTHD;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgv_KhoHang;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgv_dsKhoHang;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_LoadForm;
    }
}