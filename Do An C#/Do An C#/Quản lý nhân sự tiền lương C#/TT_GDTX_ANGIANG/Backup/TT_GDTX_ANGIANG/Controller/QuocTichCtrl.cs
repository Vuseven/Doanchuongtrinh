using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using DevComponents.DotNetBar;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;

namespace TT_GDTX_ANGIANG.Controller
{
    public class QuocTichCtrl
    {
        #region data_QuocTich
        private QuocTichData m_dataQuocTich;
        public QuocTichData data_QuocTich
        {
            get { return m_dataQuocTich; }
            set { m_dataQuocTich = value; }
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

        #region HienThi_dsQuocTich()
        public void HienThi_dsQuocTich(ListView listView)
        {
            if (data_QuocTich == null)
            {
                data_QuocTich = new QuocTichData();
            }
            Table = data_QuocTich.lay_dsQuocTich();
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                QuocTichInfo info = new QuocTichInfo();

                info.MaQuocTich = row["MAQT"].ToString();
                info.TenQuocTich = row["TENQT"].ToString();
                info.GhiChu = row["GHICHU"].ToString();

                ListViewItem item = new ListViewItem();
                item.Text = info.MaQuocTich;
                item.SubItems.Add(info.TenQuocTich);
                item.SubItems.Add(info.GhiChu);
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(TextBox txtMaQT, TextBox txtTenQT, TextBox txtGhiChu, QuocTichInfo info)
        {
            txtMaQT.Text = info.MaQuocTich;
            txtTenQT.Text = info.TenQuocTich;
            txtGhiChu.Text = info.GhiChu;
        }
        #endregion

        #region Add()
        public bool Add(QuocTichInfo info)
        {
            DataRow row = Table.NewRow();
            row["MAQT"] = info.MaQuocTich;
            row["TENQT"] = info.TenQuocTich;
            row["GHICHU"] = info.GhiChu;

            Table.Rows.Add(row);
            if (this.data_QuocTich.Update())
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

        #region Update()
        public void Update(QuocTichInfo info, int index)
        {
            this.Table.Rows[index]["MAQT"] = info.MaQuocTich;
            this.Table.Rows[index]["TENQT"] = info.TenQuocTich;
            this.Table.Rows[index]["GHICHU"] = info.GhiChu;

            this.data_QuocTich.Update();
        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_QuocTich.Update();
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaQT)
        {
            Table = data_QuocTich.lay_dsQuocTich();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaQT.Text = "QT1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("QT", t.ToString());
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

        #region HienThiComboBox()
        public void HienThiComboBox(ComboBox cmb)
        {
            if (data_QuocTich == null)
            {
                data_QuocTich = new QuocTichData();
            }
            this.Table = this.data_QuocTich.lay_dsQuocTich();
            cmb.DataSource = this.Table;
            cmb.DisplayMember = "TENQT";
            cmb.ValueMember = "MAQT";
        }
        #endregion

        #region GetQuocTich()
        public QuocTichInfo GetQuocTich(string maQT)
        {
            if (this.data_QuocTich == null)
            {
                this.data_QuocTich = new QuocTichData();
            }
            return this.data_QuocTich.GetQuocTich(maQT);
        }
        #endregion

        #region XoaQuocTich

        public void XoaQuocTich(string maQT)
        {
            if (data_QuocTich == null)
            {
                data_QuocTich = new QuocTichData();
            }
            Table = data_QuocTich.lay_dsNhanVienThuocQuocTich(maQT);
            if (Table.Rows.Count != 0)
            {
                MessageBoxEx.Show("Đã có Nhân Viên thuộc Quốc Tịch này nên không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
                data_QuocTich.XoaQuocTich(maQT);
        }
        #endregion
    }
}
