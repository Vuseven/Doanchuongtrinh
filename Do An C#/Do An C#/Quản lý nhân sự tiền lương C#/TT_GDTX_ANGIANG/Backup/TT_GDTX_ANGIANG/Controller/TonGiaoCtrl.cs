using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using DevComponents.DotNetBar;
using TT_GDTX_ANGIANG.BusinessObject;
using TT_GDTX_ANGIANG.DataLayer;
using System.Windows.Forms;
using System.Data;

namespace TT_GDTX_ANGIANG.Controller
{
    public class TonGiaoCtrl
    {
        #region data_TonGiao
        private TonGiaoData m_dataTonGiao;
        public TonGiaoData data_TonGiao
        {
            get { return m_dataTonGiao; }
            set { m_dataTonGiao = value; }
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

        #region HienThi_dsTonGiao()
        public void HienThi_dsTonGiao(ListView listView)
        {
            if (data_TonGiao == null)
            {
                data_TonGiao = new TonGiaoData();
            }
            Table = data_TonGiao.lay_dsTonGiao();
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                TonGiaoInfo info = new TonGiaoInfo();

                info.MaTonGiao = row["MATG"].ToString();
                info.TenTonGiao = row["TENTG"].ToString();
                info.GhiChu = row["GHICHU"].ToString();

                ListViewItem item = new ListViewItem();
                item.Text = info.MaTonGiao;
                item.SubItems.Add(info.TenTonGiao);
                item.SubItems.Add(info.GhiChu);
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(TextBox txtMaTonGiao, TextBox txtTenTonGiao, TextBox txtGhiChu, TonGiaoInfo info)
        {
            txtMaTonGiao.Text = info.MaTonGiao;
            txtTenTonGiao.Text = info.TenTonGiao;
            txtGhiChu.Text = info.GhiChu;
        }
        #endregion

        #region Add()
        public bool Add(TonGiaoInfo info)
        {
            DataRow row = Table.NewRow();
            row["MATG"] = info.MaTonGiao;
            row["TENTG"] = info.TenTonGiao;
            row["GHICHU"] = info.GhiChu;

            Table.Rows.Add(row);
            if (this.data_TonGiao.Update())
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
        public void Update(TonGiaoInfo info, int index)
        {
            //this.Table.Rows[index]["MATG"] = info.MaTonGiao;
            this.Table.Rows[index]["TENTG"] = info.TenTonGiao;
            this.Table.Rows[index]["GHICHU"] = info.GhiChu;

            this.data_TonGiao.Update();
        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_TonGiao.Update();
        }
        #endregion

        #region Create()        
        public void Create(TextBox txtMaTG)
        {
            Table = data_TonGiao.lay_dsTonGiao();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaTG.Text = "TG1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("TG", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaTG.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region HienThiComboBox()
        public void HienThiComboBox(ComboBox cmb)
        {
            if (data_TonGiao == null)
            {
                data_TonGiao = new TonGiaoData();
            }
            this.Table = this.data_TonGiao.lay_dsTonGiao();
            cmb.DataSource = this.Table;
            cmb.DisplayMember = "TENTG";
            cmb.ValueMember = "MATG";
        }
        #endregion

        #region GetTonGiao()
        public TonGiaoInfo GetTonGiao(string maTG)
        {
            if (this.data_TonGiao == null)
            {
                this.data_TonGiao = new TonGiaoData();
            }
            return this.data_TonGiao.GetTonGiao(maTG);
        }
        #endregion       

        #region XoaTonGiao

        public void XoaTonGiao(string maTG)
        {
            if (data_TonGiao == null)
            {
                data_TonGiao = new TonGiaoData();
            }
            Table = data_TonGiao.lay_dsNhanVienThuocTonGiao(maTG);           
            if (Table.Rows.Count != 0)
            {
                MessageBoxEx.Show("Đã có Nhân Viên thuộc Tôn Giáo này nên không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
                data_TonGiao.XoaTonGiao(maTG);
        }
        #endregion
    }
}
