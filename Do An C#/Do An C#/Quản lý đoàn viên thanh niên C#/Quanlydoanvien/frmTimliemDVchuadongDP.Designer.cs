namespace Quanlydoanvien
{
    partial class frmTimliemDVchuadongDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimliemDVchuadongDP));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTNTIM = new DevComponents.DotNetBar.ButtonX();
            this.DGTIMKIEM = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radong = new System.Windows.Forms.RadioButton();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radchuadong = new System.Windows.Forms.RadioButton();
            this.txtthunghiem = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnxuat = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGTIMKIEM)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // BTNTIM
            // 
            this.BTNTIM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNTIM.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNTIM.Image = ((System.Drawing.Image)(resources.GetObject("BTNTIM.Image")));
            this.BTNTIM.Location = new System.Drawing.Point(171, 320);
            this.BTNTIM.Name = "BTNTIM";
            this.BTNTIM.Size = new System.Drawing.Size(102, 44);
            this.BTNTIM.TabIndex = 0;
            this.BTNTIM.Text = "Search ";
            this.BTNTIM.Click += new System.EventHandler(this.BTNTIM_Click);
            // 
            // DGTIMKIEM
            // 
            this.DGTIMKIEM.AllowUserToDeleteRows = false;
            this.DGTIMKIEM.BackgroundColor = System.Drawing.Color.Aquamarine;
            this.DGTIMKIEM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGTIMKIEM.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGTIMKIEM.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGTIMKIEM.Location = new System.Drawing.Point(85, 121);
            this.DGTIMKIEM.Name = "DGTIMKIEM";
            this.DGTIMKIEM.ReadOnly = true;
            this.DGTIMKIEM.Size = new System.Drawing.Size(444, 184);
            this.DGTIMKIEM.TabIndex = 22;
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.Class = "";
            this.reflectionLabel1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reflectionLabel1.ForeColor = System.Drawing.Color.Yellow;
            this.reflectionLabel1.Location = new System.Drawing.Point(79, 7);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(518, 56);
            this.reflectionLabel1.TabIndex = 21;
            this.reflectionLabel1.Text = "Tìm Kiếm Đoàn Viên Đã Và Chưa Đóng Đoàn Phí";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 305);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(617, 13);
            this.progressBar1.TabIndex = 26;
            // 
            // radong
            // 
            this.radong.AutoSize = true;
            this.radong.BackColor = System.Drawing.Color.Transparent;
            this.radong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radong.Location = new System.Drawing.Point(35, 4);
            this.radong.Name = "radong";
            this.radong.Size = new System.Drawing.Size(130, 17);
            this.radong.TabIndex = 28;
            this.radong.TabStop = true;
            this.radong.Text = "Đã đóng đoàn phí";
            this.radong.UseVisualStyleBackColor = false;
            this.radong.CheckedChanged += new System.EventHandler(this.radong_CheckedChanged);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.radchuadong);
            this.groupPanel1.Controls.Add(this.radong);
            this.groupPanel1.Location = new System.Drawing.Point(208, 55);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(200, 66);
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
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.TabIndex = 29;
            this.groupPanel1.Text = "Bạn hãy chọn";
            // 
            // radchuadong
            // 
            this.radchuadong.AutoSize = true;
            this.radchuadong.BackColor = System.Drawing.Color.Transparent;
            this.radchuadong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radchuadong.Location = new System.Drawing.Point(35, 25);
            this.radchuadong.Name = "radchuadong";
            this.radchuadong.Size = new System.Drawing.Size(143, 17);
            this.radchuadong.TabIndex = 28;
            this.radchuadong.TabStop = true;
            this.radchuadong.Text = "Chưa đóng đoàn phí";
            this.radchuadong.UseVisualStyleBackColor = false;
            this.radchuadong.CheckedChanged += new System.EventHandler(this.radchuadong_CheckedChanged);
            // 
            // txtthunghiem
            // 
            // 
            // 
            // 
            this.txtthunghiem.Border.Class = "TextBoxBorder";
            this.txtthunghiem.Location = new System.Drawing.Point(467, 55);
            this.txtthunghiem.Name = "txtthunghiem";
            this.txtthunghiem.Size = new System.Drawing.Size(100, 20);
            this.txtthunghiem.TabIndex = 30;
            this.txtthunghiem.Text = "1";
            this.txtthunghiem.Visible = false;
            // 
            // btnxuat
            // 
            this.btnxuat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnxuat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnxuat.Image = ((System.Drawing.Image)(resources.GetObject("btnxuat.Image")));
            this.btnxuat.Location = new System.Drawing.Point(298, 320);
            this.btnxuat.Name = "btnxuat";
            this.btnxuat.Size = new System.Drawing.Size(183, 46);
            this.btnxuat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnxuat.TabIndex = 31;
            this.btnxuat.Text = "Xuất danh sách những đoàn viên chưa đóng đoàn phí";
            this.btnxuat.Click += new System.EventHandler(this.btnxuat_Click);
            // 
            // frmTimliemDVchuadongDP
            // 
            this.AcceptButton = this.BTNTIM;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(614, 375);
            this.Controls.Add(this.btnxuat);
            this.Controls.Add(this.txtthunghiem);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.BTNTIM);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DGTIMKIEM);
            this.Controls.Add(this.reflectionLabel1);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTimliemDVchuadongDP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm đoàn viên chưa đóng đoàn phí";
            this.Load += new System.EventHandler(this.frmTimliemDVchuadongDP_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTimliemDVchuadongDP_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGTIMKIEM)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ButtonX BTNTIM;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGTIMKIEM;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radong;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.RadioButton radchuadong;
        private DevComponents.DotNetBar.Controls.TextBoxX txtthunghiem;
        private DevComponents.DotNetBar.ButtonX btnxuat;
    }
}