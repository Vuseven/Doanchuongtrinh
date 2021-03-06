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
    public partial class frmTimkiemdv : DevComponents.DotNetBar.Office2007Form
    {
        public frmTimkiemdv()
        {
            InitializeComponent();
            
        }
        private OleDbConnection objConnect;
        

       
        private void frmTimkiemdv_Load(object sender, EventArgs e)
        {
            btnchidoan.Enabled = false;
            btnten.Enabled = false;
            btnma.Enabled = false;
            btnchongioitinh.Enabled = false;
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
        
        public int demgiatri()
        {
            int i;
            for (i = 0; i <= dgdoanvien.RowCount -1 ; i++)
            {
                i.ToString();
            }
            return i;
        }
        public bool timkiem()
        {
            int k = dgdoanvien.RowCount;
            if (radmasv.Checked == true)
            {

                string select = " Select * From DOANVIEN where MADV = '" + comboma.Text.ToString().Trim() + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(select, objConnect);
                DataSet ds = new DataSet();
                da.Fill(ds, "ds");
                dgdoanvien.DataSource = ds;
                dgdoanvien.DataMember = "ds";
                if (demgiatri() == 0)
                {
                    MessageBoxEx.Show("Không tìm thấy đoàn viên có tên " + comboma.Text + " !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBoxEx.Show("Đã tìm thấy đoàn viên " + comboma.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;

            }
            else
                if (radtensv.Checked == true)
                {

                    string select = " Select * From DOANVIEN where TEN = '" + comboma.Text.ToString().Trim() + "'";
                    OleDbDataAdapter da = new OleDbDataAdapter(select, objConnect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ds");
                    dgdoanvien.DataSource = ds;
                    dgdoanvien.DataMember = "ds";
                    if (demgiatri() == 0)
                    {
                        MessageBoxEx.Show("Không tìm thấy đoàn viên có mã " + comboma.Text + " !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    }
                    else
                        MessageBoxEx.Show("Đã tìm thấy đoàn viên " + comboma.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                }
                else
                    if (radgioitinh.Checked == true)
                    {

                        string select = " Select * From DOANVIEN where GIOITINH = '" + comboma.Text.ToString().Trim() + "'";
                        OleDbDataAdapter da = new OleDbDataAdapter(select, objConnect);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "ds");
                        dgdoanvien.DataSource = ds;
                        dgdoanvien.DataMember = "ds";
                        if (demgiatri() == 0)
                        {
                            MessageBoxEx.Show("Không tìm thấy đoàn viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                           
                                MessageBoxEx.Show("Đã tìm thấy " + demgiatri().ToString() + " đoàn viên có giới tính là "+comboma.Text+"!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                         
                        return true;

                    }
                    else
                        if (radchidoan.Checked == true)
                        {

                            string select = " Select * From DOANVIEN where CHIDOAN = '" + comboma.Text.ToString().Trim() + "'";
                            OleDbDataAdapter da = new OleDbDataAdapter(select, objConnect);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "ds");
                            dgdoanvien.DataSource = ds;
                            dgdoanvien.DataMember = "ds";
                            if (demgiatri() == 0)
                            {
                                MessageBoxEx.Show("Không tìm thấy đoàn viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else

                                MessageBoxEx.Show("Đã tìm thấy " + demgiatri().ToString() + " đoàn viên có chi đoàn là " + comboma.Text + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            return true;

                        }
                else
                {
                    return false;
                    
                }
        }
     

        public void timkiem2()
        {
            
           
                if (radtensv.Checked == false && radmasv.Checked == false && radgioitinh.Checked == false && radchidoan.Checked == false)
                {
                    progressBar1.Visible = false;
                    MessageBoxEx.Show(" Bạn phải chọn lĩnh vực tìm kiếm", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (comboma.Text == "" &&( radtensv.Checked == true || radmasv.Checked == true || radgioitinh.Checked == true || radchidoan.Checked == true))
                {
                    progressBar1.Visible = false;
                    MessageBoxEx.Show(" Điều kiện tìm kiếm không được để rỗng!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }           
                    else
                    {
                        for (int i = 0; i < 100; i++)
                        {
                            
                            progressBar1.Value++;
                            
                            System.Threading.Thread.Sleep(20);
                            
                            progressBar1.Update();
                            
                        }      
                        timkiem();
                        
                    }

                
        }
         
        private void BTNTIM_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;                               
            timkiem2();
           
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        

        private void frmTimkiemdv_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult thoat = MessageBoxEx.Show("Có phải bạn muốn thoát khỏi chức năng tìm kiếm này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (thoat == DialogResult.No);
        }
        public void GetFirstValue(string value)
        {
            comboma.Text = value;
        }

        private void btnma_Click(object sender, EventArgs e)
        {
            frmChonMADVtimkiem first = new frmChonMADVtimkiem();
            first.passData = new frmChonMADVtimkiem.PassData(GetFirstValue);
            
            first.Show(); 
        }

        private void btnten_Click(object sender, EventArgs e)
        {
            frmChonTendv first = new frmChonTendv();
            first.passData = new frmChonTendv.PassData(GetFirstValue);
            first.Show(); 
        }

        private void btnchongioitinh_Click(object sender, EventArgs e)
        {
            frmChonGioitinh first = new frmChonGioitinh();
            first.passData = new frmChonGioitinh.PassData(GetFirstValue);
            first.Show(); 
        }

        public void disable()
        {
            btnchongioitinh.Enabled = false;
            btnma.Enabled = true;
            btnten.Enabled = false;
            btnchidoan.Enabled = false;
        }
        public void disable1()
        {
            btnchongioitinh.Enabled = true;
            btnma.Enabled = false;
            btnten.Enabled = false;
            btnchidoan.Enabled = false;
        }
        public void disable2()
        {
            btnchongioitinh.Enabled = false;
            btnma.Enabled = false;
            btnten.Enabled = true;
            btnchidoan.Enabled = false;
        }
        public void disable3()
        {
            btnchongioitinh.Enabled = false;
            btnma.Enabled = false;
            btnten.Enabled = false;
            btnchidoan.Enabled = true;
        }

        private void radmasv_CheckedChanged(object sender, EventArgs e)
        {
            disable();
        }

        private void radgioitinh_CheckedChanged(object sender, EventArgs e)
        {
            disable1();
        }

        private void radtensv_CheckedChanged(object sender, EventArgs e)
        {
            disable2();
        }

        private void btnchonchidoan_Click(object sender, EventArgs e)
        {
            frmchonChidoan first = new frmchonChidoan();
            first.passData = new frmchonChidoan.PassData(GetFirstValue);
            first.Show(); 
        }

        private void radchidoan_CheckedChanged(object sender, EventArgs e)
        {
            disable3();
        }

       
       
    }
}