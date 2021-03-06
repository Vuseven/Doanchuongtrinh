using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach.Data
{
    public class TonKhoData
    {
        DataService data = new DataService();
        SqlCommand cmd = new SqlCommand();

        public TonKhoData()
        {
            data.CreateAdapter();
        }

        //public DataTable Laynhanvien()
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM TONKHO");
        //    data.Load1(cmd);
        //    return data;
        //}
        public DataTable DS_SachTon()
        {            
            string select = "Select* from TONKHO";
            return data.Table(select);
        }
        public DataTable Table_SachTon(string str)
        {
            return data.Table(str);
        }
        public string Value(string str, string column)
        {
            return data.Value(str, column);
        }

        public void ThemSachTon(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 2);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sách tồn được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Không thêm vào được");
            }
        }

        public void XoaSachTon(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 3);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sách đã bị xóa");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public void UpdateSachTon(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sách tồn đã được sửa");
            }
            catch
            {
                MessageBox.Show("Không sửa được");
            }
        }
        public DataTable TimSachTon(string masach)
        {
            if (masach == "")
                masach = " ";
            SqlCommand cmd = new SqlCommand();
            String sql = "select * from TONKHO where (MASACH Like '%' + @masach + '%' )";
            cmd.Parameters.Add("masach", SqlDbType.VarChar).Value = masach;

            cmd.CommandText = sql;
            data.Load1(cmd);
            return data;
        }
    }
}
