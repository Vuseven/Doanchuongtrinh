using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quanlykhachsan.Lopdoituong;


namespace Quanlykhachsan
{
    public partial class Xoakhach : Form
    {
        public Xoakhach()
        {
            InitializeComponent();
        }
        DataSet ds;

        private void button1_Click(object sender, EventArgs e)
        {
            
            string strcom = "Delete from khachhang where makhach='" + textBox1.Text + "'";
            //string strcom2 = "Delete from checkin where makhach='" + textBox1.Text + "'";
            
            if (MessageBox.Show("Bạn có thật sự muốn xoá nhân viên này", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    laydulieu dl = new laydulieu();
                    DataSet ds1 = dl.getdata("select makhach from khachhang where makhach='" + textBox1.Text + "'");


                    if (ds1.Tables[0].Rows.Count == 0)

                        MessageBox.Show("Không tồn tại mã khách hàng này,bạn hãy thử lại", "thông báo");


                    //ketnoi.ThietlapketNoi();


                    SqlCommand com = new SqlCommand(strcom, ketnoi.con);
                    //SqlCommand com2 = new SqlCommand(strcom2, ketnoi.con);
                    if (com.ExecuteNonQuery() > 0 )
                    {
                        DataRow dr = ds.Tables[0].Rows.Find(textBox1.Text);
                        ds.Tables[0].Rows.Remove(dr);
                        dataGridView1.DataSource = ds.Tables[0];
                        MessageBox.Show("Đã xoá thông tin khách", "thông báo");
                        ketnoi.HuyKetNoi();
                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xoakhach_Load(object sender, EventArgs e)
        {
            laydulieu dl = new laydulieu();
            ds = dl.getdata("select * from khachhang");
            DataColumn[] dt = new DataColumn[1];
            dt[0] = ds.Tables[0].Columns[0];
            ds.Tables[0].PrimaryKey = dt;
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}