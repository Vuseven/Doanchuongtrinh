using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Data;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;

namespace TT_GDTX_ANGIANG.Controller
{
    public class PhongBanCtrl
    {
        #region data_PhongBan
        private PhongBanData m_dataPhongBan;
        public PhongBanData data_PhongBan
        {
            get { return m_dataPhongBan; }
            set { m_dataPhongBan = value; }
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

        #region HienThi_dsPhongBan()
        public void HienThi_dsPhongBan(ListView listView)
        {
            if (data_PhongBan == null)
            {
                data_PhongBan = new PhongBanData();
            }
            Table = data_PhongBan.lay_dsPhongBan();
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                PhongBanInfo info = new PhongBanInfo();

                info.MaPhong = row["MAPB"].ToString();
                info.TenPhong = row["TENPB"].ToString();
                info.SoNhanVien = int.Parse(row["SONHANVIEN"].ToString());
                info.GhiChu = row["GHICHU"].ToString();

                ListViewItem item = new ListViewItem();
                item.Text = info.MaPhong;
                item.SubItems.Add(info.TenPhong);
                item.SubItems.Add(info.SoNhanVien.ToString());
                item.SubItems.Add(info.GhiChu);
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaPH)
        {
            Table = data_PhongBan.lay_dsPhongBan();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaPH.Text = "PH1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("PH", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaPH.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(TextBox txtMaPH, TextBox txtTenPH, TextBox txtSONHANVIEN, TextBox txtGhiChu, PhongBanInfo info)
        {
            txtMaPH.Text = info.MaPhong;
            txtTenPH.Text = info.TenPhong;
            txtSONHANVIEN.Text = info.SoNhanVien.ToString();
            txtGhiChu.Text = info.GhiChu;
        }
        #endregion

        #region Add()
        public bool Add(PhongBanInfo info)
        {
            DataRow row = Table.NewRow();
            row["MAPB"] = info.MaPhong;
            row["TENPB"] = info.TenPhong;
            row["SONHANVIEN"] = info.SoNhanVien;
            row["GHICHU"] = info.GhiChu;

            Table.Rows.Add(row);
            if (this.data_PhongBan.Update())
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

        #region Delete()
        public bool Delete(int index)
        {
            
            this.Table.Rows[index].Delete();

            return this.data_PhongBan.Update();
        }
        #endregion

        #region XoaPhongBan        
       
        public void XoaPhongBan( string maPH)
        {
            if (data_PhongBan == null)
            {
                data_PhongBan = new PhongBanData();
            }
            Table = data_PhongBan.lay_dsNhanVienCoTrongPhongBan(maPH);
            if (Table.Rows.Count != 0)
            { 
                MessageBoxEx.Show("Đã có Nhân Viên thuộc Phòng này nên không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               
            }
            else
                data_PhongBan.XoaPhongBan(maPH);
        }
        #endregion

        #region Update()
        public void Update(PhongBanInfo info, int index)
        {
            //this.Table.Rows[index]["MAPH"] = info.MaPhong;
            this.Table.Rows[index]["TENPB"] = info.TenPhong;
            this.Table.Rows[index]["SONHANVIEN"] = info.SoNhanVien;
            this.Table.Rows[index]["GHICHU"] = info.GhiChu;

            this.data_PhongBan.Update();
        }
        #endregion


        #region HienThiComboBox()
        public void HienThiComboBox(ComboBox cmb)
        {
            if (this.data_PhongBan == null)
            {
                data_PhongBan = new PhongBanData();
            }
            this.Table = this.data_PhongBan.lay_dsPhongBan();
            cmb.DataSource = this.Table;
            cmb.DisplayMember = "TENPB";
            cmb.ValueMember = "MAPB";
        }
        #endregion

        #region GetPhongBan()
        public PhongBanInfo GetPhongBan(string maPB)
        {
            if (this.data_PhongBan == null)
            {
                this.data_PhongBan = new PhongBanData();
            }
            return this.data_PhongBan.GetPhongBan(maPB);
        }
        #endregion       







    }
}