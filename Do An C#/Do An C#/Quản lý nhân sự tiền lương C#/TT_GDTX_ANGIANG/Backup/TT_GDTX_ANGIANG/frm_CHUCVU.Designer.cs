namespace TT_GDTX_ANGIANG
{
    partial class frm_CHUCVU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CHUCVU));
            this.txtGHICHU = new System.Windows.Forms.TextBox();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.listViewExDanToc = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtHeSoCV = new System.Windows.Forms.TextBox();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtTENCV = new System.Windows.Forms.TextBox();
            this.txtMACV = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.itemThoat = new DevComponents.DotNetBar.ButtonX();
            this.itemLuu = new DevComponents.DotNetBar.ButtonX();
            this.itemXoa = new DevComponents.DotNetBar.ButtonX();
            this.itemBoQua = new DevComponents.DotNetBar.ButtonX();
            this.itemThemMoi = new DevComponents.DotNetBar.ButtonX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGHICHU
            // 
            this.txtGHICHU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGHICHU.Location = new System.Drawing.Point(127, 114);
            this.txtGHICHU.Multiline = true;
            this.txtGHICHU.Name = "txtGHICHU";
            this.txtGHICHU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGHICHU.Size = new System.Drawing.Size(210, 53);
            this.txtGHICHU.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.listViewExDanToc);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(151, 266);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Danh Sách Chức Vụ";
            // 
            // listViewExDanToc
            // 
            // 
            // 
            // 
            this.listViewExDanToc.Border.Class = "ListViewBorder";
            this.listViewExDanToc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewExDanToc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewExDanToc.FullRowSelect = true;
            this.listViewExDanToc.GridLines = true;
            this.listViewExDanToc.Location = new System.Drawing.Point(0, 0);
            this.listViewExDanToc.MultiSelect = false;
            this.listViewExDanToc.Name = "listViewExDanToc";
            this.listViewExDanToc.Size = new System.Drawing.Size(145, 245);
            this.listViewExDanToc.TabIndex = 2;
            this.listViewExDanToc.UseCompatibleStateImageBehavior = false;
            this.listViewExDanToc.View = System.Windows.Forms.View.Details;
            this.listViewExDanToc.SelectedIndexChanged += new System.EventHandler(this.listViewExDanToc_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Chức Vụ";
            this.columnHeader2.Width = 140;
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtHeSoCV);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.txtGHICHU);
            this.groupPanel2.Controls.Add(this.txtTENCV);
            this.groupPanel2.Controls.Add(this.txtMACV);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(371, 193);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "Thông Tin";
            // 
            // txtHeSoCV
            // 
            this.txtHeSoCV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHeSoCV.Location = new System.Drawing.Point(127, 82);
            this.txtHeSoCV.Name = "txtHeSoCV";
            this.txtHeSoCV.Size = new System.Drawing.Size(119, 20);
            this.txtHeSoCV.TabIndex = 2;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.Location = new System.Drawing.Point(32, 114);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 15;
            this.labelX4.Text = "Ghi Chú:";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.Location = new System.Drawing.Point(32, 80);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(84, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "Hệ số Chức Vụ:";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.Location = new System.Drawing.Point(32, 47);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "Tên Chức Vụ:";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.Location = new System.Drawing.Point(32, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "Mã Chức Vụ:";
            // 
            // txtTENCV
            // 
            this.txtTENCV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTENCV.Location = new System.Drawing.Point(127, 50);
            this.txtTENCV.Name = "txtTENCV";
            this.txtTENCV.Size = new System.Drawing.Size(119, 20);
            this.txtTENCV.TabIndex = 1;
            // 
            // txtMACV
            // 
            this.txtMACV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMACV.Location = new System.Drawing.Point(127, 19);
            this.txtMACV.Name = "txtMACV";
            this.txtMACV.ReadOnly = true;
            this.txtMACV.Size = new System.Drawing.Size(119, 20);
            this.txtMACV.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(526, 266);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.itemThoat);
            this.groupPanel3.Controls.Add(this.itemLuu);
            this.groupPanel3.Controls.Add(this.itemXoa);
            this.groupPanel3.Controls.Add(this.itemBoQua);
            this.groupPanel3.Controls.Add(this.itemThemMoi);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel3.Location = new System.Drawing.Point(0, 193);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(371, 74);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel3.TabIndex = 1;
            // 
            // itemThoat
            // 
            this.itemThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.itemThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.itemThoat.Location = new System.Drawing.Point(305, 22);
            this.itemThoat.Name = "itemThoat";
            this.itemThoat.Size = new System.Drawing.Size(56, 26);
            this.itemThoat.TabIndex = 5;
            this.itemThoat.Text = "Thoát";
            this.itemThoat.Click += new System.EventHandler(this.itemThoat_Click);
            // 
            // itemLuu
            // 
            this.itemLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.itemLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.itemLuu.Location = new System.Drawing.Point(146, 22);
            this.itemLuu.Name = "itemLuu";
            this.itemLuu.Size = new System.Drawing.Size(59, 26);
            this.itemLuu.TabIndex = 3;
            this.itemLuu.Text = "Lưu Lại";
            this.itemLuu.Click += new System.EventHandler(this.itemLuu_Click);
            // 
            // itemXoa
            // 
            this.itemXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.itemXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.itemXoa.Location = new System.Drawing.Point(210, 22);
            this.itemXoa.Name = "itemXoa";
            this.itemXoa.Size = new System.Drawing.Size(59, 26);
            this.itemXoa.TabIndex = 4;
            this.itemXoa.Text = "Xóa";
            this.itemXoa.Click += new System.EventHandler(this.itemXoa_Click);
            // 
            // itemBoQua
            // 
            this.itemBoQua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.itemBoQua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.itemBoQua.Location = new System.Drawing.Point(76, 22);
            this.itemBoQua.Name = "itemBoQua";
            this.itemBoQua.Size = new System.Drawing.Size(65, 26);
            this.itemBoQua.TabIndex = 1;
            this.itemBoQua.Text = "Bỏ Qua";
            this.itemBoQua.Click += new System.EventHandler(this.itemBoQua_Click);
            // 
            // itemThemMoi
            // 
            this.itemThemMoi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.itemThemMoi.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.itemThemMoi.Location = new System.Drawing.Point(2, 22);
            this.itemThemMoi.Name = "itemThemMoi";
            this.itemThemMoi.Size = new System.Drawing.Size(69, 26);
            this.itemThemMoi.TabIndex = 2;
            this.itemThemMoi.Text = "Thêm Mới";
            this.itemThemMoi.Click += new System.EventHandler(this.itemThemMoi_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "start.png");
            // 
            // frm_CHUCVU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 266);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_CHUCVU";
            this.Text = "Chức Vụ";
            this.Load += new System.EventHandler(this.frm_CHUCVU_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtGHICHU;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewExDanToc;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.TextBox txtTENCV;
        private System.Windows.Forms.TextBox txtMACV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX itemThoat;
        private DevComponents.DotNetBar.ButtonX itemLuu;
        private DevComponents.DotNetBar.ButtonX itemXoa;
        private DevComponents.DotNetBar.ButtonX itemBoQua;
        private DevComponents.DotNetBar.ButtonX itemThemMoi;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.TextBox txtHeSoCV;
    }
}