namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    partial class frmCapNhatPhanCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatPhanCong));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMonHoc = new System.Windows.Forms.TextBox();
            this.cmbGiaoVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn Học:";
            // 
            // txtMonHoc
            // 
            this.txtMonHoc.Location = new System.Drawing.Point(90, 10);
            this.txtMonHoc.Name = "txtMonHoc";
            this.txtMonHoc.Size = new System.Drawing.Size(170, 20);
            this.txtMonHoc.TabIndex = 1;
            // 
            // cmbGiaoVien
            // 
            this.cmbGiaoVien.FormattingEnabled = true;
            this.cmbGiaoVien.Location = new System.Drawing.Point(90, 36);
            this.cmbGiaoVien.Name = "cmbGiaoVien";
            this.cmbGiaoVien.Size = new System.Drawing.Size(168, 21);
            this.cmbGiaoVien.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Giáo Viên:";
            // 
            // btCapNhat
            // 
            this.btCapNhat.Location = new System.Drawing.Point(63, 77);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btCapNhat.TabIndex = 3;
            this.btCapNhat.Text = "Cập Nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.Location = new System.Drawing.Point(153, 77);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 4;
            this.btThoat.Text = "Đóng";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // frmCapNhatPhanCong
            // 
            this.AcceptButton = this.btCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.CancelButton = this.btThoat;
            this.ClientSize = new System.Drawing.Size(292, 115);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btCapNhat);
            this.Controls.Add(this.cmbGiaoVien);
            this.Controls.Add(this.txtMonHoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCapNhatPhanCong";
            this.Text = "Cap nhat phan cong";
            this.Load += new System.EventHandler(this.frmCapNhatPhanCong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMonHoc;
        private System.Windows.Forms.ComboBox cmbGiaoVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCapNhat;
        private System.Windows.Forms.Button btThoat;
    }
}