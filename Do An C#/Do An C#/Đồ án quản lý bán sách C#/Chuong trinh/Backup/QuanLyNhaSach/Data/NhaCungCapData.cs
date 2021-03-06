using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach.Data
{
    public class NhaCungCapData
    {
        DataService data = new DataService();
        SqlCommand cmd = new SqlCommand();

        public NhaCungCapData()
        {
            data.CreateAdapter();
        }
        public DataTable Laynhacungcap()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHA_CUNG_CAP");
            data.Load(cmd);
            return data;
        }
        public DataTable DS_NCC()
        {
            //SqlCommand scm = new SqlCommand("Select * from NHANVIEN");
            //data.Load(scm);
            string select = "Select* from NHA_CUNG_CAP";
            return data.Table(select);

        }
        public DataTable Table_NhaCungCap(string str)
        {
            return data.Table(str);
        }
        public string Value(string str, string column)
        {
            return data.Value(str, column);
        }

        public void ThemNCC(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 2);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một nhà cung cấp được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Không thêm vào được");
            }
        }

        public void XoaNCC(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 3);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một nhà cung cấp đã bị xóa");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public void UpdateNCC(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một nhà cung cấp đã được sửa");
            }
            catch
            {
                MessageBox.Show("Không sửa được");
            }
        }

        public DataTable TimNCC(string mancc, string chonten, string ten, string chondiachi, string diachi, string chondienthoai, string dienthoai)
        {
            if (ten == "")
                ten = " ";
            SqlCommand cmd = new SqlCommand();
            String sql = "select * from NHA_CUNG_CAP where (TENNCC Like '%' + @ten + '%' )";
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = ten;

            cmd.CommandText = sql;
            data.Load1(cmd);
            return data;
        }
    }
}