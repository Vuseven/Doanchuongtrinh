using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach.Data
{
    public class PhieuThuData
    {
        //DataService data = new DataService();
        //public DataTable Ds_PhieuThu()
        //{
        //    string Select = "Select * from PHIEUTHU";
        //    return data.Table(Select);
        //}

        DataService data = new DataService();
        SqlCommand cmd = new SqlCommand();

        public PhieuThuData()
        {
            data.CreateAdapter();
        }

        public DataTable DS_PhieuThu()
        {
            //SqlCommand scm = new SqlCommand("Select * from NHANVIEN");
            //data.Load(scm);
            string select = "Select* from PHIEUTHU";
            return data.Table(select);

        }
        public DataTable Table_PhieuThu(string str)
        {
            return data.Table(str);
        }
        public string Value(string str, string column)
        {
            return data.Value(str, column);
        }

        public void ThemPT(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 2);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một Phiếu thu được thêm vào danh sách");
            }
            catch
            {
                MessageBox.Show("Không thêm vào được");
            }
        }

        public void XoaPT(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 3);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một Phiếu thu đã bị xóa");
            }
            catch
            {
                MessageBox.Show("Không xóa được");
            }
        }

        public void UpdatePT(string str)
        {
            cmd.CommandText = str;
            data.AddTypeUpdate(cmd, 1);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Một Phiếu thu đã được sửa");
            }
            catch
            {
                MessageBox.Show("Không sửa được");
            }
        }
    }
}
