namespace QLDiemSoHocSinhTHPT.GiaoDien
{
    partial class frmDanToc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanToc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDS = new System.Windows.Forms.DataGridView();
            this.colMaDanToc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDanToc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itThemMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.itBoQua = new System.Windows.Forms.ToolStripMenuItem();
            this.itLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.itXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.itThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.bnDS = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btThemMoi = new System.Windows.Forms.ToolStripButton();
            this.btBoQua = new System.Windows.Forms.ToolStripButton();
            this.btLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btThoat = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnDS)).BeginInit();
            this.bnDS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDS);
            this.panel1.Controls.Add(this.bnDS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 601);
            this.panel1.TabIndex = 0;
            // 
            // dgvDS
            // 
            this.dgvDS.AllowUserToAddRows = false;
            this.dgvDS.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dgvDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDanToc,
            this.colTenDanToc});
            this.dgvDS.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDS.Location = new System.Drawing.Point(0, 44);
            this.dgvDS.Name = "dgvDS";
            this.dgvDS.Size = new System.Drawing.Size(1049, 557);
            this.dgvDS.TabIndex = 4;
            this.dgvDS.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDS_CellValueChanged);
            // 
            // colMaDanToc
            // 
            this.colMaDanToc.DataPropertyName = "MaDanToc";
            this.colMaDanToc.HeaderText = "Mã dân tộc";
            this.colMaDanToc.Name = "colMaDanToc";
            // 
            // colTenDanToc
            // 
            this.colTenDanToc.DataPropertyName = "TenDanToc";
            this.colTenDanToc.HeaderText = "Tên dân tộc";
            this.colTenDanToc.Name = "colTenDanToc";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itThemMoi,
            this.itBoQua,
            this.itLuu,
            this.toolStripSeparator3,
            this.itXoa,
            this.toolStripSeparator4,
            this.itThoat});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 126);
            // 
            // itThemMoi
            // 
            this.itThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("itThemMoi.Image")));
            this.itThemMoi.Name = "itThemMoi";
            this.itThemMoi.Size = new System.Drawing.Size(130, 22);
            this.itThemMoi.Text = "Thêm Mới";
            this.itThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // itBoQua
            // 
            this.itBoQua.Image = ((System.Drawing.Image)(resources.GetObject("itBoQua.Image")));
            this.itBoQua.Name = "itBoQua";
            this.itBoQua.Size = new System.Drawing.Size(130, 22);
            this.itBoQua.Text = "Bỏ Qua";
            this.itBoQua.Click += new System.EventHandler(this.btBoQua_Click);
            // 
            // itLuu
            // 
            this.itLuu.Image = ((System.Drawing.Image)(resources.GetObject("itLuu.Image")));
            this.itLuu.Name = "itLuu";
            this.itLuu.Size = new System.Drawing.Size(130, 22);
            this.itLuu.Text = "Lưu";
            this.itLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // itXoa
            // 
            this.itXoa.Image = ((System.Drawing.Image)(resources.GetObject("itXoa.Image")));
            this.itXoa.Name = "itXoa";
            this.itXoa.Size = new System.Drawing.Size(130, 22);
            this.itXoa.Text = "Xóa";
            this.itXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // itThoat
            // 
            this.itThoat.Image = ((System.Drawing.Image)(resources.GetObject("itThoat.Image")));
            this.itThoat.Name = "itThoat";
            this.itThoat.Size = new System.Drawing.Size(130, 22);
            this.itThoat.Text = "Thoát";
            this.itThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // bnDS
            // 
            this.bnDS.AddNewItem = null;
            this.bnDS.CountItem = this.bindingNavigatorCountItem1;
            this.bnDS.DeleteItem = null;
            this.bnDS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.btThemMoi,
            this.btBoQua,
            this.btLuu,
            this.toolStripSeparator1,
            this.btXoa,
            this.toolStripSeparator2,
            this.btThoat});
            this.bnDS.Location = new System.Drawing.Point(0, 0);
            this.bnDS.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bnDS.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bnDS.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bnDS.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bnDS.Name = "bnDS";
            this.bnDS.PositionItem = this.bindingNavigatorPositionItem1;
            this.bnDS.Size = new System.Drawing.Size(1049, 44);
            this.bnDS.TabIndex = 3;
            this.bnDS.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(36, 41);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 44);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 44);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 41);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 44);
            // 
            // btThemMoi
            // 
            this.btThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btThemMoi.Image")));
            this.btThemMoi.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btThemMoi.Name = "btThemMoi";
            this.btThemMoi.RightToLeftAutoMirrorImage = true;
            this.btThemMoi.Size = new System.Drawing.Size(56, 41);
            this.btThemMoi.Text = "Thêm mới";
            this.btThemMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btThemMoi.Click += new System.EventHandler(this.btThemMoi_Click);
            // 
            // btBoQua
            // 
            this.btBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btBoQua.Image")));
            this.btBoQua.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btBoQua.Name = "btBoQua";
            this.btBoQua.Size = new System.Drawing.Size(53, 41);
            this.btBoQua.Text = "  Bỏ qua ";
            this.btBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btBoQua.Click += new System.EventHandler(this.btBoQua_Click);
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
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
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
            this.btXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(53, 41);
            this.btXoa.Text = "    Xóa    ";
            this.btXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // btThoat
            // 
            this.btThoat.Image = ((System.Drawing.Image)(resources.GetObject("btThoat.Image")));
            this.btThoat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(57, 41);
            this.btThoat.Text = "   Thoát   ";
            this.btThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaDanToc";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã dân tộc";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenDanToc";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên dân tộc";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // frmDanToc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 601);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDanToc";
            this.Text = "Dan toc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frmDanToc_Shown);
            this.Load += new System.EventHandler(this.frmDanToc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDS)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnDS)).EndInit();
            this.bnDS.ResumeLayout(false);
            this.bnDS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem itThemMoi;
        private System.Windows.Forms.ToolStripMenuItem itBoQua;
        private System.Windows.Forms.ToolStripMenuItem itLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem itXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem itThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingNavigator bnDS;
        private System.Windows.Forms.ToolStripButton btThemMoi;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ToolStripButton btBoQua;
        private System.Windows.Forms.ToolStripButton btLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btThoat;
        private System.Windows.Forms.DataGridView dgvDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDanToc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDanToc;
    }
}