using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach.Data
{
    public class PhieuChiData
    {
        DataService data = new DataService();
        SqlCommand cmd = new SqlCommand();

        public PhieuChiData()
        {
            data.CreateAdapter();
        }

        public DataTable DS_PhieuChi()
        {
            string select = "Select* from PHIEUCHI";
            return data.Table(select);

        }
        public DataTable Table_PhieuChi(string str)
        {
            return data.Table(str);
        }
        public string Value(string str, string column)
        {
            return data.Value(str, column);
        }

        public void ThemPC(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 2);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một Phiếu chi được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Không thêm vào được");
            }
        }

        public void XoaPC(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 3);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một Phiếu chi đã bị xóa");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public void UpdatePC(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một Phiếu chi đã được sửa");
            }
            catch
            {
                MessageBox.Show("Không sửa được");
            }
        }
    }
}
