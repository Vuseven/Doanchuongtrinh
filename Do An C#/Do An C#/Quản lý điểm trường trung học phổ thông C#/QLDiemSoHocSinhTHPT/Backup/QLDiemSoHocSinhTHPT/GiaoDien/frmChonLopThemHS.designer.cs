namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    partial class frmChonLopThemHS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonLopThemHS));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKhoiLop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.lbNamHoc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChon = new System.Windows.Forms.Button();
            this.cmbThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khối Lớp:";
            // 
            // cmbKhoiLop
            // 
            this.cmbKhoiLop.FormattingEnabled = true;
            this.cmbKhoiLop.Location = new System.Drawing.Point(117, 47);
            this.cmbKhoiLop.Name = "cmbKhoiLop";
            this.cmbKhoiLop.Size = new System.Drawing.Size(121, 21);
            this.cmbKhoiLop.TabIndex = 1;
            this.cmbKhoiLop.SelectedIndexChanged += new System.EventHandler(this.cmbKhoiLop_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lớp:";
            // 
            // cmbLop
            // 
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(117, 74);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(121, 21);
            this.cmbLop.TabIndex = 2;
            // 
            // lbNamHoc
            // 
            this.lbNamHoc.AutoSize = true;
            this.lbNamHoc.Location = new System.Drawing.Point(49, 20);
            this.lbNamHoc.Name = "lbNamHoc";
            this.lbNamHoc.Size = new System.Drawing.Size(55, 13);
            this.lbNamHoc.TabIndex = 0;
            this.lbNamHoc.Text = "Năm Học:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chú ý: Hãy chắc chắc rằng đây là năm học hiện tại";
            // 
            // cmbChon
            // 
            this.cmbChon.Location = new System.Drawing.Point(55, 118);
            this.cmbChon.Name = "cmbChon";
            this.cmbChon.Size = new System.Drawing.Size(75, 23);
            this.cmbChon.TabIndex = 3;
            this.cmbChon.Text = "Chọn";
            this.cmbChon.UseVisualStyleBackColor = true;
            this.cmbChon.Click += new System.EventHandler(this.cmbChon_Click);
            // 
            // cmbThoat
            // 
            this.cmbThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmbThoat.Location = new System.Drawing.Point(163, 118);
            this.cmbThoat.Name = "cmbThoat";
            this.cmbThoat.Size = new System.Drawing.Size(75, 23);
            this.cmbThoat.TabIndex = 4;
            this.cmbThoat.Text = "Thoát";
            this.cmbThoat.UseVisualStyleBackColor = true;
            this.cmbThoat.Click += new System.EventHandler(this.cmbThoat_Click);
            // 
            // frmChonLopThemHS
            // 
            this.AcceptButton = this.cmbChon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.CancelButton = this.cmbThoat;
            this.ClientSize = new System.Drawing.Size(292, 181);
            this.Controls.Add(this.cmbThoat);
            this.Controls.Add(this.cmbChon);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKhoiLop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbNamHoc);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChonLopThemHS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chon lop";
            this.Load += new System.EventHandler(this.frmChonLopThemHS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKhoiLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.Label lbNamHoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmbChon;
        private System.Windows.Forms.Button cmbThoat;
    }
}