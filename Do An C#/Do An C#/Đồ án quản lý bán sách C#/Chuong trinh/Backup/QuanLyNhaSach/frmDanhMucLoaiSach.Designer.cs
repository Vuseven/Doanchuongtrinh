namespace QuanLyNhaSach
{
    partial class frmDanhMucLoaiSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhMucLoaiSach));
            this.pnDMLS = new System.Windows.Forms.Panel();
            this.lbDMLS = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbDSKH = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbThaoTac = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLS = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenLS = new System.Windows.Forms.TextBox();
            this.txtMaLS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnDMLS.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbDSKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbThaoTac.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDMLS
            // 
            this.pnDMLS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnDMLS.Controls.Add(this.lbDMLS);
            this.pnDMLS.Location = new System.Drawing.Point(0, 0);
            this.pnDMLS.Name = "pnDMLS";
            this.pnDMLS.Size = new System.Drawing.Size(792, 70);
            this.pnDMLS.TabIndex = 0;
            // 
            // lbDMLS
            // 
            this.lbDMLS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDMLS.AutoSize = true;
            this.lbDMLS.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDMLS.ForeColor = System.Drawing.Color.Blue;
            this.lbDMLS.Location = new System.Drawing.Point(185, 11);
            this.lbDMLS.Name = "lbDMLS";
            this.lbDMLS.Size = new System.Drawing.Size(427, 42);
            this.lbDMLS.TabIndex = 0;
            this.lbDMLS.Text = "DANH MỤC LOẠI SÁCH";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.gbDSKH);
            this.panel3.ForeColor = System.Drawing.Color.Blue;
            this.panel3.Location = new System.Drawing.Point(0, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 245);
            this.panel3.TabIndex = 23;
            // 
            // gbDSKH
            // 
            this.gbDSKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDSKH.Controls.Add(this.dataGridView1);
            this.gbDSKH.Location = new System.Drawing.Point(20, 11);
            this.gbDSKH.Name = "gbDSKH";
            this.gbDSKH.Size = new System.Drawing.Size(375, 219);
            this.gbDSKH.TabIndex = 7;
            this.gbDSKH.TabStop = false;
            this.gbDSKH.Text = "Danh sách Nhân viên";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(10, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(356, 195);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MALOAISACH";
            this.Column1.HeaderText = "Mã loại sách";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENLOAISACH";
            this.Column2.HeaderText = "Tên loại sách";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.gbThaoTac);
            this.panel1.Location = new System.Drawing.Point(433, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 125);
            this.panel1.TabIndex = 24;
            // 
            // gbThaoTac
            // 
            this.gbThaoTac.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbThaoTac.Controls.Add(this.btnThoat);
            this.gbThaoTac.Controls.Add(this.btnLS);
            this.gbThaoTac.Controls.Add(this.btnTaoMoi);
            this.gbThaoTac.Controls.Add(this.btnXoa);
            this.gbThaoTac.Controls.Add(this.btnThem);
            this.gbThaoTac.Controls.Add(this.btnSua);
            this.gbThaoTac.ForeColor = System.Drawing.Color.Blue;
            this.gbThaoTac.Location = new System.Drawing.Point(11, 11);
            this.gbThaoTac.Name = "gbThaoTac";
            this.gbThaoTac.Size = new System.Drawing.Size(337, 99);
            this.gbThaoTac.TabIndex = 8;
            this.gbThaoTac.TabStop = false;
            this.gbThaoTac.Text = "Thao Tác";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(243, 63);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 30);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLS
            // 
            this.btnLS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLS.Location = new System.Drawing.Point(128, 63);
            this.btnLS.Name = "btnLS";
            this.btnLS.Size = new System.Drawing.Size(80, 30);
            this.btnLS.TabIndex = 17;
            this.btnLS.Text = "Lưu sửa";
            this.btnLS.UseVisualStyleBackColor = true;
            this.btnLS.Click += new System.EventHandler(this.btnLS_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoMoi.Location = new System.Drawing.Point(15, 63);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(80, 30);
            this.btnTaoMoi.TabIndex = 16;
            this.btnTaoMoi.Text = "Tạo mới";
            this.btnTaoMoi.UseVisualStyleBackColor = true;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(243, 23);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(15, 23);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "   Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(128, 23);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "    Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.ForeColor = System.Drawing.Color.Blue;
            this.panel2.Location = new System.Drawing.Point(433, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 120);
            this.panel2.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtTenLS);
            this.groupBox1.Controls.Add(this.txtMaLS);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 99);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // txtTenLS
            // 
            this.txtTenLS.Location = new System.Drawing.Point(108, 60);
            this.txtTenLS.Name = "txtTenLS";
            this.txtTenLS.Size = new System.Drawing.Size(192, 20);
            this.txtTenLS.TabIndex = 9;
            // 
            // txtMaLS
            // 
            this.txtMaLS.Location = new System.Drawing.Point(108, 29);
            this.txtMaLS.Name = "txtMaLS";
            this.txtMaLS.Size = new System.Drawing.Size(192, 20);
            this.txtMaLS.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mã loại sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên loại sách";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MALOAISACH";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã loại sách";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TENLOAISACH";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên loại sách";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // frmDanhMucLoaiSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnDMLS);
            this.Name = "frmDanhMucLoaiSach";
            this.TabText = "DANH MUC LOAI SACH";
            this.Text = "DANH MUC LOAI SACH";
            this.Load += new System.EventHandler(this.frmDanhMucLoaiSach_Load);
            this.pnDMLS.ResumeLayout(false);
            this.pnDMLS.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gbDSKH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbThaoTac.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnDMLS;
        private System.Windows.Forms.Label lbDMLS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbDSKH;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbThaoTac;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenLS;
        private System.Windows.Forms.TextBox txtMaLS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnLS;
        private System.Windows.Forms.Button btnThoat;
    }
}