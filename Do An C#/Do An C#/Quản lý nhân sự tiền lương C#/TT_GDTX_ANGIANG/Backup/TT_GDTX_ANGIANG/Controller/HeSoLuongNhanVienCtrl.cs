using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;


namespace TT_GDTX_ANGIANG.Controller
{
    public class HeSoLuongNhanVienCtrl
    {
        #region data_HSLuongNhanVien
        private HeSoLuongNhanVienData m_data_HSLuongNhanVien;
        public HeSoLuongNhanVienData data_HSLuongNhanVien
        {
            get { return m_data_HSLuongNhanVien; }
            set { m_data_HSLuongNhanVien = value; }
        }
        #endregion

        #region Table
        private DataTable m_Table;
        public DataTable Table
        {
            get { return m_Table; }
            set { m_Table = value; }
        }

        #endregion

        #region HienThi_dsHSLuongNhanVien()
        public void HienThi_dsHSLuongNhanVien(ListView listView)
        {
            if (data_HSLuongNhanVien == null)
            {
                data_HSLuongNhanVien = new HeSoLuongNhanVienData();
            }
            Table = data_HSLuongNhanVien.lay_dsHeSoLuongNhanVien();
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                HeSoLuongNhanVienInfo info = new HeSoLuongNhanVienInfo();

                info.MaHeSoLuong = row["MAHSLUONG"].ToString();
                try
                {
                    NgachCtrl ctrl_Ngach = new NgachCtrl();
                    info.TenNgach = ctrl_Ngach.GetNgach(row["TENNGACHLUONG"].ToString());
                }
                catch
                {
                    MessageBox.Show("Lỗi tên ngạch");
                }
                try
                {
                    BacCtrl ctrl_Bac = new BacCtrl();
                    info.TenBac = ctrl_Bac.GetBac(row["TENBACLUONG"].ToString());
                }
                catch
                {
                    MessageBox.Show("lỗi bậc lương");
                }

                info.HeSoLuong = float.Parse(row["HSLUONGNHANVIEN"].ToString());


                ListViewItem item = new ListViewItem();
                item.Text = info.MaHeSoLuong;
                try
                {
                    item.SubItems.Add(info.TenNgach.TenNgach);
                }
                catch
                {
                    MessageBox.Show("lỗi tên ngạch","Thông Báo");
                }
                try
                {
                    item.SubItems.Add(info.TenBac.TenBac);
                }
                catch
                {
                    MessageBox.Show("lỗi bậc lương","Thông Báo");
                }
                item.SubItems.Add(info.HeSoLuong.ToString());
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaCV)
        {
            Table = data_HSLuongNhanVien.lay_dsHeSoLuongNhanVien();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaCV.Text = "HSL1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("HSL", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaCV.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(TextBox txtmaHSL, ComboBox cboTenNgach, ComboBox cboTenBac, DevComponents.Editors.DoubleInput hesoluong, HeSoLuongNhanVienInfo info)
        {
            txtmaHSL.Text = info.MaHeSoLuong;
            try
            {
                cboTenNgach.Text = info.TenNgach.TenNgach;
            }
            catch
            {
                MessageBox.Show("lỗi tên ngạch","Thông Báo");
            }
            try
            {
                cboTenBac.Text = info.TenBac.TenBac;
            }
            catch
            {
                MessageBox.Show("lỗi bậc lương","Thông Báo");
            }
            hesoluong.Text = info.HeSoLuong.ToString();

        }
        #endregion

        #region Add()
        public bool Add(HeSoLuongNhanVienInfo info)
        {
            DataRow row = Table.NewRow();
            row["MAHSLUONG"] = info.MaHeSoLuong;
            row["TENNGACHLUONG"] = info.TenNgach.MaNgach;
            row["TENBACLUONG"] = info.TenBac.MaBac;
            row["HSLUONGNHANVIEN"] = info.HeSoLuong;


            Table.Rows.Add(row);
            if (this.data_HSLuongNhanVien.Update())
            {
                return true;
            }
            else
            {
                Table.Rows.Remove(row);
                return false;
            }

           
        }
        #endregion

        public string LayHeSoLuong(string tenNgach, string tenBac)
        {
            HeSoLuongNhanVienData hsldata = new HeSoLuongNhanVienData();
            return hsldata.lay_HeSoLuong(tenNgach, tenBac);
        }
        #region Delete()
        public bool Delete(int index)
        {
            //this.Table.Rows[index].Delete();
            this.Table.Rows[index].Delete();

            return this.data_HSLuongNhanVien.Update();
        }
        #endregion

        #region Update()
        public void Update(HeSoLuongNhanVienInfo info, int index)
        {
            //this.Table.Rows[index]["MAPH"] = info.MaPhong;
            this.Table.Rows[index]["TENNGACHLUONG"] = info.TenNgach;
            this.Table.Rows[index]["TENBACLUONG"] = info.TenBac;
            this.Table.Rows[index]["HSLUONGNHANVIEN"] = info.HeSoLuong;

            this.data_HSLuongNhanVien.Update();
        }
        #endregion
        #region CapNhatHeSoLuongNhanVien()
        public void CapNhatHeSoLuongNhanVien(HeSoLuongNhanVienInfo info, int index)
        {
            //this.Table.Rows[index]["MAPH"] = info.MaPhong;
            this.Table.Rows[index]["TENNGACHLUONG"] = info.TenNgach;
            this.Table.Rows[index]["TENBACLUONG"] = info.TenBac;
            this.Table.Rows[index]["HSLUONGNHANVIEN"] = info.HeSoLuong;

            this.data_HSLuongNhanVien.CapNhatHeSoLuongNhanVien(info);
        }
         #endregion

        #region XoaHeSoLuongNhanVien

        public void XoaHeSoLuongNhanVien(String MaNV)
        {
            if (data_HSLuongNhanVien == null)
                data_HSLuongNhanVien = new HeSoLuongNhanVienData();
            data_HSLuongNhanVien.XoaHeSoLuongNhanVien(MaNV);
        }
        #endregion
    }
}
