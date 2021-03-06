namespace QuanLyNhaSach
{
    partial class frmBackup_Database
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvDatabase = new System.Windows.Forms.ListView();
            this.TenDatabase = new System.Windows.Forms.ColumnHeader();
            this.DateCreate = new System.Windows.Forms.ColumnHeader();
            this.DateBackup = new System.Windows.Forms.ColumnHeader();
            this.SoTable = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDetach = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnbackup = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.Dialog_openfile = new System.Windows.Forms.OpenFileDialog();
            this.Dialog_savefile = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvDatabase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 438);
            this.panel2.TabIndex = 6;
            // 
            // lvDatabase
            // 
            this.lvDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TenDatabase,
            this.DateCreate,
            this.DateBackup,
            this.SoTable});
            this.lvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDatabase.GridLines = true;
            this.lvDatabase.Location = new System.Drawing.Point(0, 0);
            this.lvDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.lvDatabase.Name = "lvDatabase";
            this.lvDatabase.Size = new System.Drawing.Size(792, 438);
            this.lvDatabase.TabIndex = 1;
            this.lvDatabase.UseCompatibleStateImageBehavior = false;
            this.lvDatabase.View = System.Windows.Forms.View.Details;
            this.lvDatabase.SelectedIndexChanged += new System.EventHandler(this.lvDatabase_SelectedIndexChanged);
            // 
            // TenDatabase
            // 
            this.TenDatabase.Text = "Database";
            this.TenDatabase.Width = 136;
            // 
            // DateCreate
            // 
            this.DateCreate.Text = "Ngày tạo Database";
            this.DateCreate.Width = 149;
            // 
            // DateBackup
            // 
            this.DateBackup.Text = "Ngày Backup";
            this.DateBackup.Width = 141;
            // 
            // SoTable
            // 
            this.SoTable.Text = "Số bảng";
            this.SoTable.Width = 116;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDetach);
            this.panel3.Controls.Add(this.btnAttach);
            this.panel3.Controls.Add(this.btnRestore);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnbackup);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnCreate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 518);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 55);
            this.panel3.TabIndex = 5;
            // 
            // btnDetach
            // 
            this.btnDetach.Location = new System.Drawing.Point(288, 19);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(75, 23);
            this.btnDetach.TabIndex = 6;
            this.btnDetach.Text = "Detach";
            this.btnDetach.UseVisualStyleBackColor = true;
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(196, 20);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 23);
            this.btnAttach.TabIndex = 5;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(106, 19);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(570, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnbackup
            // 
            this.btnbackup.Location = new System.Drawing.Point(12, 19);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(75, 23);
            this.btnbackup.TabIndex = 2;
            this.btnbackup.Text = "Backup";
            this.btnbackup.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(480, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(383, 20);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // Dialog_openfile
            // 
            this.Dialog_openfile.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 80);
            this.panel1.TabIndex = 4;
            // 
            // frmBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "frmBackupRestore";
            this.Text = "frmBackupRestore";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvDatabase;
        private System.Windows.Forms.ColumnHeader TenDatabase;
        private System.Windows.Forms.ColumnHeader DateCreate;
        private System.Windows.Forms.ColumnHeader DateBackup;
        private System.Windows.Forms.ColumnHeader SoTable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDetach;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.OpenFileDialog Dialog_openfile;
        private System.Windows.Forms.SaveFileDialog Dialog_savefile;
        private System.Windows.Forms.Panel panel1;
    }
}