using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace TT_GDTX_ANGIANG
{
    public partial class frm_CSDL : DevComponents.DotNetBar.Office2007Form
    {
        public frm_CSDL()
        {
            InitializeComponent();
        }

        private void frm_CSDL_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            importDatabase();
            Close();
        }

        public void importDatabase()
        {
            //DataService dt = new DataService();
            //if (dt.testConnected() == 0)
            //{
            //    OpenFileDialog op = new OpenFileDialog();
            //    if (op.ShowDialog() == DialogResult.OK)
            //    {
            //        string sql = "    use master EXEC sp_attach_single_file_db @dbname = 'QLNSTL_TTGDTX_AG', @physname = '" + op.FileName.ToString() + "'  ";
            //        SqlCommand cmd = new SqlCommand(sql);
            //        dt.Load_Database(cmd);
            //        MessageBoxEx.Show("Cơ sở dữ liệu đã import thành công!");
            //        sql = " use QLNSTL_TTGDTX_AG ";

            //        cmd = new SqlCommand(sql);
            //        dt.Load_Database(cmd);
            //        this.Close();
            //    }
            //    this.Close();
            //}


        }
    }
}