using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach.Data
{
    public class NhanVienData
    {
        DataService data = new DataService();
        SqlCommand cmd = new SqlCommand();

        public NhanVienData()
        {
            data.CreateAdapter();
        }

        public DataTable Laynhanvien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NHANVIEN");
            data.Load1(cmd);
            return data;
        }
        public DataTable DS_NhanVien()
        {
            //SqlCommand scm = new SqlCommand("Select * from NHANVIEN");
            //data.Load(scm);
            string select = "Select* from NHANVIEN";
            return data.Table(select);
        }
        public DataTable Table_NhanVien(string str)
        {
            return data.Table(str);
        }
        public string Value(string str, string column)
        {
            return data.Value(str, column);
        }

        public void ThemNV(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 2);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một nhân viên được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Không thêm nhân viên này vào được");
            }
        }

        public void XoaNV(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 3);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một nhân viên đã bị xóa");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public void UpdateNV(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một nhân viên đã được sửa");
            }
            catch
            {
                MessageBox.Show("Không sửa được");
            }
        }
        public DataTable TimNhanVien(string ten, string choncv,string chucvu)
        {
            if (ten == "")
                ten = " ";
            SqlCommand cmd = new SqlCommand();
            String sql = "select * from NHANVIEN where (HOTENNV Like '%' + @ten + '%' )";
            cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = ten;

            //if (chonten != "None")
            //{
            //    sql += chonten + " (HOTENNV LIKE '%' + @ten  + '%') ";
            //    cmd.Parameters.Add("ten", SqlDbType.VarChar).Value = ten;
            //}

            if (choncv != "None")
            {
                sql += choncv + " (CHUCVU LIKE '%' + @cv  + '%') ";
                cmd.Parameters.Add("cv", SqlDbType.VarChar).Value = chucvu;

            }
            cmd.CommandText = sql;
            data.Load1(cmd);
            return data;
        }
    }
}
