namespace Quanlydoanvien
{
    partial class frmTimkiemdv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimkiemdv));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.radtensv = new System.Windows.Forms.RadioButton();
            this.radmasv = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BTNTIM = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnchidoan = new DevComponents.DotNetBar.ButtonX();
            this.radchidoan = new System.Windows.Forms.RadioButton();
            this.comboma = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnchongioitinh = new DevComponents.DotNetBar.ButtonX();
            this.btnten = new DevComponents.DotNetBar.ButtonX();
            this.btnma = new DevComponents.DotNetBar.ButtonX();
            this.radgioitinh = new System.Windows.Forms.RadioButton();
            this.dgdoanvien = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.reflectionLabel1 = new DevComponents.DotNetBar.Controls.ReflectionLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.balloonTip1 = new DevComponents.DotNetBar.BalloonTip();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdoanvien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radtensv
            // 
            this.radtensv.AutoSize = true;
            this.radtensv.BackColor = System.Drawing.Color.Transparent;
            this.radtensv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radtensv.Location = new System.Drawing.Point(34, 36);
            this.radtensv.Name = "radtensv";
            this.radtensv.Size = new System.Drawing.Size(108, 17);
            this.radtensv.TabIndex = 0;
            this.radtensv.TabStop = true;
            this.radtensv.Text = "Tên đoàn viên";
            this.radtensv.UseVisualStyleBackColor = false;
            this.radtensv.CheckedChanged += new System.EventHandler(this.radtensv_CheckedChanged);
            // 
            // radmasv
            // 
            this.radmasv.AutoSize = true;
            this.radmasv.BackColor = System.Drawing.Color.Transparent;
            this.radmasv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radmasv.Location = new System.Drawing.Point(34, 5);
            this.radmasv.Name = "radmasv";
            this.radmasv.Size = new System.Drawing.Size(103, 17);
            this.radmasv.TabIndex = 0;
            this.radmasv.TabStop = true;
            this.radmasv.Text = "Mã đoàn viên";
            this.radmasv.UseVisualStyleBackColor = false;
            this.radmasv.CheckedChanged += new System.EventHandler(this.radmasv_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-1, 432);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(950, 13);
            this.progressBar1.TabIndex = 19;
            // 
            // BTNTIM
            // 
            this.BTNTIM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNTIM.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNTIM.Image = ((System.Drawing.Image)(resources.GetObject("BTNTIM.Image")));
            this.BTNTIM.Location = new System.Drawing.Point(423, 447);
            this.BTNTIM.Name = "BTNTIM";
            this.BTNTIM.Size = new System.Drawing.Size(102, 38);
            this.BTNTIM.TabIndex = 0;
            this.BTNTIM.Text = "Search ";
            this.BTNTIM.Click += new System.EventHandler(this.BTNTIM_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnchidoan);
            this.groupPanel2.Controls.Add(this.radchidoan);
            this.groupPanel2.Controls.Add(this.comboma);
            this.groupPanel2.Controls.Add(this.btnchongioitinh);
            this.groupPanel2.Controls.Add(this.btnten);
            this.groupPanel2.Controls.Add(this.btnma);
            this.groupPanel2.Controls.Add(this.radgioitinh);
            this.groupPanel2.Controls.Add(this.radtensv);
            this.groupPanel2.Controls.Add(this.radmasv);
            this.groupPanel2.Location = new System.Drawing.Point(242, 68);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(464, 153);
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
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.TabIndex = 16;
            this.groupPanel2.Text = "Tìm theo";
            // 
            // btnchidoan
            // 
            this.btnchidoan.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnchidoan.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnchidoan.Location = new System.Drawing.Point(312, 94);
            this.btnchidoan.Name = "btnchidoan";
            this.btnchidoan.Size = new System.Drawing.Size(112, 23);
            this.btnchidoan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnchidoan.TabIndex = 25;
            this.btnchidoan.Text = "Chọn chi đoàn";
            this.btnchidoan.Click += new System.EventHandler(this.btnchonchidoan_Click);
            // 
            // radchidoan
            // 
            this.radchidoan.AutoSize = true;
            this.radchidoan.BackColor = System.Drawing.Color.Transparent;
            this.radchidoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radchidoan.Location = new System.Drawing.Point(34, 94);
            this.radchidoan.Name = "radchidoan";
            this.radchidoan.Size = new System.Drawing.Size(76, 17);
            this.radchidoan.TabIndex = 24;
            this.radchidoan.TabStop = true;
            this.radchidoan.Text = "Chi đoàn";
            this.radchidoan.UseVisualStyleBackColor = false;
            this.radchidoan.CheckedChanged += new System.EventHandler(this.radchidoan_CheckedChanged);
            // 
            // comboma
            // 
            // 
            // 
            // 
            this.comboma.Border.Class = "TextBoxBorder";
            this.comboma.Location = new System.Drawing.Point(155, 56);
            this.comboma.Name = "comboma";
            this.comboma.ReadOnly = true;
            this.comboma.Size = new System.Drawing.Size(148, 20);
            this.comboma.TabIndex = 23;
            this.comboma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnchongioitinh
            // 
            this.btnchongioitinh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnchongioitinh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnchongioitinh.Location = new System.Drawing.Point(312, 63);
            this.btnchongioitinh.Name = "btnchongioitinh";
            this.btnchongioitinh.Size = new System.Drawing.Size(112, 23);
            this.btnchongioitinh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnchongioitinh.TabIndex = 22;
            this.btnchongioitinh.Text = "Chọn giới tính";
            this.btnchongioitinh.Click += new System.EventHandler(this.btnchongioitinh_Click);
            // 
            // btnten
            // 
            this.btnten.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnten.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnten.Location = new System.Drawing.Point(312, 33);
            this.btnten.Name = "btnten";
            this.btnten.Size = new System.Drawing.Size(112, 23);
            this.btnten.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnten.TabIndex = 3;
            this.btnten.Text = "Chọn tên đoàn viên";
            this.btnten.Click += new System.EventHandler(this.btnten_Click);
            // 
            // btnma
            // 
            this.btnma.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnma.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnma.Location = new System.Drawing.Point(312, 2);
            this.btnma.Name = "btnma";
            this.btnma.Size = new System.Drawing.Size(112, 23);
            this.btnma.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnma.TabIndex = 2;
            this.btnma.Text = "Chọn mã đoàn viên";
            this.btnma.Click += new System.EventHandler(this.btnma_Click);
            // 
            // radgioitinh
            // 
            this.radgioitinh.AutoSize = true;
            this.radgioitinh.BackColor = System.Drawing.Color.Transparent;
            this.radgioitinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radgioitinh.Location = new System.Drawing.Point(34, 64);
            this.radgioitinh.Name = "radgioitinh";
            this.radgioitinh.Size = new System.Drawing.Size(74, 17);
            this.radgioitinh.TabIndex = 1;
            this.radgioitinh.TabStop = true;
            this.radgioitinh.Text = "Giới tính";
            this.radgioitinh.UseVisualStyleBackColor = false;
            this.radgioitinh.CheckedChanged += new System.EventHandler(this.radgioitinh_CheckedChanged);
            // 
            // dgdoanvien
            // 
            this.dgdoanvien.AllowUserToAddRows = false;
            this.dgdoanvien.AllowUserToDeleteRows = false;
            this.dgdoanvien.BackgroundColor = System.Drawing.Color.LawnGreen;
            this.dgdoanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgdoanvien.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgdoanvien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgdoanvien.Location = new System.Drawing.Point(10, 227);
            this.dgdoanvien.Name = "dgdoanvien";
            this.dgdoanvien.ReadOnly = true;
            this.dgdoanvien.Size = new System.Drawing.Size(929, 203);
            this.dgdoanvien.TabIndex = 14;
            // 
            // reflectionLabel1
            // 
            // 
            // 
            // 
            this.reflectionLabel1.BackgroundStyle.Class = "";
            this.reflectionLabel1.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.reflectionLabel1.ForeColor = System.Drawing.Color.Red;
            this.reflectionLabel1.Location = new System.Drawing.Point(315, 2);
            this.reflectionLabel1.Name = "reflectionLabel1";
            this.reflectionLabel1.Size = new System.Drawing.Size(395, 66);
            this.reflectionLabel1.TabIndex = 13;
            this.reflectionLabel1.Text = "Tìm Kiếm Đoàn Viên";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(239, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // balloonTip1
            // 
            this.balloonTip1.DefaultBalloonWidth = 340;
            this.balloonTip1.ShowCloseButton = false;
            // 
            // frmTimkiemdv
            // 
            this.AcceptButton = this.BTNTIM;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(949, 509);
            this.Controls.Add(this.BTNTIM);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.dgdoanvien);
            this.Controls.Add(this.reflectionLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTimkiemdv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm đoàn viên";
            this.Load += new System.EventHandler(this.frmTimkiemdv_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTimkiemdv_FormClosing);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdoanvien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radtensv;
        private System.Windows.Forms.RadioButton radmasv;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevComponents.DotNetBar.ButtonX BTNTIM;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgdoanvien;
        private DevComponents.DotNetBar.Controls.ReflectionLabel reflectionLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radgioitinh;
        private DevComponents.DotNetBar.BalloonTip balloonTip1;
        private DevComponents.DotNetBar.ButtonX btnchongioitinh;
        private DevComponents.DotNetBar.ButtonX btnten;
        private DevComponents.DotNetBar.ButtonX btnma;
        private DevComponents.DotNetBar.Controls.TextBoxX comboma;
        private System.Windows.Forms.RadioButton radchidoan;
        private DevComponents.DotNetBar.ButtonX btnchidoan;
    }
}