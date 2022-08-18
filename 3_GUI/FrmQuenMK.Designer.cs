
namespace _3_GUI
{
    partial class FrmQuenMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuenMK));
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.txt_NhapEmail = new System.Windows.Forms.TextBox();
            this.lb_email = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.BackColor = System.Drawing.Color.MintCream;
            this.btn_xacnhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_xacnhan.ForeColor = System.Drawing.Color.Black;
            this.btn_xacnhan.Location = new System.Drawing.Point(333, 246);
            this.btn_xacnhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(136, 48);
            this.btn_xacnhan.TabIndex = 10;
            this.btn_xacnhan.Text = "Nhận code";
            this.btn_xacnhan.UseVisualStyleBackColor = false;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click_1);
            // 
            // txt_NhapEmail
            // 
            this.txt_NhapEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_NhapEmail.Location = new System.Drawing.Point(343, 179);
            this.txt_NhapEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_NhapEmail.Name = "txt_NhapEmail";
            this.txt_NhapEmail.Size = new System.Drawing.Size(245, 30);
            this.txt_NhapEmail.TabIndex = 9;
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.BackColor = System.Drawing.Color.Transparent;
            this.lb_email.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lb_email.Location = new System.Drawing.Point(218, 187);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(102, 23);
            this.lb_email.TabIndex = 8;
            this.lb_email.Text = "Nhập Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(245, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 50);
            this.label1.TabIndex = 7;
            this.label1.Text = "Quên mật khẩu ";
            // 
            // FrmQuenMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.txt_NhapEmail);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmQuenMK";
            this.Text = "FrmDoiMK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.TextBox txt_NhapEmail;
        private System.Windows.Forms.Label lb_email;
        private System.Windows.Forms.Label label1;
    }
}