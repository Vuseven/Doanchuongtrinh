using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyNhaSach.Builder_layer;

namespace QuanLyNhaSach.Data
{
    public class ThongTinSachData
    {
        DataService data = new DataService();
        SqlCommand cmd = new SqlCommand();

        
        public DataTable Ds_ThongTinSach()
        {
            string select = "Select * from THONG_TIN_SACH";
            return data.Table(select);
        }
        public DataTable Ds_TTinSach(string masach)
        {
            string qr = "select * from THONG_TIN_SACH where MASACH='" + masach + "'";
            SqlCommand cm = new SqlCommand(qr);
            data.Load(cm);
            return data;
        }
        public DataTable LaySach()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM THONG_TIN_SACH");            
            data.Load(cmd);
            return data;
        }

        public ThongTinSachData()
        {
            data.CreateAdapter();
        }

        public DataTable LayTTSach()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM THONG_TIN_SACH");
            data.Load1(cmd);
            return data;
        }       
        public DataTable Table_ThongTinSach(string str)
        {
            return data.Table(str);
        }
        public string Value(string str, string column)
        {
            return data.Value(str, column);
        }

        public void ThemThongTinSach(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 2);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thong tin được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Không thêm vào được");
            }
        }

        public void XoaThongTinSach(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 3);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thong Tin đã bị xóa");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public void UpdateThongTinSach(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thong tin đã được sửa");
            }
            catch
            {
                MessageBox.Show("Không sửa được");
            }
        }
    }
}
