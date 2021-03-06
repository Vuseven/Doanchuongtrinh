using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Nmo;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;

namespace QuanLyNhaSach
{
    public partial class frmBackup_Database : Form
    {
        ServerConnection serverconnect;
        Server server;
        public frmBackup_Database()
        {
            InitializeComponent();
            Create_Connect_Server();
            Show_Database();
        }

        // Tạo kết nối với Server
        void Create_Connect_Server()
        {
            serverconnect = new ServerConnection();
            serverconnect.LoginSecure = true;
            serverconnect.ServerInstance = @"(local)";
            server = new Server(serverconnect);
        }

        // Hiển thị các Database lên ListView

        void Show_Database()
        {
            try
            {
                int i = 0;
                lvDatabase.Items.Clear();
                foreach (Database database in server.Databases)
                {
                    i++;
                    // Tên cơ sở dữ liệu
                    ListViewItem item = new ListViewItem(database.Name);
                    // Ngày tạo cơ sở dữ liệu
                    item.SubItems.Add(database.CreateDate.ToShortDateString());
                    // Ngày backup cơ sở dữ liệu
                    item.SubItems.Add(database.LastBackupDate.ToShortDateString());
                    // Số table trong database
                    item.SubItems.Add(database.Tables.Count.ToString());
                    lvDatabase.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Cơ sở dữ liệu không tồn tại! Hãy kiểm tra lại");
            }
        }

        // Hàm tạo Database mới

        void Create_Database()
        {
            DatabaseName temp = new DatabaseName();
            temp.ShowDialog();
            string database = temp.textBox1.Text;
            Database new_Database = new Database(server, database);
            try
            {
                new_Database.Create();
                MessageBox.Show("Create database successfull!");
                Show_Database();
            }
            catch
            {
                MessageBox.Show("Create database failed!");
            }
            Show_Database();
        }

        // Hàm Attach Database: sử dụng SqlCommand 

        void Attach_Database()
        {
            Dialog_openfile.ShowDialog();
            string path = Dialog_openfile.FileName;
            DatabaseName temp = new DatabaseName();
            temp.ShowDialog();
            string db_name = temp.textBox1.Text;
            DataService data = new DataService();
            string str = "exec Attach_db '" + db_name + "','" + path + "'";
            data.ExecuteNonQuery(str);
        }

        //----------------------------------------------------------------------------
        // Hàm Detach Database: loại bỏ cơ sở dữ liệu ra khỏi SQLServer

        void Detach_Database()
        {
            ListViewItem item = lvDatabase.FocusedItem;
            if (item != null)
            {
                string database = item.SubItems[0].Text;
                try
                {
                    server.DetachDatabase(database, true);
                    MessageBox.Show("Detach database successfull!");
                    Show_Database();
                }
                catch { MessageBox.Show("Detach database failed!"); }
            }
        }
        //-------------------------------------------------------------------------------
        // Hàm Delete Database: Xóa CSDL -> xóa luôn source

        void Delete_Database()
        {
            ListViewItem item = lvDatabase.FocusedItem;
            if (item != null)
            {
                string database = item.SubItems[0].Text;
                try
                {
                    server.KillDatabase(database);
                    MessageBox.Show("Delete database successfull!");
                    Show_Database();
                }
                catch { MessageBox.Show("Delete database failled!"); }
            }
        }
        //-----------------------------------------------------------------------
        // Tạo BackupDevice nếu nó chưa tồn tại
        void makeBackupDevice(string backupDeviceName, Server server)
        {
            bool isBackupDevice = false;
            try
            {
                // Duyệt qua các BackupDevice đang có trong SQL Server
                foreach (BackupDevice backupdevice in server.BackupDevices)
                {
                    if (backupdevice.Name == backupDeviceName)
                    {
                        // Nếu đã tồn tại BackupDevice thì khai báo biến isBackupDevice là true
                        isBackupDevice = true;
                        break;
                    }
                }

                // Nếu backupDevice chưa có trong SQL Server
                if (!isBackupDevice)
                {
                    BackupDevice newbackupdevice = new BackupDevice();
                    Dialog_savefile.ShowDialog();
                    string name = Dialog_savefile.FileName;
                    newbackupdevice.Parent = server;
                    newbackupdevice.Name = backupDeviceName;
                    newbackupdevice.PhysicalLocation = @"" + name + ".bak";
                    newbackupdevice.BackupDeviceType = BackupDeviceType.Disk;

                    newbackupdevice.Create();
                }
            }
            catch { MessageBox.Show("Create BackupDevice failed!"); }
        }
        //---------------------------------------------------------------------------
        // Backup Database cách thứ 1: sử dụng SqlCommand

        void Backup_Database()
        {
            ListViewItem item = lvDatabase.FocusedItem;
            string database = item.SubItems[0].Text;
            Dialog_savefile.ShowDialog();
            string strSQL = "BACKUP DATABASE ";
            strSQL += database;
            strSQL += " TO DISK = '" + Dialog_savefile.FileName + "'";
            DataService data = new DataService();
            try
            {
                data.ExecuteNonQuery(strSQL);
                MessageBox.Show("Backup Database thành công");
            }
            catch { MessageBox.Show("Backup Database thất bại"); }
        }
        
        //---------------------------------------------------------------------------------
        // Restore Database cách thứ I: sử dụng SqlCommand

        void Restore_Database()
        {
            Dialog_openfile.ShowDialog();
            ListViewItem item = lvDatabase.FocusedItem;
            string database = item.SubItems[0].Text;
            string strSQL = "RESTORE DATABASE ";
            strSQL += database;
            strSQL += " FROM DISK = '" + Dialog_openfile.FileName + "'";
            strSQL += " WITH RECOVERY";
            MessageBox.Show(strSQL);
            DataService data = new DataService();
            try
            {
                data.ExecuteNonQuery(strSQL);
            }
            catch { MessageBox.Show("Restore Database thất bại"); }
        }

        private void lvDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Backup_Database();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Restore_Database();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            Attach_Database();
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            Detach_Database();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Create_Database();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Database();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}