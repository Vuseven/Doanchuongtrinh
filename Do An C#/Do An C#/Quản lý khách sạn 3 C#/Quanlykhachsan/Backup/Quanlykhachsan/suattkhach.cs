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
    public partial class suattkhach : Form
    {
        public suattkhach()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void suattkhach_Load(object sender, EventArgs e)
        {
            
         
        
        }



        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
         public static string ma, ten, tuoi, cmnd, dt, quoctich, diachi, ngay;

       


        private void tmakhachcu_TextChanged(object sender, EventArgs e)
        {

           
            if (tmakhachcu.Text!="")
            try
            {

                laydulieu dl = new laydulieu();
                SqlDataReader dr = dl.lay_reader("select tenkhach,tuoi,chungminh,dienthoai,quoctich,diachi,ngaydatphong from khachhang where makhach='" + tmakhachcu.Text + "'");
                while (dr.Read())
                {
                    ttenkhachcu.Text = dr.GetValue(0).ToString();

                    ttuoicu.Text = dr.GetValue(1).ToString();
                    tcmndcu.Text = dr.GetValue(2).ToString();
                    tdtcu.Text = dr.GetValue(3).ToString();
                    tquoctichcu.Text = dr.GetValue(4).ToString();
                    tdiachicu.Text = dr.GetValue(5).ToString();
                    tngaycu.Text = dr.GetValue(6).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tmakhachmoi.Text != "") ma = tmakhachmoi.Text;
            else
                ma = tngaycu.Text;

            if (ttenmoi.Text != "") ten = ttenmoi.Text;
            else ten = ttenkhachcu.Text;
            if (ttuoimoi.Text != "") tuoi = ttuoimoi.Text;
            else tuoi = ttuoicu.Text;
            if (tcmndmoi.Text != "") cmnd = tcmndmoi.Text;
            else cmnd = ttuoicu.Text;

            if (tsdtmoi.Text != "") dt = tsdtmoi.Text;
            else dt = tdtcu.Text;

            if (tquoctichmoi.Text != "") quoctich = tquoctichmoi.Text;
            else quoctich = tquoctichcu.Text;

            if (tdiachimoi.Text != "") diachi = tdiachimoi.Text;
            else diachi = tdiachicu.Text;

            if (tngaymoi.Text != "") ngay = tngaymoi.Text;
            else ngay = tngaycu.Text;

            string strcom = "Update khachhang set makhach='" + ma + "'," + "tenkhach='" + ten + "'," + "tuoi=" + Convert.ToInt16(tuoi) + ",chungminh='" + cmnd + "'," + "dienthoai='" + dt + "'," + "quoctich='" + quoctich + "'," + "diachi='" + diachi + "'," + "ngaydatphong='" + ngay + "'" + " where makhach='" + tmakhachcu.Text+"'" ;
           
            try {
                ketnoi.ThietlapketNoi();
                SqlCommand com = new SqlCommand(strcom,ketnoi.con);
                com.ExecuteNonQuery();
                ketnoi.HuyKetNoi();
               


               // if (dl.thucthitruyvan("Update khachhang set makhach='"+ma+"',"+"tenkhach='"+ten+"',"+"tuoi="+Convert.ToInt16(tuoi)+",chungminh='"+cmnd+"',"+"dienthoai='"+dt+"',"+"quoctich='"+quoctich+"',"+"diachi='"+diachi+"',"+"ngaydatphong='"+ngay+"'")==1)
                
               // ketnoi.HuyKetNoi();
                    MessageBox.Show("Đã sửa thông tin","thông báo");
                
            }

                catch { }


               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}