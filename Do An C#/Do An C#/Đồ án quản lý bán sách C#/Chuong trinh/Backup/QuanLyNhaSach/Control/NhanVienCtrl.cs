using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuanLyNhaSach.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyNhaSach.Builder_layer;


namespace QuanLyNhaSach.Control
{
    public class NhanVienCtrl
    {
        NhanVienData nvData = new NhanVienData();
        DataShow datashow = new DataShow();         
        public void LoadComboBox(ComboBox cbo, string Display, string Value)
        {
            datashow.LoadToComboBox(cbo, nvData.DS_NhanVien(), Display, Value);
        }
        public void HienThiCB(ComboBox cb)
        {
            cb.DataSource = nvData.Laynhanvien();
            cb.DisplayMember = "MANV";
            cb.ValueMember = "MANV";
        }
        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Tbl_NhanVien();
            bn.BindingSource = bs;
            dg.DataSource = bs;
            //t.Text = dg[0, 0].Value.ToString();
        }
        public void load_data(TextBox t1, TextBox t2, RadioButton r1 , RadioButton r2 , TextBox t4, TextBox t5, TextBox t6, DataGridViewRow row)
        {
            t1.Text = row.Cells[0].Value.ToString();
            t2.Text = row.Cells[1].Value.ToString();
            if ( row.Cells[2].Value.ToString()== "NAM")
                r1.Checked = true;
            else r2.Checked = true;
            t4.Text = row.Cells[3].Value.ToString();
            t5.Text = row.Cells[4].Value.ToString();
            t6.Text = row.Cells[5].Value.ToString();
        }

        public DataTable Tbl_NhanVien()
        {
            string select = "Select * from NHANVIEN";
            return nvData.Table_NhanVien(select);
        }

        public void ThemNV(string manv,string hoten,string phai,string chucvu,string diachi,string dienthoai )
        {
            string str = "Insert into NHANVIEN values('"+manv+"','"+hoten+"','"+phai+"','"+chucvu+"','"+diachi+"','"+dienthoai+"')";
            nvData.ThemNV(str);   
            
        }

        public void XoaNV(string maNV)
        {
            string str = "delete from NHANVIEN where MANV='"+maNV+"'";
            nvData.XoaNV(str);
        }

        public void UpdateNV(NhanVienInfo nvInfo, string maNV)
        {
            string str = "update NHANVIEN set MANV='" + nvInfo.MaNhanVien + "',HOTENNV='" + nvInfo.TenNhanVien + "',PHAI='" + nvInfo.Phai + "',CHUCVU='" + nvInfo.ChucVu + "',DIACHI='" + nvInfo.DiaChi + "',DIENTHOAI='" + nvInfo.DienThoai + "'";
            str += "where MANV = '" + maNV + "'";
            nvData.UpdateNV(str);
        }

       

        public void TimNhanVien(TextBox t2,ComboBox c3,TextBox t3, DataGridView dg)
        {
            DataTable tbl = nvData.TimNhanVien( t2.Text,c3.Text,t3.Text);
            dg.DataSource = tbl;
        }
     }
}
