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
    public class TrinhDo_NgoaiNguCtrl
    {
        #region data_TrinhDoNgoaiNgu
        private TrinhDo_NgoaiNguData m_dataTrinhDoNgoaiNgu;
        public TrinhDo_NgoaiNguData data_TrinhDoNgoaiNgu
        {
            get { return m_dataTrinhDoNgoaiNgu; }
            set { m_dataTrinhDoNgoaiNgu = value; }
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

        #region HienThi_dsTrinhDoNgoaiNgu()
        public void HienThi_dsTrinhDoNgoaiNgu(ListView listView)
        {
            if (data_TrinhDoNgoaiNgu == null)
            {
                data_TrinhDoNgoaiNgu = new TrinhDo_NgoaiNguData();
            }
            Table = data_TrinhDoNgoaiNgu.lay_dsTrinhDoNgoaiNgu();
            IEnumerator ie = Table.Rows.GetEnumerator();
            listView.Items.Clear();

            while (ie.MoveNext())
            {
                DataRow row = (DataRow)ie.Current;
                TrinhDo_NgoaiNguInfo info = new TrinhDo_NgoaiNguInfo();

                info.MaTrinhDoNgoaiNgu = row["MATDNN"].ToString();
                info.TenTrinhDoNgoaiNgu = row["TENTDNN"].ToString();
              
                ListViewItem item = new ListViewItem();
                item.Text = info.MaTrinhDoNgoaiNgu;
                item.SubItems.Add(info.TenTrinhDoNgoaiNgu);
               
                item.Tag = info;

                listView.Items.Add(item);
            }
        }
        #endregion

        #region HienThiInfo()
        public void HienThiInfo(TextBox txtMaTDNN, TextBox txtTenTDNN,  TrinhDo_NgoaiNguInfo info)
        {
            txtMaTDNN.Text = info.MaTrinhDoNgoaiNgu;
            txtTenTDNN.Text = info.TenTrinhDoNgoaiNgu;
           
        }
        #endregion

        #region Add()
        public bool Add(TrinhDo_NgoaiNguInfo info)
        {
            DataRow row = Table.NewRow();
            row["MATDNN"] = info.MaTrinhDoNgoaiNgu;
            row["TENTDNN"] = info.TenTrinhDoNgoaiNgu;
            

            Table.Rows.Add(row);
            if (this.data_TrinhDoNgoaiNgu.Update())
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
        public void Update(TrinhDo_NgoaiNguInfo info, int index)
        {
            //this.Table.Rows[index]["MADT"] = info.MaDanToc;
            this.Table.Rows[index]["TENTDNN"] = info.TenTrinhDoNgoaiNgu;
            
            this.data_TrinhDoNgoaiNgu.Update();
        }
        #endregion

        #region Delete()
        public bool Delete(int index)
        {
            this.Table.Rows[index].Delete();

            return this.data_TrinhDoNgoaiNgu.Update();
        }
        #endregion

        #region Create()
        public void Create(TextBox txtMaTDNN)
        {
            Table = data_TrinhDoNgoaiNgu.lay_dsTrinhDoNgoaiNgu();
            bool b = true;
            int i = 0;
            int t = 1;
            if (Table.Rows.Count == 0)
            {
                txtMaTDNN.Text = "TDNN1";
                return;
            }
            while (b)
            {
                string s1 = string.Concat("TDNN", t.ToString());
                if (Table.Rows[i][0].ToString() == s1)
                {
                    t++;
                    i = 0;
                    continue;
                }
                if (i == (Table.Rows.Count - 1))
                {
                    txtMaTDNN.Text = s1;
                    b = false;
                }
                i++;
            }
        }
        #endregion

        #region HienThiComboBox()
        public void HienThiComboBox(ComboBox cmb)
        {
            if (data_TrinhDoNgoaiNgu == null)
            {
                data_TrinhDoNgoaiNgu = new TrinhDo_NgoaiNguData();
            }
            this.Table = this.data_TrinhDoNgoaiNgu.lay_dsTrinhDoNgoaiNgu();
            cmb.DataSource = this.Table;
            cmb.DisplayMember = "TENTDNN";
            cmb.ValueMember = "MATDNN";
        }
        #endregion

        #region GetTrinhDoNgoaiNgu()
        public TrinhDo_NgoaiNguInfo GetTrinhDoNgoaiNgu(string maTDNN)
        {
            if (this.data_TrinhDoNgoaiNgu == null)
            {
                this.data_TrinhDoNgoaiNgu = new TrinhDo_NgoaiNguData();
            }
            return this.data_TrinhDoNgoaiNgu.GetTrinhDoNgoaiNgu(maTDNN);
        }
        #endregion       

        #region XoaTrinhDoNgoaiNgu

        public void XoaTrinhDoNgoaiNgu(string maTDNN)
        {
            if (data_TrinhDoNgoaiNgu == null)
            {
                data_TrinhDoNgoaiNgu = new TrinhDo_NgoaiNguData();
            }
            Table = data_TrinhDoNgoaiNgu.lay_dsNhanVienThuocTrinhDoNgoaiNgu(maTDNN);
            if (Table.Rows.Count != 0)
            {
                MessageBoxEx.Show("Đã có Nhân Viên thuộc Trình Độ Ngoại Ngữ này nên không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
                data_TrinhDoNgoaiNgu.XoaTrinhDoNgoaiNgu(maTDNN);
        }
        #endregion
    }
}
