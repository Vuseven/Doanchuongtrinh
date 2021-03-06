using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DevComponents.DotNetBar;

namespace Quanlydoanvien
{
    public partial class frmTimliemDVchuadongDP : DevComponents.DotNetBar.Office2007Form
    {
        public frmTimliemDVchuadongDP()
        {
            InitializeComponent();
            
        }
        private OleDbConnection objConnect;
        private DataTable objDataTable;
        private void subDestroyConnect()
        {
            objConnect.Close(); //Đóng kết nối 
            objConnect.Dispose();//Giải phóng tài nguyên 
            objConnect = null; //Hủy đối tượng 
        }
        private void subCreateConnect()
        {
            try
            {
                String varChuoiConnect = "Provider = Microsoft.Jet.OLEDB.4.0 ;" +
                            "Data Source =" + Application.StartupPath + @"\quanlydoanvien.mdb;" +
                            "Jet OLEDB:Database Password =000000;" +
                            "User ID = admin";
                objConnect = new OleDbConnection(varChuoiConnect);
                objConnect.Open();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("Không thể kết nối tới CSDL. Xin kiểm tra lại kết nối!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void subSelectByDataAdapter()
        {    //Tạo kết nối tới file Access 
            subCreateConnect();
            //Tao Command 
            OleDbCommand objCommand = new OleDbCommand();
            objCommand.Connection = objConnect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = "Select * From DOANPHI where SOTIEN>@SOTIEN";
            
            //Tạo đối tượng Adapter 
            OleDbDataAdapter objAdapter = new OleDbDataAdapter();
            objAdapter.SelectCommand = objCommand;//Nạp command cho DataAdapter 
            //Tạo DataTable nhận dữ liệu trả về 
            objDataTable = new DataTable("abc");
            objAdapter.Fill(objDataTable); //Điền dữ liệu trả về vào Table 
            //Gán dữ liệu vào Datagrid 
            DGTIMKIEM.DataSource = objDataTable;
            //Hủy các đối tượng 
            objCommand.Dispose();
            objCommand = null;
            objDataTable.Dispose();
            objDataTable = null;
            objAdapter.Dispose();
            objAdapter = null;
            subDestroyConnect();
        }
        private void frmTimliemDVchuadongDP_Load(object sender, EventArgs e)
        {
            btnxuat.Enabled = false;
            AdvancedCursors av = new AdvancedCursors();
            this.Cursor = AdvancedCursors.Create(@".\3dc_3043.ani");
            progressBar1.Visible = false;
            try
            {
                subCreateConnect();
               
            }
            catch
            {
                MessageBoxEx.Show("Không kết nối được CSDL xin xem lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chức năng nâng cao này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
                Close();
        }
        public int demgiatri()
        {
            int i;
            for (i = 0; i < DGTIMKIEM.RowCount - 1 ; i++)
            {
                i.ToString();
            }
            return i ;
        }
        
        public bool ktso()
        {
            int i= Convert.ToInt32(txtthunghiem.Text);
            if (i > 0)
                return true;
            return false;
        }
        private void BTNTIM_Click(object sender, EventArgs e)
        {
            
            if (radchuadong.Checked == false && radong.Checked == false)
            {
                progressBar1.Visible = false;
                MessageBoxEx.Show("Bạn chưa chọn lĩnh vực tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                if (radong.Checked == true)
                {
                    progressBar1.Visible = true;
                    for (int i = 0; i < 100; i++)
                    {
                        progressBar1.Value++;
                        System.Threading.Thread.Sleep(20);
                        progressBar1.Update();

                    }
                    frmDoanphi DP = new frmDoanphi();
                    string select = " Select * From DOANPHI where SOTIEN ="+ ktso() +"";
                    OleDbDataAdapter da = new OleDbDataAdapter(select, objConnect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ds");
                    DGTIMKIEM.DataSource = ds;
                    DGTIMKIEM.DataMember = "ds";                   
                    MessageBoxEx.Show("Đã tìm thấy " + demgiatri() + " đoàn viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;
                }

                else
                {
                    progressBar1.Visible = true;
                    for (int i = 0; i < 100; i++)
                    {
                        progressBar1.Value++;
                        System.Threading.Thread.Sleep(20);
                        progressBar1.Update();

                    }
                    string select = " Select * From DOANPHI where SOTIEN =0";
                    OleDbDataAdapter da = new OleDbDataAdapter(select, objConnect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ds");
                    DGTIMKIEM.DataSource = ds;
                    DGTIMKIEM.DataMember = "ds";                 
                    MessageBoxEx.Show("Đã tìm thấy " + demgiatri() + " đoàn viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;

                }
        }

        private void frmTimliemDVchuadongDP_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chức năng tìm kiếm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (thoat == DialogResult.No);
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            try
            {

                frmInDP dp = new frmInDP();
                dp.Show();

            }
            catch (Exception)
            {
                MessageBoxEx.Show(" Bạn chưa cài đặt Reportreview để bật chức năng này!", " Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radong_CheckedChanged(object sender, EventArgs e)
        {
            btnxuat.Enabled = false;
        }

        private void radchuadong_CheckedChanged(object sender, EventArgs e)
        {
            btnxuat.Enabled = true;
                                  
        }
    }
}