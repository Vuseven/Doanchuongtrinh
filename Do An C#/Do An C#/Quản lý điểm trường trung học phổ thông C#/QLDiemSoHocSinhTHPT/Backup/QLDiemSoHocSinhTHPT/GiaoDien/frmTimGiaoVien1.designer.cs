namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    partial class frmTimGiaoVien1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimGiaoVien1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btTim = new System.Windows.Forms.Button();
            this.txtTenGiaoVien = new System.Windows.Forms.TextBox();
            this.gbDanhSachGiaoVien = new System.Windows.Forms.GroupBox();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.colMaGiaoVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNgaySinh = new QLDiemSoHocSinhTHPT.ThuVien.DataGridViewCalendarColumn();
            this.colNoiSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonHoc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bnDS = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btBoQua = new System.Windows.Forms.ToolStripButton();
            this.btLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btChinhSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.gbDanhSachGiaoVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnDS)).BeginInit();
            this.bnDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox1.Controls.Add(this.btTim);
            this.groupBox1.Controls.Add(this.txtTenGiaoVien);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1147, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập tên giáo viên";
            // 
            // btTim
            // 
            this.btTim.Location = new System.Drawing.Point(426, 17);
            this.btTim.Name = "btTim";
            this.btTim.Size = new System.Drawing.Size(75, 23);
            this.btTim.TabIndex = 2;
            this.btTim.Text = "Tìm";
            this.btTim.UseVisualStyleBackColor = true;
            this.btTim.Click += new System.EventHandler(this.btTim_Click);
            // 
            // txtTenGiaoVien
            // 
            this.txtTenGiaoVien.Location = new System.Drawing.Point(182, 19);
            this.txtTenGiaoVien.Name = "txtTenGiaoVien";
            this.txtTenGiaoVien.Size = new System.Drawing.Size(172, 20);
            this.txtTenGiaoVien.TabIndex = 1;
            // 
            // gbDanhSachGiaoVien
            // 
            this.gbDanhSachGiaoVien.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.gbDanhSachGiaoVien.Controls.Add(this.dgvDS);
            this.gbDanhSachGiaoVien.Controls.Add(this.bnDS);
            this.gbDanhSachGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDanhSachGiaoVien.Location = new System.Drawing.Point(0, 56);
            this.gbDanhSachGiaoVien.Name = "gbDanhSachGiaoVien";
            this.gbDanhSachGiaoVien.Size = new System.Drawing.Size(1147, 536);
            this.gbDanhSachGiaoVien.TabIndex = 2;
            this.gbDanhSachGiaoVien.TabStop = false;
            this.gbDanhSachGiaoVien.Text = "Danh sách giáo viên";
            // 
            // dgvDS
            // 
            this.dgvDS.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaGiaoVien,
            this.colHoTen,
            this.colGioiTinh,
            this.colNgaySinh,
            this.colNoiSinh,
            this.colDiaChi,
            this.colDienThoai,
            this.colMonHoc});
            this.dgvDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDS.Location = new System.Drawing.Point(3, 60);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(1141, 473);
            this.dgvDS.TabIndex = 1;
            // 
            // colMaGiaoVien
            // 
            this.colMaGiaoVien.DataPropertyName = "MaGiaoVien";
            this.colMaGiaoVien.HeaderText = "Mã Giáo Viên";
            this.colMaGiaoVien.Name = "colMaGiaoVien";
            this.colMaGiaoVien.ReadOnly = true;
            this.colMaGiaoVien.Width = 105;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ Tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.Width = 105;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.HeaderText = "Giới Tính";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGioiTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colGioiTinh.Width = 105;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.DataPropertyName = "NgaySinh";
            this.colNgaySinh.HeaderText = "Ngày Sinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNgaySinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colNgaySinh.Width = 105;
            // 
            // colNoiSinh
            // 
            this.colNoiSinh.DataPropertyName = "NoiSinh";
            this.colNoiSinh.HeaderText = "Nơi Sinh";
            this.colNoiSinh.Name = "colNoiSinh";
            this.colNoiSinh.Width = 105;
            // 
            // colDiaChi
            // 
            this.colDiaChi.DataPropertyName = "DiaChi";
            this.colDiaChi.HeaderText = "Địa Chỉ";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Width = 105;
            // 
            // colDienThoai
            // 
            this.colDienThoai.DataPropertyName = "DienThoai";
            this.colDienThoai.HeaderText = "Điện Thoại";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Width = 105;
            // 
            // colMonHoc
            // 
            this.colMonHoc.DataPropertyName = "MonHoc";
            this.colMonHoc.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colMonHoc.HeaderText = "Chuyên môn";
            this.colMonHoc.Name = "colMonHoc";
            this.colMonHoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMonHoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMonHoc.Width = 105;
            // 
            // bnDS
            // 
            this.bnDS.AddNewItem = null;
            this.bnDS.CountItem = this.bindingNavigatorCountItem;
            this.bnDS.DeleteItem = null;
            this.bnDS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btBoQua,
            this.btLuu,
            this.toolStripSeparator1,
            this.btXoa,
            this.toolStripSeparator2,
            this.btChinhSua,
            this.toolStripSeparator3,
            this.btThoat});
            this.bnDS.Location = new System.Drawing.Point(3, 16);
            this.bnDS.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnDS.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnDS.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnDS.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnDS.Name = "bnDS";
            this.bnDS.PositionItem = this.bindingNavigatorPositionItem;
            this.bnDS.Size = new System.Drawing.Size(1141, 44);
            this.bnDS.TabIndex = 0;
            this.bnDS.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 41);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 44);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // btBoQua
            // 
            this.btBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btBoQua.Image")));
            this.btBoQua.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBoQua.Name = "btBoQua";
            this.btBoQua.Size = new System.Drawing.Size(58, 41);
            this.btBoQua.Text = "  Bỏ Qua  ";
            this.btBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btLuu
            // 
            this.btLuu.Image = ((System.Drawing.Image)(resources.GetObject("btLuu.Image")));
            this.btLuu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(53, 41);
            this.btLuu.Text = "    Lưu    ";
            this.btLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // btXoa
            // 
            this.btXoa.Image = ((System.Drawing.Image)(resources.GetObject("btXoa.Image")));
            this.btXoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btXoa.Name = "btXoa";
            this.btXoa.RightToLeftAutoMirrorImage = true;
            this.btXoa.Size = new System.Drawing.Size(56, 41);
            this.btXoa.Text = "     Xóa    ";
            this.btXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // btChinhSua
            // 
            this.btChinhSua.Image = ((System.Drawing.Image)(resources.GetObject("btChinhSua.Image")));
            this.btChinhSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btChinhSua.Name = "btChinhSua";
            this.btChinhSua.Size = new System.Drawing.Size(59, 41);
            this.btChinhSua.Text = "Chỉnh sửa";
            this.btChinhSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 44);
            // 
            // btThoat
            // 
            this.btThoat.Image = ((System.Drawing.Image)(resources.GetObject("btThoat.Image")));
            this.btThoat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(63, 41);
            this.btThoat.Text = "    Thoát    ";
            this.btThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmTimGiaoVien1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 592);
            this.Controls.Add(this.gbDanhSachGiaoVien);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimGiaoVien1";
            this.Text = "Tim giao vien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTimGiaoVien1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDanhSachGiaoVien.ResumeLayout(false);
            this.gbDanhSachGiaoVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnDS)).EndInit();
            this.bnDS.ResumeLayout(false);
            this.bnDS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btTim;
        private System.Windows.Forms.TextBox txtTenGiaoVien;
        private System.Windows.Forms.GroupBox gbDanhSachGiaoVien;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGiaoVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colGioiTinh;
        private QLDiemSoHocSinhTHPT.ThuVien.DataGridViewCalendarColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDienThoai;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMonHoc;
        private System.Windows.Forms.BindingNavigator bnDS;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btBoQua;
        private System.Windows.Forms.ToolStripButton btLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btThoat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btChinhSua;
    }
}