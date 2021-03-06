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
    public class KhachHangCtrl
    {
        KhachHangData khData = new KhachHangData();
        DataShow datashow = new DataShow();       

        public void HienThi(DataGridView dg, BindingNavigator bn)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = Tbl_KhachHang();
            bn.BindingSource = bs;
            dg.DataSource = bs;
            //t.Text = dg[0, 0].Value.ToString();
        }

        public void LoadComboBox(ComboBox cbo, string Display, string Value)
        {
            datashow.LoadToComboBox(cbo, khData.DS_KhachHang(), Display, Value);
        }

        public void HienThiCB(ComboBox cb)
        {
            cb.DataSource = khData.LayKhachHang();
            cb.DisplayMember = "MAKH";
            cb.ValueMember = "MAKH";
        }      

        public DataTable Tbl_KhachHang()
        {
            string select = "Select * from KHACHHANG";
            return khData.Table_KhachHang(select);
        }

        public void ThemKH(string MaKH, string HoTenKH, string Phai, string DiaChi, string DienThoai, string MaSoThue, string GhiChu)
        {
            string str = "Insert into KHACHHANG values('" + MaKH + "','" + HoTenKH + "','" + Phai + "','" + DiaChi + "','" + DienThoai + "','" + MaSoThue + "','"+ GhiChu +"')";
            khData.ThemKH(str);

        }

        public void XoaKH(string maKH)
        {
            string str = "delete from KHACHHANG where MAKH='" + maKH + "'";
            khData.XoaKH(str);
        }

        public void UpdateKH(KhachHangInfo khInfo,string maKH)
        {
            string str = "update KHACHHANG set MAKH='" + khInfo.MaKhachHang + "',HOTENKH='" + khInfo.TenKhachHang + "',PHAI='" + khInfo.Phai + "',DIACHI='" + khInfo.DiaChi + "',DIENTHOAI='" + khInfo.DienThoai + "',MASOTHUE = '" + khInfo.MaSoThue + "',GHICHU = '" + khInfo.GhiChu + "'";
            str += "where MAKH = '" + maKH + "'";
            khData.UpdateKH(str);
        }
        public void TimKhachHang(TextBox t1, ComboBox c1, TextBox t2, ComboBox c2, TextBox t3, DataGridView dg)
        {            
            DataTable tbl = khData.TimKhachHang(t1.Text, c1.Text, t2.Text, c2.Text, t3.Text);
            dg.DataSource = tbl;
        }


    }
}
