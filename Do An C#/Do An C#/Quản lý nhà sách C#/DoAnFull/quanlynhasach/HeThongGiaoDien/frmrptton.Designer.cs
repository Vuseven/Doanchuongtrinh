namespace quanlynhasach.HeThongGiaoDien
{
    partial class frmrptton
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
            this.xembaocaoton = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // xembaocaoton
            // 
            this.xembaocaoton.ActiveViewIndex = -1;
            this.xembaocaoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xembaocaoton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xembaocaoton.Location = new System.Drawing.Point(0, 0);
            this.xembaocaoton.Name = "xembaocaoton";
            this.xembaocaoton.SelectionFormula = "";
            this.xembaocaoton.Size = new System.Drawing.Size(452, 360);
            this.xembaocaoton.TabIndex = 0;
            this.xembaocaoton.ViewTimeSelectionFormula = "";
            // 
            // frmrptton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 360);
            this.Controls.Add(this.xembaocaoton);
            this.Name = "frmrptton";
            this.Text = "Báo cáo tồn";
            this.ResumeLayout(false);

        }

        #endregion

        internal CrystalDecisions.Windows.Forms.CrystalReportViewer xembaocaoton;

    }
}