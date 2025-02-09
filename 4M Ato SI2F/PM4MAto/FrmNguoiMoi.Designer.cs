using System;

namespace PM4MAto
{
    partial class c
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
            this.txtTenNvMoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbChonNguoi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChonCongDoan = new System.Windows.Forms.ComboBox();
            this.txtMaNvMoi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNguoiMoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTenNvMoi
            // 
            this.txtTenNvMoi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNvMoi.Location = new System.Drawing.Point(253, 78);
            this.txtTenNvMoi.Name = "txtTenNvMoi";
            this.txtTenNvMoi.Size = new System.Drawing.Size(279, 29);
            this.txtTenNvMoi.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(77, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tên nhân viên:";
            // 
            // cbChonNguoi
            // 
            this.cbChonNguoi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChonNguoi.FormattingEnabled = true;
            this.cbChonNguoi.Items.AddRange(new object[] {
            "Người hỗ trợ",
            "Người thay thế",
            "Người mới học vị trí",
            "Người cũ học vị trí",
            "Người thay thế + Người hỗ trợ",
            "Người thay thế quản lý"});
            this.cbChonNguoi.Location = new System.Drawing.Point(253, 189);
            this.cbChonNguoi.Name = "cbChonNguoi";
            this.cbChonNguoi.Size = new System.Drawing.Size(279, 30);
            this.cbChonNguoi.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(77, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "Chọn vị trí:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(76, 135);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Chọn công đoạn:";
            // 
            // cbChonCongDoan
            // 
            this.cbChonCongDoan.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChonCongDoan.FormattingEnabled = true;
            this.cbChonCongDoan.Items.AddRange(new object[] {
            "LINECHOU",
            "LQC 1",
            "LQC 2",
            "SETTA 1",
            "SETTA 2",
            "KAIBAN",
            "BUHIN 1",
            "BUHIN 2",
            "OFFLINE 1",
            "OFFLINE 2",
            "OFFLINE 3",
            "OFFLINE 4",
            "OFFLINE 5",
            "OFFLINE 6",
            "CHECKA 1",
            "CHECKA 2",
            "CHECKA 3",
            "CHECKA 4",
            "SHIAGE 1",
            "SHIAGE 2",
            "SHIAGE 3",
            "SHIAGE 4",
            "SHIAGE 5",
            "GAIKAN 1",
            "GAIKAN 2",
            "GAIKAN 3",
            "GAIKAN 4",
            "PACKING",
            "TAPE 1",
            "TAPE 2",
            "TAPE 3",
            "TAPE 4",
            "TAPE 5",
            "TAPE 6",
            "TAPE 7",
            "TAPE 8",
            "TAPE 9",
            "TAPE 10",
            "TAPE 11",
            "TAPE 12",
            "TAPE 13",
            "TAPE 14",
            "TAPE 15",
            "TAPE 16",
            "LAYOUT 1",
            "LAYOUT 2",
            "LAYOUT 3",
            "LAYOUT 4",
            "LAYOUT 5",
            "LAYOUT 6",
            "LAYOUT 7",
            "LAYOUT 8",
            "LAYOUT 9",
            "SUB 1",
            "SUB 2",
            "SUB 3",
            "SUB 4",
            "SUB 5",
            "SUB 6",
            "SUB 7",
            "SUB 8",
            "SUB 9",
            "SUB 10",
            "SUB 11",
            "SUB 12",
            "SUB13 - SUB",
            "SUB13TAPE",
            "SUB 14",
            "SUB 15",
            "SUB 16",
            "SUB 17",
            "OSUB 1",
            "OSUB 2",
            "OSUB 3",
            "OSUB 4",
            "OSUB 5",
            "OSUB 6.7.8",
            "OSUB 9"});
            this.cbChonCongDoan.Location = new System.Drawing.Point(253, 131);
            this.cbChonCongDoan.Margin = new System.Windows.Forms.Padding(2);
            this.cbChonCongDoan.Name = "cbChonCongDoan";
            this.cbChonCongDoan.Size = new System.Drawing.Size(279, 30);
            this.cbChonCongDoan.TabIndex = 12;
            // 
            // txtMaNvMoi
            // 
            this.txtMaNvMoi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNvMoi.Location = new System.Drawing.Point(253, 27);
            this.txtMaNvMoi.Name = "txtMaNvMoi";
            this.txtMaNvMoi.Size = new System.Drawing.Size(279, 29);
            this.txtMaNvMoi.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mã nhân viên:";
            // 
            // btnNguoiMoi
            // 
            this.btnNguoiMoi.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNguoiMoi.Location = new System.Drawing.Point(230, 246);
            this.btnNguoiMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnNguoiMoi.Name = "btnNguoiMoi";
            this.btnNguoiMoi.Size = new System.Drawing.Size(108, 30);
            this.btnNguoiMoi.TabIndex = 22;
            this.btnNguoiMoi.Text = "Đồng ý";
            this.btnNguoiMoi.UseVisualStyleBackColor = true;
            this.btnNguoiMoi.Click += new System.EventHandler(this.btnNguoiMoi_Click);
            // 
            // c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 324);
            this.Controls.Add(this.btnNguoiMoi);
            this.Controls.Add(this.txtMaNvMoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTenNvMoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbChonNguoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChonCongDoan);
            this.Name = "c";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNguoiMoi";
            this.Load += new System.EventHandler(this.FrmNguoiMoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenNvMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbChonNguoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChonCongDoan;
        private System.Windows.Forms.TextBox txtMaNvMoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNguoiMoi;
    }
}