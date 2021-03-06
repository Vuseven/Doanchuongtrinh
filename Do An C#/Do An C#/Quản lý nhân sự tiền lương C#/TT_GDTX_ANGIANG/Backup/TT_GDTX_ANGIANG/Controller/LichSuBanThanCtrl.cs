using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DevComponents.DotNetBar.Controls;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;
using System.Windows.Forms;
using System.Data;

namespace TT_GDTX_ANGIANG.Controller
{
    public class LichSuBanThanCtrl
    {
        #region data_LichSuBanThan
        private LichSuBanThanData m_data_LichSuBanThan;
        public LichSuBanThanData data_LichSuBanThan
        {
            get { return m_data_LichSuBanThan; }
            set { m_data_LichSuBanThan = value; }
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

        #region HienThi_dsLichSuBanThan()
        public void HienThi_dsLichSuBanThan(ListView listView, string manv)
        {
            if (data_LichSuBanThan == null)
            {
                data_LichSuBanThan = new LichSuBanThanData();
            }
            Table = data_LichSuBanThan.lay_dsLichSuBanThan(manv);
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                LichSuBanThanInfo info = new LichSuBanThanInfo();

               
                info.MaLichSuBanThan = row["MALSBT"].ToString();
                info.MaNhanVien = row["MANHANVIEN"].ToString();
                info.TuNgay = (DateTime)row["NGAYBD"];
                info.DenNgay = (DateTime)row["NGAYKT"];
                info.NoiDung = row["NOIDUNG"].ToString();
               

                ListViewItem item = new ListViewItem();
                
                item.Text = info.MaLichSuBanThan;
                item.SubItems.Add(info.TuNgay.ToShortDateString());
                item.SubItems.Add(info.DenNgay.ToShortDateString());
                item.SubItems.Add(info.NoiDung);               
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(TextBox txtLSBT, DateTimePicker dtTuNgay, DateTimePicker dtDenNgay, TextBox txtNoiDung, LichSuBanThanInfo info)
        {
            
            txtLSBT.Text = info.MaLichSuBanThan;
            dtTuNgay.Text = info.TuNgay.ToShortDateString();
            dtDenNgay.Text = info.DenNgay.ToShortDateString();
            txtNoiDung.Text = info.NoiDung;            

        }
        #endregion

        #region Add()
        public bool Add(LichSuBanThanInfo info)
        {
            DataRow row = Table.NewRow();
            
            row["MALSBT"] = info.MaLichSuBanThan;
            row["MANHANVIEN"] = info.MaNhanVien;
            row["NGAYBD"] = info.TuNgay;
            row["NGAYKT"] = info.DenNgay;
            row["NOIDUNG"] = info.NoiDung;
           

            Table.Rows.Add(row);
            if (this.data_LichSuBanThan.Update())
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
       
        #region CapNhatLichSuBanThan
        public void CapNhatLichSuBanThan(LichSuBanThanInfo info, int index)
        {
            this.Table.Rows[index]["NGAYBD"] = info.TuNgay;
            this.Table.Rows[index]["NGAYKT"] = info.DenNgay;
            this.Table.Rows[index]["NOIDUNG"] = info.NoiDung;


            this.data_LichSuBanThan.CapNhatLichSuBanThan(info);
        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_LichSuBanThan.Update();
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaQT)
        {
            Table = data_LichSuBanThan.lay_dsLichSuBanThan();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaQT.Text = "LSBT1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("LSBT", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaQT.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region Xoa_LichSuBanThan

        public void Xoa_LichSuBanThan(String MaLSBT)
        {
            if (data_LichSuBanThan == null)
                data_LichSuBanThan = new LichSuBanThanData();
            data_LichSuBanThan.Xoa_LichSuBanThan(MaLSBT);
        }
        #endregion

        #region Xoa_LichSuBanThan_NhanVien

        public void Xoa_LichSuBanThan_NhanVien(String MaNV)
        {
            if (data_LichSuBanThan == null)
                data_LichSuBanThan = new LichSuBanThanData();
            data_LichSuBanThan.Xoa_LichSuBanThan_NhanVien(MaNV);
        }
        #endregion
    }
}
